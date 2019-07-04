

CREATE Proc [dbo].[GetProjectsByClient]
@ClientID INT
AS
BEGIN
SELECT [ID]      
      ,[ProjectName]      
  FROM [dbo].[Project] WITH(NOLOCK) 
  WHERE fkClientId=@ClientID
END
 

