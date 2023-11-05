-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Nov 05, 2023 at 04:45 PM
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
    IF NOT EXISTS (
        SELECT 1
        FROM payslip
        WHERE CURDATE() BETWEEN startDate AND endDate
    ) THEN
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
    DECLARE clockinTime DATETIME;
    DECLARE clockoutTime DATETIME;
    DECLARE totalHours DECIMAL(10, 6);
    
    SET currentDate = CURDATE();
    SET clockinTime = NULL;
    SET clockoutTime = NULL;
    SET totalHours = 0;

    IF NOT EXISTS (
        SELECT 1
        FROM dtr
        WHERE dtrDate = currentDate
          AND userID = pUserID
          AND nthPayslip = pNthPayslip
    )
    THEN
        INSERT INTO dtr (nthPayslip, userID, clockinTime, clockoutTime, totalHours, dtrDate)
        VALUES (pNthPayslip, pUserID, clockinTime, clockoutTime, totalHours, currentDate);
    END IF;
END$$

DROP PROCEDURE IF EXISTS `editUserAcc`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `editUserAcc` (IN `p_staffID` INT, IN `p_firstname` VARCHAR(50), IN `p_lastname` VARCHAR(50), IN `p_sex` VARCHAR(50), IN `p_dOB` DATETIME, IN `p_position` VARCHAR(50), IN `p_salary` DECIMAL, IN `p_allowance` DECIMAL, IN `p_stationNo` VARCHAR(50), IN `p_isEnabled` INT, IN `p_accountLevel` INT, IN `p_sss` VARCHAR(50), IN `p_philhealth` VARCHAR(50), IN `p_pagibig` VARCHAR(50))   UPDATE staff s, account a
SET s.firstName = p_firstname,
	s.lastName = p_lastname,
    s.sex = p_sex,
    s.DOB = p_dOB,
    s.position = p_position,
    s.salary = p_salary,
    s.allowance = p_allowance,
    s.SSS = p_sss,
    s.PhilHealth = p_philhealth,
    s.PagIbig = p_pagibig,
    s.stationNo = p_stationNo,
    a.isEnabled = p_isEnabled,
    a.accountLevel = p_accountLevel
WHERE s.staffID = p_staffID
AND a.staffID = p_staffID$$

DROP PROCEDURE IF EXISTS `EventLog`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `EventLog` (IN `p_eventDescription` VARCHAR(255))   INSERT INTO eventlog (eventDateTime, eventDescription)
VALUES(NOW(), p_eventDescription)$$

DROP PROCEDURE IF EXISTS `FillPayslipDetail`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `FillPayslipDetail` (IN `p_userID` INT, IN `p_date` DATE)   BEGIN
    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;
	
    CALL `UpdatePayrollAllowance`(p_userID, p_date);
    SELECT `CalculatPayslipTotalHour`(p_userID, p_date);
	SELECT `CalculatPayslipSubTotal`(p_userID, p_date);
	SELECT `CalculateSSSDeduction`(p_userID, p_date);
    SELECT `CalculateDeduction`(p_userID, p_date);
    SELECT `CalculateTotalSalary`(p_userID, p_date);

    COMMIT;
    
END$$

DROP PROCEDURE IF EXISTS `GenerateDTRTotalHours`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GenerateDTRTotalHours` ()   BEGIN
    UPDATE dtr
    SET totalHours = CalculateTotalHours(clockouttime, clockintime)
    WHERE DATE(dtrDate) = CURDATE();
END$$

DROP PROCEDURE IF EXISTS `GeneratePayslipDetails`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GeneratePayslipDetails` (IN `userID` INT)   BEGIN
    DECLARE retpayslipID INT;

    START TRANSACTION;
    
    SELECT payslipID INTO retpayslipID
    FROM payslip
    WHERE CURDATE() BETWEEN startDate AND endDate;

    IF retpayslipID IS NOT NULL THEN
        INSERT IGNORE INTO payslipdetail (payslipID, userID, totalHours, subtotal, allowance, deduction, totalSalary)
        VALUES (retpayslipID, userID, 0, 0, 0, 0, 0);
    END IF;

    COMMIT;
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
    stf.SSS,
    stf.PagIbig,
    stf.PhilHealth,
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

