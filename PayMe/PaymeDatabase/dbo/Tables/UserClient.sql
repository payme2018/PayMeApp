CREATE TABLE [dbo].[UserClient] (
    [fkEmpID]    INT NOT NULL,
    [fKClientID] INT NOT NULL,
    CONSTRAINT [FK_UserClient_Client] FOREIGN KEY ([fKClientID]) REFERENCES [dbo].[Client] ([ID]),
    CONSTRAINT [FK_UserClient_Employee] FOREIGN KEY ([fkEmpID]) REFERENCES [dbo].[Employee] ([ID])
);

