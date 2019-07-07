Create PROCEDURE [dbo].[UpdateTimeTrackerDate] (
	 @ID INT
	)
AS
BEGIN
	DECLARE @TransactionName NVARCHAR(32) = 'TimeTrackerUpdatepayme';

	BEGIN TRY
		BEGIN TRANSACTION;

		SAVE TRANSACTION @TransactionName;

		Update [dbo].[TimeTracker] set CheckOutDateTime =GETUTCDATE() WHERE ID =@ID

		COMMIT;
	END TRY

	BEGIN CATCH
		IF @@trancount > 0
			ROLLBACK TRANSACTION @TransactionName;

		throw;
	END CATCH
END