DROP PROCEDURE IF EXISTS `GetPayslip`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetPayslip` (IN `p_userID` INT)   SELECT 
	CONCAT(ps.payslipID, '-', psd.payslipDetailID) AS combined_column,
	ps.payslipID,
    ps.startDate,
    ps.endDate,
	psd.payslipDetailID,
    psd.userID,
    psd.totalHours,
    psd.subtotal,
    psd.allowance,
    psd.deduction,
    psd.totalSalary
FROM payslip as ps
INNER JOIN payslipdetail as psd on psd.payslipID = ps.payslipID
WHERE CURDATE() > endDate AND psd.userID = p_userID$$

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

	INSERT INTO staffinsurance(useriD, SSS, PagIbig, PhilHealth)
	VALUES (generatedStaffID, 10, 250, 100);
END$$

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

DROP PROCEDURE IF EXISTS `UpdateLoginStatus`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateLoginStatus` (IN `p_userID` INT)   UPDATE account
SET isLoggedIn = 0
WHERE userID = p_userID$$

DROP PROCEDURE IF EXISTS `UpdatePayrollAllowance`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePayrollAllowance` (IN `p_userID` INT, IN `p_date` DATE)   UPDATE payslipdetail pd
JOIN account a ON a.userID = pd.userID
INNER JOIN staff s ON s.staffID = a.staffID
SET pd.allowance = s.salary
WHERE pd.userID = p_userID AND pd.payslipID IN (
    SELECT payslipID
    FROM payslip
    WHERE p_date BETWEEN startDate AND endDate
)$$

DROP PROCEDURE IF EXISTS `UpdateSpecificDTRTotalHour`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateSpecificDTRTotalHour` (IN `p_date` DATE)   BEGIN
    UPDATE dtr
    SET totalHours = CalculateTotalHours(clockouttime, clockintime)
    WHERE DATE(dtrDate) = p_date;
END$$

--
-- Functions
--
DROP FUNCTION IF EXISTS `CalculateDeduction`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculateDeduction` (`p_userID` INT, `p_date` DATE) RETURNS DECIMAL(10,6)  BEGIN
	DECLARE p_payslipID INT;
    DECLARE p_deduction DECIMAL(10, 6);
    
    SELECT payslipID
    INTO p_payslipID
    FROM payslip
    WHERE p_date BETWEEN startDate AND endDate;
    
    SELECT pd.SSSDeduction + si.PagIbig + si.PhilHealth
	INTO p_deduction
    FROM payslipdetail pd
    JOIN account a ON a.userID = pd.userID
    JOIN staff s ON s.staffID = a.staffID
    JOIN staffinsurance si ON si.userID = a.userID
    WHERE pd.userID = p_userID AND pd.payslipID = p_payslipID;

	UPDATE payslipdetail
    SET deduction = p_deduction
    WHERE userID = p_userid AND payslipID = p_payslipID;
    
RETURN p_deduction;
END$$

DROP FUNCTION IF EXISTS `CalculateSSSDeduction`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculateSSSDeduction` (`p_userID` INT, `p_date` DATE) RETURNS DECIMAL(10,6)  BEGIN
	DECLARE p_payslipID INT;
    DECLARE sss_deduction DECIMAL(10, 6);
    
    SELECT payslipID
    INTO p_payslipID
    FROM payslip
    WHERE p_date BETWEEN startDate AND endDate;
    
    SELECT (pd.subtotal * (si.SSS/100))
	INTO sss_deduction
    FROM payslipdetail pd
    JOIN account a ON a.userID = pd.userID
    JOIN staff s ON s.staffID = a.staffID
    JOIN staffinsurance si ON si.userID = a.userID
    WHERE pd.userID = p_userID AND pd.payslipID = p_payslipID;

	UPDATE payslipdetail
    SET SSSDeduction = sss_deduction
    WHERE userID = p_userid AND payslipID = p_payslipID;
    
RETURN sss_deduction;
END$$

