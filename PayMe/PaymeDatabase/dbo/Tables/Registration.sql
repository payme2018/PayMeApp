﻿CREATE TABLE [dbo].[Registration] (
    [RegistrationID]         INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]              NVARCHAR (MAX) NOT NULL,
    [LastName]               NVARCHAR (MAX) NOT NULL,
    [MobileNo]               NVARCHAR (MAX) NOT NULL,
    [EmailID]                NVARCHAR (MAX) NOT NULL,
    [Username]               NVARCHAR (MAX) NOT NULL,
    [Password]               NVARCHAR (MAX) NOT NULL,
    [ConfirmPassword]        NVARCHAR (MAX) NULL,
    [Gender]                 INT            NOT NULL,
    [Birthdate]              DATETIME       NULL,
    [DateofJoining]          DATETIME       NULL,
    [RoleID]                 INT            NULL,
    [EmployeeID]             INT            NOT NULL,
    [EmployeeCode]           NVARCHAR (MAX) NULL,
    [CreatedOn]              DATETIME       NULL,
    [ForceChangePassword]    INT            NULL,
    [fkEmploymentLocationID] INT            NULL,
    [fkDepartmentID]         INT            NULL,
    [fkManagerId]            INT            NULL,
    [fkContactID]            INT            NULL,
    [Designation]            NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Registration] PRIMARY KEY CLUSTERED ([RegistrationID] ASC)
);

