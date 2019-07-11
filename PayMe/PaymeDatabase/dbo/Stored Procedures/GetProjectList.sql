    
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
   ,isnull(e.id,0) as ManagerID,    
      e.FirstName + ' ' + e.LastName as ManagerName    
  FROM [dbo].[Project] p WITH(NOLOCK)     
  JOIN dbo.Client c ON p.fkClientId =c.ID     
  left join Employee e on e.ID = p.ManagerID    
  WHERE p.AccountID =@AccountID      
      
      
      
END
 
