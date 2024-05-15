CREATE TABLE tblOrder(
	ProductID nvarchar (255),
	SalesOrder nvarchar (255),
	SalesOrderItem nvarchar (255),
	WorkOrder nvarchar (255)  NOT NULL PRIMARY KEY,
	ProductDescription nvarchar (255),
	OrderQuantity decimal,
	OrderStatus nvarchar (255),
	Timestamp datetime DEFAULT GETDATE()
	);

CREATE PROCEDURE spAddOrder          
(          
    @ProductID nvarchar (255),
	@SalesOrder nvarchar (255),
	@SalesOrderItem nvarchar (255),
	@WorkOrder nvarchar (255),
	@ProductDescription nvarchar (255),
	@OrderQuantity decimal,
	@OrderStatus nvarchar (255)            
)          
AS        
BEGIN         
    INSERT into tblOrder (ProductID, SalesOrder, SalesOrderItem, WorkOrder, ProductDescription, OrderQuantity, OrderStatus)           
    VALUES (@ProductID, @SalesOrder, @SalesOrderItem, @WorkOrder, @ProductDescription, @OrderQuantity, @OrderStatus)  
END;

CREATE PROCEDURE spUpdateOrder          
(          
    @ProductID nvarchar(255),
	@SalesOrder nvarchar(255),
	@SalesOrderItem nvarchar(255),
	@WorkOrder nvarchar(255),
	@ProductDescription nvarchar(255),
	@OrderQuantity decimal,
	@OrderStatus nvarchar(255)               
)          
AS           
BEGIN           
    UPDATE tblOrder
    SET 
        ProductID = @ProductID,
		SalesOrder = @SalesOrder,
        SalesOrderItem = @SalesOrderItem,
        WorkOrder = @WorkOrder,
        ProductDescription = @ProductDescription,
        OrderQuantity = @OrderQuantity,
        OrderStatus = @OrderStatus
    WHERE WorkOrder = @WorkOrder;
END;

CREATE PROCEDURE spDeleteOrder          
(          
    @WorkOrder nvarchar(255)       
)          
AS           
BEGIN           
    DELETE FROM tblOrder WHERE WorkOrder = @WorkOrder;
END;

CREATE PROCEDURE spGetAllOrder          
AS           
BEGIN           
    SELECT * FROM tblOrder;
END;