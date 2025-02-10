INSERT INTO
[Sales].[Orders]
(
    Empid,
    Shipperid,
    Shipname,
    Shipaddress,
    Shipcity,
    Orderdate,
    Requireddate,
    Shippeddate,
    Freight,
    Shipcountry
)
VALUES
(
    @EmpId,
    @ShipperId,
    @ShipName, 
    @ShipAddress, 
    @ShipCity, 
    @OrderDate, 
    @RequiredDate, 
    @ShippedDate, 
    @Freight, 
    @ShipCountry
);
SELECT SCOPE_IDENTITY();