USE OFICINA;
GO

CREATE VIEW vw_ServiceDetails
AS
SELECT
    s.ServicoID,
    s.DataServico,
    s.Descricao,
    s.Preco AS ServicePrice,
    v.VeiculoID,
    v.Marca,
    v.Modelo,
    c.clienteID,
    c.Nome AS ClienteNome,
    c.Telefone AS ClienteTelefone,
    c.Email AS ClienteEmail,
    c.Morada AS ClienteMorada
FROM
    SERVICOS s
    JOIN VEICULOS v ON s.VeiculoID = v.VeiculoID
    JOIN CLIENTES c ON v.ClienteID = c.clienteID;
GO


-- UDF
USE OFICINA;
GO

CREATE FUNCTION dbo.CalculateTotalServiceCost (@VeiculoID VARCHAR(50))
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @TotalCost DECIMAL(10, 2)
    SELECT @TotalCost = SUM(CAST(Preco AS DECIMAL(10, 2)))
    FROM SERVICOS
    WHERE VeiculoID = @VeiculoID
    RETURN ISNULL(@TotalCost, 0)
END;
GO


-- Trigger

USE OFICINA;
GO

ALTER TABLE VEICULOS ADD TotalServiceCost DECIMAL(10, 2) DEFAULT 0;
GO

CREATE TRIGGER trg_UpdateTotalServiceCost
ON SERVICOS
AFTER INSERT, DELETE
AS
BEGIN
    DECLARE @VeiculoID VARCHAR(50)

    -- Handle insert
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        SELECT @VeiculoID = VeiculoID FROM inserted
        UPDATE VEICULOS
        SET TotalServiceCost = dbo.CalculateTotalServiceCost(@VeiculoID)
        WHERE VeiculoID = @VeiculoID
    END

    -- Handle delete
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @VeiculoID = VeiculoID FROM deleted
        UPDATE VEICULOS
        SET TotalServiceCost = dbo.CalculateTotalServiceCost(@VeiculoID)
        WHERE VeiculoID = @VeiculoID
    END
END;
GO


-- UDF
CREATE FUNCTION dbo.GetClientDetails (@ClienteID VARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT clienteID, Nome, Telefone, Email, Morada
    FROM CLIENTES
    WHERE clienteID = @ClienteID
);
GO


CREATE TABLE ClientInsertLog (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID VARCHAR(50),
    Nome VARCHAR(50),
    InsertedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TRIGGER trg_LogClientInsert
ON CLIENTES
AFTER INSERT
AS
BEGIN
    INSERT INTO ClientInsertLog (ClienteID, Nome)
    SELECT clienteID, Nome
    FROM inserted;
END;
GO
