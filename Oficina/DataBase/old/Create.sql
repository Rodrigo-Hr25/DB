-- SQLBook: Code
/*-------------- Creation of entities -------------*/

GO
CREATE PROC add_empregado @funcionarioID INT,
                          @nome VARCHAR(50),
                          @telefone VARCHAR(9),
                          @morada VARCHAR(50),
                          @email VARCHAR(50),
                          @salario INT,
                          @cargo VARCHAR(50)
AS       
    BEGIN
        INSERT INTO FUNCIONARIOS (FuncionarioID ,Nome, Telefone, Morada, Email, Salario, Cargo)
        VALUES (@funcionarioID, @nome, @telefone, @morada, @email, @salario, @cargo)
    END


GO
CREATE PROC add_cliente @clienteID INT,
                        @nome VARHCAR(50),
                        @telefone VARCHAR(9),
                        @morada VARCHAR(50),
                        @email VARCHAR(50)
AS
    BEGIN
        INSERT INTO CLIENTES (ClienteID, Nome, Telefone, Morada, Email)
        VALUES (@clienteID, @nome, @telefone, @morada, @email)
    END

GO 
CREATE PROC add_veiculo @veiculoID INT,
                        @clienteID INT,
                        @marca VARCHAR(50),
                        @modelo VARCHAR(50),
                        @dataVeiculo DATE,
                        @placa VARCHAR(8)
AS
    BEGIN
        INSERT INTO VEICULOS (VeiculoID, ClienteID, Marca, Modelo, DataVeiculo, Placa)
        VALUES (@VeiculoID, @clienteID, @marca, @modelo, @dataVeiculo, @placa)
    END

GO
CREATE PROC add_encomenda @ordemServicoID INT, 
                          @veiculoID INT,
                          @data DATE,
                          @servicoID INT,
                          @precoFinal INT,
                          @status VARCHAR(10)
AS
    BEGIN
        INSERT INTO ENCOMENDA (OrdemServicoID, VeiculoID, Data, ServicoID, PrecoFinal, Status)
        VALUES (@ordemServicoID, @veiculoID, @data, @servicoID, @precoFinal, @status)
    END

GO
CREATE PROC add_servico @servicoID INT,
                        @descricao VARCHAR(255),
                        @preco INT,
                        @clienteID INT
AS
    BEGIN
        INSERT INTO SERVICOS (ServicoID, Descricao, Preco, ClienteID)
        VALUES (@servicoID, @descricao, @preco, @clienteID)
    END

GO
CREATE PROC PECAS @pecaID INT, 
                  @nome VARCHAR(50),
                  @preco INT,
                  @quantidade INT
AS
    BEGIN
        INSERT INTO PECAS (PecaID, Nome, Preco, Quantidade)
        VALUES (@pecaID, @nome, @preco, @quantidade)
    END

GO
CREATE PROC add_order_servico @ordemServicoID INT,
                              @veiculoID INT,
                              @data DATE,
                              @servicoID INT,
                              @precoFinal INT,
                              @status VARCHAR(10)
AS
    BEGIN
        INSERT INTO ENCOMENDA (OrdemServicoID, VeiculoID, Data, ServicoID, PrecoFinal, Status)
        VALUES (@ordemServicoID, @veiculoID, @data, @servicoID, @precoFinal, @status)
    END
