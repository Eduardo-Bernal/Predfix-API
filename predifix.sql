CREATE DATABASE PrediFix;
GO

USE PrediFix;
GO

CREATE TABLE Usuario(
	UsuarioID INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(60) NOT NULL,
	Email VARCHAR(150) UNIQUE NOT NULL,
	Senha VARBINARY(32) NOT NULL,
	IsAdmin BIT NOT NULL 
);
GO

CREATE TABLE Inspecao(
	InspecaoID INT PRIMARY KEY IDENTITY,
	Equipamento VARCHAR(150) NOT NULL,
	Localizacao VARCHAR(150) NOT NULL,
	Cliente VARCHAR(150) NOT NULL,
	Observacao VARBINARY(MAX) NOT NULL,
	StatusInspecao BIT NOT NULL,
	DataCriacao DATETIME DEFAULT GETDATE() NOT NULL,
	UsuarioID INT NOT NULL,
	
	CONSTRAINT FK_Inspecao_Usuario_UsuarioID FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID) 
);
GO

INSERT INTO Usuario(Nome, Email, Senha, IsAdmin)
VALUES('Sérgio', 'sergio@email.com', HASHBYTES('SHA2_256', '123'), 1),
('Carlos', 'carlos@email.com', HASHBYTES('SHA2_256', '123'), 0)
GO


SELECT * FROM Inspecao