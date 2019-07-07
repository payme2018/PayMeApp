CREATE Proc [dbo].[GetClientListByID](@AccountID int,@Id int)
AS
BEGIN


SELECT [ID]
      ,[ClientCode]
      ,[ClientName]
      ,[PrimaryContact]
      ,[LocationInfo]
      ,[Description]
      ,[IsActive]
  FROM [dbo].[Client] WHERE AccountID=@AccountID and [ID]=@Id 

  END
