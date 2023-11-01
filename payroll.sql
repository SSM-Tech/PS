-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Nov 01, 2023 at 02:31 PM
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

DROP PROCEDURE IF EXISTS `checkUsername`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `checkUsername` (IN `usn` VARCHAR(50))   SELECT username FROM account WHERE username = usn$$

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
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAccDetails` (IN `staffID` DOUBLE)   SELECT
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
Where a.staffID = 1$$

DROP PROCEDURE IF EXISTS `getAllAccountDetails`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllAccountDetails` ()   SELECT
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
LEFT JOIN station stn ON stf.stationNO = stn.stationNO$$

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

DROP PROCEDURE IF EXISTS `getManagerName`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getManagerName` (IN `p_managerID` INT)   SELECT s.firstName
FROM staff s
INNER JOIN manager m ON s.staffId = m.staffID
WHERE m.managerID = p_managerID$$

DROP PROCEDURE IF EXISTS `getManagerNames`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getManagerNames` ()   SELECT s.firstName
FROM manager m
JOIN staff s ON s.staffID = m.staffID$$

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

DROP PROCEDURE IF EXISTS `getSelectedManagerID`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getSelectedManagerID` (IN `fname` VARCHAR(50))   SELECT m.managerID, st.stationNo
FROM manager m
JOIN staff s ON s.staffID = m.staffID
LEFT JOIN station st ON m.managerID = st.managerID
WHERE s.firstName LIKE CONCAT('%', fname, '%') COLLATE utf8mb4_unicode_ci$$

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
    dtr.clockouttime,
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
(7, 7, 'johnmatheow.morillo', 'cho12345', 1, 1, 0),
(8, 8, 'emily.johnson', 'johnson123', 1, 1, 0),
(9, 9, 'mikejasper.otero', '7n8Vh', 1, 1, 0),
(10, 10, 'johnwilliard.sanjuan', 'sanjuan123', 1, 1, 0),
(11, 11, 'walterhartwel.white', 'ShZiG7dbbehjJwUj', 1, 1, 0),
(12, 12, 'jesse.pinkman', 'hJnbdrtqJXdZ6XRJ', 1, 1, 0),
(13, 13, 'gus.fring', 'yXuJMxQH6N3mlcep', 1, 1, 0),
(14, 14, 'saul.goodman', 'gwhVrBVqucCmKTgc', 1, 1, 0),
(15, 15, 'mike.ermantrauth', 'zs5TeAfNlDvQwGoR', 1, 1, 0),
(16, 16, 'smurf.account', 'vo7bEeE1YNumW6d0', 1, 1, 0),
(17, 17, 'hank.shrader', 'MZULPv1yQuYSFLmM', 1, 1, 0),
(18, 18, 'thomas.shelby', 'yPxhZVUQ6G5M7JyV', 1, 1, 0),
(19, 19, 'normal.abnormal', '3AADvkh4ZMeeQSvN', 1, 1, 0),
(20, 20, 'asjd.ashflasd', 'jQGo0IyqNo79MDVg', 1, 1, 0),
(21, 21, 'test20.test20', 'jgRhpZdCwo57Or6V', 1, 1, 0),
(22, 22, 'aa.z', '3AOsDiR6OJ4ofXqB', 1, 1, 0),
(23, 23, 'aaa.a', 'a5uFVEN2424ZEkpB', 1, 1, 0),
(24, 24, 'a.a', 'fYE3TSY1pcqxDED4', 1, 1, 0),
(25, 25, 'johnmari.giducos', 'uo5h2', 1, 1, 0),
(27, 27, 'kontra.dengue', 'GnF1P', 1, 2, 0);

-- --------------------------------------------------------

--
-- Table structure for table `dtr`
--

DROP TABLE IF EXISTS `dtr`;
CREATE TABLE IF NOT EXISTS `dtr` (
  `dtrID` int NOT NULL AUTO_INCREMENT,
  `payslipID` int NOT NULL,
  `userID` int NOT NULL,
  `clockintime` time NOT NULL,
  `clockedIn` tinyint NOT NULL DEFAULT '0',
  `clockouttime` time NOT NULL,
  `clockedOut` tinyint NOT NULL DEFAULT '0',
  `totalHours` decimal(10,2) DEFAULT NULL,
  `dtrDate` date NOT NULL,
  PRIMARY KEY (`dtrID`),
  UNIQUE KEY `dtrID_Unique` (`dtrID`) USING BTREE,
  KEY `dtrID_Index` (`dtrID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=180 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `dtr`
