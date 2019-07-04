CREATE Proc [dbo].[GetAccountList]
AS
BEGIN

SELECT [ID]
      ,[Name]
      ,[IsActive]
  FROM [dbo].[Account] where IsActive =1 Order by Name ASC

  
END