DROP FUNCTION IF EXISTS `CalculateTotalHours`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculateTotalHours` (`clockin_time` DATETIME, `clockout_time` DATETIME) RETURNS DECIMAL(10,6)  BEGIN
    DECLARE total_seconds INT;
    DECLARE total_hours DECIMAL(10, 6); -- Increase precision
    
    SET total_seconds = TIMESTAMPDIFF(SECOND, clockout_time, clockin_time);
    SET total_hours = total_seconds / 3600.0;
    
    -- Check if total_hours is greater than 5 and subtract 1 if true
    IF total_hours > 5 THEN
        SET total_hours = total_hours - 1;
    END IF;

    RETURN COALESCE(total_hours, 0);
END$$

DROP FUNCTION IF EXISTS `CalculateTotalSalary`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculateTotalSalary` (`p_userID` INT, `p_date` DATE) RETURNS DECIMAL(10,6)  BEGIN
    DECLARE p_payslipID INT;
    DECLARE total_salary DECIMAL(10, 6);

    SELECT payslipID
    INTO p_payslipID
    FROM payslip
    WHERE p_date BETWEEN startDate AND endDate;

    SELECT IF(pd.subtotal = 0, 0, pd.subtotal + pd.allowance - pd.deduction)
    INTO total_salary
    FROM payslipdetail pd
    JOIN account a ON a.userID = pd.userID
    JOIN staff s ON s.staffID = a.staffID
    JOIN staffinsurance si ON si.userID = a.userID
    WHERE pd.userID = p_userID AND pd.payslipID = p_payslipID;

    UPDATE payslipdetail
    SET totalSalary = total_salary
    WHERE userID = p_userid AND payslipID = p_payslipID;

    RETURN total_salary;
END$$

DROP FUNCTION IF EXISTS `CalculatPayslipSubTotal`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculatPayslipSubTotal` (`p_userid` INT, `p_date` DATE) RETURNS DECIMAL(10,6)  BEGIN
    DECLARE p_payslipID INT;
    DECLARE sub_total DECIMAL(10, 6);

    SELECT payslipID
    INTO p_payslipID
    FROM payslip
    WHERE p_date BETWEEN startDate AND endDate;

    SELECT (pd.totalHours * (s.salary / 8 / 5))
    INTO sub_total
    FROM payslipdetail pd
    JOIN account a ON a.userID = pd.userID
    JOIN staff s ON s.staffID = a.staffID
    WHERE pd.userID = p_userid AND pd.payslipID = p_payslipID;

    UPDATE payslipdetail
    SET subtotal = sub_total
    WHERE userID = p_userid AND payslipID = p_payslipID;

    RETURN sub_total;
END$$

DROP FUNCTION IF EXISTS `CalculatPayslipTotalHour`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculatPayslipTotalHour` (`p_userid` INT, `p_date` DATE) RETURNS DECIMAL(10,6)  BEGIN
    DECLARE p_payslipID INT;
    DECLARE new_total DECIMAL(10, 6);

    -- Find the payslipID for the current date
    SELECT payslipID
    INTO p_payslipID
    FROM payslip
    WHERE p_date BETWEEN startDate AND endDate;
    
    SELECT SUM(totalHours)
    INTO new_total
    FROM dtr
    WHERE userID = p_userid AND payslipID = p_payslipID;

    -- Update the payslipdetail table
    UPDATE payslipdetail
    SET totalHours = new_total
    WHERE userID = p_userid AND payslipID = p_payslipID;

    RETURN new_total;
END$$

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
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`userID`, `staffID`, `username`, `password`, `isEnabled`, `accountLevel`, `isLoggedIn`) VALUES
(1, 1, 'johnrey.silverio', 'berio123', 1, 2, 0),
(2, 2, 'laurence.silverio', 'laurence', 1, 2, 0),
(3, 3, 'username.password', 'password', 1, 1, 0),
(5, 5, 'test.test', 'test1234', 0, 1, 0),
(7, 7, 'johnmatheow.morillo', 'cho12345', 1, 1, 0),
(27, 27, 'kontra.dengue', 'kontra.dengue', 1, 1, 0),
(28, 28, 'jesus.crist', 'jesus.crist', 1, 2, 0),
(29, 29, 'philhealth.pagibig', 'h1yAB', 1, 1, 0);

