
CREATE Proc [dbo].[GetExpenseSummaryByUserID]
(@UserID Int)
AS BEGIN
SELECT e.[ID]
      ,e.[Name]
      ,e.[ExpenseStatusID]
	  ,es.[Name] AS ExpenseStatusName
      ,SUM(ed.Amount) AS TotalAmount
      ,e.[ApprovedAmount]
      ,e.[EmpID]
      ,e.[ProjectID]
	  ,p.ProjectName
      ,e.[FromDate]
      ,e.[ToDate]
      ,e.[Description]
	  ,ed.ExpenseSummaryID
  FROM [dbo].[ExpenseSummary] e with (nolock) 
  JOIN  ExpenseStatus es with (nolock) on e.[ExpenseStatusID] = es.ID 
  JOIN  Project p on  p.ID = e.[ProjectID] 
  LEFT JOIN [dbo].[ExpenseDetail] ed on ed.ExpenseSummaryID=e.ID WHERE EmpID = @UserID
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
     


  
END
 
