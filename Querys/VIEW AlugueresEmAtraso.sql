CREATE VIEW vw_AlugueresEmAtraso AS
SELECT
    c.Nome AS NomeCliente,           
    c.NIF AS NIFCliente,             
    f.Titulo AS TituloFilme,         
    a.DataAluguer,
    a.DataPrevistaDev
FROM Cliente c
JOIN Aluguer a ON c.ClienteID = a.Cliente_ClienteID
JOIN Filme f ON f.FilmeID = a.Filme_FilmeID
WHERE a.DataPrevistaDev < GETDATE() 
  AND a.DataDevolucao IS NULL; 