--
-- Triggers `account`
--
DROP TRIGGER IF EXISTS `DeleteAccountAndRelatedRows`;
DELIMITER $$
CREATE TRIGGER `DeleteAccountAndRelatedRows` AFTER DELETE ON `account` FOR EACH ROW BEGIN
    DELETE FROM staff WHERE staffID = OLD.staffID;
    DELETE FROM dtr WHERE userID = OLD.staffID;
    DELETE FROM payslipdetail WHERE userID = OLD.staffID;
    DELETE FROM staffinsurance WHERE userID = OLD.staffID;
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
  `totalHours` decimal(10,6) DEFAULT NULL,
  `dtrDate` date NOT NULL,
  PRIMARY KEY (`dtrID`),
  UNIQUE KEY `dtrID_Unique` (`dtrID`) USING BTREE,
  KEY `dtrID_Index` (`dtrID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=348 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `dtr`
--

INSERT INTO `dtr` (`dtrID`, `payslipID`, `userID`, `clockintime`, `clockedIn`, `clockouttime`, `clockedOut`, `totalHours`, `dtrDate`) VALUES
(250, 7, 1, NULL, 0, NULL, 0, '0.000000', '2023-10-29'),
(251, 7, 1, NULL, 0, NULL, 0, '0.000000', '2023-10-30'),
(252, 7, 1, NULL, 0, NULL, 0, '0.000000', '2023-10-31'),
(253, 7, 1, NULL, 0, NULL, 0, '0.000000', '2023-11-01'),
(254, 7, 1, '2023-11-02 09:15:16', 1, '2023-11-02 15:40:12', 1, '6.415556', '2023-11-02'),
(255, 7, 1, '2023-11-03 08:25:39', 1, '2023-11-03 22:51:38', 1, '14.433056', '2023-11-03'),
(256, 7, 1, '2023-11-04 20:29:33', 1, '2023-11-04 22:16:28', 1, '1.781944', '2023-11-04'),
(257, 7, 2, NULL, 0, NULL, 0, '0.000000', '2023-10-29'),
(258, 7, 2, NULL, 0, NULL, 0, '0.000000', '2023-10-30'),
(259, 7, 2, NULL, 0, NULL, 0, '0.000000', '2023-10-31'),
(260, 7, 2, NULL, 0, NULL, 0, '0.000000', '2023-11-01'),
(261, 7, 2, '2023-11-02 20:01:41', 1, '2023-11-02 20:06:43', 1, '0.083889', '2023-11-02'),
(262, 7, 2, '2023-11-03 08:25:56', 1, '2023-11-03 22:51:59', 1, '14.434167', '2023-11-03'),
(263, 7, 2, '2023-11-04 20:30:17', 1, '2023-11-04 22:34:48', 1, '2.075278', '2023-11-04'),
(264, 7, 3, NULL, 0, NULL, 0, '0.000000', '2023-10-29'),
(265, 7, 3, NULL, 0, NULL, 0, '0.000000', '2023-10-30'),
(266, 7, 3, NULL, 0, NULL, 0, '0.000000', '2023-10-31'),
(267, 7, 3, NULL, 0, NULL, 0, '0.000000', '2023-11-01'),
(268, 7, 3, '2023-11-02 20:17:53', 1, '2023-11-02 20:21:15', 1, '0.056111', '2023-11-02'),
(269, 7, 3, '2023-11-03 08:26:21', 1, '2023-11-03 22:52:16', 1, '14.431944', '2023-11-03'),
(270, 7, 3, '2023-11-04 20:30:39', 1, '2023-11-04 22:35:01', 1, '2.072778', '2023-11-04'),
(271, 7, 5, NULL, 0, NULL, 0, '0.000000', '2023-10-29'),
(272, 7, 5, NULL, 0, NULL, 0, '0.000000', '2023-10-30'),
(273, 7, 5, NULL, 0, NULL, 0, '0.000000', '2023-10-31'),
(274, 7, 5, NULL, 0, NULL, 0, '0.000000', '2023-11-01'),
(275, 7, 5, NULL, 0, NULL, 0, '0.000000', '2023-11-02'),
(276, 7, 5, NULL, 0, NULL, 0, '0.000000', '2023-11-03'),
(277, 7, 5, NULL, 0, NULL, 0, '0.000000', '2023-11-04'),
(278, 7, 7, NULL, 0, NULL, 0, '0.000000', '2023-10-29'),
(279, 7, 7, NULL, 0, NULL, 0, '0.000000', '2023-10-30'),
(280, 7, 7, NULL, 0, NULL, 0, '0.000000', '2023-10-31'),
(281, 7, 7, NULL, 0, NULL, 0, '0.000000', '2023-11-01'),
(282, 7, 7, '2023-11-02 20:10:40', 1, '2023-11-02 20:13:49', 1, '0.052500', '2023-11-02'),
(283, 7, 7, '2023-11-03 08:26:33', 1, '2023-11-03 22:52:41', 1, '14.435556', '2023-11-03'),
(284, 7, 7, '2023-11-04 20:30:30', 1, '2023-11-04 22:27:51', 1, '1.955833', '2023-11-04'),
(285, 7, 28, NULL, 0, NULL, 0, '0.000000', '2023-10-29'),
(286, 7, 28, NULL, 0, NULL, 0, '0.000000', '2023-10-30'),
(287, 7, 28, NULL, 0, NULL, 0, '0.000000', '2023-10-31'),
(288, 7, 28, NULL, 0, NULL, 0, '0.000000', '2023-11-01'),
(289, 7, 28, NULL, 0, NULL, 0, '0.000000', '2023-11-02'),
(290, 7, 28, NULL, 0, NULL, 0, '0.000000', '2023-11-03'),
(291, 7, 28, '2023-11-04 22:37:45', 1, '2023-11-04 22:37:50', 1, '0.001389', '2023-11-04'),
(292, 9, 1, '2023-11-05 08:32:41', 1, '2023-11-05 17:03:14', 1, '7.509167', '2023-11-05'),
(293, 9, 1, NULL, 0, NULL, 0, '0.000000', '2023-11-06'),
(294, 9, 1, NULL, 0, NULL, 0, '0.000000', '2023-11-07'),
(295, 9, 1, NULL, 0, NULL, 0, '0.000000', '2023-11-08'),
(296, 9, 1, NULL, 0, NULL, 0, '0.000000', '2023-11-09'),
(297, 9, 1, NULL, 0, NULL, 0, '0.000000', '2023-11-10'),
(298, 9, 1, NULL, 0, NULL, 0, '0.000000', '2023-11-11'),
(299, 9, 2, '2023-11-05 08:33:04', 1, '2023-11-05 19:08:26', 1, '9.589444', '2023-11-05'),
(300, 9, 2, NULL, 0, NULL, 0, '0.000000', '2023-11-06'),
(301, 9, 2, NULL, 0, NULL, 0, '0.000000', '2023-11-07'),
(302, 9, 2, NULL, 0, NULL, 0, '0.000000', '2023-11-08'),
(303, 9, 2, NULL, 0, NULL, 0, '0.000000', '2023-11-09'),
(304, 9, 2, NULL, 0, NULL, 0, '0.000000', '2023-11-10'),
(305, 9, 2, NULL, 0, NULL, 0, '0.000000', '2023-11-11'),
(306, 9, 3, '2023-11-05 08:33:20', 1, '2023-11-05 19:08:38', 1, '9.588333', '2023-11-05'),
(307, 9, 3, NULL, 0, NULL, 0, '0.000000', '2023-11-06'),
(308, 9, 3, NULL, 0, NULL, 0, '0.000000', '2023-11-07'),
(309, 9, 3, NULL, 0, NULL, 0, '0.000000', '2023-11-08'),
(310, 9, 3, NULL, 0, NULL, 0, '0.000000', '2023-11-09'),
(311, 9, 3, NULL, 0, NULL, 0, '0.000000', '2023-11-10'),
(312, 9, 3, NULL, 0, NULL, 0, '0.000000', '2023-11-11'),
(313, 9, 5, NULL, 0, NULL, 0, '0.000000', '2023-11-05'),
(314, 9, 5, NULL, 0, NULL, 0, '0.000000', '2023-11-06'),
(315, 9, 5, NULL, 0, NULL, 0, '0.000000', '2023-11-07'),
(316, 9, 5, NULL, 0, NULL, 0, '0.000000', '2023-11-08'),
(317, 9, 5, NULL, 0, NULL, 0, '0.000000', '2023-11-09'),
(318, 9, 5, NULL, 0, NULL, 0, '0.000000', '2023-11-10'),
(319, 9, 5, NULL, 0, NULL, 0, '0.000000', '2023-11-11'),
(320, 9, 7, '2023-11-05 08:33:35', 1, '2023-11-05 19:08:52', 1, '9.588056', '2023-11-05'),
(321, 9, 7, NULL, 0, NULL, 0, '0.000000', '2023-11-06'),
(322, 9, 7, NULL, 0, NULL, 0, '0.000000', '2023-11-07'),
(323, 9, 7, NULL, 0, NULL, 0, '0.000000', '2023-11-08'),
(324, 9, 7, NULL, 0, NULL, 0, '0.000000', '2023-11-09'),
(325, 9, 7, NULL, 0, NULL, 0, '0.000000', '2023-11-10'),
(326, 9, 7, NULL, 0, NULL, 0, '0.000000', '2023-11-11'),
(327, 9, 28, '2023-11-05 08:33:44', 1, '2023-11-05 19:09:04', 1, '9.588889', '2023-11-05'),
(328, 9, 28, NULL, 0, NULL, 0, '0.000000', '2023-11-06'),
(329, 9, 28, NULL, 0, NULL, 0, '0.000000', '2023-11-07'),
(330, 9, 28, NULL, 0, NULL, 0, '0.000000', '2023-11-08'),
(331, 9, 28, NULL, 0, NULL, 0, '0.000000', '2023-11-09'),
(332, 9, 28, NULL, 0, NULL, 0, '0.000000', '2023-11-10'),
(333, 9, 28, NULL, 0, NULL, 0, '0.000000', '2023-11-11'),
(334, 9, 29, NULL, 0, NULL, 0, '0.000000', '2023-11-05'),
(335, 9, 29, NULL, 0, NULL, 0, '0.000000', '2023-11-06'),
(336, 9, 29, NULL, 0, NULL, 0, '0.000000', '2023-11-07'),
(337, 9, 29, NULL, 0, NULL, 0, '0.000000', '2023-11-08'),
(338, 9, 29, NULL, 0, NULL, 0, '0.000000', '2023-11-09'),
(339, 9, 29, NULL, 0, NULL, 0, '0.000000', '2023-11-10'),
(340, 9, 29, NULL, 0, NULL, 0, '0.000000', '2023-11-11'),
(341, 9, 27, NULL, 0, NULL, 0, '0.000000', '2023-11-05'),
(342, 9, 27, NULL, 0, NULL, 0, '0.000000', '2023-11-06'),
(343, 9, 27, NULL, 0, NULL, 0, '0.000000', '2023-11-07'),
(344, 9, 27, NULL, 0, NULL, 0, '0.000000', '2023-11-08'),
(345, 9, 27, NULL, 0, NULL, 0, '0.000000', '2023-11-09'),
(346, 9, 27, NULL, 0, NULL, 0, '0.000000', '2023-11-10'),
(347, 9, 27, NULL, 0, NULL, 0, '0.000000', '2023-11-11');

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
) ENGINE=InnoDB AUTO_INCREMENT=93 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
(62, '2023-11-02 20:24:13', 'Server Terminated'),
(63, '2023-11-03 08:25:18', 'Server Started'),
(64, '2023-11-03 09:46:45', 'Server Terminated'),
(65, '2023-11-03 22:49:57', 'Server Started'),
(66, '2023-11-03 22:52:49', 'Server Terminated'),
(67, '2023-11-03 23:07:32', 'Server Started'),
(68, '2023-11-03 23:08:32', 'Server Terminated'),
(69, '2023-11-03 23:15:58', 'Server Started'),
(70, '2023-11-03 23:17:47', 'Server Terminated'),
(71, '2023-11-04 20:28:08', 'Server Started'),
(72, '2023-11-04 20:31:13', 'Server Terminated'),
(73, '2023-11-04 20:33:33', 'Server Started'),
(74, '2023-11-04 23:30:43', 'Server Terminated'),
(75, '2023-11-05 08:27:33', 'Server Started'),
(76, '2023-11-05 13:06:50', 'Server Terminated'),
(77, '2023-11-05 13:30:49', 'Server Started'),
(78, '2023-11-05 18:59:44', 'Server Terminated'),
(79, '2023-11-05 19:07:57', 'Server Started'),
(80, '2023-11-05 19:11:20', 'Server Terminated'),
(81, '2023-11-05 19:15:17', 'Server Started'),
(82, '2023-11-05 19:15:34', 'Server Terminated'),
(83, '2023-11-05 19:17:09', 'Server Started'),
(84, '2023-11-05 19:57:44', 'Server Terminated'),
(85, '2023-11-05 20:03:17', 'Server Started'),
(86, '2023-11-05 20:51:28', 'Server Terminated'),
(87, '2023-11-05 20:53:48', 'Server Started'),
(88, '2023-11-05 20:57:38', 'Server Terminated'),
(89, '2023-11-05 21:26:16', 'Server Started'),
(90, '2023-11-05 21:39:46', 'Server Terminated'),
(91, '2023-11-05 22:07:24', 'Server Started'),
(92, '2023-11-06 00:45:08', 'Server Terminated');

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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `payslip`
--

INSERT INTO `payslip` (`payslipID`, `startDate`, `endDate`) VALUES
(7, '2023-10-29', '2023-11-04'),
(9, '2023-11-05', '2023-11-12');

-- --------------------------------------------------------

--
-- Table structure for table `payslipdetail`
--

DROP TABLE IF EXISTS `payslipdetail`;
CREATE TABLE IF NOT EXISTS `payslipdetail` (
  `payslipDetailID` double NOT NULL AUTO_INCREMENT,
  `payslipID` int NOT NULL,
  `userID` int NOT NULL,
  `totalHours` decimal(10,6) DEFAULT NULL,
  `subtotal` decimal(10,2) NOT NULL,
  `allowance` decimal(10,2) NOT NULL,
  `SSSDeduction` decimal(10,2) NOT NULL DEFAULT '0.00',
  `deduction` decimal(10,2) NOT NULL,
  `totalSalary` double(10,2) NOT NULL,
  PRIMARY KEY (`payslipDetailID`),
  UNIQUE KEY `payslipID_Unique` (`payslipDetailID`) USING BTREE,
  UNIQUE KEY `unique_user_payslip` (`userID`,`payslipID`),
  KEY `payslipID_Index` (`payslipDetailID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=1052 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `payslipdetail`
--

INSERT INTO `payslipdetail` (`payslipDetailID`, `payslipID`, `userID`, `totalHours`, `subtotal`, `allowance`, `SSSDeduction`, `deduction`, `totalSalary`) VALUES
(601, 7, 1, '22.630556', '282.88', '500.00', '28.29', '378.29', 404.59),
(602, 7, 2, '16.593334', '207.42', '500.00', '20.74', '370.74', 336.68),
(603, 7, 3, '16.560833', '0.00', '0.00', '0.00', '0.00', 0.00),
(604, 7, 5, '0.000000', '0.00', '0.00', '0.00', '0.00', 0.00),
(605, 7, 7, '16.443889', '205.55', '0.00', '0.00', '0.00', 0.00),
(726, 7, 28, '0.001389', '0.35', '0.00', '0.00', '0.00', 0.00),
(751, 9, 1, '7.509167', '93.86', '500.00', '9.39', '359.39', 234.47),
(752, 9, 2, '9.589444', '119.87', '500.00', '11.99', '361.99', 257.88),
(753, 9, 3, '9.588333', '0.00', '0.00', '0.00', '350.00', 0.00),
(754, 9, 5, '0.000000', '0.00', '1500.00', '0.00', '350.00', 0.00),
(755, 9, 7, '9.588056', '119.85', '500.00', '11.99', '361.99', 257.86),
(756, 9, 28, '9.588889', '2397.22', '10000.00', '239.72', '589.72', 10000.00),
(811, 9, 29, '0.000000', '0.00', '2500.00', '0.00', '350.00', 0.00),
(955, 9, 27, '0.000000', '0.00', '0.00', '0.00', '350.00', 0.00);

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
    VALUES (NEW.payslipID, NEW.userID, NULL, 0, NULL, 0, 0, DATE_ADD(@startDate, INTERVAL i DAY));
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
('PS Server', 0, '2023-11-06 00:45:08');

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
  `salary` decimal(10,2) DEFAULT '500.00',
  `allowance` decimal(10,2) DEFAULT NULL,
  `SSS` varchar(50) DEFAULT NULL,
  `PagIbig` varchar(50) DEFAULT NULL,
  `PhilHealth` varchar(50) DEFAULT NULL,
  `stationNo` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`staffID`),
  UNIQUE KEY `employeeID_Unique` (`staffID`) USING BTREE,
  KEY `employeeID_Index` (`staffID`) USING BTREE,
  KEY `firstName_Index` (`firstName`) USING BTREE,
  KEY `lastName_Index` (`lastName`) USING BTREE,
  KEY `firstName` (`firstName`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `staff`
--

INSERT INTO `staff` (`staffID`, `firstName`, `lastName`, `sex`, `DOB`, `position`, `salary`, `allowance`, `SSS`, `PagIbig`, `PhilHealth`, `stationNo`) VALUES
(1, 'John Rey', 'Silverio', 'Male', '2001-04-17 00:00:00', 'Employee', '500.00', '0.00', '124151235412', '1251234125123', '15125123512', 'S002'),
(2, 'laurence', 'silverio', 'Male', '2023-08-22 00:00:00', 'Employee', '500.00', '0.00', NULL, NULL, NULL, 'S002'),
(3, 'username', 'password', 'Female', '2023-10-26 16:23:27', 'Employee', '0.00', '0.00', NULL, NULL, NULL, ''),
(5, 'Edit', 'Test', 'Male', '2023-09-28 00:00:00', 'New Manager', '1500.00', '500.00', NULL, NULL, NULL, ''),
(7, 'john matheo', 'morillo', 'Male', '2023-09-28 00:00:00', 'Employee', '500.00', '0.00', NULL, NULL, NULL, 'S002'),
(27, 'Kontra', 'Dengue', 'Male', '2023-04-04 14:03:45', 'Dengue', '0.00', '0.00', NULL, NULL, NULL, 'S003'),
(28, 'jesus', 'crist', 'Male', '1753-12-25 22:35:14', 'Messiah', '10000.00', '10000.00', NULL, NULL, NULL, 'Jerusalem'),
(29, 'PhilHealth', 'PagIbig', 'Male', '2023-11-05 15:25:23', 'Insurance', '2500.00', '2500.00', NULL, NULL, NULL, 'SSS');

-- --------------------------------------------------------

--
-- Table structure for table `staffinsurance`
--

DROP TABLE IF EXISTS `staffinsurance`;
CREATE TABLE IF NOT EXISTS `staffinsurance` (
  `userID` int NOT NULL AUTO_INCREMENT,
  `SSS` decimal(10,2) NOT NULL,
  `PagIbig` decimal(10,2) NOT NULL,
  `PhilHealth` decimal(10,2) NOT NULL,
  PRIMARY KEY (`userID`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `staffinsurance`
--

INSERT INTO `staffinsurance` (`userID`, `SSS`, `PagIbig`, `PhilHealth`) VALUES
(1, '10.00', '250.00', '100.00'),
(2, '10.00', '250.00', '100.00'),
(3, '10.00', '250.00', '100.00'),
(5, '10.00', '250.00', '100.00'),
(7, '10.00', '250.00', '100.00'),
(27, '10.00', '250.00', '100.00'),
(28, '10.00', '250.00', '100.00'),
(29, '10.00', '250.00', '100.00');

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
