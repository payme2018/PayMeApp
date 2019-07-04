CREATE TABLE [dbo].[Task] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [fkProjectId] INT           NOT NULL,
    [TaskName]    VARCHAR (200) NOT NULL,
    [IsActive]    BIT           CONSTRAINT [DF_Task_IsActive] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED ([ID] ASC)
);

