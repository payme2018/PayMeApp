
CREATE Proc [dbo].[GetTimesheetByUserID]
(@UserID Int)
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

FROM  [dbo].[TimeSheet] t 

JOIN Project p on p.ID = t.fkProjectID
JOIN Client c  on c.ID = t.fkClientId
JOIN Task ts on ts.ID = t.fkTaskID

WHERE t.fkEmpId = @UserID

  
END
 
