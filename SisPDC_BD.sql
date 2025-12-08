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
    email VARCHAR(100) NOT NULL,
    palavraPasse VARBINARY(255) NOT NULL,
    palavraPasseSalt VARBINARY(255) NOT Null,
    tipoUtilizador VARCHAR(20) NOT NULL, -- 'Utente', 'Clinico', 'Administrativo'
    dataCriacao DATETIME,
    ultimoAcesso DATETIME NULL,
    ativo BIT DEFAULT 1,

    CONSTRAINT PK_Utilizador PRIMARY KEY (idUtilizador),
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
    idUtente INT AUTO_INCREMENT,
    idUtilizador INT NOT NULL,
    
    nome VARCHAR(100) NOT NULL,
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
    CONSTRAINT CHK_Utente_Nome CHECK (LENGTH(nome) >= 2),
    CONSTRAINT CHK_Utente_Email CHECK (email IS NULL OR email LIKE '%_@__%.__%'),
    CONSTRAINT CHK_Utente_Telefone CHECK (telefone IS NULL OR telefone REGEXP '^[0-9+]+$'),
    CONSTRAINT CHK_Utente_CodigoPostal CHECK (codigoPostal IS NULL OR codigoPostal REGEXP '^[0-9]{4}-[0-9]{3}$')
);


-- Pessoal Administrativo
CREATE TABLE PessoalAdministrativo (
    idPessoalAdmin INT AUTO_INCREMENT,
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

    CONSTRAINT PK_PessoalAdministrativo PRIMARY KEY (idPessoalAdmin),
    CONSTRAINT FK_PessoalAdministrativo_Utilizador FOREIGN KEY (idUtilizador) 
        REFERENCES Utilizador(idUtilizador),
    
    CONSTRAINT UQ_PessoalAdministrativo_Utilizador UNIQUE (idUtilizador),
    CONSTRAINT UQ_PessoalAdministrativo_Email UNIQUE (email),
    
    -- Validações
    CONSTRAINT CHK_PessoalAdministrativo_Nome CHECK (LEN(nome) >= 2),
    CONSTRAINT CHK_PessoalAdministrativo_Email CHECK (email LIKE '%_@__%.__%'),
    CONSTRAINT CHK_PessoalAdministrativo_Telefone CHECK (telefone IS NULL OR telefone NOT LIKE '%[^0-9+]%'),
    CONSTRAINT CHK_PessoalAdministrativo_DataAdmissao CHECK (dataAdmissao IS NULL OR dataAdmissao <= GETDATE())
);



-- ========================================
-- SELECTs DAS TABELAS
-- ========================================
SELECT * FROM utentes;
SELECT * FROM utilizadores;

DROP TABLE utentes;
DROP TABLE utilizadores;

DELETE FROM utilizadores
WHERE idUtilizador = '1';
SELECT * FROM utentes;