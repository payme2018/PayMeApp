
CREATE Proc [dbo].[GetTimesheetDetailReportByDate]
(@FromDate DateTime,
@ToDate DateTime)
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
,E.FirstName+' '+E.LastName AS 'EmployeeName'
FROM  [dbo].[TimeSheet] t 

JOIN Project p on p.ID = t.fkProjectID
JOIN Client c  on c.ID = t.fkClientId
JOIN Task ts on ts.ID = t.fkTaskID
JOIN Employee E ON E.ID=T.fkEmpId
WHERE t.CheckInDate BETWEEN @FromDate AND @ToDate

  
END
 

