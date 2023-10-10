-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Oct 10, 2023 at 10:14 AM
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
DROP PROCEDURE IF EXISTS `checkUsername`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `checkUsername` (IN `usn` VARCHAR(50))   SELECT username FROM account WHERE username = usn$$

DROP PROCEDURE IF EXISTS `getAccDetails`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAccDetails` (IN `staffID` DOUBLE)   SELECT 
                        a.*,
                        stf.managerID,
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

DROP PROCEDURE IF EXISTS `getAllAccountDetailsForLVL2`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllAccountDetailsForLVL2` (IN `managerID` DOUBLE)   SELECT
    a.staffID as Staff_ID,
    a.isEnabled as Locked,
    a.accountLevel as Restriction,
    a.username as Username,
    stf.firstName as Firstname,
    stf.lastName as Lastname,
    stf.position as Position
FROM account a
JOIN staff stf ON a.staffID = stf.staffID
LEFT JOIN station stn ON stf.stationNO = stn.stationNO
JOIN manager m ON stf.managerID = m.managerID
Where stf.managerID = managerID$$

DROP PROCEDURE IF EXISTS `getAllAccountDetailsForLVL3`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllAccountDetailsForLVL3` ()   SELECT
    a.staffID as Staff_ID,
    stf.managerID as Manager_ID,
    a.isEnabled as Locked,
    a.accountLevel as Restriction,
    a.username as Username,
    stf.firstName as Firstname,
    stf.lastName as Lastname,
    stf.position as Position,
    stf.stationNo as Station_No
FROM account a
JOIN staff stf ON a.staffID = stf.staffID
LEFT JOIN station stn ON stf.stationNO = stn.stationNO
JOIN manager m ON stf.managerID = m.managerID$$

DROP PROCEDURE IF EXISTS `getLogin`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getLogin` (IN `usn` VARCHAR(50), IN `pass` VARCHAR(50))   SELECT * FROM account WHERE username = usn AND password = pass$$

DROP PROCEDURE IF EXISTS `getManagerNames`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getManagerNames` ()   SELECT s.firstName
FROM manager m
JOIN staff s ON s.staffID = m.staffID$$

DROP PROCEDURE IF EXISTS `getSelectedManagerID`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getSelectedManagerID` (IN `fname` VARCHAR(50))   SELECT m.managerID, st.stationNo
FROM manager m
JOIN staff s ON s.staffID = m.staffID
LEFT JOIN station st ON m.managerID = st.managerID
WHERE s.firstName LIKE CONCAT('%', fname, '%') COLLATE utf8mb4_unicode_ci$$

DROP PROCEDURE IF EXISTS `registerAccount`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `registerAccount` (IN `p_managerID` DOUBLE, IN `p_firstName` VARCHAR(50), IN `p_lastName` VARCHAR(50), IN `p_sex` VARCHAR(50), IN `p_DOB` DATETIME, IN `p_position` VARCHAR(50), IN `p_salary` DECIMAL(18,2), IN `p_allowance` DECIMAL(18,2), IN `p_stationNo` VARCHAR(50), IN `p_username` VARCHAR(50), IN `p_password` VARCHAR(50), IN `p_isEnabled` DOUBLE, IN `p_accountLevel` VARCHAR(50))   BEGIN
    DECLARE generatedStaffID INT;

    -- Step 1: Insert data into the "staff" table
    INSERT INTO staff (managerID, firstName, lastName, sex, DOB, position, salary, allowance, stationNo)
    VALUES (p_managerID, p_firstName, p_lastName, p_sex, p_DOB, p_position, p_salary, p_allowance, p_stationNo);

    -- Retrieve the generated staffID
    SET generatedStaffID = LAST_INSERT_ID();

    -- Step 2: Insert data into the "account" table
    INSERT INTO account (staffID, username, password, isEnabled, accountLevel)
    VALUES (generatedStaffID, p_username, p_password, p_isEnabled, p_accountLevel);

    -- Step 3: Conditional insert into the "manager" table based on accountLevel
    IF (p_accountLevel = 2 OR p_accountLevel = 3) THEN
        INSERT INTO manager (staffID)
        VALUES (generatedStaffID);
    END IF;
END$$

DROP PROCEDURE IF EXISTS `searchAccForLvl2`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `searchAccForLvl2` (IN `p_search` VARCHAR(50), IN `managerID` INT)   SELECT
    a.staffID as Staff_ID,
    stf.managerID as Manager_ID,
    a.isEnabled as Locked,
    a.accountLevel as Restriction,
    a.username as Username,
    stf.firstName as Firstname,
    stf.lastName as Lastname,
    stf.position as Position
