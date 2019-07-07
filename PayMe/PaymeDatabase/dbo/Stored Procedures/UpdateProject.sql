

/*
    This procedure update a Project.
    Change History:
    12/16/2018, Dinesh Kalyanasundaram
    Original Creation
*/
CREATE PROCEDURE [dbo].[UpdateProject] (
     @ID INT
	,@ClientID INT
	,@ProjectName VARCHAR(250)
	,@PrimaryContact VARCHAR(200) = NULL
	,@LocationInfo VARCHAR(500) = NULL
	,@Description VARCHAR(500) = NULL
	,@IsActive BIT = 0
	
	,@output INT OUTPUT
	)
AS
BEGIN
	DECLARE @TransactionName NVARCHAR(32) = 'Projectpayme';

	BEGIN TRY
		BEGIN TRANSACTION;

		SAVE TRANSACTION @TransactionName;

		IF NOT EXISTS (
				SELECT TOP 1 ProjectName
				FROM Project
				WHERE ProjectName = @ProjectName and ID != @ID
				)
		BEGIN

				Update [dbo].[Project] Set 
				fkClientId =@ClientID
				,ProjectName = @ProjectName
				,[PrimaryContact]=@PrimaryContact
				,[LocationInfo] = @LocationInfo
				,[Description] = @Description
				,[IsActive] =@IsActive WHERE ID=@ID 

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
