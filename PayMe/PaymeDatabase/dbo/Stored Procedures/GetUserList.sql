
CREATE Proc [dbo].[GetUserList](@AccountID int=NULL)

AS
BEGIN
SELECT
e.ID
,e.FirstName
,e.LastName
,e.JoiningDate
,e.DOB
,e.fkEmploymentLocationID
,e.Designation
,e.WorkingHoursPerDay
,e.EmployeeCode
,e.InternalCode
,e.fkDepartmentID
,e.fkManagerId
,e.fkContactID
,e.IsActive
,e.InactiveDate
,e.LastWorkingDate
,e.Createdate
,e.UpdatedDate
,CASE WHEN e.Gender = 1 THEN 'Male' ELSE 'Female' END AS Gender
,e.EmailID
,e.CreatedBy
,u.fkEmpID
,u.UserName
,u.[Password]
,u.fkRoleId
,u.LastLogin
,u.IsActive
,r.RoleName
,e.FirstName +' '+ e.LastName as FullName
FROM
[dbo].[Employee] e With(nolock) 
JOIN  [dbo].[User] u on e.ID = u.fkEmpID 
JOIN  [Role] r on r.ID = u.fkRoleId

WHERE e.AccountID=@AccountID

END
