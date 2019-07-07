CREATE Proc [dbo].[ValidateUser]
(
@UserName nvarchar(250),
@Password nvarchar(250)
)
AS
BEGIN

Select * from [dbo].[Employee] e With(nolock) JOIN  [dbo].[User] u on e.ID = u.fkEmpID Where u.UserName =@UserName AND u.[Password] =@Password

END
 
