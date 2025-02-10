INSERT INTO [Sales].[OrderDetails]
(
    Orderid,
    Productid,
    Unitprice,
    Qty,
    Discount
)
VALUES
(
    @OrderId,
    @ProductId,
    @UnitPrice,
    @Qty,
    @Discount
);