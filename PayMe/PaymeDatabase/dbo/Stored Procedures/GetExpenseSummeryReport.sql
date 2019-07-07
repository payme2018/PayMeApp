
CREATE Proc [dbo].[GetExpenseSummeryReport]
(@ClientId Int,
 @ProjectId int
)
AS 
BEGIN
	IF (@ProjectId<>-2)
	BEGIN
		SELECT e.[ID]
			  ,e.[Name]
			  ,e.[ExpenseStatusID]
			  ,es.[Name] AS ExpenseStatusName
			  ,SUM(ed.Amount) AS TotalAmount
			  ,e.[ApprovedAmount]
			  ,e.[EmpID]
			  ,e.[ProjectID]
			  ,p.ProjectName
			  ,c.ClientName
			  ,e.[FromDate]
			  ,e.[ToDate]
			  ,e.[Description]
			  ,ed.ExpenseSummaryID
			  ,u.FirstName + ' '+u.LastName as UserName
		  FROM [dbo].[ExpenseSummary] e with (nolock) 
		  JOIN  ExpenseStatus es with (nolock) on e.[ExpenseStatusID] = es.ID 
		  JOIN  Project p on  p.ID = e.[ProjectID] 
		  JOIN  Client c on  p.fkClientId = c.ID
		  JOIN  Employee u on u.id=e.EmpID
		  LEFT JOIN [dbo].[ExpenseDetail] ed on ed.ExpenseSummaryID=e.ID WHERE ProjectID = @ProjectId
		  GROUP by e.[ID]
			  ,e.[Name]
			  ,e.[ExpenseStatusID]
			  ,es.[Name] 
			  ,e.[ApprovedAmount]
			  ,e.[EmpID]
			  ,e.[ProjectID]
			  ,p.ProjectName
			  ,e.[FromDate]
			  ,e.[ToDate]
			  ,e.[Description]
			  ,ed.ExpenseSummaryID
			  ,c.ClientName
			  ,u.FirstName + ' '+u.LastName
	END     
	ELSE
	BEGIN
		SELECT e.[ID]
			  ,e.[Name]
			  ,e.[ExpenseStatusID]
			  ,es.[Name] AS ExpenseStatusName
			  ,SUM(ed.Amount) AS TotalAmount
			  ,e.[ApprovedAmount]
			  ,e.[EmpID]
			  ,e.[ProjectID]
			  ,p.ProjectName
			  ,c.ClientName
			  ,e.[FromDate]
			  ,e.[ToDate]
			  ,e.[Description]
			  ,ed.ExpenseSummaryID
			  ,u.FirstName + ' '+u.LastName as UserName
		  FROM [dbo].[ExpenseSummary] e with (nolock) 
		  JOIN  ExpenseStatus es with (nolock) on e.[ExpenseStatusID] = es.ID 
		  JOIN  Project p on  p.ID = e.[ProjectID] 
		  JOIN  Client c on  p.fkClientId = c.ID
		  JOIN  Employee u on u.id=e.EmpID
		  LEFT JOIN [dbo].[ExpenseDetail] ed on ed.ExpenseSummaryID=e.ID 
		  WHERE p.fkClientId=@ClientId
		  GROUP by e.[ID]
			  ,e.[Name]
			  ,e.[ExpenseStatusID]
			  ,es.[Name] 
			  ,e.[ApprovedAmount]
			  ,e.[EmpID]
			  ,e.[ProjectID]
			  ,p.ProjectName
			  ,e.[FromDate]
			  ,e.[ToDate]
			  ,e.[Description]
			  ,ed.ExpenseSummaryID
			  ,c.ClientName
			  ,u.FirstName + ' '+u.LastName
	END
  
END
 

