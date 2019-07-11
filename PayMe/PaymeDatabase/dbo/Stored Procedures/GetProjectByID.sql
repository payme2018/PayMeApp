    
    
CREATE Proc [dbo].[GetProjectByID]    
(    
 @id int,    
 @AccountID int =NULL    
)    
AS    
BEGIN    
    
    
SELECT p.[ID]    
      ,p.[fkClientId]    
      ,p.[ProjectName]    
      ,p.[PrimaryContact]    
      ,p.[LocationInfo]    
      ,p.[Description]    
      ,p.[IsActive]    
   ,isnull (e.ID,0) as ManagerID  
   ,e.FirstName + ' '+ e.LastName as ManagerName  
  FROM [dbo].[Project]  p  
    left join dbo.Employee e on p.ManagerID = e.id  
  where p.ID = @id and p.AccountID = @AccountID    
    
    
    
END
 
