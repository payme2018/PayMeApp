
/*
    This procedure creates a Client.
    Change History:
    12/16/2018, Dinesh Kalyanasundaram
    Original Creation
*/
CREATE PROCEDURE [dbo].[CreateClient] (
	@ClientCode VARCHAR(100) = ''
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

		IF NOT EXISTS (
				SELECT TOP 1 ClientName
				FROM Client
				WHERE ClientName = @ClientName
				)
		BEGIN
			INSERT INTO [dbo].[Client] (
				[ClientCode]
				,[ClientName]
				,[PrimaryContact]
				,[LocationInfo]
				,[Description]
				,[IsActive]
				,AccountID
				)
			VALUES (
				@ClientCode
				,@ClientName
				,@PrimaryContact
				,@LocationInfo
				,@Description
				,@IsActive
				,@AccountID
				)
			SET @output = 1;
		END
		ELSE
		BEGIN
			SET @output = 2;
		END
			COMMIT;
	END TRY

	BEGIN CATCH
		IF @@trancount > 0
			ROLLBACK TRANSACTION @TransactionName;

		throw;
	END CATCH
END
