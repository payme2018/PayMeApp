

/*
    This procedure creates a Expense Summary.
    Change History:
    12/16/2018, Dinesh Kalyanasundaram
    Original Creation
*/
CREATE PROCEDURE [dbo].[CreateExpenseSummary] (
	@ProjectID INT
	,@ExpenseName VARCHAR(250)
	,@FromDate datetime
	,@ToDate datetime
	,@Description VARCHAR(500) = NULL
	,@EmployeeID int
	,@output INT OUTPUT
	)
AS
BEGIN
	DECLARE @TransactionName NVARCHAR(32) = 'Expensepayme';

	BEGIN TRY
		BEGIN TRANSACTION;

		SAVE TRANSACTION @TransactionName;

		
		BEGIN
			INSERT INTO [dbo].[ExpenseSummary] (
				
                 [Name]
                ,ExpenseStatusID
                
                ,EmpID
                ,ProjectID
                ,FromDate
                ,ToDate
                ,[Description]
				)
			VALUES (
				@ExpenseName
				,1
				,@EmployeeID
				,@ProjectID
				,@FromDate
				,@ToDate
				,@Description
				)

			SET @output = 1;
		END
		

		COMMIT;
	END TRY

	BEGIN CATCH
		IF @@trancount > 0
			ROLLBACK TRANSACTION @TransactionName;

		throw;
	END CATCH
END
