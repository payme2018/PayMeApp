
      
CREATE Proc [dbo].[GetUserForDD]    
   (
   @AccountID INT  
   ) 
AS    
BEGIN    
SELECT    
e.ID    
,E.FirstName+' '+E.LastName AS EmployeeName   
  
FROM    
[dbo].[Employee] e With(nolock)    where IsActive=1  and  e.AccountID = @AccountID  
    
END  
   

