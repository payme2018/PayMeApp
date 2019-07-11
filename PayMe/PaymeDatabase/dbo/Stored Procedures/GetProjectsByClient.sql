
  
  
CREATE Proc [dbo].[GetProjectsByClient]  
@AccountID INT  ,
@ClientID INT  
AS  
BEGIN  
SELECT [ID]        
      ,[ProjectName]        
  FROM [dbo].[Project] WITH(NOLOCK)   
  WHERE fkClientId= isnull(@ClientID,fkClientId)
  and   @AccountID = AccountID
END
 

