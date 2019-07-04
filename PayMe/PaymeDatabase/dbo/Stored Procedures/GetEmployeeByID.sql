
CREATE Proc [dbo].[GetEmployeeByID](@EmployeeID int )

AS
BEGIN
SELECT
e.ID
,e.FirstName
,e.LastName
,e.JoiningDate
, CONVERT(date,e.DOB) AS DOB
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
,e.PassportNo
,e.PassportIssuedBy
,e.PassportIssuedOn
,e.PassportExpireOn
,e.VISANo
,e.VISAIssuedBy
,e.VISAIssuedOn
,e.VISAExpireOn
,e.LabourCardNo
,e.LabourCardIssuedBy
,e.LabourCardIssuedOn
,e.LabourCardExpireOn
,e.AccountID
, e.Gender
,e.EmailID
,e.CreatedBy
,u.fkEmpID
,u.UserName
,u.[Password]
,u.fkRoleId
,u.LastLogin
,u.IsActive
,r.RoleName
,e.MobileNo
FROM
[dbo].[Employee] e With(nolock) 
JOIN  [dbo].[User] u on e.ID = u.fkEmpID 
JOIN  [Role] r on r.ID = u.fkRoleId

WHERE e.ID=@EmployeeID

END
