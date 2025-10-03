USE OFICINA;
GO

-- Insert Employee
CREATE PROCEDURE dbo.InsertEmployee
    @Nome VARCHAR(50),
    @Telefone VARCHAR(9),
    @Email VARCHAR(50),
    @Morada VARCHAR(50),
    @Cargo VARCHAR(50),
    @Salario VARCHAR(10),
    @FuncionarioID VARCHAR(50) OUTPUT
AS
BEGIN
SET NOCOUNT ON;

    DECLARE @NewID VARCHAR(50)
    SET @NewID = NEWID()

    INSERT INTO FUNCIONARIOS (FuncionarioID, Nome, Telefone, Email, Morada, Cargo, Salario)
    VALUES (@NewID, @Nome, @Telefone, @Email, @Morada, @Cargo, @Salario)

    SET @FuncionarioID = @NewID
END;
GO

-- Update Employee

CREATE PROCEDURE dbo.UpdateEmployee
    @FuncionarioID VARCHAR(50),
    @Nome VARCHAR(50),
    @Telefone VARCHAR(9),
    @Email VARCHAR(50),
    @Morada VARCHAR(50),
    @Cargo VARCHAR(50),
    @Salario VARCHAR(10)
AS
BEGIN
    UPDATE FUNCIONARIOS
    SET Nome = @Nome,
        Telefone = @Telefone,
        Email = @Email,
        Morada = @Morada,
        Cargo = @Cargo,
        Salario = @Salario
    WHERE FuncionarioID = @FuncionarioID
END;
GO


-- Delete Employee
CREATE PROCEDURE dbo.DeleteEmployee
    @FuncionarioID VARCHAR(50)
AS
BEGIN
    DELETE FROM FUNCIONARIOS
    WHERE FuncionarioID = @FuncionarioID
END;
GO


-- Assign Employee to Service:
CREATE PROCEDURE dbo.AssignEmployeeToService
    @ServicoID VARCHAR(50),
    @FuncionarioID VARCHAR(50)
AS
BEGIN
    INSERT INTO SERVICOS_FUNCIONARIOS (ServicoID, FuncionarioID)
    VALUES (@ServicoID, @FuncionarioID)
END;
GO
