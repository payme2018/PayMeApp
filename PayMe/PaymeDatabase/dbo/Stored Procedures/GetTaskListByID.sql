CREATE Proc [dbo].[GetTaskListByID]
 @ID INT
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
  WHERE T.ID=@ID



END
 
