

/*
    This procedure creates a Project.
    Change History:
    12/16/2018, Dinesh Kalyanasundaram
    Original Creation
*/
CREATE PROCEDURE [dbo].[DeleteTask] (
	 @Id INT,	
	 @output INT OUTPUT
	)
AS
BEGIN
	DECLARE @TransactionName NVARCHAR(32) = 'Projectpayme';

	BEGIN TRY
		BEGIN TRANSACTION;

		SAVE TRANSACTION @TransactionName;

		--IF NOT EXISTS (
		--		SELECT TOP 1 TaskName
		--		FROM [dbo].[Task]
		--		WHERE TaskName = @TaskName AND fkProjectId=@ProjectID
		--		)
		--BEGIN

			Delete [dbo].[Task] WHERE id=@Id
			
			SET @output = 1;
		--END
		--ELSE
		--BEGIN
		--	SET @output = 2;
		--END

		COMMIT;
	END TRY

	BEGIN CATCH
		IF @@trancount > 0
			ROLLBACK TRANSACTION @TransactionName;

		throw;
	END CATCH
END

