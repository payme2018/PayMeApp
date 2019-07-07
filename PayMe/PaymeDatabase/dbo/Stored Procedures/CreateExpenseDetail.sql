


/*
    This procedure creates a Expense Detail.
    Change History:
    12/16/2018, Dinesh Kalyanasundaram
    Original Creation
*/

CREATE PROCEDURE [dbo].[CreateExpenseDetail] (
	@CategoryID INT
	,@ExpenseSummaryID INT
	,@CurrencyBillNo VARCHAR(250) = NULL
	,@Amount decimal(10,2) = NULL
	,@BillDate datetime = null
	,@Location VARCHAR(500) = NULL
	,@HasAttachment bit =NULL
	,@Notes VARCHAR(500) = NULL
	,@GrossTotal decimal(10,2)= NULL
	,@TaxAmount decimal(10,2)= NULL
	,@VatNumber VARCHAR(100)= NULL
	,@PaidTo VARCHAR(500) = NULL
	,@HasBill bit =0
	,@output INT OUTPUT	
	)
AS
BEGIN
	DECLARE @TransactionName NVARCHAR(32) = 'ExpenseDetailpayme';

	BEGIN TRY
		BEGIN TRANSACTION;

		SAVE TRANSACTION @TransactionName;

	
		BEGIN
			INSERT INTO ExpenseDetail (
				CategoryID
				,ExpenseSummaryID
				,CurrencyBillNo
				,Amount
				,BillDate
				,[Location]
				,HasAttachment
				,Notes
				,GrossTotal
				,TaxAmount
				,VatNumber
				,PaidTo
				,HasBill
				)
			VALUES (
				@CategoryID
				,@ExpenseSummaryID
				,@CurrencyBillNo
				,@Amount
				,isnull(@BillDate,getdate())
				,@Location
			    ,@HasAttachment
				,@Notes
				,@GrossTotal
				,@TaxAmount
				,@VatNumber
				,@PaidTo
				,@HasBill
				)

			SET @output = SCOPE_IDENTITY();
		END
		

		COMMIT;
	END TRY

	BEGIN CATCH
		IF @@trancount > 0
			ROLLBACK TRANSACTION @TransactionName;

		throw;
	END CATCH
END
