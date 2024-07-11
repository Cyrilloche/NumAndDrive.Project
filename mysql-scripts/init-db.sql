CREATE DATABASE IF NOT EXISTS numanddrive;

USE numanddrive;

CREATE TABLE
    IF NOT EXISTS `__EFMigrationsHistory` (
        `MigrationId` varchar(150) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `ProductVersion` varchar(32) CHARACTER
        SET
            utf8mb4 NOT NULL,
            CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
    ) CHARACTER
SET
    = utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER
SET
    utf8mb4;

CREATE TABLE
    `activationday` (
        `ActivationDayId` int NOT NULL AUTO_INCREMENT,
        `Day` longtext CHARACTER
        SET
            utf8mb4 NOT NULL,
            `IsSelected` tinyint (1) NOT NULL,
            CONSTRAINT `PK_activationday` PRIMARY KEY (`ActivationDayId`)
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `address` (
        `AddressId` int NOT NULL AUTO_INCREMENT,
        `Street` varchar(50) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `City` varchar(50) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `PostalCode` varchar(25) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `Coordinates` longtext CHARACTER
        SET
            utf8mb4 NOT NULL,
            CONSTRAINT `PK_address` PRIMARY KEY (`AddressId`)
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `drivertype` (
        `DriverTypeId` int NOT NULL AUTO_INCREMENT,
        `Name` varchar(50) CHARACTER
        SET
            utf8mb4 NOT NULL,
            CONSTRAINT `PK_drivertype` PRIMARY KEY (`DriverTypeId`)
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `filter` (
        `FilterId` int NOT NULL AUTO_INCREMENT,
        `Name` varchar(50) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `IsSelected` tinyint (1) NOT NULL,
            CONSTRAINT `PK_filter` PRIMARY KEY (`FilterId`)
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `fuel` (
        `FuelId` int NOT NULL AUTO_INCREMENT,
        `Name` varchar(25) CHARACTER
        SET
            utf8mb4 NOT NULL,
            CONSTRAINT `PK_fuel` PRIMARY KEY (`FuelId`)
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `notification` (
        `NotificationId` int NOT NULL AUTO_INCREMENT,
        `Name` varchar(50) CHARACTER
        SET
            utf8mb4 NOT NULL,
            CONSTRAINT `PK_notification` PRIMARY KEY (`NotificationId`)
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `reward` (
        `RewardId` int NOT NULL AUTO_INCREMENT,
        `Name` longtext CHARACTER
        SET
            utf8mb4 NOT NULL,
            `IllustrationPath` longtext CHARACTER
        SET
            utf8mb4 NOT NULL,
            CONSTRAINT `PK_reward` PRIMARY KEY (`RewardId`)
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `Role` (
        `Id` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `Name` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NULL,
            `NormalizedName` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NULL,
            `ConcurrencyStamp` longtext CHARACTER
        SET
            utf8mb4 NULL,
            CONSTRAINT `PK_Role` PRIMARY KEY (`Id`)
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `status` (
        `StatusId` int NOT NULL AUTO_INCREMENT,
        `Name` varchar(50) CHARACTER
        SET
            utf8mb4 NOT NULL,
            CONSTRAINT `PK_status` PRIMARY KEY (`StatusId`)
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `travelpreference` (
        `TravelPreferenceId` int NOT NULL AUTO_INCREMENT,
        `Name` varchar(50) CHARACTER
        SET
            utf8mb4 NOT NULL,
            CONSTRAINT `PK_travelpreference` PRIMARY KEY (`TravelPreferenceId`)
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `school` (
        `SchoolId` int NOT NULL AUTO_INCREMENT,
        `Name` varchar(50) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `AddressId` int NOT NULL,
            CONSTRAINT `PK_school` PRIMARY KEY (`SchoolId`),
            CONSTRAINT `FK_school_address_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `address` (`AddressId`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `RoleClaim` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `RoleId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `ClaimType` longtext CHARACTER
        SET
            utf8mb4 NULL,
            `ClaimValue` longtext CHARACTER
        SET
            utf8mb4 NULL,
            CONSTRAINT `PK_RoleClaim` PRIMARY KEY (`Id`),
            CONSTRAINT `FK_RoleClaim_Role_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `Role` (`Id`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `classroom` (
        `ClassroomId` int NOT NULL AUTO_INCREMENT,
        `Name` varchar(50) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `SchoolId` int NULL,
            CONSTRAINT `PK_classroom` PRIMARY KEY (`ClassroomId`),
            CONSTRAINT `FK_classroom_school_SchoolId` FOREIGN KEY (`SchoolId`) REFERENCES `school` (`SchoolId`)
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `User` (
        `Id` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `Lastname` varchar(50) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `Firstname` varchar(30) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `FirstConnection` tinyint (1) NOT NULL,
            `CountCreatedTravel` tinyint NOT NULL,
            `CurrentStatusId` int NULL,
            `CurrentDriverTypeId` int NULL,
            `CurrentClassroomId` int NULL,
            `UserName` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NULL,
            `NormalizedUserName` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NULL,
            `Email` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NULL,
            `NormalizedEmail` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NULL,
            `EmailConfirmed` tinyint (1) NOT NULL,
            `PasswordHash` longtext CHARACTER
        SET
            utf8mb4 NULL,
            `SecurityStamp` longtext CHARACTER
        SET
            utf8mb4 NULL,
            `ConcurrencyStamp` longtext CHARACTER
        SET
            utf8mb4 NULL,
            `PhoneNumber` longtext CHARACTER
        SET
            utf8mb4 NULL,
            `PhoneNumberConfirmed` tinyint (1) NOT NULL,
            `TwoFactorEnabled` tinyint (1) NOT NULL,
            `LockoutEnd` datetime (6) NULL,
            `LockoutEnabled` tinyint (1) NOT NULL,
            `AccessFailedCount` int NOT NULL,
            CONSTRAINT `PK_User` PRIMARY KEY (`Id`),
            CONSTRAINT `FK_User_classroom_CurrentClassroomId` FOREIGN KEY (`CurrentClassroomId`) REFERENCES `classroom` (`ClassroomId`),
            CONSTRAINT `FK_User_drivertype_CurrentDriverTypeId` FOREIGN KEY (`CurrentDriverTypeId`) REFERENCES `drivertype` (`DriverTypeId`),
            CONSTRAINT `FK_User_status_CurrentStatusId` FOREIGN KEY (`CurrentStatusId`) REFERENCES `status` (`StatusId`)
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `car` (
        `CarId` int NOT NULL,
        `Brand` varchar(25) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `Model` varchar(25) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `PaintColor` varchar(25) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `Registration` varchar(25) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `PicturePath` varchar(255) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `UserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `FuelId` int NOT NULL,
            CONSTRAINT `PK_car` PRIMARY KEY (`CarId`),
            CONSTRAINT `FK_car_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE,
            CONSTRAINT `FK_car_fuel_CarId` FOREIGN KEY (`CarId`) REFERENCES `fuel` (`FuelId`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `message` (
        `MessageId` int NOT NULL AUTO_INCREMENT,
        `MessageContent` text CHARACTER
        SET
            utf8mb4 NOT NULL,
            `SendingDate` datetime NOT NULL,
            `ReceiptDate` datetime NOT NULL,
            `SenderUserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `ReceiverUserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            CONSTRAINT `PK_message` PRIMARY KEY (`MessageId`),
            CONSTRAINT `FK_message_User_ReceiverUserId` FOREIGN KEY (`ReceiverUserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE,
            CONSTRAINT `FK_message_User_SenderUserId` FOREIGN KEY (`SenderUserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `travel` (
        `TravelId` int NOT NULL AUTO_INCREMENT,
        `DepartureTime` time NOT NULL,
        `ArrivalTime` time(6) NOT NULL,
        `AvailablePlace` tinyint NOT NULL,
        `CreationDate` datetime NOT NULL,
        `PublisherUserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `DepartureAddressId` int NOT NULL,
            `ArrivalAddressId` int NOT NULL,
            `IsAReturnTravel` tinyint (1) NOT NULL,
            CONSTRAINT `PK_travel` PRIMARY KEY (`TravelId`),
            CONSTRAINT `FK_travel_User_PublisherUserId` FOREIGN KEY (`PublisherUserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE,
            CONSTRAINT `FK_travel_address_ArrivalAddressId` FOREIGN KEY (`ArrivalAddressId`) REFERENCES `address` (`AddressId`) ON DELETE CASCADE,
            CONSTRAINT `FK_travel_address_DepartureAddressId` FOREIGN KEY (`DepartureAddressId`) REFERENCES `address` (`AddressId`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `user_notification` (
        `UserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `NotificationId` int NOT NULL,
            CONSTRAINT `PK_user_notification` PRIMARY KEY (`UserId`, `NotificationId`),
            CONSTRAINT `FK_user_notification_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE,
            CONSTRAINT `FK_user_notification_notification_NotificationId` FOREIGN KEY (`NotificationId`) REFERENCES `notification` (`NotificationId`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `user_reward` (
        `UserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `RewardId` int NOT NULL,
            `WinOn` date NOT NULL,
            CONSTRAINT `PK_user_reward` PRIMARY KEY (`UserId`, `RewardId`),
            CONSTRAINT `FK_user_reward_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE,
            CONSTRAINT `FK_user_reward_reward_RewardId` FOREIGN KEY (`RewardId`) REFERENCES `reward` (`RewardId`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `user_travelpreference` (
        `UserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `TravelPreferenceId` int NOT NULL,
            CONSTRAINT `PK_user_travelpreference` PRIMARY KEY (`UserId`, `TravelPreferenceId`),
            CONSTRAINT `FK_user_travelpreference_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE,
            CONSTRAINT `FK_user_travelpreference_travelpreference_TravelPreferenceId` FOREIGN KEY (`TravelPreferenceId`) REFERENCES `travelpreference` (`TravelPreferenceId`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `UserClaim` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `UserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `ClaimType` longtext CHARACTER
        SET
            utf8mb4 NULL,
            `ClaimValue` longtext CHARACTER
        SET
            utf8mb4 NULL,
            CONSTRAINT `PK_UserClaim` PRIMARY KEY (`Id`),
            CONSTRAINT `FK_UserClaim_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `UserLogin` (
        `LoginProvider` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `ProviderKey` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `ProviderDisplayName` longtext CHARACTER
        SET
            utf8mb4 NULL,
            `UserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            CONSTRAINT `PK_UserLogin` PRIMARY KEY (`LoginProvider`, `ProviderKey`),
            CONSTRAINT `FK_UserLogin_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `userreview` (
        `UserReviewId` int NOT NULL AUTO_INCREMENT,
        `Rating` tinyint NOT NULL,
        `Comment` text CHARACTER
        SET
            utf8mb4 NULL,
            `ReviewedUserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `ReviewerUserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            CONSTRAINT `PK_userreview` PRIMARY KEY (`UserReviewId`),
            CONSTRAINT `FK_userreview_User_ReviewedUserId` FOREIGN KEY (`ReviewedUserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE,
            CONSTRAINT `FK_userreview_User_ReviewerUserId` FOREIGN KEY (`ReviewerUserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `UserRole` (
        `UserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `RoleId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            CONSTRAINT `PK_UserRole` PRIMARY KEY (`UserId`, `RoleId`),
            CONSTRAINT `FK_UserRole_Role_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `Role` (`Id`) ON DELETE CASCADE,
            CONSTRAINT `FK_UserRole_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `UserToken` (
        `UserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `LoginProvider` VARCHAR(50) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `Name` VARCHAR(50) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `Value` longtext CHARACTER
        SET
            utf8mb4 NULL,
            CONSTRAINT `PK_UserToken` PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
            CONSTRAINT `FK_UserToken_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `reservation` (
        `TravelId` int NOT NULL,
        `PassengerUserId` VARCHAR(100) CHARACTER
        SET
            utf8mb4 NOT NULL,
            `ReservationDate` datetime NOT NULL,
            `ResponseDate` datetime NOT NULL,
            `Acceptation` tinyint (1) NOT NULL,
            `AwaitingResponse` tinyint (1) NOT NULL,
            CONSTRAINT `PK_reservation` PRIMARY KEY (`PassengerUserId`, `TravelId`),
            CONSTRAINT `FK_reservation_User_PassengerUserId` FOREIGN KEY (`PassengerUserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE,
            CONSTRAINT `FK_reservation_travel_TravelId` FOREIGN KEY (`TravelId`) REFERENCES `travel` (`TravelId`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `travel_activationday` (
        `ActivationDayId` int NOT NULL,
        `TravelId` int NOT NULL,
        CONSTRAINT `PK_travel_activationday` PRIMARY KEY (`TravelId`, `ActivationDayId`),
        CONSTRAINT `FK_travel_activationday_activationday_ActivationDayId` FOREIGN KEY (`ActivationDayId`) REFERENCES `activationday` (`ActivationDayId`) ON DELETE CASCADE,
        CONSTRAINT `FK_travel_activationday_travel_TravelId` FOREIGN KEY (`TravelId`) REFERENCES `travel` (`TravelId`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `travel_filter` (
        `TravelId` int NOT NULL,
        `FilterId` int NOT NULL,
        CONSTRAINT `PK_travel_filter` PRIMARY KEY (`TravelId`, `FilterId`),
        CONSTRAINT `FK_travel_filter_filter_FilterId` FOREIGN KEY (`FilterId`) REFERENCES `filter` (`FilterId`) ON DELETE CASCADE,
        CONSTRAINT `FK_travel_filter_travel_TravelId` FOREIGN KEY (`TravelId`) REFERENCES `travel` (`TravelId`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

CREATE TABLE
    `travel_stop` (
        `CurrentTravelId` int NOT NULL,
        `CurrentAddressId` int NOT NULL,
        CONSTRAINT `PK_travel_stop` PRIMARY KEY (`CurrentTravelId`, `CurrentAddressId`),
        CONSTRAINT `FK_travel_stop_address_CurrentAddressId` FOREIGN KEY (`CurrentAddressId`) REFERENCES `address` (`AddressId`) ON DELETE CASCADE,
        CONSTRAINT `FK_travel_stop_travel_CurrentTravelId` FOREIGN KEY (`CurrentTravelId`) REFERENCES `travel` (`TravelId`) ON DELETE CASCADE
    ) CHARACTER
SET
    = utf8mb4;

INSERT INTO
    `Role` (
        `Id`,
        `ConcurrencyStamp`,
        `Name`,
        `NormalizedName`
    )
VALUES
    ('1', NULL, 'Admin', 'ADMIN'),
    ('2', NULL, 'Client', 'CLIENT');

INSERT INTO
    `User` (
        `Id`,
        `AccessFailedCount`,
        `ConcurrencyStamp`,
        `CountCreatedTravel`,
        `CurrentClassroomId`,
        `CurrentDriverTypeId`,
        `CurrentStatusId`,
        `Email`,
        `EmailConfirmed`,
        `FirstConnection`,
        `Firstname`,
        `Lastname`,
        `LockoutEnabled`,
        `LockoutEnd`,
        `NormalizedEmail`,
        `NormalizedUserName`,
        `PasswordHash`,
        `PhoneNumber`,
        `PhoneNumberConfirmed`,
        `SecurityStamp`,
        `TwoFactorEnabled`,
        `UserName`
    )
VALUES
    (
        '1',
        0,
        'd9bfc014-9a93-48c9-93e7-76f8dd27cbaa',
        0,
        NULL,
        NULL,
        NULL,
        'admin@admin-numanddrive.fr',
        TRUE,
        FALSE,
        '',
        '',
        FALSE,
        NULL,
        'ADMIN@ADMIN-NUMANDDRIVE.FR',
        'ADMIN@ADMIN-NUMANDDRIVE.FR',
        'AQAAAAIAAYagAAAAEF2bjhIzUjlAd+xiQ5nfTIVkPHjOKRAhX4l4jQNPghjg5z1wVPm1S7BZsbtEpfsaZw==',
        NULL,
        FALSE,
        '',
        FALSE,
        'admin@admin-numanddrive.fr'
    );

INSERT INTO
    `activationday` (`ActivationDayId`, `Day`, `IsSelected`)
VALUES
    (1, 'Lundi', FALSE),
    (2, 'Mardi', FALSE),
    (3, 'Mercredi', FALSE),
    (4, 'Jeudi', FALSE),
    (5, 'Vendredi', FALSE),
    (6, 'Samedi', FALSE),
    (7, 'Dimanche', FALSE);

INSERT INTO
    `drivertype` (`DriverTypeId`, `Name`)
VALUES
    (1, 'Nouveau-elle venu-e'),
    (2, 'Sébastien Loeb'),
    (3, 'Auto-tamponneur'),
    (4, 'Boîte de nuit mobile'),
    (5, 'Grand-e voyageur-euse'),
    (6, 'Grand-e bavard-e'),
    (7, 'Pas du matin'),
    (8, 'Copilote au top'),
    (9, 'Compteur-euse d''histoires'),
    (10, 'Ronfleur-euse'),
    (11, 'Mamie au volant');

INSERT INTO
    `filter` (`FilterId`, `IsSelected`, `Name`)
VALUES
    (1, FALSE, 'Non-fumeur'),
    (2, FALSE, 'Animaux acceptés');

INSERT INTO
    `fuel` (`FuelId`, `Name`)
VALUES
    (1, 'Essence'),
    (2, 'Diesel'),
    (3, 'Hybride'),
    (4, 'Électrique');

INSERT INTO
    `status` (`StatusId`, `Name`)
VALUES
    (1, 'Statut non renseigné'),
    (2, 'Intervenant-e'),
    (3, 'Administrateur-trice'),
    (4, 'Apprenant-e'),
    (5, 'Formateur-trice');

INSERT INTO
    `UserRole` (`RoleId`, `UserId`)
VALUES
    ('1', '1');

CREATE INDEX `IX_car_UserId` ON `car` (`UserId`);

CREATE INDEX `IX_classroom_SchoolId` ON `classroom` (`SchoolId`);

CREATE INDEX `IX_message_ReceiverUserId` ON `message` (`ReceiverUserId`);

CREATE INDEX `IX_message_SenderUserId` ON `message` (`SenderUserId`);

CREATE INDEX `IX_reservation_TravelId` ON `reservation` (`TravelId`);

CREATE UNIQUE INDEX `RoleNameIndex` ON `Role` (`NormalizedName`);

CREATE INDEX `IX_RoleClaim_RoleId` ON `RoleClaim` (`RoleId`);

CREATE INDEX `IX_school_AddressId` ON `school` (`AddressId`);

CREATE INDEX `IX_travel_ArrivalAddressId` ON `travel` (`ArrivalAddressId`);

CREATE INDEX `IX_travel_DepartureAddressId` ON `travel` (`DepartureAddressId`);

CREATE INDEX `IX_travel_PublisherUserId` ON `travel` (`PublisherUserId`);

CREATE INDEX `IX_travel_activationday_ActivationDayId` ON `travel_activationday` (`ActivationDayId`);

CREATE INDEX `IX_travel_filter_FilterId` ON `travel_filter` (`FilterId`);

CREATE INDEX `IX_travel_stop_CurrentAddressId` ON `travel_stop` (`CurrentAddressId`);

CREATE INDEX `EmailIndex` ON `User` (`NormalizedEmail`);

CREATE INDEX `IX_User_CurrentClassroomId` ON `User` (`CurrentClassroomId`);

CREATE INDEX `IX_User_CurrentDriverTypeId` ON `User` (`CurrentDriverTypeId`);

CREATE INDEX `IX_User_CurrentStatusId` ON `User` (`CurrentStatusId`);

CREATE UNIQUE INDEX `UserNameIndex` ON `User` (`NormalizedUserName`);

CREATE INDEX `IX_user_notification_NotificationId` ON `user_notification` (`NotificationId`);

CREATE INDEX `IX_user_reward_RewardId` ON `user_reward` (`RewardId`);

CREATE INDEX `IX_user_travelpreference_TravelPreferenceId` ON `user_travelpreference` (`TravelPreferenceId`);

CREATE INDEX `IX_UserClaim_UserId` ON `UserClaim` (`UserId`);

CREATE INDEX `IX_UserLogin_UserId` ON `UserLogin` (`UserId`);

CREATE INDEX `IX_userreview_ReviewedUserId` ON `userreview` (`ReviewedUserId`);

CREATE INDEX `IX_userreview_ReviewerUserId` ON `userreview` (`ReviewerUserId`);

CREATE INDEX `IX_UserRole_RoleId` ON `UserRole` (`RoleId`);

INSERT INTO
    `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES
    ('20240606145304_InitialMigration', '8.0.4');

COMMIT;