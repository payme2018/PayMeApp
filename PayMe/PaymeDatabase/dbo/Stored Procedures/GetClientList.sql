CREATE Proc [dbo].[GetClientList](@AccountID int)
AS
BEGIN


SELECT [ID]
      ,[ClientCode]
      ,[ClientName]
      ,[PrimaryContact]
      ,[LocationInfo]
      ,[Description]
      ,[IsActive]
  FROM [dbo].[Client] WHERE AccountID=@AccountID

  
END
