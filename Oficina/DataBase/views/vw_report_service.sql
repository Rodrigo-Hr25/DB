-- SQLBook: Code
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