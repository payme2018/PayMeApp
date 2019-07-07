CREATE TABLE [dbo].[Location] (
    [ID]       INT           IDENTITY (1, 1) NOT NULL,
    [Location] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([ID] ASC)
);

