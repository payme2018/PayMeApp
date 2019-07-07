Create Procedure [dbo].[GetPayRateByEmployeeID]
(@EmployeeID int)
AS
BEGIN

SELECT ep.[ID]
      ,[EmployeeID]
      ,[StartDate]
      ,[EndDate]
      ,[PayRateTypeID]
      ,[RegularRate]
      ,[OTRate]
	  ,[Name]
  FROM [payme].[dbo].[EmployeePayRate] ep join PayRateType pt on ep.[PayRateTypeID] = pt.ID where [EmployeeID] =@EmployeeID

END
