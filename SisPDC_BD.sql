-- ========================================
-- BASE DE DADOS: Sistema de Informação de Saúde (SIS)
-- ========================================

CREATE DATABASE dbSIS;

USE dbSIS;


-- ========================================
-- TABELAS DE REFERÊNCIA
-- ========================================

-- Especialidades médicas
CREATE TABLE especialidades (
    Id INT AUTO_INCREMENT,
    Descricao VARCHAR(100) NOT NULL,
    Ativo INT DEFAULT 1,
    DateTime DATETIME NOT NULL DEFAULT NOW(),
    
    PRIMARY KEY (Id),
    UNIQUE KEY UQ_Especialidade_Descricao (Descricao),
    CONSTRAINT CHK_Especialidade_Descricao CHECK (CHAR_LENGTH(Descricao) >= 3)
);


-- ========================================
-- TABELAS DE AUTENTICAÇÃO E UTILIZADORES
-- ========================================

-- Tabela principal de autenticação
CREATE TABLE utilizadores (
    idUtilizador INT AUTO_INCREMENT,
	nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    palavraPasse VARBINARY(255) NOT NULL,
    palavraPasseSalt VARBINARY(255) NOT Null,
    tipoUtilizador VARCHAR(20) NOT NULL, -- 'Utente', 'Clinico', 'Administrativo'
    dataCriacao DATETIME,
    ultimoAcesso DATETIME NULL,
    ativo BIT DEFAULT 1,

    CONSTRAINT PK_Utilizador PRIMARY KEY (idUtilizador),
    CONSTRAINT CHK_Utilizador_Nome CHECK (LENGTH(nome) >= 2),
    CONSTRAINT UQ_Utilizador_Email UNIQUE (email),
    CONSTRAINT CHK_Utilizador_Email CHECK (email LIKE '%_@__%.__%'),
    CONSTRAINT CHK_Utilizador_Password CHECK (LENGTH(palavraPasse) >= 6),
    CONSTRAINT CHK_Utilizador_Tipo CHECK (tipoUtilizador IN ('Utente', 'Clinico', 'Administrativo'))
);

-- ========================================
-- TABELAS DE PESSOAS
-- ========================================

-- Utentes (pacientes)
CREATE TABLE utentes (
    idUtente NVARCHAR(15),
    idUtilizador INT NOT NULL,
    
    dataNascimento DATE NOT NULL,
    telefone VARCHAR(20) NULL,
    email VARCHAR(100) NULL,
    
    -- Endereço
    morada VARCHAR(150) NULL,
    codigoPostal VARCHAR(20) NULL,
    localidade VARCHAR(80) NULL,
    
    -- Informações administrativas
    entidadeFinanciadora VARCHAR(100) NULL,
    numeroUtente VARCHAR(50) NULL, -- Número de identificação do utente
    ativo BIT DEFAULT 1,
    
    CONSTRAINT PK_Utente PRIMARY KEY (idUtente),
    CONSTRAINT FK_Utente_Utilizador FOREIGN KEY (idUtilizador) 
        REFERENCES utilizadores(idUtilizador),
    CONSTRAINT UQ_Utente_Utilizador UNIQUE (idUtilizador),
    
    -- Validações corrigidas
    CONSTRAINT CHK_Utente_Email CHECK (email IS NULL OR email LIKE '%_@__%.__%'),
    CONSTRAINT CHK_Utente_Telefone CHECK (telefone IS NULL OR telefone REGEXP '^[0-9+]+$'),
    CONSTRAINT CHK_Utente_CodigoPostal CHECK (codigoPostal IS NULL OR codigoPostal REGEXP '^[0-9]{4}-[0-9]{3}$')
);


