-- SQLBook: Code
-- Dropping existing procedures if they exist

GO
DROP PROCEDURE IF EXISTS add_funcionario;
GO
CREATE PROCEDURE add_funcionario 
    @funcionarioID VARCHAR(50),
    @nome VARCHAR(50),
    @telefone VARCHAR(9),
    @morada VARCHAR(50),
    @email VARCHAR(50),
    @salario VARCHAR(10),
    @cargo VARCHAR(50)
AS       
BEGIN
    INSERT INTO FUNCIONARIOS (FuncionarioID, Nome, Telefone, Morada, Email, Salario, Cargo)
    VALUES (@funcionarioID, @nome, @telefone, @morada, @email, @salario, @cargo)
END
GO

DROP PROCEDURE IF EXISTS add_cliente;
GO
CREATE PROCEDURE add_cliente 
    @clienteID VARCHAR(50),
    @nome VARCHAR(50),
    @telefone VARCHAR(9),
    @morada VARCHAR(50),
    @email VARCHAR(50)
AS
BEGIN
    INSERT INTO CLIENTES (ClienteID, Nome, Telefone, Morada, Email)
    VALUES (@clienteID, @nome, @telefone, @morada, @email)
END
GO

DROP PROCEDURE IF EXISTS add_veiculo;
GO
CREATE PROCEDURE add_veiculo 
    @veiculoID VARCHAR(50),
    @clienteID VARCHAR(50),
    @marca VARCHAR(50),
    @modelo VARCHAR(50),
    @dataVeiculo DATE,
    @placa VARCHAR(8)
AS
BEGIN
    INSERT INTO VEICULOS (VeiculoID, ClienteID, Marca, Modelo, DataVeiculo, Placa)
    VALUES (@veiculoID, @clienteID, @marca, @modelo, @dataVeiculo, @placa)
END
GO

DROP PROCEDURE IF EXISTS add_encomenda;
GO
CREATE PROCEDURE add_encomenda 
    @ordemServicoID VARCHAR(50), 
    @veiculoID VARCHAR(50),
    @data DATE,
    @servicoID VARCHAR(50),
    @precoFinal VARCHAR(10),
    @status VARCHAR(10)
AS
BEGIN
    INSERT INTO ENCOMENDA (OrdemServicoID, VeiculoID, Data, ServicoID, PrecoFinal, Status)
    VALUES (@ordemServicoID, @veiculoID, @data, @servicoID, @precoFinal, @status)
END
GO

DROP PROCEDURE IF EXISTS add_servico;
GO
CREATE PROCEDURE add_servico 
    @servicoID VARCHAR(50),
    @descricao VARCHAR(255),
    @preco VARCHAR(10),
    @clienteID VARCHAR(50)
AS
BEGIN
    INSERT INTO SERVICOS (ServicoID, Descricao, Preco, ClienteID)
    VALUES (@servicoID, @descricao, @preco, @clienteID)
END
GO

DROP PROCEDURE IF EXISTS add_peca;
GO
CREATE PROCEDURE add_peca 
    @pecaID VARCHAR(50), 
    @descricao VARCHAR(255),
    @preco VARCHAR(10),
    @quantidadeStock VARCHAR(10)
AS
BEGIN
    INSERT INTO PECAS (PecaID, Descricao, Preco, QuantidadeStock)
    VALUES (@pecaID, @descricao, @preco, @quantidadeStock)
END
GO

DROP PROCEDURE IF EXISTS add_order_servico;
GO
CREATE PROCEDURE add_order_servico 
    @ordemServicoID VARCHAR(50),
    @pecaID VARCHAR(50),
    @quantidade VARCHAR(10)
AS
BEGIN
    INSERT INTO ORDERSERVICE (OrdemServicoID, PecaID, Quantidade)
    VALUES (@ordemServicoID, @pecaID, @quantidade)
END
GO
