
CREATE PROCEDURE [dbo].[GetExpenseDetailReport] 
(@ClientId Int,
 @ProjectId int
)
AS
BEGIN
	IF (@ProjectId<>-2)
	BEGIN
	SELECT 
		 u.FirstName + ' '+u.LastName as UserName
		,p.ProjectName
		,c.ClientName
		,e.[EmpID]
		,e.[Name]
		,ed.ID
		,CategoryID
		,ec.[Name] AS CategoryName
		,ExpenseSummaryID
		,CurrencyBillNo
		,Amount
		,BillDate
		,Location
		,HasAttachment
		,Notes
		,es.[Name] AS ExpenseStatusName
		,e.[Description]
	FROM [dbo].[ExpenseDetail] ed WITH (NOLOCK)
	INNER JOIN [dbo].[ExpenseCategory] ec ON ed.CategoryID = ec.ID	
	JOIN ExpenseSummary e on e.ID=ed.ExpenseSummaryID
	JOIN  ExpenseStatus es with (nolock) on e.[ExpenseStatusID] = es.ID 
	JOIN  Project p on  p.ID = e.[ProjectID] 
	JOIN  Client c on  p.fkClientId = c.ID
	JOIN  Employee u on u.id=e.EmpID
	WHERE e.ProjectID = @ProjectId
	END     
	ELSE
	BEGIN
	SELECT 
		 u.FirstName + ' '+u.LastName as UserName
		,p.ProjectName
		,c.ClientName
		,e.[EmpID]
		,e.[Name]
		,ed.ID
		,CategoryID
		,ec.[Name] AS CategoryName
		,ExpenseSummaryID
		,CurrencyBillNo
		,Amount
		,BillDate
		,Location
		,HasAttachment
		,Notes
		,es.[Name] AS ExpenseStatusName
		,e.[Description]
	FROM [dbo].[ExpenseDetail] ed WITH (NOLOCK)
	INNER JOIN [dbo].[ExpenseCategory] ec ON ed.CategoryID = ec.ID	
	JOIN ExpenseSummary e on e.ID=ed.ExpenseSummaryID
	JOIN  ExpenseStatus es with (nolock) on e.[ExpenseStatusID] = es.ID 
	JOIN  Project p on  p.ID = e.[ProjectID] 
	JOIN  Client c on  p.fkClientId = c.ID
	JOIN  Employee u on u.id=e.EmpID
	 WHERE p.fkClientId=@ClientId
	END
END
