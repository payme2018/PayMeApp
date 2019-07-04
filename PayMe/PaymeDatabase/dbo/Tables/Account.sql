CREATE TABLE [dbo].[Account] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (1000) NULL,
    [IsActive] BIT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

