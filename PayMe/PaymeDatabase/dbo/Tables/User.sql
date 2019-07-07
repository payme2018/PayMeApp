CREATE TABLE [dbo].[User] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [fkEmpID]   INT           NOT NULL,
    [UserName]  VARCHAR (100) NOT NULL,
    [Password]  VARCHAR (100) NOT NULL,
    [fkRoleId]  INT           NOT NULL,
    [LastLogin] DATETIME      NULL,
    [IsActive]  BIT           CONSTRAINT [DF_User_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_User_Employee] FOREIGN KEY ([fkEmpID]) REFERENCES [dbo].[Employee] ([ID]),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([fkRoleId]) REFERENCES [dbo].[Role] ([ID])
);

