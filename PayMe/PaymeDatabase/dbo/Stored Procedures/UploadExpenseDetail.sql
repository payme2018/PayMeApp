CREATE PROCEDURE [dbo].[UploadExpenseDetail]
(                                 
 @ExpenseDetail AS [dbo].[ExpenseDetailType] READONLY                
)                    
AS   
BEGIN 

DECLARE @Upload TABLE -- SIMULATES HLMCServiceWorklogTaskMapping                   
    (                   
     [ExpenseSummaryID] [int] NOT NULL,
	[Category] [nvarchar](400)  NULL,
	[BillNo] [nvarchar](400)  NULL,
	[Amount] [decimal](18, 2)  NULL,
	[BillDate] [datetime] null,
	[Location] [nvarchar](250) NULL,
	[Notes] [nvarchar](250) NULL,	
	[Error] [varchar](500) NULL	
    );        

	INSERT INTO @Upload([ExpenseSummaryID],[Category],[BillNo],[Amount],[BillDate],[Location],[Notes])  
    SELECT [ExpenseSummaryID],[Category],[BillNo],[Amount],[BillDate],[Location],[Notes] FROM @ExpenseDetail A  

	
DECLARE @ErrorCount INT  
IF OBJECT_ID('tempdb.dbo.#Validation', 'U') IS NOT NULL                  
 BEGIN                  
  DROP TABLE #Validation;                   
 END  

SELECT O.*,EC.ID AS CategoryIdS 
INTO #Validation
FROM @Upload O
LEFT OUTER JOIN [dbo].[ExpenseCategory] EC ON EC.Name=O.Category

UPDATE V SET V.Error='| '+      
   CASE WHEN V.CategoryIdS is null THEN 'Invalid Category | ' else '' end +       
   CASE WHEN V.BillNo is null THEN 'BillNo should not empty | ' else '' end +   
   CASE WHEN V.Amount is null THEN 'Amount should not empty | ' else '' end        
FROM #Validation V          
WHERE  V.CategoryIdS IS NULL OR V.BillNo IS NULL OR V.Amount IS NULL 


UPDATE V SET V.Error='Validation Success'   
FROM #Validation V          
WHERE  V.CategoryIds IS NOT NULL AND V.BillNo IS NOT NULL AND V.Amount IS NOT NULL 


SET @ErrorCount=(SELECT COUNT(1) FROM #Validation WHERE Error<>'Validation Success')  
IF (@ErrorCount<=0)  
  BEGIN     
		INSERT INTO [dbo].[ExpenseDetail]
           ([CategoryID]
           ,[ExpenseSummaryID]
           ,[CurrencyBillNo]
           ,[Amount]
           ,[BillDate]
           ,[Location]
           ,[HasAttachment]
           ,[Notes])
		SELECT CategoryIdS,ExpenseSummaryID,BillNo,Amount,BillDate,Location,0 AS HasAttachment,Notes FROM #Validation where Error='Validation Success'  

          SELECT
  			Category AS CategoryName,
  			BillNo AS CurrencyBillNo,	
			Amount	AS Amount,
			BillDate AS BillDate,	
			Location AS Location,	
			Notes AS Notes,
			Error AS Error
		  FROM #Validation WHERE Error<>'Validation Success'  

  END
  ELSE
  BEGIN 
	 SELECT
  			Category AS CategoryName,
  			BillNo AS CurrencyBillNo,	
			Amount	AS Amount,
			BillDate AS BillDate,	
			Location AS Location,	
			Notes AS Notes,
			Error AS Error
		  FROM #Validation WHERE Error<>'Validation Success'  
  END

END