--

INSERT INTO `dtr` (`dtrID`, `payslipID`, `userID`, `clockintime`, `clockedIn`, `clockouttime`, `clockedOut`, `totalHours`, `dtrDate`) VALUES
(12, 7, 1, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(13, 7, 1, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(14, 7, 1, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(15, 7, 1, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(16, 7, 1, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(17, 7, 1, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(18, 7, 1, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(19, 7, 2, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(20, 7, 2, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(21, 7, 2, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(22, 7, 2, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(23, 7, 2, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(24, 7, 2, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(25, 7, 2, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(26, 7, 3, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(27, 7, 3, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(28, 7, 3, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(29, 7, 3, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(30, 7, 3, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(31, 7, 3, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(32, 7, 3, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(33, 7, 5, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(34, 7, 5, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(35, 7, 5, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(36, 7, 5, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(37, 7, 5, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(38, 7, 5, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(39, 7, 5, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(40, 7, 7, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(41, 7, 7, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(42, 7, 7, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(43, 7, 7, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(44, 7, 7, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(45, 7, 7, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(46, 7, 7, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(47, 7, 8, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(48, 7, 8, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(49, 7, 8, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(50, 7, 8, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(51, 7, 8, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(52, 7, 8, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(53, 7, 8, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(54, 7, 9, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(55, 7, 9, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(56, 7, 9, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(57, 7, 9, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(58, 7, 9, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(59, 7, 9, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(60, 7, 9, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(61, 7, 10, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(62, 7, 10, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(63, 7, 10, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(64, 7, 10, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(65, 7, 10, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(66, 7, 10, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(67, 7, 10, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(68, 7, 11, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(69, 7, 11, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(70, 7, 11, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(71, 7, 11, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(72, 7, 11, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(73, 7, 11, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(74, 7, 11, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(75, 7, 12, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(76, 7, 12, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(77, 7, 12, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(78, 7, 12, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(79, 7, 12, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(80, 7, 12, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(81, 7, 12, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(82, 7, 13, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(83, 7, 13, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(84, 7, 13, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(85, 7, 13, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(86, 7, 13, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(87, 7, 13, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(88, 7, 13, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(89, 7, 14, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(90, 7, 14, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(91, 7, 14, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(92, 7, 14, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(93, 7, 14, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(94, 7, 14, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(95, 7, 14, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(96, 7, 15, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(97, 7, 15, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(98, 7, 15, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(99, 7, 15, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(100, 7, 15, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(101, 7, 15, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(102, 7, 15, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(103, 7, 16, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(104, 7, 16, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(105, 7, 16, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(106, 7, 16, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(107, 7, 16, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(108, 7, 16, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(109, 7, 16, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(110, 7, 17, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(111, 7, 17, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(112, 7, 17, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(113, 7, 17, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(114, 7, 17, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(115, 7, 17, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(116, 7, 17, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(117, 7, 18, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(118, 7, 18, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(119, 7, 18, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(120, 7, 18, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(121, 7, 18, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(122, 7, 18, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(123, 7, 18, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(124, 7, 19, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(125, 7, 19, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(126, 7, 19, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(127, 7, 19, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(128, 7, 19, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(129, 7, 19, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(130, 7, 19, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(131, 7, 20, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(132, 7, 20, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(133, 7, 20, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(134, 7, 20, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(135, 7, 20, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(136, 7, 20, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(137, 7, 20, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(138, 7, 21, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(139, 7, 21, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(140, 7, 21, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(141, 7, 21, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(142, 7, 21, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(143, 7, 21, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(144, 7, 21, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(145, 7, 22, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(146, 7, 22, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(147, 7, 22, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(148, 7, 22, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(149, 7, 22, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(150, 7, 22, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(151, 7, 22, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(152, 7, 23, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(153, 7, 23, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(154, 7, 23, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(155, 7, 23, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(156, 7, 23, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(157, 7, 23, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(158, 7, 23, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(159, 7, 24, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(160, 7, 24, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(161, 7, 24, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(162, 7, 24, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(163, 7, 24, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(164, 7, 24, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(165, 7, 24, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(166, 7, 25, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(167, 7, 25, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(168, 7, 25, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(169, 7, 25, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(170, 7, 25, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(171, 7, 25, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(172, 7, 25, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04'),
(173, 7, 27, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-29'),
(174, 7, 27, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-30'),
(175, 7, 27, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-10-31'),
(176, 7, 27, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-01'),
(177, 7, 27, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-02'),
(178, 7, 27, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-03'),
(179, 7, 27, '00:00:00', 0, '00:00:00', 0, '0.00', '2023-11-04');

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
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
(48, '2023-11-01 22:30:20', 'Server Terminated');

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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=InnoDB AUTO_INCREMENT=368 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `payslipdetail`
--

INSERT INTO `payslipdetail` (`payslipDetailID`, `payslipID`, `userID`, `totalHours`, `subtotal`, `allowance`, `deduction`, `totalSalary`) VALUES
(56, 7, 1, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(57, 7, 2, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(58, 7, 3, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(59, 7, 5, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(60, 7, 7, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(61, 7, 8, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(62, 7, 9, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(63, 7, 10, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(64, 7, 11, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(65, 7, 12, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(66, 7, 13, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(67, 7, 14, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(68, 7, 15, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(69, 7, 16, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(70, 7, 17, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(71, 7, 18, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(72, 7, 19, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(73, 7, 20, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(74, 7, 21, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(75, 7, 22, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(76, 7, 23, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(77, 7, 24, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(78, 7, 25, '00:00:00', '0.00', '0.00', '0.00', 0.00),
(79, 7, 27, '00:00:00', '0.00', '0.00', '0.00', 0.00);

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
    INSERT INTO dtr (payslipID, userID, clockintime, clockouttime, totalHours, dtrDate)
    VALUES (NEW.payslipID, NEW.userID, '00:00:00', '00:00:00', 0, DATE_ADD(@startDate, INTERVAL i DAY));
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
('PS Server', 0, '2023-11-01 22:30:20');

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
(8, 'Emily', 'Johnson', 'Male', '2023-08-22 00:00:00', 'Cashier', '500.00', '0.00', 'S001'),
(9, 'Mike Jasper', 'Otero', 'Male', '2023-10-01 00:00:00', 'Guitarist', '1000.00', '500.00', 'S002'),
(10, 'John Williard', 'San Juan', 'Male', '2023-10-01 00:00:00', 'Cashier', '1000.00', '500.00', 'S001'),
(11, 'Walter Hartwel', 'White', 'Male', '1958-09-07 11:43:13', 'Cook', '5220.00', '5220.00', ''),
(12, 'Jesse', 'Pinkman', 'Male', '1984-09-24 13:54:45', 'Sous Chef', '3000.00', '3000.00', ''),
(13, 'Gus', 'Fring', 'Male', '1958-09-07 14:00:45', 'Manager', '4000.00', '4000.00', ''),
(14, 'Saul', 'Goodman', 'Male', '1960-11-12 14:03:32', 'Lawyer', '2000.00', '2000.00', ''),
(15, 'Mike', 'Ermantrauth', 'Male', '1963-10-01 14:05:40', 'Gunner', '12.00', '12.00', ''),
(16, 'smurf', 'account', 'Female', '2023-02-22 14:07:40', 'smurf', '12.00', '12.00', ''),
(17, 'Hank', 'Shrader', 'Male', '1960-09-19 14:26:26', 'DEA', '1500.00', '1500.00', ''),
(18, 'Thomas', 'Shelby', 'Male', '2001-02-28 14:56:56', 'Leader', '10000.00', '10000.00', ''),
(19, 'Normal', 'Abnormal', 'Prefer not to say', '2023-10-01 14:59:35', 'normal', '0.00', '0.00', ''),
(20, 'asjd', 'ashflasd', 'Male', '2023-10-01 17:35:06', 'sad', '12.00', '12.00', 'S001'),
(21, 'test20', 'test20', 'Male', '2023-10-01 17:40:29', 'test20', '20.00', '20.00', 'S001'),
(22, 'aa', 'z', 'Male', '2023-10-01 17:42:19', 'as1', '1.00', '1.00', 'S001'),
(23, 'aaa', 'a', 'Male', '2023-10-01 17:44:31', 'aa', '1.00', '1.00', ''),
(24, 'a', 'a', 'Male', '2023-10-01 17:50:52', 'a', '1.00', '1.00', 'S001'),
(25, 'John Mari', 'Giducos', 'Male', '2023-10-10 15:03:46', 'okems', '0.00', '0.00', ''),
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
