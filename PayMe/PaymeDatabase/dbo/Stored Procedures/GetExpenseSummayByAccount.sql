

CREATE PROCEDURE [dbo].[GetExpenseSummayByAccount]
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
	isnull(sum(e.ApprovedAmount),0.0) as ApprovedAmount,
	isnull(sum(e.TotalAmount),0.0) as TotalAmount
	from 
	 vProject p 
	left join ExpenseSummary e on p.ProjectID = e.ProjectID and e.ToDate < @Year + @Month + '01'
	where 
	p.AccountID = @AccountId
	
	group by AccountID,
	AccountName,
	IsAccountActive,
	ClientID,
	ClientName,
	IsClientActive,
	ProjectName,
	p.ProjectID,
	IsProjectActive
end