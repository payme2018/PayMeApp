CREATE Proc [dbo].[GetTaskList] (@ProjectID int = null,@AccountID int)
AS
BEGIN



SELECT t.[ID]
	  ,p.[fkClientId] as ClientID
	  ,c.ClientName	
      ,t.[fkProjectId] as ProjectId
      ,p.[ProjectName]	 
      ,t.[TaskName]
      ,t.[IsActive]	  
  FROM [dbo].[Task] t WITH(NOLOCK) JOIN [dbo].[Project] p ON t.fkProjectId =p.ID
  JOIN dbo.Client c ON p.fkClientId =c.ID 
  AND   p.ID  = isnull( @ProjectID, p.ID)
  AND  c.AccountID = @AccountID


END
 

