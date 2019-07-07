
Create Proc [dbo].[GetTimesheetEntries]
(@AccountID Int)
AS BEGIN
SELECT
 t.ID
,t.fkEmpId
,t.fkClientId
,t.fkProjectID
,t.[fkTaskID]
,t.CheckInDate

,t.CheckInDateTime
,t.CheckOutDatetime
,t.Description
,t.IsBillable
,t.IsApproved
,t.CreatedOn
,t.CreatedBy
,t.EditedOn
,t.EditedBy
,t.ApprovedDate
,p.ProjectName
,c.ClientName
,ts.TaskName
,e.FirstName +' '+e.LastName As EmployeeName
,t.WorkedHours
FROM  [dbo].[TimeSheet] t 

JOIN Project p on p.ID = t.fkProjectID
JOIN Client c  on c.ID = t.fkClientId
JOIN Task ts on ts.ID = t.fkTaskID
JOIN Employee e on e.ID = t.fkEmpId
where e.AccountID =@AccountID

  
END
 
