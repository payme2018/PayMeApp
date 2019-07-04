CREATE TYPE [dbo].[ExpenseDetailType] AS TABLE (
    [ExpenseSummaryID] INT             NOT NULL,
    [Category]         NVARCHAR (400)  NOT NULL,
    [BillNo]           NVARCHAR (400)  NOT NULL,
    [Amount]           DECIMAL (18, 2) NOT NULL,
    [BillDate]         DATETIME        NULL,
    [Location]         NVARCHAR (250)  NULL,
    [Notes]            NVARCHAR (250)  NULL);

