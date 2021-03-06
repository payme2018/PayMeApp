﻿CREATE TABLE [dbo].[Employee] (
    [ID]                     INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]              VARCHAR (50)  NULL,
    [LastName]               VARCHAR (50)  NULL,
    [JoiningDate]            DATETIME      NULL,
    [DOB]                    DATETIME      NULL,
    [fkEmploymentLocationID] INT           NULL,
    [Designation]            VARCHAR (50)  NULL,
    [WorkingHoursPerDay]     INT           NOT NULL,
    [EmployeeCode]           VARCHAR (50)  NOT NULL,
    [InternalCode]           VARCHAR (50)  NULL,
    [fkDepartmentID]         INT           NULL,
    [fkManagerId]            VARCHAR (50)  NULL,
    [fkContactID]            INT           NULL,
    [IsActive]               BIT           CONSTRAINT [DF_Employee_IsActive] DEFAULT ((1)) NOT NULL,
    [InactiveDate]           DATETIME      NULL,
    [LastWorkingDate]        DATETIME      NULL,
    [Createdate]             DATETIME      NOT NULL,
    [UpdatedDate]            DATETIME      NOT NULL,
    [Gender]                 TINYINT       NULL,
    [EmailID]                VARCHAR (256) NULL,
    [CreatedBy]              VARCHAR (200) NULL,
    [PassportNo]             VARCHAR (250) NULL,
    [PassportIssuedBy]       VARCHAR (250) NULL,
    [PassportIssuedOn]       DATETIME      NULL,
    [PassportExpireOn]       DATETIME      NULL,
    [VISANo]                 VARCHAR (250) NULL,
    [VISAIssuedBy]           VARCHAR (250) NULL,
    [VISAIssuedOn]           DATETIME      NULL,
    [VISAExpireOn]           DATETIME      NULL,
    [LabourCardNo]           VARCHAR (250) NULL,
    [LabourCardIssuedBy]     VARCHAR (250) NULL,
    [LabourCardIssuedOn]     DATETIME      NULL,
    [LabourCardExpireOn]     DATETIME      NULL,
    [AccountID]              INT           NULL,
    [MobileNo]               VARCHAR (20)  NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Employee_Contact] FOREIGN KEY ([fkContactID]) REFERENCES [dbo].[Contact] ([Id]),
    CONSTRAINT [FK_Employee_Department] FOREIGN KEY ([fkDepartmentID]) REFERENCES [dbo].[Department] ([DeptId]),
    CONSTRAINT [FK_Employee_Location] FOREIGN KEY ([fkEmploymentLocationID]) REFERENCES [dbo].[Location] ([ID])
);

