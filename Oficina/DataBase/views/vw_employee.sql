USE OFICINA;
GO


-- Create View for Employee Details
CREATE VIEW vw_EmployeeDetails
AS
SELECT FuncionarioID, Nome, Telefone, Email, Morada, Cargo, Salario
FROM FUNCIONARIOS;
GO

-- Create View for Services History
CREATE VIEW vw_EmployeeServiceHistory
AS
SELECT f.FuncionarioID, f.Nome, s.ServicoID, s.DataServico, s.Descricao, s.Preco
FROM FUNCIONARIOS f
JOIN SERVICOS_FUNCIONARIOS sf ON f.FuncionarioID = sf.FuncionarioID
JOIN SERVICOS s ON sf.ServicoID = s.ServicoID;
GO
