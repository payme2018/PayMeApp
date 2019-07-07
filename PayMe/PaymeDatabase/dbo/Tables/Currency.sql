CREATE TABLE [dbo].[Currency] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [ISO]  CHAR (3)      CONSTRAINT [DF__Currency__ISO__534D60F1] DEFAULT ('') NOT NULL,
    [Name] VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED ([Id] ASC)
);

