-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Sep 13, 2023 at 03:00 PM
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

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
CREATE TABLE IF NOT EXISTS `account` (
  `userID` double NOT NULL AUTO_INCREMENT,
  `employeeID` double NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `isEnabled` double NOT NULL DEFAULT '1',
  `accountDescription` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT 'Employee',
  `accountLevel` double NOT NULL DEFAULT '1',
  `salary` double NOT NULL DEFAULT '0',
  `allowance` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`userID`),
  UNIQUE KEY `userID_Unique` (`userID`) USING BTREE,
  KEY `userID_Index` (`userID`),
  KEY `username_Index` (`username`) USING BTREE,
  KEY `accountLevel_Index` (`accountLevel`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`userID`, `employeeID`, `username`, `password`, `isEnabled`, `accountDescription`, `accountLevel`, `salary`, `allowance`) VALUES
(1, 1, 'johnrey', 'johnrey', 1, 'Employee', 3, 0, 0),
(2, 2, 'laurence', 'laurence', 1, 'employee', 2, 0, 0),
(3, 3, 'username', 'password', 0, 'Test', 1, 0, 0),
(5, 5, 'test', 'test', 1, 'Manager', 2, 3, 3);

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
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
CREATE TABLE IF NOT EXISTS `employee` (
  `employeeID` double NOT NULL AUTO_INCREMENT,
  `managerID` double NOT NULL,
  `firstName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL,
  PRIMARY KEY (`employeeID`),
  UNIQUE KEY `employeeID_Unique` (`employeeID`) USING BTREE,
  KEY `employeeID_Index` (`employeeID`) USING BTREE,
  KEY `firstName_Index` (`firstName`) USING BTREE,
  KEY `lastName_Index` (`lastName`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`employeeID`, `managerID`, `firstName`, `lastName`) VALUES
(1, 0, 'johnrey', 'silverio'),
(2, 1, 'laurence', 'silverio'),
(3, 1, 'username', 'password'),
(5, 1, 'test', 'test');

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
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
