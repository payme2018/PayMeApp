

CREATE PROCEDURE [dbo].[GetTimeSheetSummayByAccount]
	@AccountId int = 0,
	@Year int = null,
	@Month int = null
AS
begin
	if (@Year is null)
		set @Year =  YEAR(getdate())
	if (@Month is null)
		set @Month	= MONTH(getdate())
	select 
	AccountID,
	AccountName,
	IsAccountActive,
	ClientID,
	ClientName,
	IsClientActive,
	ProjectName,
	p.ProjectID,
	IsProjectActive,
	isnull(sum( (datepart(hh,Cast(T.[WorkedHours] as Datetime))
+datepart(MINUTE,Cast(T.[WorkedHours] as Datetime))/60.0 )),0.0)  as TotalHoursinNumber
	from 
	 [dbo].[vProject] p 
	 
	left join Timesheet t on p.ProjectID = t.fkProjectID and t.CheckInDate < @Year + @Month + '01'
	where 
	p.AccountID = @AccountId
	
	group by 	AccountID,
	AccountName,
	IsAccountActive,
	ClientID,
	ClientName,
	IsClientActive,
	ProjectName,
	p.ProjectID,
	IsProjectActive
end