CREATE PROCEDURE [dbo].[CreateTimesheet] (
	@UserID INT
	,@UserName VARCHAR(256)
	,@ClientId INT
	,@ProjectId INT
	,@TaskId int
	,@CheckInDate DATETIME = NULL
	,@CheckInDateTime DATETIME = NULL
	,@CheckOutDateTime DATETIME = NULL
	,@Description VARCHAR(1000)
		,@output INT OUTPUT
	)
AS
BEGIN
	DECLARE @TransactionName NVARCHAR(32) = 'Timsheetpayme';

	BEGIN TRY
		BEGIN TRANSACTION;

		SAVE TRANSACTION @TransactionName;

		INSERT INTO [dbo].[TimeSheet] (
			fkEmpId
			,fkClientId
			,fkProjectID
			,fkTaskID
			,CheckInDate
			,CheckInDateTime
			,CheckOutDatetime
			,[Description]
			,IsBillable
			,CreatedOn
			,CreatedBy
			)
		VALUES (
			@UserID
			,@ClientId
			,@ProjectId
			,@TaskId
			,@CheckInDate
			,@CheckInDateTime
			,@CheckOutDateTime
			,@Description
			,1
			,GETUTCDATE()
			,@UserName
			)
			SET @output = 1;

		COMMIT;
	END TRY

	BEGIN CATCH
		IF @@trancount > 0
			ROLLBACK TRANSACTION @TransactionName;

		throw;
	END CATCH
END
