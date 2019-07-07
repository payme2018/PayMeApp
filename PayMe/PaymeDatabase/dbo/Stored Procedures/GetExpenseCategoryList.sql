CREATE Proc [dbo].[GetExpenseCategoryList]
AS
BEGIN

Select ID, Name, Status From [dbo].[ExpenseCategory]

END
 
