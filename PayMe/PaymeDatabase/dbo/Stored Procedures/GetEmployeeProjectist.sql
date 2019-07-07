  
CREATE Proc [dbo].[GetEmployeeProjectist] --[GetExpenseCategoryList] 11,0  
@ProjectID INT,  
@IsActive BIT=NULL  
AS  
BEGIN  
 IF(@IsActive=0)
 BEGIN
 SET @IsActive=NULL;
 END
 SELECT EP.[Id]  
		,EP.[fkEmpID]  AS EmpID
		,E.FirstName+' '+E.LastName AS EmployeeName  
		,EP.[fkProjectID]  AS ProjectID
		,P.ProjectName  
		,EP.[fkTaskID]  AS TaskID
		,T.TaskName  
		,EP.[StartDate]  
		,EP.[EndDate]  
		,EP.[RegularRate]  
		,EP.[OTRate]  
  FROM [dbo].[EmployeeProject] EP  
  INNER JOIN [Employee] E ON E.ID=EP.fkEmpID  
  INNER JOIN [Project] P ON P.ID=EP.fkProjectID  
  INNER JOIN [Task] T ON T.ID=EP.fkTaskID  
  WHERE EP.fkProjectID=@ProjectID 
  --AND E.IsActive=CASE WHEN @IsActive IS NULL  THEN E.IsActive ELSE 1 END AND EP.IsActive=1
   AND EP.IsActive=CASE WHEN @IsActive IS NULL  THEN E.IsActive ELSE 1 END 
  
END  
   
  
