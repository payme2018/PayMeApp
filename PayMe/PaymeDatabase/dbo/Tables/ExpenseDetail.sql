CREATE TABLE [dbo].[ExpenseDetail] (
    [ID]               INT             IDENTITY (1, 1) NOT NULL,
    [CategoryID]       INT             NOT NULL,
    [ExpenseSummaryID] INT             NOT NULL,
    [CurrencyBillNo]   VARCHAR (250)   NULL,
    [Amount]           DECIMAL (18, 2) NULL,
    [BillDate]         DATETIME        NULL,
    [Location]         VARCHAR (250)   NULL,
    [HasAttachment]    BIT             NULL,
    [Notes]            VARCHAR (MAX)   NULL,
    [GrossTotal]       DECIMAL (10, 2) NULL,
    [TaxAmount]        DECIMAL (10, 2) NULL,
    [VatNumber]        VARCHAR (100)   NULL,
    [PaidTo]           VARCHAR (500)   NULL,
    [HasBill]          BIT             DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ExpenseDetail_ExpenseCategory] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[ExpenseCategory] ([ID]),
    CONSTRAINT [FK_ExpenseDetail_ExpenseSummary] FOREIGN KEY ([ExpenseSummaryID]) REFERENCES [dbo].[ExpenseSummary] ([ID])
);

