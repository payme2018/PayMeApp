

CREATE Proc [dbo].[GetClientByID]
(
 @ClientID INT
 )
AS
BEGIN

SELECT [ID]
      ,[ClientCode]
      ,[ClientName]
      ,[PrimaryContact]
      ,[LocationInfo]
      ,[Description]
      ,[IsActive]
  FROM [dbo].[Client]
  where ID =  @ClientID 

  
END
 
