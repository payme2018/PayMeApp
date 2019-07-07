CREATE TABLE [dbo].[ExpenseCategory] (
    [ID]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (500) NULL,
    [Status] VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

