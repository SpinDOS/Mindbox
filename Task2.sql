USE Mindbox;

SELECT P.Name, C.Name
FROM dbo.Product AS P
LEFT JOIN dbo.[Product-Category] AS PC
ON P.Id = PC.Product_Id
LEFT JOIN dbo.Category AS C
ON C.Id = PC.Category_Id;

