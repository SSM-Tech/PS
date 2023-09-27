-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Sep 27, 2023 at 03:41 AM
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
                        stf.salary,
                        stf.allowance
                    FROM account a
                    JOIN staff stf ON a.staffID = stf.staffID
                    JOIN station stn ON stf.stationNO = stn.stationNO
                    JOIN manager m ON stf.managerID = m.managerID
                    Where a.staffID = staffID$$

DROP PROCEDURE IF EXISTS `getLogin`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getLogin` (IN `usn` VARCHAR(50), IN `pass` VARCHAR(50))   SELECT * FROM account WHERE username = usn AND password = pass$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
CREATE TABLE IF NOT EXISTS `account` (
  `userID` double NOT NULL AUTO_INCREMENT,
  `staffID` double NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `isEnabled` double NOT NULL DEFAULT '1',
  `accountLevel` double NOT NULL DEFAULT '1',
  PRIMARY KEY (`userID`),
  UNIQUE KEY `userID_Unique` (`userID`) USING BTREE,
  KEY `userID_Index` (`userID`),
  KEY `username_Index` (`username`) USING BTREE,
  KEY `accountLevel_Index` (`accountLevel`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`userID`, `staffID`, `username`, `password`, `isEnabled`, `accountLevel`) VALUES
(1, 1, 'johnrey', 'johnrey', 1, 3),
(2, 2, 'laurence', 'laurence', 1, 2),
(3, 3, 'username', 'password', 0, 1),
(5, 5, 'test', 'test', 1, 2),
(7, 7, 'cho', 'cho', 1, 1);

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
  `employeeID` double NOT NULL,
  PRIMARY KEY (`managerID`),
  UNIQUE KEY `managerID` (`managerID`),
  KEY `managerID_2` (`managerID`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `manager`
--

INSERT INTO `manager` (`managerID`, `employeeID`) VALUES
(1, 1);

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
  `staffID` double NOT NULL AUTO_INCREMENT,
  `managerID` double DEFAULT NULL,
  `firstName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL,
  `sex` varchar(50) DEFAULT NULL,
  `DOB` datetime DEFAULT NULL,
  `position` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'Employee',
  `salary` decimal(18,2) DEFAULT '500.00',
  `allowance` decimal(18,2) DEFAULT NULL,
  `stationNo` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`staffID`),
  UNIQUE KEY `employeeID_Unique` (`staffID`) USING BTREE,
  KEY `employeeID_Index` (`staffID`) USING BTREE,
  KEY `firstName_Index` (`firstName`) USING BTREE,
  KEY `lastName_Index` (`lastName`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `staff`
--

INSERT INTO `staff` (`staffID`, `managerID`, `firstName`, `lastName`, `sex`, `DOB`, `position`, `salary`, `allowance`, `stationNo`) VALUES
(1, 1, 'johnrey', 'silverio', 'm', NULL, 'Employee', '500.00', '0.00', 'S001'),
(2, 1, 'laurence', 'silverio', 'm', NULL, 'Employee', '500.00', '0.00', 'S001'),
(3, 1, 'username', 'password', 'm', NULL, 'Employee', '500.00', '0.00', 'S002'),
(5, 1, 'test', 'test', 'm', NULL, 'Manager', '1000.00', '500.00', 'S002'),
(7, 1, 'john matheo', 'morillo', 'm', NULL, 'Employee', '500.00', NULL, 'S001');

-- --------------------------------------------------------

--
-- Table structure for table `station`
--

DROP TABLE IF EXISTS `station`;
CREATE TABLE IF NOT EXISTS `station` (
  `stationNo` varchar(50) NOT NULL,
  `stationName` varchar(50) DEFAULT NULL,
  `stationFloor` int DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `station`
--

INSERT INTO `station` (`stationNo`, `stationName`, `stationFloor`) VALUES
('S001', 'Lobby', 1),
('S002', 'Grocery', 1);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
