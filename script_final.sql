USE [master]
GO
/****** Object:  Database [Videoclube]    Script Date: 05/06/2025 14:19:40 ******/
CREATE DATABASE [Videoclube]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Videoclube', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Videoclube.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Videoclube_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Videoclube_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Videoclube] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Videoclube].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Videoclube] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Videoclube] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Videoclube] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Videoclube] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Videoclube] SET ARITHABORT OFF 
GO
ALTER DATABASE [Videoclube] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Videoclube] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Videoclube] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Videoclube] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Videoclube] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Videoclube] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Videoclube] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Videoclube] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Videoclube] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Videoclube] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Videoclube] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Videoclube] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Videoclube] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Videoclube] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Videoclube] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Videoclube] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Videoclube] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Videoclube] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Videoclube] SET  MULTI_USER 
GO
ALTER DATABASE [Videoclube] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Videoclube] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Videoclube] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Videoclube] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Videoclube] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Videoclube] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Videoclube] SET QUERY_STORE = ON
GO
ALTER DATABASE [Videoclube] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Videoclube]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteID] [int] IDENTITY(1,1) NOT NULL,
	[NIF] [numeric](9, 0) NOT NULL,
	[Telefone] [numeric](9, 0) NOT NULL,
	[Email] [varchar](100) NULL,
	[Nome] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NIF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GetClientData]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GetClientData]
AS

SELECT

Cliente.ClienteID,
Cliente.Email,
Cliente.NIF,
Cliente.Telefone,
Cliente.Nome

FROM 
Cliente;

