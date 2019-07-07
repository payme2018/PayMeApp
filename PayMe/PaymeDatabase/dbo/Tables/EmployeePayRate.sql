CREATE TABLE [dbo].[EmployeePayRate] (
    [ID]            INT             IDENTITY (1, 1) NOT NULL,
    [EmployeeID]    INT             NULL,
    [StartDate]     DATETIME        NULL,
    [EndDate]       DATETIME        NULL,
    [PayRateTypeID] INT             NULL,
    [RegularRate]   DECIMAL (10, 2) NULL,
    [OTRate]        DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

