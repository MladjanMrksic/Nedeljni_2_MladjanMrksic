IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'MedicalInstitutionDatabase')
CREATE DATABASE MedicalInstitutionDatabase
GO

USE MedicalInstitutionDatabase
GO

IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'MedicalInstitution')
drop table MedicalInstitution
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'ClinicMaintenance')
drop table ClinicMaintenance
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'ClinicPatient')
drop table ClinicPatient
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'ClinicDoctor')
drop table ClinicDoctor
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'ClinicManager')
drop table ClinicManager
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'ClinicAdministrator')
drop table ClinicAdministrator
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'Person')
drop table Person
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'vwMaintenance')
drop view vwMaintenance
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'vwManager')
drop view vwManager
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'vwDoctor')
drop view vwDoctor
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'vwPatient')
drop view vwPatient
IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'vwAdministrator')
drop view vwAdministrator

create table Person
(
PersonID int primary key identity(1,1) not null,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
Gender nvarchar(1) Check (UPPER(Gender) = 'M' or UPPER(Gender) = 'F' or UPPER(Gender) = 'O' or UPPER(Gender) = 'X') not null,
DateOfBirth Date not null,
Residency nvarchar(50) not null,
Username nvarchar(50)  not null,
Password nvarchar(50) not null,
)

create table ClinicMaintenance
(
MaintenanaceID INT IDENTITY(1,1) PRIMARY KEY		NOT NULL,
PersonID int FOREIGN KEY REFERENCES Person(PersonID) not null,
PermitForClinicExpansion bit,
InChargeOfDisabilityAccess bit
)

create table ClinicManager
(
ManagerID INT IDENTITY(1,1) PRIMARY KEY		NOT NULL,
PersonID int FOREIGN KEY REFERENCES Person(PersonID) not null,
ClinicFloor int,
MaximumNumberOfDoctorsUnderSupervision int,
MinimumNumberOfPersonelUnderSupervision int,
NumberOfOversights int
)

create table ClinicDoctor
(
DoctorID INT IDENTITY(10000,1) PRIMARY KEY		NOT NULL,
PersonID int FOREIGN KEY REFERENCES Person(PersonID) not null,
BankAccountNumber nvarchar(50),
Department nvarchar(20),
WorkShift nvarchar(20) CHECK(UPPER(WorkShift)= 'MORNING' or UPPER(WorkShift)='AFTERNOON' or UPPER(WorkShift)='NIGHT' or UPPER(WorkShift)='24H'),
PatientReception bit,
SupervisingManager int FOREIGN KEY REFERENCES ClinicManager(ManagerID)
)

create table ClinicPatient
(
PatientID INT IDENTITY(1,1) PRIMARY KEY		NOT NULL,
PersonID int FOREIGN KEY REFERENCES Person(PersonID) not null,
HealthInsuranceCardNumber nvarchar(50),
HealthInsuranceExpiryDate Date,
ChosenDoctor int FOREIGN KEY REFERENCES ClinicDoctor(DoctorID)
)

create table MedicalInstitution
(
MedicalInstitutionID INT IDENTITY(1,1) PRIMARY KEY		NOT NULL,
ClinicName nvarchar(50),
MedicalInstitutionConstructionDate Date,
ClinicOwner nvarchar(50),
ClinicAddress nvarchar(50),
NumberOfFloors int,
NumberOfPatientsPerFloor int,
HasTerrace bit,
HasYard bit,
NumberOfAccessPointsForAmbulance int,
NumberOfDisabledAccessPoints int
)

create table ClinicAdministrator
(
AdministratorID INT IDENTITY(1,1) PRIMARY KEY		NOT NULL,
PersonID int FOREIGN KEY REFERENCES Person(PersonID) not null
)

GO
CREATE VIEW vwMaintenance AS
SELECT Person.*,ClinicMaintenance.MaintenanaceID,ClinicMaintenance.InChargeOfDisabilityAccess,ClinicMaintenance.PermitForClinicExpansion
FROM Person, ClinicMaintenance
WHERE Person.PersonID = ClinicMaintenance.PersonID

GO
CREATE VIEW vwManager AS
SELECT Person.*, ClinicManager.ManagerID,ClinicManager.ClinicFloor,ClinicManager.MaximumNumberOfDoctorsUnderSupervision, ClinicManager.MinimumNumberOfPersonelUnderSupervision,ClinicManager.NumberOfOversights
FROM Person, ClinicManager
WHERE Person.PersonID = ClinicManager.PersonID

GO
CREATE VIEW vwDoctor AS
SELECT Person.*, ClinicDoctor.DoctorID, ClinicDoctor.BankAccountNumber, ClinicDoctor.Department, ClinicDoctor.WorkShift, ClinicDoctor.PatientReception, ClinicDoctor.SupervisingManager
FROM Person, ClinicDoctor
WHERE Person.PersonID = ClinicDoctor.PersonID

GO
CREATE VIEW vwPatient AS
SELECT Person.*, ClinicPatient.PatientID, ClinicPatient.HealthInsuranceCardNumber, ClinicPatient.HealthInsuranceExpiryDate, ClinicPatient.ChosenDoctor
FROM Person, ClinicPatient
WHERE Person.PersonID = ClinicPatient.PersonID

GO
CREATE VIEW vwAdministrator AS
SELECT Person.*, ClinicAdministrator.AdministratorID
FROM Person, ClinicAdministrator
WHERE Person.PersonID = ClinicAdministrator.PersonID