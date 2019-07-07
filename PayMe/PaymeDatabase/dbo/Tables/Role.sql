CREATE TABLE [dbo].[Role] (
    [ID]       INT           IDENTITY (1, 1) NOT NULL,
    [RoleName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([ID] ASC)
);

