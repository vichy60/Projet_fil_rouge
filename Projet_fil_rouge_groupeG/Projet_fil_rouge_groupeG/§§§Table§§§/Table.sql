Drop Table Patient
Drop Table Medecin
Drop Table RDV
Drop Table Specialite
/*
 *Création table Personne
 */

 CREATE TABLE dbo.Patient
 (
	[id] INT IDENTITY (1,1) NOT NULL,
	----[codePatient] VARCHAR(50) NOT NULL,
	[nomPatient] VARCHAR(50) NOT NULL,
	[adressePatient] VARCHAR(50) NOT NULL,
	[dateNaissance] DATETIME NOT NULL,
	[sexePatient] VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([id] ASC)
 )

 CREATE TABLE dbo.Medecin
 (
	[id] INT IDENTITY (1,1) NOT NULL,
	----[codeMedecin] VARCHAR(50) NOT NULL,
	[nomMedecin] VARCHAR(50) NOT NULL,
	[telMedecin] VARCHAR(50) NOT NULL,
	[dateEmbauche] DATETIME NOT NULL,
	[specialiteMedecinId] VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([id] ASC)
 )

CREATE TABLE [dbo].[RDV] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [dateRDV]     DATETIME     NOT NULL,
    [heureRDV]    VARCHAR (50) NOT NULL,
    [medecinId] INT          NOT NULL,
    [patientId] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
	
   CREATE TABLE dbo.Specialite
 (
	[id] INT IDENTITY (1,1) NOT NULL,
	[specialiteMedecin] VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([id] ASC)
 )

