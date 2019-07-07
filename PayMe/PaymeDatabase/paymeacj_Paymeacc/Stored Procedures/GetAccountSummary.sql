--exec GetAccountSummary 3
CREATE Proc GetAccountSummary 
(
@AccountID int=NULL
)
AS  
BEGIN
--declare @AccountID int 
--set @AccountID = 3
Declare @Clientcount int
Declare @ProjectCount int
Declare @UserCount int
Declare @EmployeeCount int

Declare @totalHourIncurrentMonth int

Declare @TotalAmount decimal(9,2)
Declare @ApprovedAmount decimal(9,2)

Select @Clientcount = count(1) from [dbo].[Client] where  AccountID = @AccountID and IsActive= 1
Select @ProjectCount = count(1) from [dbo].[Project] where  AccountID = @AccountID and IsActive= 1
Select @EmployeeCount = count(1) from [dbo].[Employee] where  AccountID = @AccountID and IsActive= 1
 
 select @totalHourIncurrentMonth = sum( (datepart(hh,Cast(T.[WorkedHours] as Datetime))
+datepart(MINUTE,Cast(T.[WorkedHours] as Datetime))/60.0 ))  from [dbo].[Timesheet] t
join [Project] p on p.id = t.[fkProjectID] where AccountID = @AccountID and [CheckInDate] > Cast(DATEPART(yy, getdate())as varchar)  +'/'+cast(DATEPART(mm, getdate()) as varchar) +'/01'

select   @TotalAmount = sum(TotalAmount), @ApprovedAmount = Sum(ApprovedAmount)
 from [dbo].[ExpenseSummary] e
 join [dbo].[Project] p on e.ProjectID = p.ID
 where p.AccountID = @AccountID and  e.FromDate >= Cast(DATEPART(yy, getdate())as varchar)  +'/'+cast(DATEPART(mm, getdate()) as varchar) +'/01'
 group by p.AccountID

select a.id as AccountId, a.Name as AccountName , @Clientcount as Clientcount , @ProjectCount as ProjectCount ,@EmployeeCount as EmployeeCount ,
 isnull(@totalHourIncurrentMonth,0) as TotalHourIncurrentMonth ,  isnull(@TotalAmount,0) as TotalAmount, isNull(@ApprovedAmount, 0 ) as ApprovedAmount 
from [dbo].[Account] a  where id = @AccountID
END
