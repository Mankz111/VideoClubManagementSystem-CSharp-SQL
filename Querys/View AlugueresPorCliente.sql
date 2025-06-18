CREATE VIEW vw_AlugueresPorCliente
AS
SELECT 
    c.ClienteID,              
    c.Nome       AS NomeCliente,
    c.NIF        AS NIFCliente,
    COUNT(a.AluguerID) AS TotalAlugueres
FROM Cliente c
LEFT JOIN Aluguer a
    ON a.Cliente_ClienteID = c.ClienteID
GROUP BY
    c.ClienteID, c.Nome, c.NIF;
GO


