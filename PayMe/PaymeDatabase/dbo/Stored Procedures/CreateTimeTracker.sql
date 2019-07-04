CREATE PROCEDURE [dbo].[CreateTimeTracker] (
	 @EmployeeID INT
	,@ClientID INT
	,@ProjectID INT
	,@TaskID int
	,@CheckInDateTime DATETIME = NULL
	,@CheckOutDateTime DATETIME = NULL
	,@UserName VARCHAR(256)
    ,@output INT OUTPUT
	)
AS
BEGIN
	DECLARE @TransactionName NVARCHAR(32) = 'TimeTrackerpayme';

	BEGIN TRY
		BEGIN TRANSACTION;

		SAVE TRANSACTION @TransactionName;

		INSERT INTO [dbo].[TimeTracker] (
			
            EmployeeID
            ,ClientID
            ,ProjectID
            ,TaskID
            ,CheckInDateTime
            ,CheckOutDateTime
            ,CreatedOn
            ,CreatedBy
           
			)
		VALUES (
			@EmployeeID
			,@ClientID
			,@ProjectID
			,@TaskID
			,GETUTCDATE()
			,@CheckOutDateTime
			,GETUTCDATE()
			,@UserName
			)
			SET @output = SCOPE_IDENTITY();

		COMMIT;
	END TRY

	BEGIN CATCH
		IF @@trancount > 0
			ROLLBACK TRANSACTION @TransactionName;

		throw;
	END CATCH
END
