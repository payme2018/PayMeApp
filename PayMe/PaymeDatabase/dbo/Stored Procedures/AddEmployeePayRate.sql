Create Procedure [dbo].[AddEmployeePayRate]
(
@EmployeeID int,
@StartDate datetime,
@EndDate datetime,
@PayRateID int,
@RegularRate decimal,
@OTRate decimal
)
AS
BEGIN

Insert into [EmployeePayRate] 
    ([EmployeeID]
      ,[StartDate]
      ,[EndDate]
      ,[PayRateTypeID]
      ,[RegularRate]
      ,[OTRate]
	  )
	  Values(@EmployeeID,@StartDate,@EndDate,@PayRateID,@RegularRate,@OTRate)



END
