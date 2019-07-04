﻿  
  
/*  
    This procedure creates a Project.  
    Change History:  
    12/16/2018, Dinesh Kalyanasundaram  
    Original Creation  
*/  
CREATE PROCEDURE [dbo].[DeleteExpenseDetail] (  
  @Id INT,   
  @output INT OUTPUT  
 )  
AS  
BEGIN  
 DECLARE @TransactionName NVARCHAR(32) = 'Projectpayme';  
  
 BEGIN TRY  
  BEGIN TRANSACTION;  
  
  SAVE TRANSACTION @TransactionName;  
  delete from ExpenseDetailDocument where ExpenseDetailID=@Id
  delete from ExpenseDetail where id=@Id
   --UPDATE [Client] SET IsActive=0 WHERE Id=@Id
   SET @output = 1;
  
  COMMIT;  
 END TRY  
  
 BEGIN CATCH  
  IF @@trancount > 0  
   ROLLBACK TRANSACTION @TransactionName;  
  
  throw;  
 END CATCH  
END  
  
