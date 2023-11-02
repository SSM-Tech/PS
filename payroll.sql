-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Nov 02, 2023 at 12:25 PM
-- Server version: 8.0.31
-- PHP Version: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `payroll`
--

DELIMITER $$
--
-- Procedures
--
DROP PROCEDURE IF EXISTS `ChangeServerStatus`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ChangeServerStatus` (IN `p_status` INT)   UPDATE serverstatus
SET status = p_status,
	lastChecked = NOW()$$

DROP PROCEDURE IF EXISTS `CheckAndGeneratePayslip`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `CheckAndGeneratePayslip` ()   BEGIN
    -- Check if the current date is inside any existing payslip
    IF NOT EXISTS (
        SELECT 1
        FROM payslip
        WHERE CURDATE() BETWEEN startDate AND endDate
    ) THEN
        -- If the current date is not inside any existing payslip, generate a new row
        INSERT INTO payslip (startDate, endDate)
        VALUES (CURDATE(), DATE_ADD(CURDATE(), INTERVAL 7 DAY));
    END IF;
END$$

DROP PROCEDURE IF EXISTS `checkIsEnabled`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `checkIsEnabled` (IN `p_userID` INT)   SELECT a.isEnabled
FROM account a
WHERE a.userID = p_userID$$

DROP PROCEDURE IF EXISTS `CheckServerStatus`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `CheckServerStatus` ()   SELECT *
FROM serverstatus$$

DROP PROCEDURE IF EXISTS `ClockInOut`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ClockInOut` (IN `p_userID` INT, IN `p_clockintime` DATETIME, IN `p_clockedIn` INT, IN `p_clockouttime` DATETIME, IN `p_clockedOut` INT)   UPDATE dtr
    SET dtr.clockintime = p_clockintime,
        dtr.clockedIn = p_clockedIn,
        dtr.clockouttime = p_clockouttime,
        dtr.clockedOut = p_clockedOut
    WHERE userID = p_userID AND dtrDate = CURDATE()$$

DROP PROCEDURE IF EXISTS `DeleteUser`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteUser` (IN `p_userID` INT)   DELETE FROM account 
WHERE account.userID = p_userID$$

DROP PROCEDURE IF EXISTS `DTR`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DTR` (IN `pUserID` INT, IN `pNthPayslip` INT)   BEGIN
    DECLARE currentDate DATE;
    DECLARE clockinTime TIME;
    DECLARE clockoutTime TIME;
    DECLARE totalHours DECIMAL(10, 2);
    
    SET currentDate = CURDATE();
    SET clockinTime = '00:00:00'; -- Default value
    SET clockoutTime = '00:00:00'; -- Default value
    SET totalHours = 0; -- Default value

    -- Check if a corresponding DTR entry exists for the given user and payslip on the current date
    IF NOT EXISTS (
        SELECT 1
        FROM dtr
        WHERE dtrDate = currentDate
          AND userID = pUserID
          AND nthPayslip = pNthPayslip
    )
    THEN
        -- If no entry exists, insert a new row
        INSERT INTO dtr (nthPayslip, userID, clockinTime, clockoutTime, totalHours, dtrDate)
        VALUES (pNthPayslip, pUserID, clockinTime, clockoutTime, totalHours, currentDate);
    END IF;
END$$

