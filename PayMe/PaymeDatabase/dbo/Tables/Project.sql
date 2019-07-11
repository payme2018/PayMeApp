CREATE TABLE [dbo].[Project] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [fkClientId]     INT           NOT NULL,
    [ProjectName]    VARCHAR (200) NOT NULL,
    [PrimaryContact] VARCHAR (200) NULL,
    [LocationInfo]   VARCHAR (500) NULL,
    [Description]    VARCHAR (500) NULL,
    [IsActive]       BIT           CONSTRAINT [DF_Project_IsActive] DEFAULT ((1)) NULL,
    [AccountID]      INT           NULL,
    [ManagerID]      INT           NULL,
    CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Project_Account] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Account] ([ID]),
    CONSTRAINT [FK_Project_Client] FOREIGN KEY ([fkClientId]) REFERENCES [dbo].[Client] ([ID])
);



