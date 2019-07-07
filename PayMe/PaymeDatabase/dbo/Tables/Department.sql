CREATE TABLE [dbo].[Department] (
    [DeptId]         INT           IDENTITY (1, 1) NOT NULL,
    [DepartmentName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([DeptId] ASC)
);

