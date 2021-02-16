-- Create a new tabdbo.product' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.product', 'U') IS NOT NULL
DROP TABLE dbo.product
GO
-- Create the table in the specified schema
CREATE TABLE dbo.product(
    Id INT NOT NULL PRIMARY KEY, -- primary key column
    productName [NVARCHAR](20) NOT NULL,
    productDetail [NVARCHAR](150) NOT NULL
    -- specify more columns here
);
GO

select *
from product

insert into product
select 1,'rides','rides for smoth street'