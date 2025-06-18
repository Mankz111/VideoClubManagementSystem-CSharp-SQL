CREATE PROCEDURE GetAlugueresPorDataSP
	@DataInicial DATE,
	@DataFinal DATE

AS
BEGIN
	SET NOCOUNT ON;
	
SELECT 
	c.Nome AS Cliente, 
	f.Titulo AS Filme,
	a.DataAluguer,
	a.DataPrevistaDev,
	a.DataDevolucao
FROM Aluguer a
JOIN Cliente c ON c.ClienteID = a.Cliente_ClienteID
JOIN Filme f ON f.FilmeID = a.Filme_FilmeID
WHERE a.DataAluguer BETWEEN @DataInicial AND @DataFinal
ORDER BY a.DataAluguer;
END
GO



