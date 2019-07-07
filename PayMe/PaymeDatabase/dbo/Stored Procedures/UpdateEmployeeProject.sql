
CREATE Proc [dbo].[UpdateEmployeeProject]
 @ID  INT,
 @EmpID  INT ,
 @ProjectID  INT,
 @TaskID  INT ,
 @StartDate  DATETIME ,
 @EndDate  DATETIME ,
 @RegularRate  DECIMAL(18,2),
 @OTRate  DECIMAL(18,2)
AS 
BEGIN
UPDATE [dbo].[EmployeeProject]
   SET [fkEmpID] = @EmpID
      ,[fkProjectID] = @ProjectID
      ,[fkTaskID] = @TaskID
      ,[StartDate] = @StartDate
      ,[EndDate] = @EndDate
      ,[RegularRate] = @RegularRate
      ,[OTRate] =@OTRate
 WHERE Id=@ID
END
