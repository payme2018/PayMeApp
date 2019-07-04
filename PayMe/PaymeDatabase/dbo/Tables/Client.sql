CREATE TABLE [dbo].[Client] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [ClientCode]     VARCHAR (100) NULL,
    [ClientName]     VARCHAR (200) NOT NULL,
    [PrimaryContact] VARCHAR (200) NULL,
    [LocationInfo]   VARCHAR (500) NULL,
    [Description]    VARCHAR (500) NULL,
    [IsActive]       BIT           CONSTRAINT [DF_Client_IsActive] DEFAULT ((1)) NOT NULL,
    [AccountID]      INT           NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Client_Account] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Account] ([ID])
);

