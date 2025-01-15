-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 20, 2024 at 12:24 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12


USE fitnesslybackup;
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `fitnesslybackup`
--

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(191) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(450) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(191) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(191) NOT NULL,
  `ProviderKey` varchar(191) NOT NULL,
  `ProviderDisplayName` text DEFAULT NULL,
  `UserId` varchar(191) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(191) NOT NULL,
  `RoleId` varchar(191) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(450) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` text DEFAULT NULL,
  `SecurityStamp` text DEFAULT NULL,
  `ConcurrencyStamp` text DEFAULT NULL,
  `PhoneNumber` text DEFAULT NULL,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('014f3f8a-2bba-4504-b513-40a1dfef8403', 'Tim', 'TIM', 'verbakel.t@gmail.com', 'VERBAKEL.T@GMAIL.COM', b'0', 'AQAAAAIAAYagAAAAEGlqCGAq/SN3cmn70MnxVrK91g3Xhcld0LkEZlzUADOvLy2tt/dHxbwKTD/zA+NgzA==', 'JUQI5UL7P6UJRTPNSQBRZCWJPUPUM536', '8df34dbe-056f-4d2e-8ecf-195b7b476119', NULL, b'0', b'0', NULL, b'1', 0),
('181ff823-7ccc-410c-86bf-b9f50cbf3992', 'Gebruiker', 'GEBRUIKER', 'gebruiker@gmail.com', 'GEBRUIKER@GMAIL.COM', b'0', 'AQAAAAIAAYagAAAAEDSe3GHoKyoFdCzS3YzHV+9BQlhDJ6Ie8d4qk+Sc0Cq02QZSYsoBclvTj5v7xvfQRw==', 'ENTWJGTNF5Q25UZFXHJXEZ6URGUQBGW6', '76a385b9-c58d-4b74-9188-cc8590a98a1b', NULL, b'0', b'0', NULL, b'1', 0),
('b0dc48c9-b984-4d96-bc8a-f0a85b43accd', 'Kevin', 'KEVIN', 'verbakel.k@gmail.com', 'VERBAKEL.K@GMAIL.COM', b'0', 'AQAAAAIAAYagAAAAEFYJCTmMNq5SUgBicdyjPHG18H2h0sYwBlKr+GWHLK7LHXIr/u1f0U5qvl9B/XCgsw==', 'M4U6VZ3FNE6QZCQAJ7XOICLJANEAE3TS', 'f460ec73-56c3-4dd2-93f5-270000830a82', NULL, b'0', b'0', NULL, b'1', 0);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(191) NOT NULL,
  `LoginProvider` varchar(191) NOT NULL,
  `Name` varchar(191) NOT NULL,
  `Value` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `exercise`
--

CREATE TABLE `exercise` (
  `exercise_id` int(11) NOT NULL,
  `exercise_name` varchar(50) NOT NULL,
  `exercise_gewicht` double NOT NULL,
  `exercise_sets` int(11) NOT NULL,
  `exercise_reps` int(11) NOT NULL,
  `exercise_display` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workout`
--

