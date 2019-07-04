  
CREATE Proc [dbo].[GetUserForDD]  
  
AS  
BEGIN  
SELECT  
e.ID  
,E.FirstName+' '+E.LastName AS EmployeeName 

FROM  
[dbo].[Employee] e With(nolock)    where IsActive=1
  
END  
   

