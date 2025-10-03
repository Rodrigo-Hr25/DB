USE OFICINA;
GO

-- Insert Vehicle
CREATE PROCEDURE dbo.InsertVehicle
    @VeiculoID VARCHAR(50) OUTPUT,
    @ClienteID VARCHAR(50),
    @Marca VARCHAR(50),
    @VIN VARCHAR(17),
    @TipoVeiculo VARCHAR(50),
    @Modelo VARCHAR(50),
    @DataVeiculo VARCHAR(15),
    @Placa VARCHAR(8)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM CLIENTES WHERE ClienteID = @ClienteID)
    BEGIN
        RAISERROR(N'Cliente não encontrado', 16, 1)
        RETURN
    END;
    DECLARE @NewID VARCHAR(50)
    SET @NewID = NEWID()

    INSERT INTO VEICULOS (VeiculoID, ClienteID, Marca, VIN, TipoVeiculo, Modelo, DataVeiculo, Placa)
    VALUES (@NewID, @ClienteID, @Marca, @VIN, @TipoVeiculo, @Modelo, @DataVeiculo, @Placa)

    SET @VeiculoID = @NewID
END;
GO


-- Update Vehicle

CREATE PROCEDURE dbo.UpdateVehicle
    @VeiculoID VARCHAR(50),
    @ClienteID VARCHAR(50),
    @Marca VARCHAR(50),
    @VIN VARCHAR(17),
    @TipoVeiculo VARCHAR(50),
    @Modelo VARCHAR(50),
    @DataVeiculo VARCHAR(15),
    @Placa VARCHAR(8)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM CLIENTES WHERE ClienteID = @ClienteID)
    BEGIN
        RAISERROR(N'Cliente não encontrado', 16, 1)
        RETURN
    END;

    UPDATE VEICULOS
    SET ClienteID = @ClienteID,
        Marca = @Marca,
        VIN = @VIN,
        TipoVeiculo = @TipoVeiculo,
        Modelo = @Modelo,
        DataVeiculo = @DataVeiculo,
        Placa = @Placa
    WHERE VeiculoID = @VeiculoID
END;
GO


-- Delete Vehicle

CREATE PROCEDURE dbo.DeleteVehicle
    @VeiculoID VARCHAR(50)
AS
BEGIN
    DELETE FROM VEICULOS
    WHERE VeiculoID = @VeiculoID
END;
GO


-- Assign Vehicle to piece
CREATE PROCEDURE dbo.AssignPartToVehicle
    @VeiculoID VARCHAR(50),
    @PecaID VARCHAR(50)
AS
BEGIN
    INSERT INTO PECAS_VEICULOS (VeiculoID, PecaID)
    VALUES (@VeiculoID, @PecaID)
END;
GO
