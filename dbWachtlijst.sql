CREATE DATABASE dbWachtlijst

USE dbWachtlijst
CREATE TABLE Consulent
(
	consulentID INT NOT NULL IDENTITY(1,1),
	consulentNaam VARCHAR(100) NOT NULL,
	consulentVoornaam VARCHAR(75) NOT NULL,
	
	CONSTRAINT pk_Consulent PRIMARY KEY (consulentID)
)

CREATE TABLE Dienst
(
	dienstID INT NOT NULL IDENTITY(1,1),
	dienstNaam VARCHAR(255) NOT NULL,
	dienstAdres VARCHAR(255),
	dienstTelefoonnummer INT,
	
	CONSTRAINT pk_Dienst PRIMARY KEY (dienstID)
)

CREATE TABLE ConsulentDienst
(
	consulentID INT NOT NULL,
	dienstID INT NOT NULL,
	
	CONSTRAINT pk_ConsulentDienst PRIMARY KEY (consulentID, dienstID),
	CONSTRAINT fk_ConsulentID FOREIGN KEY (consulentID) REFERENCES Consulent(consulentID),
	CONSTRAINT fk_DienstID FOREIGN KEY (dienstID) REFERENCES Dienst(dienstID)
)

CREATE TABLE Minderjarige
(
	minderjarigeID INT NOT NULL IDENTITY(1,1),
	minderjarigeNaam VARCHAR(100) NOT NULL,
	minderjarigeVoornaam VARCHAR(75) NOT NULL,
	
	CONSTRAINT pk_Minderjarige PRIMARY KEY (minderjarigeID)
)

CREATE TABLE Aanmeldpunt
(
	aanmeldpuntID INT NOT NULL IDENTITY(1,1),
	aanmeldpuntNaam VARCHAR(255) NOT NULL,
	aanmeldpuntAdres VARCHAR(255),
	aanmeldpuntTelefoonnummer INT,
	aanmeldpuntEmail VARCHAR(255),
	aanmeldpuntContactpersoon VARCHAR(255),
	
	CONSTRAINT pk_Aanmeldpunt PRIMARY KEY (aanmeldpuntID)	
)

CREATE TABLE MinderjarigeAanmeldpunt
(
	minderjarigeID INT NOT NULL,
	aanmeldpuntID INT NOT NULL,
	consulentID INT,
	datumAanmelding DATE NOT NULL,
	datumOpneming DATE,
	
	CONSTRAINT fk_Minderjarige FOREIGN KEY (minderjarigeID) REFERENCES Minderjarige(minderjarigeID),
	CONSTRAINT fk_MinderjarigeDienst FOREIGN KEY (aanmeldpuntID) REFERENCES Aanmeldpunt(aanmeldpuntID),
	CONSTRAINT fk_AanmelderConsulent FOREIGN KEY (consulentID) REFERENCES Consulent(consulentID)
)