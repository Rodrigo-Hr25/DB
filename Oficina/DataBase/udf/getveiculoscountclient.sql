USE OFICINA;
GO

CREATE FUNCTION dbo.GetVehicleCountByClient (@ClienteID VARCHAR(50))
RETURNS INT
AS
BEGIN
    DECLARE @VehicleCount INT;
    SELECT @VehicleCount = COUNT(*)
    FROM VEICULOS
    WHERE ClienteID = @ClienteID;

    RETURN ISNULL(@VehicleCount, 0);
END;
GO
