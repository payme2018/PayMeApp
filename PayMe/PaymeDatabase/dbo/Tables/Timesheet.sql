CREATE TABLE [dbo].[Timesheet] (
    [ID]               INT           IDENTITY (1, 1) NOT NULL,
    [fkEmpId]          INT           NOT NULL,
    [fkClientId]       INT           NOT NULL,
    [fkProjectID]      INT           NOT NULL,
    [fkTaskID]         INT           NOT NULL,
    [CheckInDate]      DATETIME      NOT NULL,
    [CheckInDateTime]  DATETIME      NOT NULL,
    [CheckOutDatetime] DATETIME      NOT NULL,
    [Description]      VARCHAR (500) NULL,
    [IsBillable]       BIT           NULL,
    [IsApproved]       INT           NULL,
    [CreatedOn]        DATETIME      NOT NULL,
    [CreatedBy]        VARCHAR (500) NULL,
    [EditedOn]         DATETIME      NULL,
    [EditedBy]         VARCHAR (500) NULL,
    [ApprovedDate]     DATETIME      NULL,
    [WorkedHours]      TIME (7)      NULL,
    CONSTRAINT [PK_TimeSheet] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_TimeSheet_Client] FOREIGN KEY ([fkClientId]) REFERENCES [dbo].[Client] ([ID]),
    CONSTRAINT [FK_TimeSheet_Employee] FOREIGN KEY ([fkEmpId]) REFERENCES [dbo].[Employee] ([ID]),
    CONSTRAINT [FK_TimeSheet_Project] FOREIGN KEY ([fkProjectID]) REFERENCES [dbo].[Project] ([ID])
);

