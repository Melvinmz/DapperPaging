Create PROCEDURE [dbo].[DapperPaging_Employee_GetAll]
@PageNum int,
@PageSize int

AS
BEGIN

WITH TempResult AS
(

	SELECT  [EmpId]
		  ,[FirstName]
		  ,[LastName]
		  ,[Email]
	  FROM [DapperPaging].[dbo].[Employee]
), 
TempCount AS
(
    SELECT COUNT(*) AS  TotalRows FROM TempResult
)
SELECT *
FROM TempResult, TempCount
ORDER BY TempResult.[EmpId]
OFFSET (@PageNum - 1) * @PageSize ROWS
FETCH NEXT @PageSize ROWS ONLY;
  


END