-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Oct 26, 2023 at 04:16 PM
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

DROP PROCEDURE IF EXISTS `GeneratePayslipDetails`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GeneratePayslipDetails` (IN `userID` INT)   BEGIN
    DECLARE retpayslipID INT;

    -- Get the payslipID from the payslip table for the current date
    SELECT payslipID INTO retpayslipID
    FROM payslip
    WHERE CURDATE() BETWEEN startDate AND endDate;

    -- Check if payslipID is found
    IF retpayslipID IS NOT NULL THEN
        -- Check if a row with the same userID and payslipID doesn't already exist
        IF NOT EXISTS (
            SELECT 1
            FROM payslipdetail
            WHERE userID = userID AND payslipID = retpayslipID
        ) THEN
            -- Insert a new row in payslipDetails with initial values set to 0
            INSERT INTO payslipdetail (payslipID, userID, totalHours, subtotal, allowance, deduction, totalSalary)
            VALUES (retpayslipID, userID, 0, 0, 0, 0, 0);
        END IF;
    END IF;
END$$

DROP PROCEDURE IF EXISTS `getAccDetails`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAccDetails` (IN `staffID` DOUBLE)   SELECT 
                        a.*,
                        stf.firstName,
                        stf.lastName,
                        stf.sex,
                        stf.DOB,
                        stf.position,
                        stf.stationNo,
                        stf.allowance,
                        stf.salary,
                        m.managerID AS ownManagerID
                        
                    FROM account a
                    JOIN staff stf ON a.staffID = stf.staffID
                    LEFT JOIN station stn ON stf.stationNO = stn.stationNO
                    LEFT JOIN manager m ON stf.staffID = m.staffID
                    Where a.staffID = staffID$$

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
  KEY `userID_Index` (`userID`),
  KEY `username_Index` (`username`) USING BTREE,
  KEY `accountLevel_Index` (`accountLevel`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
  `nthPayslip` int NOT NULL,
  `userID` int NOT NULL,
  `clockintime` time NOT NULL,
  `clockouttime` time NOT NULL,
  `totalHours` decimal(10,2) DEFAULT NULL,
  `dtrDate` date NOT NULL,
  PRIMARY KEY (`dtrID`),
  UNIQUE KEY `dtrID_Unique` (`dtrID`) USING BTREE,
  KEY `dtrID_Index` (`dtrID`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `dtr`
--

INSERT INTO `dtr` (`dtrID`, `nthPayslip`, `userID`, `clockintime`, `clockouttime`, `totalHours`, `dtrDate`) VALUES
(11, 1, 5, '00:00:00', '00:00:00', '0.00', '2023-10-24'),
(10, 1, 3, '00:00:00', '00:00:00', '0.00', '2023-10-24'),
(9, 1, 2, '00:00:00', '00:00:00', '0.00', '2023-10-24'),
(8, 1, 1, '00:00:00', '00:00:00', '0.00', '2023-10-24');

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
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `manager`
--

DROP TABLE IF EXISTS `manager`;
CREATE TABLE IF NOT EXISTS `manager` (
  `managerID` double NOT NULL AUTO_INCREMENT,
  `staffID` double NOT NULL,
  PRIMARY KEY (`managerID`),
  UNIQUE KEY `managerID` (`managerID`),
  KEY `managerID_2` (`managerID`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `manager`
--

INSERT INTO `manager` (`managerID`, `staffID`) VALUES
(1, 1),
(2, 2),
(3, 5),
(4, 11),
(5, 12),
(6, 17),
(7, 18);

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
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
  KEY `payslipID_Index` (`payslipDetailID`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
) ENGINE=MyISAM AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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

-- --------------------------------------------------------

--
-- Table structure for table `station`
--

DROP TABLE IF EXISTS `station`;
CREATE TABLE IF NOT EXISTS `station` (
  `stationNo` varchar(50) NOT NULL,
  `stationName` varchar(50) DEFAULT NULL,
  `stationFloor` int DEFAULT NULL,
  `managerID` int NOT NULL,
  PRIMARY KEY (`stationNo`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `station`
--

INSERT INTO `station` (`stationNo`, `stationName`, `stationFloor`, `managerID`) VALUES
('S001', 'Lobby', 1, 2),
('S002', 'Grocery', 1, 3);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
