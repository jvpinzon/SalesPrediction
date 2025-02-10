WITH OrderDeltas AS (
SELECT 
    custid,
    OrderDate,
    DATEDIFF(DAY, OrderDate, (LEAD(OrderDate) OVER (PARTITION BY custid ORDER BY OrderDate))) AS DaysBetweenOrders
FROM Sales.Orders
),
AverageDays AS (
SELECT 
    custid,
    (SUM(DaysBetweenOrders) / (SELECT COUNT(custid))) AS AvgDaysBetweenOrders
FROM OrderDeltas
GROUP BY custid
)
SELECT 
    (SELECT c.companyname FROM Sales.Customers c WHERE c.custid = o.custid) AS CustomerName,
    MAX(o.OrderDate) AS LastOrderDate,
    DATEADD(DAY, a.AvgDaysBetweenOrders, MAX(o.OrderDate)) AS NextOrderDate
FROM Sales.Orders o
JOIN AverageDays a ON o.custid = a.custid
GROUP BY o.custid, a.AvgDaysBetweenOrders
ORDER BY CustomerName