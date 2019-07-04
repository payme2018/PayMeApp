CREATE TABLE [dbo].[ExpenseDetailDocument] (
    [ID]              INT             IDENTITY (1, 1) NOT NULL,
    [ExpenseDetailID] INT             NOT NULL,
    [Name]            VARCHAR (250)   NOT NULL,
    [ContentType]     NVARCHAR (200)  NOT NULL,
    [Data]            VARBINARY (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

