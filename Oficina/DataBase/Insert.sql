-- Insert data into CLIENTES table
USE OFICINA;
GO
INSERT INTO CLIENTES (clienteID, Nome, Telefone, Email, Morada)
VALUES
('C001', 'John Doe', '912345678', 'john@example.com', '123 Elm St'),
('C002', 'Jane Smith', '923456789', 'jane@example.com', '456 Oak St'),
('C003', 'Alice Johnson', '934567890', 'alice@example.com', '789 Pine St');
GO

-- Insert data into FUNCIONARIOS table
INSERT INTO FUNCIONARIOS (FuncionarioID, Nome, Telefone, Email, Morada, Cargo, Salario)
VALUES
('F001', 'Mike Brown', '945678901', 'mike@example.com', '321 Maple St', 'Mechanic', '3000'),
('F002', 'Sara Davis', '956789012', 'sara@example.com', '654 Birch St', 'Electrician', '3200'),
('F003', 'Tom White', '967890123', 'tom@example.com', '987 Cedar St', 'Manager', '3500');
GO

-- Insert data into VEICULOS table
INSERT INTO VEICULOS (VeiculoID, ClienteID, Marca, VIN, TipoVeiculo, Modelo, DataVeiculo, Placa)
VALUES
('V001', 'C001', 'Toyota', '1HGBH41JXMN109186', 'Car', 'Corolla', '2021-03-15', 'AB C1 23'),
('V002', 'C002', 'Honda', '2HGBH41JXMN109187', 'Car', 'Civic', '2020-06-20', 'DE-F5-67'),
('V003', 'C003', 'Ford', '3HGBH41JXMN109188', 'Truck', 'F-150', '2019-09-25', 'GH I9 01');
GO

-- Insert data into TIPOS_SERVICOS table
INSERT INTO TIPOS_SERVICOS (TipoServicoID, NomeServico, Preco)
VALUES
('TS001', 'Oil Change', '50'),
('TS002', 'Tire Rotation', '30'),
('TS003', 'Brake Inspection', '40');
GO

-- Insert data into SERVICOS table
INSERT INTO SERVICOS (ServicoID, VeiculoID, TipoServiçoID, DataServico, Descricao, Preco)
VALUES
('S001', 'V001', 'TS001', '2022-01-10', 'Changed engine oil', '50'),
('S002', 'V002', 'TS002', '2022-02-15', 'Rotated tires', '30'),
('S003', 'V003', 'TS003', '2022-03-20', 'Inspected brakes', '40');
GO

-- Insert data into SERVICOS_FUNCIONARIOS table
INSERT INTO SERVICOS_FUNCIONARIOS (ServicoID, FuncionarioID)
VALUES
('S001', 'F001'),
('S002', 'F002'),
('S003', 'F001');
GO

-- Insert data into PECAS table
INSERT INTO PECAS (PecaID, NomePeca, Preco)
VALUES
('P001', 'Oil Filter', '10'),
('P002', 'Tire', '100'),
('P003', 'Brake Pad', '20');
GO

-- Insert data into PECAS_SERVICOS table
INSERT INTO PECAS_SERVICOS (PecaID, ServicoID)
VALUES
('P001', 'S001'),
('P002', 'S002'),
('P003', 'S003');
GO

-- Insert data into PECAS_VEICULOS table
INSERT INTO PECAS_VEICULOS (PecaID, VeiculoID)
VALUES
('P001', 'V001'),
('P002', 'V002'),
('P003', 'V003');
GO

-- Insert data into ENCOMENDAS table
INSERT INTO ENCOMENDAS (EncomendaID, PecaID, ServicoID, DataEncomenda, Quantidade, PrecoTotal)
VALUES
('E001', 'P001', 'S001', '2022-01-05', '1', '10'),
('E002', 'P002', 'S002', '2022-02-10', '4', '400'),
('E003', 'P003', 'S003', '2022-03-15', '2', '40');
GO
