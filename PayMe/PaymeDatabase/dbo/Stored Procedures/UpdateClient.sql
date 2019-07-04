/*
    This procedure creates a Client.
    Change History:
    12/16/2018, Dinesh Kalyanasundaram
    Original Creation
*/
CREATE PROCEDURE [dbo].[UpdateClient] (
	@Id int
	,@ClientCode VARCHAR(100) = ''
	,@ClientName VARCHAR(200)
	,@PrimaryContact VARCHAR(200) = NULL
	,@LocationInfo VARCHAR(500) = NULL
	,@Description VARCHAR(500) = NULL
	,@IsActive BIT = 0
	,@AccountID int
	,@output INT OUTPUT
	)
AS
BEGIN
	DECLARE @TransactionName NVARCHAR(32) = 'Clientpayme';

	BEGIN TRY
		BEGIN TRANSACTION;

		SAVE TRANSACTION @TransactionName;

		UPDATE [dbo].[Client]
		   SET [ClientCode] = @ClientCode
			  ,[ClientName] = @ClientName
			  ,[PrimaryContact] = @PrimaryContact
			  ,[LocationInfo] = @LocationInfo
			  ,[Description] = @Description
			  ,[IsActive] = @IsActive
			  ,[AccountID] = @AccountID
		 WHERE ID=@Id
		
			SET @output = 1;
		
			COMMIT;
	END TRY

	BEGIN CATCH
		IF @@trancount > 0
			ROLLBACK TRANSACTION @TransactionName;

		throw;
	END CATCH
END
