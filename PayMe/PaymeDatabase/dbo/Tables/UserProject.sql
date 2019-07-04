CREATE TABLE [dbo].[UserProject] (
    [fkEmpID]     INT NOT NULL,
    [fKProjectID] INT NOT NULL,
    CONSTRAINT [FK_UserProject_Employee] FOREIGN KEY ([fkEmpID]) REFERENCES [dbo].[Employee] ([ID]),
    CONSTRAINT [FK_UserProject_Project] FOREIGN KEY ([fKProjectID]) REFERENCES [dbo].[Project] ([ID])
);

