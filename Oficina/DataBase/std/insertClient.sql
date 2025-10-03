USE OFICINA;
GO

-- Insert Client
CREATE PROCEDURE dbo.InsertClient
    @Nome VARCHAR(50),
    @Telefone VARCHAR(9),
    @Email VARCHAR(50),
    @Morada VARCHAR(50),
    @ClienteID VARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewID VARCHAR(50)
    SET @NewID = NEWID()

    INSERT INTO CLIENTES (clienteID, Nome, Telefone, Email, Morada)
    VALUES (@NewID, @Nome, @Telefone, @Email, @Morada)

    SET @ClienteID = @NewID
END;
GO

-- Update Client

CREATE PROCEDURE dbo.UpdateClient
    @ClienteID VARCHAR(50),
    @Nome VARCHAR(50),
    @Telefone VARCHAR(9),
    @Email VARCHAR(50),
    @Morada VARCHAR(50)
AS
BEGIN
    UPDATE CLIENTES
    SET Nome = @Nome,
        Telefone = @Telefone,
        Email = @Email,
        Morada = @Morada
    WHERE clienteID = @ClienteID
END;
GO

-- Delete Client
CREATE PROCEDURE dbo.DeleteClient
    @ClienteID VARCHAR(50)
AS
BEGIN
    DELETE FROM CLIENTES
    WHERE clienteID = @ClienteID
END;
GO


