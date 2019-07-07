CREATE Procedure [dbo].[GetTimeTracker]
AS
BEGIN
SELECT 
 tt.ID
,tt.EmployeeID
,tt.ClientID
,tt.ProjectID
,tt.TaskID
,tt.CheckInDateTime
,tt.CheckOutDateTime
,c.ClientName
,p.ProjectName
,t.TaskName
,e.FirstName +' '+ e.LastName AS EmployeeName
,tt.[CreatedOn] 
,tt.[CreatedBy] 
,tt.[EditedOn] 
,tt.[EditedBy] 
,CAST((ISNULL(CheckOutDateTime,GETUTCDATE())-CheckInDateTime) as time(0)) As TimeWorked
FROM TimeTracker tt with (nolock) 
JOIN Project p  with (nolock) on p.ID = tt.ProjectID 
JOIN Client c  with (nolock) on c.ID = tt.ClientID 
JOIN Task t with (nolock) on t.ID = tt.TaskID
JOIN Employee e with (nolock) on e.ID = tt.EmployeeID 




END
