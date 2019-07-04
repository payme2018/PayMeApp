


/*
    This procedure creates a employee.
    Change History:
    12/16/2018, Dinesh Kalyanasundaram
    Original Creation
*/
CREATE PROCEDURE [dbo].[CreateUser] (
	@FirstName VARCHAR(256)
	,@LastName VARCHAR(256)
	,@Email VARCHAR(256)
	,@DateOfJoining DATETIME = NULL
	,@DOB DATETIME
	,@Designation VARCHAR(200) = NULL
	,@EmployeeCode VARCHAR(200) =NULL
	,@Gender INT
	,@UserName VARCHAR(200)
	,@Password VARCHAR(200)
	,@MobileNo VARCHAR(20)=null
	,@RoleID INT
	,@CreatedBy VARCHAR(200)
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
	DECLARE @TransactionName NVARCHAR(32) = 'Userpayme';

	BEGIN TRY
		

		DECLARE @EmpID INT;
		DECLARE @EmailExists NVARCHAR(256);
		DECLARE @UserNameExists NVARCHAR(256);

		SET @EmailExists = (
				SELECT TOP 1 EmailID
				FROM Employee
				WHERE EmailID = @Email
				)
		SET @UserNameExists = (
				SELECT TOP 1 UserName
				FROM [User]
				WHERE Username = @UserName
				)

		IF (
				@EmailExists IS NOT NULL
				OR @UserNameExists IS NOT NULL
				)
		BEGIN
			IF (@EmailExists IS NOT NULL)
			BEGIN
				SET @output = 2; -- EmailID Already Exist
			END

			IF (@UserNameExists IS NOT NULL)
			BEGIN
				SET @output = 3; -- UserName Already Exist
			END
		END
		ELSE
		BEGIN
		BEGIN TRANSACTION;

		SAVE TRANSACTION @TransactionName;
			INSERT INTO Employee (
				FirstName
				,LastName
				,JoiningDate
				,DOB
				,Gender
				,EmailID
				,Designation
				,WorkingHoursPerDay
				,EmployeeCode
				,fkDepartmentID
				,fkManagerId
				,IsActive
				,Createdate
				,UpdatedDate
				,CreatedBy
				,PassportNo
                ,PassportIssuedBy
                ,PassportIssuedOn
                ,PassportExpireOn
                ,VISANo
                ,VISAIssuedBy
                ,VISAIssuedOn
                ,VISAExpireOn
                ,LabourCardNo
                ,LabourCardIssuedBy
                ,LabourCardIssuedOn
                ,LabourCardExpireOn
				,AccountID
				,fkEmploymentLocationID
				,MobileNo
				)
			VALUES (
				@FirstName
				,@LastName
				,@DateOfJoining
				,@DOB
				,@Gender
				,@Email
				,@Designation
				,8
				,@EmployeeCode
				,@fkDepartmentID
				,@fkManagerId
				,1
				,GETUTCDATE()
				,GETUTCDATE()
				,@CreatedBy
				,@PassportNo
                ,@PassportIssuedBy
                ,@PassportIssuedOn
                ,@PassportExpireOn
                ,@VISANo
                ,@VISAIssuedBy
                ,@VISAIssuedOn
                ,@VISAExpireOn
                ,@LabourCardNo
                ,@LabourCardIssuedBy
                ,@LabourCardIssuedOn
                ,@LabourCardExpireOn
				,@AccountID
				,@fkEmploymentLocationID
				,@MobileNo
				)

			--Get last inserted EmpId
			SET @EmpID = (
					SELECT Scope_Identity()
					)

			INSERT INTO [User] (
				fkEmpID
				,UserName
				,[Password]
				,fkRoleId
				,IsActive
				)
			VALUES (
				@EmpID
				,@UserName
				,@Password
				,@RoleID
				,1
				)

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
