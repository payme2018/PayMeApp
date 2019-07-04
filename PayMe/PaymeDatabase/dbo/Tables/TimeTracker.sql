CREATE TABLE [dbo].[TimeTracker] (
    [ID]               INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeID]       INT           NOT NULL,
    [ClientID]         INT           NOT NULL,
    [ProjectID]        INT           NOT NULL,
    [TaskID]           INT           NOT NULL,
    [CheckInDateTime]  DATETIME      NULL,
    [CheckOutDateTime] DATETIME      NULL,
    [CreatedOn]        DATETIME      NOT NULL,
    [CreatedBy]        VARCHAR (500) NULL,
    [EditedOn]         DATETIME      NULL,
    [EditedBy]         VARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_TimeTracker_Client] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Client] ([ID]),
    CONSTRAINT [FK_TimeTracker_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([ID]),
    CONSTRAINT [FK_TimeTracker_Project] FOREIGN KEY ([ProjectID]) REFERENCES [dbo].[Project] ([ID]),
    CONSTRAINT [FK_TimeTracker_Task] FOREIGN KEY ([TaskID]) REFERENCES [dbo].[Task] ([ID])
);

