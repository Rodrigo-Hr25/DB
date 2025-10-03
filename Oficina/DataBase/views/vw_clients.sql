USE OFICINA;
GO

CREATE VIEW vw_ClientAndVehiclesWithCount
AS
SELECT
    c.clienteID,
    c.Nome AS ClienteNome,
    c.Telefone AS ClienteTelefone,
    c.Email AS ClienteEmail,
    c.Morada AS ClienteMorada,
    v.VeiculoID,
    v.Marca,
    v.VIN,
    v.TipoVeiculo,
    v.Modelo,
    v.DataVeiculo,
    v.Placa,
    dbo.GetVehicleCountByClient(c.clienteID) AS NumeroDeVeiculos
FROM CLIENTES c
LEFT JOIN VEICULOS v ON c.clienteID = v.ClienteID;
GO