CREATE TABLE `workout` (
  `workout_id` int(11) NOT NULL,
  `workout_name` varchar(50) NOT NULL,
  `UserId` varchar(255) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `workout`
--

INSERT INTO `workout` (`workout_id`, `workout_name`, `UserId`) VALUES
(1, 'Test', '014f3f8a-2bba-4504-b513-40a1dfef8403'),
(2, 'Test2', '014f3f8a-2bba-4504-b513-40a1dfef8403'),
(4, 'Test3', '014f3f8a-2bba-4504-b513-40a1dfef8403'),
(6, 'Test4', '014f3f8a-2bba-4504-b513-40a1dfef8403'),
(8, 'Kevin zijn Test', 'b0dc48c9-b984-4d96-bc8a-f0a85b43accd'),
(9, 'Test5', '014f3f8a-2bba-4504-b513-40a1dfef8403'),
(15, 'Test6', '014f3f8a-2bba-4504-b513-40a1dfef8403'),
(17, 'Test8', '181ff823-7ccc-410c-86bf-b9f50cbf3992'),
(18, 'Test1', '181ff823-7ccc-410c-86bf-b9f50cbf3992'),
(19, 'Test4', '181ff823-7ccc-410c-86bf-b9f50cbf3992');

-- --------------------------------------------------------

--
-- Table structure for table `workoutexercise`
--

CREATE TABLE `workoutexercise` (
  `id` int(11) NOT NULL,
  `workout_id` int(11) NOT NULL,
  `exercise_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workoutsessie`
--

CREATE TABLE `workoutsessie` (
  `workoutsessie_id` int(11) NOT NULL,
  `workoutsessie_name` varchar(50) NOT NULL,
  `workoutsessie_tijd` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workoutsessieexercise`
--

CREATE TABLE `workoutsessieexercise` (
  `workoutsessieexercise_id` int(11) NOT NULL,
  `workoutsessieexercise_name` varchar(50) NOT NULL,
  `workoutsessieexercise_sets` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workoutsessieexerciseworkoutsessiestats`
--

CREATE TABLE `workoutsessieexerciseworkoutsessiestats` (
  `id` int(11) NOT NULL,
  `workoutsessieexercise_id` int(11) NOT NULL,
  `workoutsessiestats_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workoutsessiestats`
--

CREATE TABLE `workoutsessiestats` (
  `workoutsessiestats_id` int(11) NOT NULL,
  `workoutsessiestats_gewicht` double NOT NULL,
  `workoutsessiestats_reps` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workoutsessieworkoutsessieexercise`
--

CREATE TABLE `workoutsessieworkoutsessieexercise` (
  `id` int(11) NOT NULL,
  `workoutsessie_id` int(11) NOT NULL,
  `workoutsessieexercise_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20241202133140_AddIdentityTables', '8.0.11');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FK_AspNetRoleClaims_AspNetRoles_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FK_AspNetUserClaims_AspNetUsers_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `FK_AspNetUserLogins_AspNetUsers_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `FK_AspNetUserRoles_AspNetRoles_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `exercise`
--
ALTER TABLE `exercise`
  ADD PRIMARY KEY (`exercise_id`);

--
-- Indexes for table `workout`
--
ALTER TABLE `workout`
  ADD PRIMARY KEY (`workout_id`);

--
-- Indexes for table `workoutexercise`
--
ALTER TABLE `workoutexercise`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_exercise_id` (`exercise_id`),
  ADD KEY `fk_workout_id` (`workout_id`);

--
-- Indexes for table `workoutsessie`
--
ALTER TABLE `workoutsessie`
  ADD PRIMARY KEY (`workoutsessie_id`);

--
-- Indexes for table `workoutsessieexercise`
--
ALTER TABLE `workoutsessieexercise`
  ADD PRIMARY KEY (`workoutsessieexercise_id`);

--
-- Indexes for table `workoutsessieexerciseworkoutsessiestats`
--
ALTER TABLE `workoutsessieexerciseworkoutsessiestats`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_workoutsessieexercise_id` (`workoutsessieexercise_id`),
  ADD KEY `fk_workoutsessiestats_id` (`workoutsessiestats_id`);

--
-- Indexes for table `workoutsessiestats`
--
ALTER TABLE `workoutsessiestats`
  ADD PRIMARY KEY (`workoutsessiestats_id`);

--
-- Indexes for table `workoutsessieworkoutsessieexercise`
--
ALTER TABLE `workoutsessieworkoutsessieexercise`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_workoutsessie_id` (`workoutsessie_id`),
  ADD KEY `fk2_workoutsessieexercise_id` (`workoutsessieexercise_id`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `exercise`
--
ALTER TABLE `exercise`
  MODIFY `exercise_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `workout`
--
ALTER TABLE `workout`
  MODIFY `workout_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `workoutexercise`
--
ALTER TABLE `workoutexercise`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `workoutsessie`
--
ALTER TABLE `workoutsessie`
  MODIFY `workoutsessie_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `workoutsessieexercise`
--
ALTER TABLE `workoutsessieexercise`
  MODIFY `workoutsessieexercise_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `workoutsessieexerciseworkoutsessiestats`
--
ALTER TABLE `workoutsessieexerciseworkoutsessiestats`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `workoutsessiestats`
--
ALTER TABLE `workoutsessiestats`
  MODIFY `workoutsessiestats_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `workoutsessieworkoutsessieexercise`
--
ALTER TABLE `workoutsessieworkoutsessieexercise`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `workoutexercise`
--
ALTER TABLE `workoutexercise`
  ADD CONSTRAINT `fk_exercise_id` FOREIGN KEY (`exercise_id`) REFERENCES `exercise` (`exercise_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_workout_id` FOREIGN KEY (`workout_id`) REFERENCES `workout` (`workout_id`) ON DELETE CASCADE;

--
-- Constraints for table `workoutsessieexerciseworkoutsessiestats`
--
ALTER TABLE `workoutsessieexerciseworkoutsessiestats`
  ADD CONSTRAINT `fk_workoutsessieexercise_id` FOREIGN KEY (`workoutsessieexercise_id`) REFERENCES `workoutsessieexercise` (`workoutsessieexercise_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_workoutsessiestats_id` FOREIGN KEY (`workoutsessiestats_id`) REFERENCES `workoutsessiestats` (`workoutsessiestats_id`) ON DELETE CASCADE;

--
-- Constraints for table `workoutsessieworkoutsessieexercise`
--
ALTER TABLE `workoutsessieworkoutsessieexercise`
  ADD CONSTRAINT `fk2_workoutsessieexercise_id` FOREIGN KEY (`workoutsessieexercise_id`) REFERENCES `workoutsessieexercise` (`workoutsessieexercise_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_workoutsessie_id` FOREIGN KEY (`workoutsessie_id`) REFERENCES `workoutsessie` (`workoutsessie_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