FROM account a
JOIN staff stf ON a.staffID = stf.staffID
LEFT JOIN station stn ON stf.stationNO = stn.stationNO
JOIN manager m ON stf.managerID = m.managerID
WHERE stf.managerID = managerID
AND (a.username LIKE CONCAT('%', p_search, '%')
     OR stf.firstName LIKE CONCAT('%', p_search, '%')
     OR stf.lastName LIKE CONCAT('%', p_search, '%'))$$

DROP PROCEDURE IF EXISTS `searchAccforLvl3`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `searchAccforLvl3` (IN `p_search` VARCHAR(50))   SELECT
    a.staffID as Staff_ID,
    stf.managerID as Manager_ID,
    a.isEnabled as Locked,
    a.accountLevel as Restriction,
    a.username as Username,
    stf.firstName as Firstname,
    stf.lastName as Lastname,
    stf.position as Position
FROM account a
JOIN staff stf ON a.staffID = stf.staffID
LEFT JOIN station stn ON stf.stationNO = stn.stationNO
JOIN manager m ON stf.managerID = m.managerID
WHERE a.username LIKE CONCAT('%', p_search, '%')
OR stf.firstName LIKE CONCAT('%', p_search, '%')
OR stf.lastName LIKE CONCAT('%', p_search, '%')$$

DROP PROCEDURE IF EXISTS `updateAccountAndStaff`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `updateAccountAndStaff` (IN `p_staffID` DOUBLE, IN `p_fname` VARCHAR(50), IN `p_lname` VARCHAR(50), IN `p_sex` VARCHAR(50), IN `p_dOB` DATETIME)   UPDATE staff
SET firstName = p_fname,
	lastName = p_lname,
	sex = p_sex,
	DOB = p_dOB
WHERE staff.staffID = p_staffID$$

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
  PRIMARY KEY (`userID`),
  UNIQUE KEY `userID_Unique` (`userID`) USING BTREE,
  KEY `userID_Index` (`userID`),
  KEY `username_Index` (`username`) USING BTREE,
  KEY `accountLevel_Index` (`accountLevel`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`userID`, `staffID`, `username`, `password`, `isEnabled`, `accountLevel`) VALUES
