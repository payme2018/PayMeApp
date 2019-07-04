
CREATE PROCEDURE [dbo].[GetExpenseDetailBySummary] (@ExpenseSummaryID INT)
AS
BEGIN
	SELECT ed.ID
		,CategoryID
		,ec.[Name] AS CategoryName
		,ExpenseSummaryID
		,CurrencyBillNo
		,Amount
		,BillDate
		,Location
		,HasAttachment
		,Notes
	FROM [dbo].[ExpenseDetail] ed WITH (NOLOCK)
	INNER JOIN [dbo].[ExpenseCategory] ec ON ed.CategoryID = ec.ID
	WHERE ExpenseSummaryID = @ExpenseSummaryID
END