GO
/****** Object:  Table [dbo].[Filme]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Filme](
	[FilmeID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[Genero] [varchar](50) NULL,
	[AnoLancamento] [numeric](4, 0) NULL,
	[Realizador] [varchar](100) NULL,
	[Duracao] [numeric](3, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[FilmeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GetFilmeData]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GetFilmeData]
AS

SELECT

Filme.FilmeID,
Filme.Titulo,
Filme.Genero,
Filme.Realizador,
Filme.Duracao,
Filme.AnoLancamento

FROM Filme

GO
/****** Object:  Table [dbo].[Aluguer]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aluguer](
	[AluguerID] [int] IDENTITY(1,1) NOT NULL,
	[DataAluguer] [date] NOT NULL,
	[DataDevolucao] [date] NULL,
	[DataPrevistaDev] [date] NOT NULL,
	[Cliente_ClienteID] [int] NOT NULL,
	[Filme_FilmeID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AluguerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_AlugueresEmAtraso]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_AlugueresEmAtraso] AS
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
GO
/****** Object:  View [dbo].[AluguerData]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AluguerData]
AS
SELECT
    Aluguer.AluguerID,        
    Cliente.Nome AS Cliente,  
    Filme.Titulo AS Filme,
    Aluguer.DataAluguer,
    Aluguer.DataPrevistaDev
FROM
    Aluguer               -- Tabela principal
INNER JOIN
    Cliente ON Aluguer.Cliente_ClienteID = Cliente.ClienteID  -- Junção com Cliente
INNER JOIN
    Filme ON Aluguer.Filme_FilmeID = Filme.FilmeID;  -- Junção com Filme
GO
/****** Object:  View [dbo].[vw_AlugueresPorCliente]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_AlugueresPorCliente]
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
ALTER TABLE [dbo].[Aluguer] ADD  DEFAULT (getdate()) FOR [DataAluguer]
GO
ALTER TABLE [dbo].[Aluguer]  WITH CHECK ADD  CONSTRAINT [FK_Aluguer_Cliente] FOREIGN KEY([Cliente_ClienteID])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
ALTER TABLE [dbo].[Aluguer] CHECK CONSTRAINT [FK_Aluguer_Cliente]
GO
ALTER TABLE [dbo].[Aluguer]  WITH CHECK ADD  CONSTRAINT [FK_Aluguer_Filme] FOREIGN KEY([Filme_FilmeID])
REFERENCES [dbo].[Filme] ([FilmeID])
GO
ALTER TABLE [dbo].[Aluguer] CHECK CONSTRAINT [FK_Aluguer_Filme]
GO
ALTER TABLE [dbo].[Aluguer]  WITH CHECK ADD  CONSTRAINT [CK_DataPrevista] CHECK  (([DataPrevistaDev]>=[DataAluguer]))
GO
ALTER TABLE [dbo].[Aluguer] CHECK CONSTRAINT [CK_DataPrevista]
GO
ALTER TABLE [dbo].[Filme]  WITH CHECK ADD  CONSTRAINT [CK_Duracao_Positiva] CHECK  (([Duracao]>(0)))
GO
ALTER TABLE [dbo].[Filme] CHECK CONSTRAINT [CK_Duracao_Positiva]
GO
ALTER TABLE [dbo].[Filme]  WITH CHECK ADD  CONSTRAINT [CK_Filme_AnoLancamento] CHECK  (([AnoLancamento]<=datepart(year,getdate()) AND [AnoLancamento]>=(1888)))
GO
ALTER TABLE [dbo].[Filme] CHECK CONSTRAINT [CK_Filme_AnoLancamento]
GO
ALTER TABLE [dbo].[Filme]  WITH CHECK ADD  CONSTRAINT [CK_Filme_Duracao] CHECK  (([Duracao]>(0) AND [Duracao]<(500)))
GO
ALTER TABLE [dbo].[Filme] CHECK CONSTRAINT [CK_Filme_Duracao]
GO
/****** Object:  StoredProcedure [dbo].[CreateAluguer]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateAluguer]
-- @AluguerID int, -- REMOVIDO: Assumindo que AluguerID é IDENTITY e é gerado pela base de dados
@DataAluguer Date,
-- @DataDevolucao Date, -- MODIFICADO: Agora permite NULL
@DataPrevistaDev Date,
@Nome varchar(100),
@Titulo varchar(100),
@DataDevolucao Date = NULL -- ADICIONADO/MODIFICADO: Permite que este parâmetro seja NULL
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Verifica se o cliente já existe
    IF NOT EXISTS (SELECT * FROM Cliente WHERE Nome = @Nome)
    BEGIN
        INSERT INTO Cliente (Nome) VALUES (@Nome)
    END

    -- Verifica se o filme já existe
    IF NOT EXISTS (SELECT * FROM Filme WHERE Titulo = @Titulo)
    BEGIN
        INSERT INTO Filme (Titulo) VALUES (@Titulo)
    END

    -- Insere o aluguer
    -- REMOVIDO AluguerID da lista de colunas, pois a base de dados irá gerá-lo (IDENTITY)
    INSERT INTO Aluguer (DataAluguer, DataDevolucao, DataPrevistaDev, Cliente_ClienteID, Filme_FilmeID)
    VALUES
    (
        @DataAluguer,
        @DataDevolucao, -- Este valor será NULL se não for fornecido ou for NULL no código C#
        @DataPrevistaDev,
        (SELECT ClienteID FROM Cliente WHERE Nome = @Nome),
        (SELECT FilmeID FROM Filme WHERE Titulo = @Titulo)
    );

    -- Se precisar de obter o AluguerID gerado (útil após uma inserção IDENTITY)
    -- SELECT SCOPE_IDENTITY();

END

GO
/****** Object:  StoredProcedure [dbo].[CreateClient]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateClient] -- Alterado de CREATE para ALTER
    @Nome varchar(100),
    @Email varchar(100),
    @NIF numeric(9,0),
    @Telefone numeric(9,0)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Tenta inserir os dados diretamente.
    -- A base de dados irá lançar uma exceção (SqlException com erro 2627 ou 2601)
    -- se o NIF já existir devido à constraint UNIQUE na tabela Cliente.
    INSERT INTO Cliente (Nome, Email, NIF, Telefone)
    VALUES (@Nome, @Email, @NIF, @Telefone);

    -- Não é necessária lógica adicional aqui para verificar duplicados de NIF,
    -- pois a constraint da tabela já faz isso e lança o erro apropriado.

END
GO
/****** Object:  StoredProcedure [dbo].[CreateFilme]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateFilme]

@Titulo varchar(100),
@Genero varchar(50),
@Realizador varchar(100),
@Duracao numeric(3,0),
@AnoLancamento numeric(4,0)

AS 

if not exists(select * from Filme where Titulo = @Titulo)
INSERT INTO Filme (Titulo, Genero, Realizador, Duracao, AnoLancamento)
VALUES
(
@Titulo,
@Genero,
@Realizador,
@Duracao,
@AnoLancamento
);
GO
/****** Object:  StoredProcedure [dbo].[CriarAluguer]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. Recria a stored procedure com o nome correto da tabela
CREATE PROCEDURE [dbo].[CriarAluguer]
    @Cliente_ClienteID INT,
    @Filme_FilmeID INT,
    @DataAluguer DATE,
    @DataDevolucaoPrevista DATE
AS
BEGIN
    -- Verifica se o cliente existe
    IF NOT EXISTS (SELECT 1 FROM Cliente WHERE ClienteID = @Cliente_ClienteID)
    BEGIN
        RAISERROR('Cliente não encontrado!', 16, 1);
        RETURN;
    END

    -- Verifica se o filme existe
    IF NOT EXISTS (SELECT 1 FROM Filme WHERE FilmeID = @Filme_FilmeID)
    BEGIN
        RAISERROR('Filme não encontrado!', 16, 1);
        RETURN;
    END

    -- Insere o aluguer na tabela 'Aluguer'
    INSERT INTO Aluguer (
        Cliente_ClienteID,
        Filme_FilmeID,
        DataAluguer,
        DataPrevistaDev
    )
    VALUES (
        @Cliente_ClienteID,
        @Filme_FilmeID,
        @DataAluguer,
        @DataDevolucaoPrevista
    );
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCliente]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCliente]

@ClienteID int 

AS

delete from Cliente WHERE ClienteID=@ClienteID

GO
/****** Object:  StoredProcedure [dbo].[DeleteFilme]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteFilme]

@FilmeID int

AS

DELETE FROM Filme where FilmeID=@FilmeID

GO
/****** Object:  StoredProcedure [dbo].[GetAluguerData]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAluguerData]
    @AluguerID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        a.AluguerID,
        a.DataAluguer,
        a.DataPrevistaDev,
        a.DataDevolucao,
        c.Nome,
        f.Titulo,
        a.Cliente_ClienteID,
        a.Filme_FilmeID      
    FROM Aluguer a
    JOIN Cliente c ON a.Cliente_ClienteID = c.ClienteID
    JOIN Filme f ON a.Filme_FilmeID = f.FilmeID
    WHERE a.AluguerID = @AluguerID;
END

GO
/****** Object:  StoredProcedure [dbo].[GetAlugueresPorDataSP]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAlugueresPorDataSP]
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
/****** Object:  StoredProcedure [dbo].[GetAlugueresRecentes]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAlugueresRecentes]
    @Quantidade INT = 10
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP (@Quantidade)
        a.AluguerID,
        a.Cliente_ClienteID,
        a.Filme_FilmeID,
        a.DataAluguer,
        a.DataPrevistaDev,
        a.DataDevolucao,
        c.Nome,
        f.Titulo
    FROM Aluguer a
    JOIN Cliente c ON a.Cliente_ClienteID = c.ClienteID
    JOIN Filme f ON a.Filme_FilmeID = f.FilmeID
    ORDER BY a.DataAluguer DESC;
END

GO
/****** Object:  StoredProcedure [dbo].[GetHistoricoByClienteID]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetHistoricoByClienteID]
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        a.AluguerID,
        a.Cliente_ClienteID,
        a.Filme_FilmeID,
        a.DataAluguer,
        a.DataPrevistaDev,
        a.DataDevolucao,
        c.Nome,
        f.Titulo
    FROM Aluguer a
    JOIN Cliente c ON a.Cliente_ClienteID = c.ClienteID
    JOIN Filme f ON a.Filme_FilmeID = f.FilmeID
    WHERE a.Cliente_ClienteID = @ClienteID
    ORDER BY a.DataAluguer DESC; 
END

GO
/****** Object:  StoredProcedure [dbo].[GetOngoingAlugueres]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOngoingAlugueres]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        a.AluguerID,
        a.Cliente_ClienteID,
        a.Filme_FilmeID,
        a.DataAluguer,
        a.DataPrevistaDev,
        a.DataDevolucao,
        c.Nome,
        f.Titulo
    FROM Aluguer a
    JOIN Cliente c ON a.Cliente_ClienteID = c.ClienteID
    JOIN Filme f ON a.Filme_FilmeID = f.FilmeID
    WHERE a.DataDevolucao IS NULL
    ORDER BY a.DataPrevistaDev ASC;
END

GO
/****** Object:  StoredProcedure [dbo].[GetTodosAlugueres]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTodosAlugueres]
AS
BEGIN
    SELECT
        a.AluguerID,
        a.DataAluguer,
        a.DataPrevistaDev,
        a.DataDevolucao, -- Incluir DataDevolucao
        c.ClienteID,     -- Incluir ClienteID
        c.Nome,
        f.FilmeID,       -- Incluir FilmeID
        f.Titulo
    FROM
        Aluguer a
    JOIN
        Cliente c ON a.Cliente_ClienteID = c.ClienteID
    JOIN
        Filme f ON a.Filme_FilmeID = f.FilmeID;
END

GO
/****** Object:  StoredProcedure [dbo].[GetTopFilmes]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetTopFilmes]
    @QtdFilmes INT = 5
AS
BEGIN
    SELECT TOP (@QtdFilmes)
        f.FilmeID,
        f.Titulo,
        COUNT(a.AluguerID) AS TotalAlugueres
    FROM Filme f
    JOIN Aluguer a ON f.FilmeID = a.Filme_FilmeID
    GROUP BY f.FilmeID, f.Titulo
    ORDER BY COUNT(a.AluguerID) DESC
END
GO
/****** Object:  StoredProcedure [dbo].[IsFilmeAlugado]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IsFilmeAlugado]
    @FilmeID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*)
    FROM Aluguer
    WHERE Filme_FilmeID = @FilmeID
    AND DataDevolucao IS NULL;
END

GO
/****** Object:  StoredProcedure [dbo].[MarkAluguerAsReturned]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MarkAluguerAsReturned]
    @AluguerID INT,
    @DataDevolucao DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Aluguer
    SET DataDevolucao = @DataDevolucao
    WHERE AluguerID = @AluguerID
    AND DataDevolucao IS NULL; 


    SELECT @@ROWCOUNT;
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateAluguer]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[UpdateAluguer]
    @AluguerID       INT,
    @DataAluguer     DATETIME,
    @DataPrevistaDev DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Aluguer
       SET DataAluguer     = @DataAluguer,
           DataPrevistaDev = @DataPrevistaDev
     WHERE AluguerID = @AluguerID;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateCliente]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCliente]

@ClienteID int,
@Nome varchar(50),
@Email varchar(50),
@NIF numeric(9,0),
@Telefone numeric(9,0)
AS
BEGIN


    UPDATE Cliente SET
        Nome = @Nome,
        Email = @Email,
        NIF = @NIF,
        Telefone = @Telefone
    WHERE ClienteID = @ClienteID;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateFilme]    Script Date: 05/06/2025 14:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateFilme]

@FilmeID int,
@Titulo varchar(100),
@Genero varchar(50),
@Realizador varchar(100),
@Duracao numeric(3,0),
@AnoLancamento numeric(4,0)

AS
BEGIN

UPDATE Filme SET
Titulo = @Titulo,
Genero = @Genero,
Realizador = @Realizador,
Duracao = @Duracao,
AnoLancamento = @AnoLancamento

WHERE FilmeID = @FilmeID;

END
GO
USE [master]
GO
ALTER DATABASE [Videoclube] SET  READ_WRITE 
GO
