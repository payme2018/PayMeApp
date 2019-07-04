CREATE TABLE [dbo].[ExpenseSummary] (
    [ID]              INT             IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (250)   NULL,
    [ExpenseStatusID] INT             NOT NULL,
    [TotalAmount]     DECIMAL (18, 2) NULL,
    [ApprovedAmount]  DECIMAL (18, 2) NULL,
    [EmpID]           INT             NULL,
    [ProjectID]       INT             NULL,
    [FromDate]        DATETIME        NULL,
    [ToDate]          DATETIME        NULL,
    [Description]     VARCHAR (MAX)   NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ExpenseSummary_ExpenseStatus] FOREIGN KEY ([ExpenseStatusID]) REFERENCES [dbo].[ExpenseStatus] ([ID]),
    CONSTRAINT [FK_ExpenseSummary_Project] FOREIGN KEY ([ProjectID]) REFERENCES [dbo].[Project] ([ID])
);

