PawPulse

in the db folder .. there is the sql file for u to run, so we get the same db design

in case of modification, you have to drop every db and start over, as following:

DROP TABLE IF EXISTS Adoption;
DROP TABLE IF EXISTS Prescription;
DROP TABLE IF EXISTS Lab_Test;
DROP TABLE IF EXISTS MEDICAL_RECORD;
DROP TABLE IF EXISTS Animal_Vaccine_History;
DROP TABLE IF EXISTS APPOINTMENT;
DROP TABLE IF EXISTS Bill_Item;
DROP TABLE IF EXISTS Medicine;
DROP TABLE IF EXISTS Bill;
DROP TABLE IF EXISTS ANIMAL;
DROP TABLE IF EXISTS CLIENT;
DROP TABLE IF EXISTS Employee;
DROP TABLE IF EXISTS Kennel;
DROP TABLE IF EXISTS Vaccine;
DROP TABLE IF EXISTS Supplier;

PRINT 'All tables have been successfully dropped! You are clear to run your CREATE script.';
