CREATE TABLE [dbo].[EmployeeProject] (
    [Id]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [fkEmpID]     INT             NULL,
    [fkProjectID] INT             NULL,
    [fkTaskID]    INT             NULL,
    [StartDate]   DATETIME        NULL,
    [EndDate]     DATETIME        NULL,
    [RegularRate] DECIMAL (18, 2) NULL,
    [OTRate]      DECIMAL (18, 2) NULL,
    [IsActive]    BIT             DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_EmployeeProject] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmployeeProject_Employee] FOREIGN KEY ([fkEmpID]) REFERENCES [dbo].[Employee] ([ID]),
    CONSTRAINT [FK_EmployeeProject_Project] FOREIGN KEY ([fkProjectID]) REFERENCES [dbo].[Project] ([ID]),
    CONSTRAINT [FK_EmployeeProject_Task] FOREIGN KEY ([fkTaskID]) REFERENCES [dbo].[Task] ([ID])
);