(1, 1, 'johnrey.silverio', 'johnrey1', 1, 3),
(2, 2, 'laurence.silverio', 'laurence', 1, 2),
(3, 3, 'username.password', 'password', 0, 1),
(5, 5, 'test.test', 'test1234', 1, 2),
(7, 7, 'johnmatheow.morillo', 'cho12345', 1, 1),
(8, 8, 'emily.johnson', 'johnson123', 1, 1),
(9, 9, 'mikejasper.otero', 'otero123', 1, 1),
(10, 10, 'johnwilliard.sanjuan', 'sanjuan123', 1, 1),
(11, 11, 'walterhartwel.white', 'ShZiG7dbbehjJwUj', 1, 2),
(12, 12, 'jesse.pinkman', 'hJnbdrtqJXdZ6XRJ', 1, 2),
(13, 13, 'gus.fring', 'yXuJMxQH6N3mlcep', 1, 2),
(14, 14, 'saul.goodman', 'gwhVrBVqucCmKTgc', 1, 1),
(15, 15, 'mike.ermantrauth', 'zs5TeAfNlDvQwGoR', 1, 1),
(16, 16, 'smurf.account', 'vo7bEeE1YNumW6d0', 1, 1),
(17, 17, 'hank.shrader', 'MZULPv1yQuYSFLmM', 1, 2),
(18, 18, 'thomas.shelby', 'yPxhZVUQ6G5M7JyV', 1, 2),
(19, 19, 'normal.abnormal', '3AADvkh4ZMeeQSvN', 1, 1),
(20, 20, 'asjd.ashflasd', 'jQGo0IyqNo79MDVg', 1, 1),
(21, 21, 'test20.test20', 'jgRhpZdCwo57Or6V', 1, 1),
(22, 22, 'aa.z', '3AOsDiR6OJ4ofXqB', 1, 1),
(23, 23, 'aaa.a', 'a5uFVEN2424ZEkpB', 1, 1),
(24, 24, 'a.a', 'fYE3TSY1pcqxDED4', 1, 1),
(25, 25, 'johnmari.giducos', 'uo5h2', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `dtr`
--

DROP TABLE IF EXISTS `dtr`;
CREATE TABLE IF NOT EXISTS `dtr` (
  `dtrID` double NOT NULL AUTO_INCREMENT,
  `userID` double NOT NULL,
  `loginTime` datetime NOT NULL,
  `logoutTime` datetime NOT NULL,
  `totalHours` double DEFAULT NULL,
  `dtrDate` date NOT NULL,
  PRIMARY KEY (`dtrID`),
  UNIQUE KEY `dtrID_Unique` (`dtrID`) USING BTREE,
  KEY `dtrID_Index` (`dtrID`) USING BTREE
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
  `payslipID` double NOT NULL AUTO_INCREMENT,
  `userID` double NOT NULL,
  `salary` double NOT NULL,
  `allowance` double NOT NULL,
  `deduction` double NOT NULL,
  `totalWeeklySalary` double NOT NULL,
  `payslipDate` date NOT NULL,
  PRIMARY KEY (`payslipID`),
  UNIQUE KEY `payslipID_Unique` (`payslipID`) USING BTREE,
  KEY `payslipID_Index` (`payslipID`) USING BTREE
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
  `managerID` int NOT NULL,
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
) ENGINE=MyISAM AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `staff`
--

INSERT INTO `staff` (`staffID`, `managerID`, `firstName`, `lastName`, `sex`, `DOB`, `position`, `salary`, `allowance`, `stationNo`) VALUES
(1, 1, 'John Rey', 'Silverio', 'Male', '2001-04-17 00:00:00', 'Employee', '500.00', '0.00', 'S001'),
(2, 1, 'laurence', 'silverio', 'Male', '2023-09-28 00:00:00', 'Employee', '500.00', '0.00', 'S001'),
(3, 2, 'username', 'password', 'm', '2023-09-28 00:00:00', 'Employee', '500.00', '0.00', 'S002'),
(5, 1, 'test', 'test', 'Female', '2023-09-28 00:00:00', 'Manager', '1000.00', '500.00', 'S002'),
(7, 3, 'john matheo', 'morillo', 'Male', '2023-09-28 00:00:00', 'Employee', '500.00', NULL, 'S001'),
(8, 2, 'Emily', 'Johnson', 'Female', '2023-10-01 00:00:00', 'Cashier', '500.00', '0.00', 'S002'),
(9, 3, 'Mike Jasper', 'Otero', 'Male', '2023-10-01 00:00:00', 'Guitarist', '1000.00', '500.00', 'S002'),
(10, 2, 'John Williard', 'San Juan', 'Male', '2023-10-01 00:00:00', 'Cashier', '1000.00', '500.00', 'S001'),
(11, 1, 'Walter Hartwel', 'White', 'Male', '1958-09-07 11:43:13', 'Cook', '5220.00', '5220.00', ''),
(12, 4, 'Jesse', 'Pinkman', 'Male', '1984-09-24 13:54:45', 'Sous Chef', '3000.00', '3000.00', ''),
(13, 1, 'Gus', 'Fring', 'Male', '1958-09-07 14:00:45', 'Manager', '4000.00', '4000.00', ''),
(14, 1, 'Saul', 'Goodman', 'Male', '1960-11-12 14:03:32', 'Lawyer', '2000.00', '2000.00', ''),
(15, 1, 'Mike', 'Ermantrauth', 'Male', '1963-10-01 14:05:40', 'Gunner', '12.00', '12.00', ''),
(16, 1, 'smurf', 'account', 'Female', '2023-02-22 14:07:40', 'smurf', '12.00', '12.00', ''),
(17, 1, 'Hank', 'Shrader', 'Male', '1960-09-19 14:26:26', 'DEA', '1500.00', '1500.00', ''),
(18, 1, 'Thomas', 'Shelby', 'Male', '2001-02-28 14:56:56', 'Leader', '10000.00', '10000.00', ''),
(19, 1, 'Normal', 'Abnormal', 'Prefer not to say', '2023-10-01 14:59:35', 'normal', '0.00', '0.00', ''),
(20, 2, 'asjd', 'ashflasd', 'Male', '2023-10-01 17:35:06', 'sad', '12.00', '12.00', 'S001'),
(21, 2, 'test20', 'test20', 'Male', '2023-10-01 17:40:29', 'test20', '20.00', '20.00', 'S001'),
(22, 2, 'aa', 'z', 'Male', '2023-10-01 17:42:19', 'as1', '1.00', '1.00', 'S001'),
(23, 4, 'aaa', 'a', 'Male', '2023-10-01 17:44:31', 'aa', '1.00', '1.00', ''),
(24, 2, 'a', 'a', 'Male', '2023-10-01 17:50:52', 'a', '1.00', '1.00', 'S001'),
(25, 1, 'John Mari', 'Giducos', 'Male', '2023-10-10 15:03:46', 'okems', '0.00', '0.00', '');

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
