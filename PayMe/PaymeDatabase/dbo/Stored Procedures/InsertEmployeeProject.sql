
CREATE Proc [dbo].[InsertEmployeeProject]
 @EmpID  INT ,
 @ProjectID  INT,
 @TaskID  INT ,
 @StartDate  DATETIME ,
 @EndDate  DATETIME ,
 @RegularRate  DECIMAL(18,2),
 @OTRate  DECIMAL(18,2),
 @output INT OUTPUT  
AS 
BEGIN

DECLARE @TransactionName NVARCHAR(32) = 'Expensepayme';  
  
 BEGIN TRY  
  BEGIN TRANSACTION;  
  
  SAVE TRANSACTION @TransactionName;  
  
    
  BEGIN  
	INSERT INTO [dbo].[EmployeeProject]
			   ([fkEmpID]
			   ,[fkProjectID]
			   ,[fkTaskID]
			   ,[StartDate]
			   ,[EndDate]
			   ,[RegularRate]
			   ,[OTRate])
		 VALUES
			   (@EmpID
			   ,@ProjectID
			   ,@TaskID
			   ,@StartDate
			   ,@EndDate
			   ,@RegularRate
			   ,@OTRate)

			   SET @output = 1;
   END  
    
  
  COMMIT;  
 END TRY  
  
 BEGIN CATCH  
  IF @@trancount > 0  
   ROLLBACK TRANSACTION @TransactionName;  
  
  throw;  
 END CATCH  
END
