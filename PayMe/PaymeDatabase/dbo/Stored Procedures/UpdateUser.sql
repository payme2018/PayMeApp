


/*
    This procedure creates a employee.
    Change History:
    12/16/2018, Dinesh Kalyanasundaram
    Original Creation
*/
CREATE PROCEDURE [dbo].[UpdateUser] (
    @ID int
	,@FirstName VARCHAR(256)
	,@LastName VARCHAR(256)
	,@Email VARCHAR(256)
	,@DateOfJoining DATETIME = NULL
	,@DOB DATETIME
	,@Designation VARCHAR(200) = NULL
	,@EmployeeCode VARCHAR(200) =NULL
	,@Gender INT
	,@RoleID INT
	,@MobileNo VARCHAR(20)=null
	,@PassportNo VARCHAR(100)= NULL
    ,@PassportIssuedBy VARCHAR(250)= NULL
    ,@PassportIssuedOn DATEtime= NULL
    ,@PassportExpireOn DATEtime= NULL
    ,@VISANo  VARCHAR(100)= NULL
    ,@VISAIssuedBy  VARCHAR(250)= NULL
    ,@VISAIssuedOn DATEtime= NULL
    ,@VISAExpireOn DATEtime= NULL
    ,@LabourCardNo VARCHAR(100)= NULL
    ,@LabourCardIssuedBy VARCHAR(250)= NULL
    ,@LabourCardIssuedOn DATEtime= NULL
    ,@LabourCardExpireOn DATEtime= NULL
	,@AccountID int =NULL
	,@fkDepartmentID int =Null
	,@fkManagerId int =null
	,@fkEmploymentLocationID INT = NULL
	,@output INT OUTPUT
	)
AS
BEGIN
	DECLARE @TransactionName NVARCHAR(32) = 'UserpaymeUpdate';

	BEGIN TRY
		

		DECLARE @EmpID INT;
		DECLARE @EmailExists NVARCHAR(256);
		
		SET @EmailExists = (
				SELECT TOP 1 EmailID
				FROM Employee
				WHERE EmailID = @Email and ID != @ID)
		

		IF (
				@EmailExists IS NOT NULL
				
				)
		BEGIN
			IF (@EmailExists IS NOT NULL)
			BEGIN
				SET @output = 2; -- EmailID Already Exist
			END

			
		END
		ELSE
		BEGIN
		BEGIN TRANSACTION;
		SAVE TRANSACTION @TransactionName;
			

		update Employee set                 
		         FirstName =@FirstName,LastName = @LastName
				,JoiningDate =@DateOfJoining
				,DOB =@DOB
				,Gender =@Gender
				,EmailID =@Email
				,Designation =@Designation
				
				,EmployeeCode = @EmployeeCode
				,fkDepartmentID =@fkDepartmentID
				,fkManagerId =@fkManagerId
				
				
				,UpdatedDate =GETUTCDATE()
			 
				,PassportNo =@PassportNo
                ,PassportIssuedBy = @PassportIssuedBy
                ,PassportIssuedOn =@PassportIssuedOn
                ,PassportExpireOn =@PassportExpireOn
                ,VISANo =@VISANo
                ,VISAIssuedBy =@VISAIssuedBy
                ,VISAIssuedOn =@VISAIssuedOn
                ,VISAExpireOn =@VISAExpireOn
                ,LabourCardNo =@LabourCardNo
                ,LabourCardIssuedBy =@LabourCardIssuedBy
                ,LabourCardIssuedOn =@LabourCardIssuedOn
                ,LabourCardExpireOn =@LabourCardExpireOn
				
				,fkEmploymentLocationID =@fkEmploymentLocationID
				,MobileNo= @MobileNo
				WHERE ID = @ID
		
		    Update [User] set fkRoleId = @RoleID where fkEmpID = @ID
			

			SET @output = 1; --Inserted Successfully

			COMMIT;
		END
	END TRY

	BEGIN CATCH
		IF @@trancount > 0
			ROLLBACK TRANSACTION @TransactionName;

		throw;
	END CATCH
END
