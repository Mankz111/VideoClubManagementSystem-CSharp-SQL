ALTER VIEW vw_AlugueresEmAtraso AS
SELECT
    c.Nome AS NomeCliente,           
    c.NIF AS NIFCliente,             
    c.Email AS EmailCliente, 
    c.Telefone AS TelefoneCliente,
    f.Titulo AS TituloFilme,         
    a.DataAluguer,
    a.DataPrevistaDev,
    DATEDIFF(day, a.DataPrevistaDev, GETDATE()) AS DiasEmAtraso 
FROM Cliente c
JOIN Aluguer a ON c.ClienteID = a.Cliente_ClienteID
JOIN Filme f ON f.FilmeID = a.Filme_FilmeID
WHERE a.DataPrevistaDev < GETDATE() 
  AND a.DataDevolucao IS NULL;