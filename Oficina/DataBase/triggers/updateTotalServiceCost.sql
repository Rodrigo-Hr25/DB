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