-- Pessoal Administrativo
CREATE TABLE PessoaAdministrativas (
    idPessoaAdmin NVARCHAR(15),
    idUtilizador INT NOT NULL,
    
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    telefone VARCHAR(20) NULL,
    cargo VARCHAR(50) NULL,
    dataAdmissao DATE NULL,
    
    -- Endereço
    morada VARCHAR(150) NULL,
    codigoPostal VARCHAR(20) NULL,
    localidade VARCHAR(80) NULL,
    
    ativo BIT DEFAULT 1,

    CONSTRAINT PK_PessoaAdministrativo PRIMARY KEY (idPessoaAdmin),
    CONSTRAINT FK_PessoaAdministrativo_Utilizador FOREIGN KEY (idUtilizador) 
        REFERENCES Utilizadores(idUtilizador),
    
    CONSTRAINT UQ_PessoaAdministrativo_Utilizador UNIQUE (idUtilizador),
    CONSTRAINT UQ_PessoaAdministrativo_Email UNIQUE (email),
    
    -- Validações
    CONSTRAINT CHK_PessoaAdministrativo_Nome CHECK (LENGTH(nome) >= 2),
    CONSTRAINT CHK_PessoaAdministrativo_Email CHECK (email LIKE '%_@__%.__%'),
    CONSTRAINT CHK_PessoaAdministrativo_Telefone CHECK (telefone IS NULL OR telefone NOT LIKE '%[^0-9+]%'),
    CONSTRAINT CHK_PessoaAdministrativo_DataAdmissao CHECK (dataAdmissao IS NULL)
);


CREATE TABLE PessoaClinicas (
    idPessoaClinica NVARCHAR(15),
    idUtilizador INT NOT NULL,
    idEspecialidade INT NOT NULL,
    
    nome NVARCHAR(100) NOT NULL,
    dataNascimento DATE NOT NULL,
    dataAdmissao DATE NOT NULL,
    telefone NVARCHAR(20) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    cargo NVARCHAR(50) NULL,
    numeroCedula NVARCHAR(50) NULL, -- Número de cédula profissional
    
    -- Endereço
    morada VARCHAR(150) NULL,
    codigoPostal VARCHAR(20) NULL,
    localidade VARCHAR(80) NULL,
    
    ativo BIT DEFAULT 1,

    CONSTRAINT PK_PessoaClinico PRIMARY KEY (idPessoaClinica),
    CONSTRAINT FK_PessoaClinico_Utilizador FOREIGN KEY (idUtilizador) 
        REFERENCES Utilizadores(idUtilizador),
    CONSTRAINT FK_PessoaClinico_Especialidade FOREIGN KEY (idEspecialidade) 
        REFERENCES Especialidades(Id),
    
    CONSTRAINT UQ_PessoalClinico_Utilizador UNIQUE (idUtilizador),
    CONSTRAINT UQ_PessoalClinico_Email UNIQUE (email),
    
    -- Validações
    CONSTRAINT CHK_PessoaClinico_Nome CHECK (LENGTH(nome) >= 2),
    CONSTRAINT CHK_PessoaClinico_Email CHECK (email LIKE '%_@__%.__%'),
    CONSTRAINT CHK_PessoaClinico_Telefone CHECK (telefone NOT LIKE '%[^0-9+]%')
);

-- Consultas
CREATE TABLE Consultas (
    idConsulta INT AUTO_INCREMENT,
    idUtente NVARCHAR(20) NOT NULL,
    idPessoaClinica NVARCHAR(20),
    
    dataConsulta DATE NOT NULL,
    horaConsulta TIME NOT NULL,
    descricao VARCHAR(200) NULL,
    observacoes NVARCHAR(500) NULL,
    estado VARCHAR(20) NOT NULL DEFAULT 'Pendente',
    
    dataCriacao DATETIME,
    dataUltimaAtualizacao DATETIME NULL,

    CONSTRAINT PK_Consulta PRIMARY KEY (idConsulta),
    CONSTRAINT FK_Consulta_Utente FOREIGN KEY (idUtente) 
        REFERENCES utentes(idUtente),
    CONSTRAINT FK_Consulta_PessoalClinico FOREIGN KEY (idPessoaClinica) 
        REFERENCES PessoaClinicas(idPessoaClinica),
    
    -- Validações
    CONSTRAINT CHK_Consulta_Hora CHECK (horaConsulta BETWEEN '07:00' AND '20:00'),
    CONSTRAINT CHK_Consulta_Estado CHECK (estado IN ('Pendente', 'Marcado', 'Realizada', 'Cancelada'))
);


-- ========================================
-- SELECTs DAS TABELAS
-- ========================================
SELECT * FROM utentes;
SELECT * FROM utilizadores;
SELECT * FROM PessoaAdministrativas;
SELECT * FROM PessoaClinicas;
SELECT * FROM Consultas;

DROP TABLE utentes;
DROP TABLE utilizadores;
DROP TABLE PessoalAdministrativo;
DROP TABLE PessoaClinicas;
DROP TABLE Consulta;


DELETE FROM utilizadores WHERE idUtilizador = 11;