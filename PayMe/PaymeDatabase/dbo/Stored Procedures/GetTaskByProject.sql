  
  
CREATE Proc [dbo].[GetTaskByProject]
@ProjectId INT  
AS  
BEGIN  
SELECT [ID]        
      ,[TaskName]    
  FROM [dbo].[Task] WITH(NOLOCK)   
  WHERE fkProjectId=@ProjectId  
END  
   
