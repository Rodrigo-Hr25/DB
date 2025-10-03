USE OFICINA;
GO

-- Create View for Vehicle Details
CREATE VIEW vw_VehicleDetails
AS
SELECT VeiculoID, ClienteID, Marca, VIN, TipoVeiculo, Modelo, DataVeiculo, Placa
FROM VEICULOS;
GO


-- Create View for Vehicle Service History
CREATE VIEW vw_ServicesOnVehicle
AS
SELECT v.VeiculoID, s.ServicoID, s.DataServico, s.Descricao, s.Preco
FROM VEICULOS v
JOIN SERVICOS s ON v.VeiculoID = s.VeiculoID;
GO
