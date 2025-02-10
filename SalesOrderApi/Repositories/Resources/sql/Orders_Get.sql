SELECT 
    OrderId,
    RequiredDate,
    ShippedDate,
    ShipName,
    ShipAddress,
    ShipCity
FROM [Sales].[Orders]
WHERE custid = @ClientId;