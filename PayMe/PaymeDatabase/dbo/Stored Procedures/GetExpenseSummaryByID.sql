
CREATE PROCEDURE [dbo].[GetExpenseSummaryByID] (@ID INT)
AS
BEGIN
	SELECT e.[ID]
		,e.[Name]
		,e.[ExpenseStatusID]
		,es.[Name] AS ExpenseStatusName
		,e.[TotalAmount]
		,e.[ApprovedAmount]
		,e.[EmpID]
		,e.[ProjectID]
		,p.ProjectName
		,e.[FromDate]
		,e.[ToDate]
		,e.[Description]
	FROM [dbo].[ExpenseSummary] e WITH (NOLOCK)
	INNER JOIN ExpenseStatus es WITH (NOLOCK) ON e.[ExpenseStatusID] = es.ID
	INNER JOIN Project p ON p.ID = e.[ProjectID]
	WHERE e.ID = @ID
END
