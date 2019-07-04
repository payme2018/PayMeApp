

CREATE Proc [dbo].[GetProjectByID]
(
	@id int,
	@AccountID int =NULL
)
AS
BEGIN


SELECT [ID]
      ,[fkClientId]
      ,[ProjectName]
      ,[PrimaryContact]
      ,[LocationInfo]
      ,[Description]
      ,[IsActive]
  FROM [dbo].[Project]
  where ID = @id and AccountID = @AccountID



END
 
