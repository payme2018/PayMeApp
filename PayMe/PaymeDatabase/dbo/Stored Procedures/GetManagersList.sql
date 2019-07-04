CREATE Proc [dbo].[GetManagersList]
AS
BEGIN


SELECT m.[ID]
      ,m.EmployeeID
      ,e.FirstName + ' ' + e.LastName as [Name]
     
  FROM [dbo].[Managers] m with (nolock) join Employee e on e.ID = m.EmployeeID

  
END
