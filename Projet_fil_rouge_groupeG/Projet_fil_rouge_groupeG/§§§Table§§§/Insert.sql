--Alimentation manuelle des tables pour essais


--insert dans la table des patients

--INSERT INTO Patient (nomPatient,adressePatient,dateNaissance,sexePatient) VALUES ('CAPPELLE','12 rue de la mairie 60380 Therines','1966/11/06','M');
--INSERT INTO Patient (nomPatient,adressePatient,dateNaissance,sexePatient) VALUES ('Cappelle','12 rue de la mairie 60380 Therines','1966/01/13','F');
--INSERT INTO Patient (nomPatient,adressePatient,dateNaissance,sexePatient) VALUES ('Maupin','rue aux maures 60210 Grandvilliers','1966/05/03','M');
--INSERT INTO Patient (nomPatient,adressePatient,dateNaissance,sexePatient) VALUES ('Macron','rue de la Paris 62000  Le Touquet','1986/05/21','M');
--INSERT INTO Patient (nomPatient,adressePatient,dateNaissance,sexePatient) VALUES ('Malade','rue des patients 00001 Outretombe','1966/03/25','M');

----insert dans la table des medecins

--INSERT INTO Medecin (nomMedecin,telMedecin,dateEmbauche,specialiteMedecinId) VALUES ('Létrangleur','0101010101',CURRENT_TIMESTAMP,1);
--INSERT INTO Medecin (nomMedecin,telMedecin,dateEmbauche,specialiteMedecinId) VALUES ('Letronçonneur','0202020202',CURRENT_TIMESTAMP,2);
--INSERT INTO Medecin (nomMedecin,telMedecin,dateEmbauche,specialiteMedecinId) VALUES ('LEBOUCHER','0303030303',CURRENT_TIMESTAMP,3);
--INSERT INTO Medecin (nomMedecin,telMedecin,dateEmbauche,specialiteMedecinId) VALUES ('LECHIRURGIEN','0404040404',CURRENT_TIMESTAMP,4);


----insert dans la table des RDV
INSERT INTO RDV (dateRDV,heureRDV,codeMedecin,codePatient) values (CURRENT_TIMESTAMP,'11h15',1,2);
INSERT INTO RDV (dateRDV,heureRDV,codeMedecin,codePatient) values (CURRENT_TIMESTAMP,'10h15',1,3);
INSERT INTO RDV (dateRDV,heureRDV,codeMedecin,codePatient) values (CURRENT_TIMESTAMP,'14h20',3,2);
INSERT INTO RDV (dateRDV,heureRDV,codeMedecin,codePatient) values (CURRENT_TIMESTAMP,'17h30',2,1);
--insert des spécialitées

INSERT into Specialite (specialiteMedecin) values ('Cardiologie');
INSERT into Specialite (specialiteMedecin) values ('Chirurgie');
INSERT into Specialite (specialiteMedecin) values ('Dermatologie');
INSERT into Specialite (specialiteMedecin) values ('Gériatrie');
INSERT into Specialite (specialiteMedecin) values ('Oncologie');
INSERT into Specialite (specialiteMedecin) values ('Pédiatrie');
INSERT into Specialite (specialiteMedecin) values ('Psychiatrie');
INSERT into Specialite (specialiteMedecin) values ('Allergologie');
