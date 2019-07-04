

CREATE Proc [dbo].[GetProjectList](@AccountID int)
AS
BEGIN


SELECT p.[ID]
      ,p.[fkClientId]
      ,p.[ProjectName]
      ,p.[PrimaryContact]
      ,p.[LocationInfo]
      ,p.[Description]
      ,p.[IsActive]
	  ,c.ClientName
  FROM [dbo].[Project] p WITH(NOLOCK) JOIN dbo.Client c ON p.fkClientId =c.ID WHERE p.AccountID =@AccountID



END
 