DROP PROCEDURE IF EXISTS `DTRTotalHour`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DTRTotalHour` (IN `p_userID` INT)   UPDATE dtr
SET dtr.totalHours = TIMEDIFF(clockouttime, clockintime)
WHERE userID = p_userID AND dtrDate = CURDATE()$$

DROP PROCEDURE IF EXISTS `editUserAcc`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `editUserAcc` (IN `p_staffID` INT, IN `p_firstname` VARCHAR(50), IN `p_lastname` VARCHAR(50), IN `p_sex` VARCHAR(50), IN `p_dOB` DATETIME, IN `p_position` VARCHAR(50), IN `p_salary` DECIMAL, IN `p_allowance` DECIMAL, IN `p_stationNo` VARCHAR(50), IN `p_isEnabled` INT, IN `p_accountLevel` INT)   UPDATE staff s, account a
SET s.firstName = p_firstname,
	s.lastName = p_lastname,
    s.sex = p_sex,
    s.DOB = p_dOB,
    s.position = p_position,
    s.salary = p_salary,
    s.allowance = p_allowance,
    s.stationNo = p_stationNo,
    a.isEnabled = p_isEnabled,
    a.accountLevel = p_accountLevel
WHERE s.staffID = p_staffID
AND a.staffID = p_staffID$$

DROP PROCEDURE IF EXISTS `EventLog`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `EventLog` (IN `p_eventDescription` VARCHAR(255))   INSERT INTO eventlog (eventDateTime, eventDescription)
VALUES(NOW(), p_eventDescription)$$

DROP PROCEDURE IF EXISTS `GeneratePayslipDetails`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GeneratePayslipDetails` (IN `userID` INT)   BEGIN
    DECLARE retpayslipID INT;

    START TRANSACTION;  -- Start a transaction

    -- Get the payslipID from the payslip table for the current date
    SELECT payslipID INTO retpayslipID
    FROM payslip
    WHERE CURDATE() BETWEEN startDate AND endDate;

    -- Check if payslipID is found
    IF retpayslipID IS NOT NULL THEN
        -- Insert a new row in payslipDetails with initial values set to 0
        INSERT IGNORE INTO payslipdetail (payslipID, userID, totalHours, subtotal, allowance, deduction, totalSalary)
        VALUES (retpayslipID, userID, 0, 0, 0, 0, 0);
    END IF;

    COMMIT;  -- Commit the transaction
END$$

DROP PROCEDURE IF EXISTS `getAccDetails`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAccDetails` (IN `p_staffID` INT)   SELECT
	a.*,
	stf.firstName,
	stf.lastName,
	stf.sex,
	stf.DOB,
	stf.position,
	stf.salary,
	stf.allowance,
	stf.stationNo,
    dtr.clockintime,
    dtr.clockedIn,
    dtr.clockouttime,
    dtr.clockedOut
FROM account a
JOIN staff stf ON a.staffID = stf.staffID
LEFT JOIN dtr dtr ON a.userID = dtr.userID AND DATE(dtr.dtrDate) = CURDATE()
Where a.staffID = p_staffID$$

DROP PROCEDURE IF EXISTS `getAllUserID`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllUserID` ()   SELECT a.userID
FROM account a$$

DROP PROCEDURE IF EXISTS `GetEventLogs`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetEventLogs` ()   SELECT 
	e.eventDateTime,
    e.eventDescription
FROM eventlog e$$

DROP PROCEDURE IF EXISTS `getLogin`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getLogin` (IN `usn` VARCHAR(50), IN `pass` VARCHAR(50))   SELECT * FROM account WHERE username = usn AND password = pass$$

DROP PROCEDURE IF EXISTS `getNthPayslip`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getNthPayslip` ()   SELECT
    a.userID,
    p.nthPayslip
FROM
    account a
LEFT JOIN
    payslip p
ON p.userID = a.userID
WHERE CURRENT_DATE BETWEEN p.startDate AND p.endDate$$

DROP PROCEDURE IF EXISTS `getUserAcc`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getUserAcc` (IN `p_search` VARCHAR(50))   SELECT
    a.staffID as Staff_ID,
    a.isEnabled as Locked,
    a.accountLevel as Restriction,
    a.username as Username,
    stf.firstName as Firstname,
    stf.lastName as Lastname,
    stf.position as Position,
    stf.stationNo as Station_No
FROM account a
JOIN staff stf ON a.staffID = stf.staffID
WHERE a.username LIKE CONCAT('%', p_search, '%')
OR stf.firstName LIKE CONCAT('%', p_search, '%')
OR stf.lastName LIKE CONCAT('%', p_search, '%')$$

DROP PROCEDURE IF EXISTS `getUserDTR`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getUserDTR` (IN `p_userID` INT)   SELECT
	dtr.dtrDate,
    dtr.clockintime,
    dtr.clockedIn,
    dtr.clockouttime,
    dtr.clockedOut,
    dtr.totalHours
FROM dtr 
WHERE DATE(dtrDate) <= CURDATE() AND userID = p_userID
ORDER BY dtr.dtrDate ASC$$

DROP PROCEDURE IF EXISTS `loginStatus`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `loginStatus` (IN `p_status` INT, IN `p_userID` INT)   UPDATE account
SET account.isLoggedIn = p_status
WHERE account.userID = p_userID$$

DROP PROCEDURE IF EXISTS `registerAccount`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `registerAccount` (IN `p_firstName` VARCHAR(50), IN `p_lastName` VARCHAR(50), IN `p_sex` VARCHAR(50), IN `p_DOB` DATETIME, IN `p_position` VARCHAR(50), IN `p_salary` DECIMAL(18,2), IN `p_allowance` DECIMAL(18,2), IN `p_stationNo` VARCHAR(50), IN `p_username` VARCHAR(50), IN `p_password` VARCHAR(50), IN `p_isEnabled` DOUBLE, IN `p_accountLevel` VARCHAR(50))   BEGIN
    DECLARE generatedStaffID INT;

    -- Step 1: Insert data into the "staff" table
    INSERT INTO staff ( firstName, lastName, sex, DOB, position, salary, allowance, stationNo)
    VALUES ( p_firstName, p_lastName, p_sex, p_DOB, p_position, p_salary, p_allowance, p_stationNo);

    -- Retrieve the generated staffID
    SET generatedStaffID = LAST_INSERT_ID();

    -- Step 2: Insert data into the "account" table
    INSERT INTO account (staffID, username, password, isEnabled, accountLevel)
    VALUES (generatedStaffID, p_username, p_password, p_isEnabled, p_accountLevel);
END$$

DROP PROCEDURE IF EXISTS `updateAccountPassword`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `updateAccountPassword` (IN `p_password` VARCHAR(50), IN `p_staffID` DOUBLE)   UPDATE account
SET account.password = p_password
WHERE account.staffID = p_staffID$$

DROP PROCEDURE IF EXISTS `UpdateLoginStatus`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateLoginStatus` (IN `p_userID` INT)   UPDATE account
SET isLoggedIn = 0
WHERE userID = p_userID$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
CREATE TABLE IF NOT EXISTS `account` (
  `userID` int NOT NULL AUTO_INCREMENT,
  `staffID` int NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `isEnabled` int NOT NULL DEFAULT '1',
  `accountLevel` int NOT NULL DEFAULT '1',
  `isLoggedIn` int NOT NULL,
  PRIMARY KEY (`userID`),
  UNIQUE KEY `userID_Unique` (`userID`) USING BTREE,
  KEY `username_Index` (`username`) USING BTREE,
  KEY `staffID` (`staffID`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`userID`, `staffID`, `username`, `password`, `isEnabled`, `accountLevel`, `isLoggedIn`) VALUES
(1, 1, 'johnrey.silverio', 'berio123', 1, 2, 0),
(2, 2, 'laurence.silverio', 'laurence', 1, 2, 0),
(3, 3, 'username.password', 'password', 1, 1, 0),
(5, 5, 'test.test', 'test1234', 0, 1, 0),
(7, 7, 'johnmatheow.morillo', 'cho12345', 1, 1, 0);

--
-- Triggers `account`
--
DROP TRIGGER IF EXISTS `DeleteAccountAndRelatedRows`;
DELIMITER $$
CREATE TRIGGER `DeleteAccountAndRelatedRows` AFTER DELETE ON `account` FOR EACH ROW BEGIN
    DELETE FROM staff WHERE staffID = OLD.staffID;

    DELETE FROM dtr WHERE userID = OLD.staffID;

    DELETE FROM payslipdetail WHERE userID = OLD.staffID;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `dtr`
--

DROP TABLE IF EXISTS `dtr`;
CREATE TABLE IF NOT EXISTS `dtr` (
  `dtrID` int NOT NULL AUTO_INCREMENT,
  `payslipID` int NOT NULL,
  `userID` int NOT NULL,
  `clockintime` datetime DEFAULT NULL,
  `clockedIn` tinyint NOT NULL DEFAULT '0',
  `clockouttime` datetime DEFAULT NULL,
  `clockedOut` tinyint NOT NULL DEFAULT '0',
  `totalHours` datetime DEFAULT NULL,
  `dtrDate` date NOT NULL,
  PRIMARY KEY (`dtrID`),
  UNIQUE KEY `dtrID_Unique` (`dtrID`) USING BTREE,
  KEY `dtrID_Index` (`dtrID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=285 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `dtr`
--

INSERT INTO `dtr` (`dtrID`, `payslipID`, `userID`, `clockintime`, `clockedIn`, `clockouttime`, `clockedOut`, `totalHours`, `dtrDate`) VALUES
(250, 7, 1, NULL, 0, NULL, 0, NULL, '2023-10-29'),
(251, 7, 1, NULL, 0, NULL, 0, NULL, '2023-10-30'),
(252, 7, 1, NULL, 0, NULL, 0, NULL, '2023-10-31'),
(253, 7, 1, NULL, 0, NULL, 0, NULL, '2023-11-01'),
(254, 7, 1, '2023-11-02 09:15:16', 0, '2023-11-02 15:40:12', 0, '2023-11-02 06:24:56', '2023-11-02'),
(255, 7, 1, NULL, 0, NULL, 0, NULL, '2023-11-03'),
(256, 7, 1, NULL, 0, NULL, 0, NULL, '2023-11-04'),
(257, 7, 2, NULL, 0, NULL, 0, NULL, '2023-10-29'),
(258, 7, 2, NULL, 0, NULL, 0, NULL, '2023-10-30'),
(259, 7, 2, NULL, 0, NULL, 0, NULL, '2023-10-31'),
(260, 7, 2, NULL, 0, NULL, 0, NULL, '2023-11-01'),
(261, 7, 2, '2023-11-02 20:01:41', 1, '2023-11-02 20:06:43', 1, '2023-11-02 00:05:02', '2023-11-02'),
(262, 7, 2, NULL, 0, NULL, 0, NULL, '2023-11-03'),
(263, 7, 2, NULL, 0, NULL, 0, NULL, '2023-11-04'),
(264, 7, 3, NULL, 0, NULL, 0, NULL, '2023-10-29'),
(265, 7, 3, NULL, 0, NULL, 0, NULL, '2023-10-30'),
(266, 7, 3, NULL, 0, NULL, 0, NULL, '2023-10-31'),
(267, 7, 3, NULL, 0, NULL, 0, NULL, '2023-11-01'),
(268, 7, 3, '2023-11-02 20:17:53', 1, '2023-11-02 20:21:15', 1, '2023-11-02 00:03:22', '2023-11-02'),
(269, 7, 3, NULL, 0, NULL, 0, NULL, '2023-11-03'),
(270, 7, 3, NULL, 0, NULL, 0, NULL, '2023-11-04'),
(271, 7, 5, NULL, 0, NULL, 0, NULL, '2023-10-29'),
(272, 7, 5, NULL, 0, NULL, 0, NULL, '2023-10-30'),
(273, 7, 5, NULL, 0, NULL, 0, NULL, '2023-10-31'),
(274, 7, 5, NULL, 0, NULL, 0, NULL, '2023-11-01'),
(275, 7, 5, NULL, 0, NULL, 0, NULL, '2023-11-02'),
(276, 7, 5, NULL, 0, NULL, 0, NULL, '2023-11-03'),
(277, 7, 5, NULL, 0, NULL, 0, NULL, '2023-11-04'),
(278, 7, 7, NULL, 0, NULL, 0, NULL, '2023-10-29'),
(279, 7, 7, NULL, 0, NULL, 0, NULL, '2023-10-30'),
(280, 7, 7, NULL, 0, NULL, 0, NULL, '2023-10-31'),
(281, 7, 7, NULL, 0, NULL, 0, NULL, '2023-11-01'),
(282, 7, 7, '2023-11-02 20:10:40', 1, '2023-11-02 20:13:49', 1, '2023-11-02 00:03:09', '2023-11-02'),
(283, 7, 7, NULL, 0, NULL, 0, NULL, '2023-11-03'),
(284, 7, 7, NULL, 0, NULL, 0, NULL, '2023-11-04');

-- --------------------------------------------------------

--
-- Table structure for table `dtrtickets`
--

DROP TABLE IF EXISTS `dtrtickets`;
CREATE TABLE IF NOT EXISTS `dtrtickets` (
  `dtrTicketID` double NOT NULL AUTO_INCREMENT,
  `dtrID` double NOT NULL,
  `employeeID` double NOT NULL,
  `managerID` double NOT NULL,
  `dtrTicketDescription` text NOT NULL,
  `dtrTicketStatus` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT 'To Be Reviewed',
  `dtrTicketDateReceived` date NOT NULL,
  `dtrTicketDateResolved` date NOT NULL,
  PRIMARY KEY (`dtrTicketID`),
  UNIQUE KEY `dtrTicketID_Unique` (`dtrTicketID`) USING BTREE,
  KEY `dtrTicketID_Index` (`dtrTicketID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `eventlog`
--

DROP TABLE IF EXISTS `eventlog`;
CREATE TABLE IF NOT EXISTS `eventlog` (
  `logID` int NOT NULL AUTO_INCREMENT,
  `eventDateTime` datetime DEFAULT NULL,
  `eventDescription` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`logID`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `eventlog`
--

INSERT INTO `eventlog` (`logID`, `eventDateTime`, `eventDescription`) VALUES
(1, '2023-10-29 18:25:07', 'TESTING eventlog 123'),
(2, '2023-10-29 18:27:13', 'testNum2 asjdaifbka'),
(3, '2023-10-29 18:31:49', 'Server Started'),
(4, '2023-10-29 18:33:57', 'Server Terminated'),
(5, '2023-10-29 20:08:45', 'Server Started'),
(6, '2023-10-29 20:09:01', 'Server Terminated'),
(7, '2023-10-29 20:09:58', 'Server Started'),
(8, '2023-10-29 20:10:04', 'Server Terminated'),
(9, '2023-10-29 20:25:30', 'Server Started'),
(10, '2023-10-29 20:25:32', 'Server Terminated'),
(11, '2023-10-29 20:25:33', 'Server Started'),
(12, '2023-10-29 20:25:33', 'Server Terminated'),
(13, '2023-10-29 20:25:34', 'Server Started'),
(14, '2023-10-29 20:25:35', 'Server Terminated'),
(15, '2023-10-29 20:25:36', 'Server Started'),
(16, '2023-10-29 20:25:36', 'Server Terminated'),
(17, '2023-10-29 20:25:37', 'Server Started'),
(18, '2023-10-29 20:25:37', 'Server Terminated'),
(19, '2023-10-29 20:25:38', 'Server Started'),
(20, '2023-10-29 20:25:39', 'Server Terminated'),
(21, '2023-10-29 20:25:39', 'Server Started'),
(22, '2023-10-29 20:25:39', 'Server Terminated'),
(23, '2023-10-29 20:25:40', 'Server Started'),
(24, '2023-10-29 20:25:40', 'Server Terminated'),
(25, '2023-10-29 20:25:41', 'Server Started'),
(26, '2023-10-29 20:25:41', 'Server Terminated'),
(27, '2023-10-29 20:25:42', 'Server Started'),
(28, '2023-10-29 20:25:42', 'Server Terminated'),
(29, '2023-10-29 20:25:43', 'Server Started'),
(30, '2023-10-29 20:25:45', 'Server Terminated'),
(31, '2023-10-31 08:29:32', 'Server Started'),
(32, '2023-10-31 08:29:54', 'Server Terminated'),
(33, '2023-10-31 16:45:44', 'Server Started'),
(34, '2023-10-31 16:47:04', 'Server Terminated'),
(35, '2023-10-31 17:05:56', 'Server Started'),
(36, '2023-10-31 19:25:58', 'Server Terminated'),
(37, '2023-10-31 19:50:45', 'Server Started'),
(38, '2023-10-31 20:56:38', 'Server Terminated'),
(39, '2023-11-01 20:11:26', 'Server Started'),
(40, '2023-11-01 20:17:27', 'Server Terminated'),
(41, '2023-11-01 20:25:58', 'Server Started'),
(42, '2023-11-01 21:29:24', 'Server Terminated'),
(43, '2023-11-01 21:30:30', 'Server Started'),
(44, '2023-11-01 22:11:48', 'Server Terminated'),
(45, '2023-11-01 22:13:32', 'Server Started'),
(46, '2023-11-01 22:14:07', 'Server Terminated'),
(47, '2023-11-01 22:15:42', 'Server Started'),
(48, '2023-11-01 22:30:20', 'Server Terminated'),
(49, '2023-11-01 22:37:24', 'Server Started'),
(50, '2023-11-01 22:38:20', 'Server Terminated'),
(51, '2023-11-02 09:49:03', 'Server Started'),
(52, '2023-11-02 09:50:11', 'Server Terminated'),
(53, '2023-11-02 10:04:48', 'Server Started'),
(54, '2023-11-02 10:05:02', 'Server Terminated'),
(55, '2023-11-02 10:53:05', 'Server Started'),
(56, '2023-11-02 13:59:19', 'Server Terminated'),
(57, '2023-11-02 14:01:31', 'Server Started'),
(58, '2023-11-02 15:19:28', 'Server Terminated'),
(59, '2023-11-02 15:19:30', 'Server Started'),
(60, '2023-11-02 15:20:25', 'Server Terminated'),
(61, '2023-11-02 15:20:44', 'Server Started'),
(62, '2023-11-02 20:24:13', 'Server Terminated');

-- --------------------------------------------------------

--
-- Table structure for table `payslip`
--

DROP TABLE IF EXISTS `payslip`;
CREATE TABLE IF NOT EXISTS `payslip` (
  `payslipID` int NOT NULL AUTO_INCREMENT,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  PRIMARY KEY (`payslipID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `payslip`
--

INSERT INTO `payslip` (`payslipID`, `startDate`, `endDate`) VALUES
(7, '2023-10-29', '2023-11-05');

-- --------------------------------------------------------

--
-- Table structure for table `payslipdetail`
--

DROP TABLE IF EXISTS `payslipdetail`;
CREATE TABLE IF NOT EXISTS `payslipdetail` (
  `payslipDetailID` double NOT NULL AUTO_INCREMENT,
  `payslipID` int NOT NULL,
  `userID` double NOT NULL,
  `totalHours` time NOT NULL,
  `subtotal` decimal(10,2) NOT NULL,
  `allowance` decimal(10,2) NOT NULL,
  `deduction` decimal(10,2) NOT NULL,
  `totalSalary` double(10,2) NOT NULL,
  PRIMARY KEY (`payslipDetailID`),
  UNIQUE KEY `payslipID_Unique` (`payslipDetailID`) USING BTREE,
  UNIQUE KEY `unique_user_payslip` (`userID`,`payslipID`),
  KEY `payslipID_Index` (`payslipDetailID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=621 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `payslipdetail`
--

INSERT INTO `payslipdetail` (`payslipDetailID`, `payslipID`, `userID`, `totalHours`, `subtotal`, `allowance`, `deduction`, `totalSalary`) VALUES
(601, 7, 1, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(602, 7, 2, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(603, 7, 3, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(604, 7, 5, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(605, 7, 7, '00:00:00', '0.00', '0.00', '0.00', 0.00);

--
-- Triggers `payslipdetail`
--
DROP TRIGGER IF EXISTS `after_insert_payslipdetail`;
DELIMITER $$
CREATE TRIGGER `after_insert_payslipdetail` AFTER INSERT ON `payslipdetail` FOR EACH ROW BEGIN
  DECLARE i INT;
  SET i = 0;
  SET @startDate = (SELECT startDate FROM payslip WHERE payslipID = NEW.payslipID);

  WHILE i < 7 DO
    INSERT INTO dtr (payslipID, userID, clockintime, clockedIn, clockouttime, clockedOut, totalHours, dtrDate)
    VALUES (NEW.payslipID, NEW.userID, NULL, 0, NULL, 0, NULL, DATE_ADD(@startDate, INTERVAL i DAY));
    SET i = i + 1;
  END WHILE;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `paysliptickets`
--

DROP TABLE IF EXISTS `paysliptickets`;
CREATE TABLE IF NOT EXISTS `paysliptickets` (
  `payslipTicketID` double NOT NULL AUTO_INCREMENT,
  `payslipID` double NOT NULL,
  `employeeID` double NOT NULL,
  `managerID` double NOT NULL,
  `payslipTicketDescription` text NOT NULL,
  `payslipTicketStatus` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT 'To Be Reviewed',
  `payslipTicketDateReceived` date NOT NULL,
  `payslipTicketDateResolved` date NOT NULL,
  PRIMARY KEY (`payslipTicketID`),
  UNIQUE KEY `payslipTicketID_Unique` (`payslipTicketID`) USING BTREE,
  KEY `payslipTicketID_Index` (`payslipTicketID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `serverstatus`
--

DROP TABLE IF EXISTS `serverstatus`;
CREATE TABLE IF NOT EXISTS `serverstatus` (
  `serverName` varchar(50) NOT NULL DEFAULT 'PS Server',
  `status` int NOT NULL,
  `lastChecked` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `serverstatus`
--

INSERT INTO `serverstatus` (`serverName`, `status`, `lastChecked`) VALUES
('PS Server', 0, '2023-11-02 20:24:13');

-- --------------------------------------------------------

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
CREATE TABLE IF NOT EXISTS `staff` (
  `staffID` int NOT NULL AUTO_INCREMENT,
  `firstName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL,
  `sex` varchar(50) DEFAULT NULL,
  `DOB` datetime NOT NULL,
  `position` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'Employee',
  `salary` decimal(18,2) DEFAULT '500.00',
  `allowance` decimal(18,2) DEFAULT NULL,
  `stationNo` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`staffID`),
  UNIQUE KEY `employeeID_Unique` (`staffID`) USING BTREE,
  KEY `employeeID_Index` (`staffID`) USING BTREE,
  KEY `firstName_Index` (`firstName`) USING BTREE,
  KEY `lastName_Index` (`lastName`) USING BTREE,
  KEY `firstName` (`firstName`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `staff`
--

INSERT INTO `staff` (`staffID`, `firstName`, `lastName`, `sex`, `DOB`, `position`, `salary`, `allowance`, `stationNo`) VALUES
(1, 'John Rey', 'Silverio', 'Male', '2001-04-17 00:00:00', 'Employee', '500.00', '0.00', 'S002'),
(2, 'laurence', 'silverio', 'Male', '2023-08-22 00:00:00', 'Employee', '500.00', '0.00', 'S002'),
(3, 'username', 'password', 'Female', '2023-10-26 16:23:27', 'Employee', '0.00', '0.00', ''),
(5, 'Edit', 'Test', 'Male', '2023-09-28 00:00:00', 'New Manager', '1500.00', '500.00', ''),
(7, 'john matheo', 'morillo', 'Male', '2023-09-28 00:00:00', 'Employee', '500.00', '0.00', 'S002'),
(27, 'Kontra', 'Dengue', 'Male', '2023-04-04 14:03:45', 'Dengue', '0.00', '0.00', 'S003');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `account`
--
ALTER TABLE `account`
  ADD CONSTRAINT `account_ibfk_1` FOREIGN KEY (`staffID`) REFERENCES `staff` (`staffID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
