-- LEVEL 1
Use PawPulse;

CREATE TABLE CLIENT (
    ClientID INT identity(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Phone VARCHAR(15) UNIQUE,
    Email VARCHAR(100) UNIQUE,
    City VARCHAR(50),
    Street VARCHAR(100),
    BuildingNumber VARCHAR(20),
    PasswordHash VARCHAR(255),
    IsActive BIT DEFAULT 1 -- The "Soft Delete" switch! 1 = Active, 0 = Inactive
);

CREATE TABLE Employee (
    EmployeeID INT identity(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    EmployeeRole VARCHAR(50), -- e.g., 'Vet', 'Admin', 'Staff'
    Phone VARCHAR(15),
    Email VARCHAR(100) UNIQUE,
    PasswordHash VARCHAR(255),
    HireDate DATE,
    Salary DECIMAL(10,2),
    IsActive BIT DEFAULT 1 -- The "Soft Delete" switch!
);

CREATE TABLE Kennel (
    KennelID INT identity(1,1) PRIMARY KEY,
    Capacity INT,
    KennelSize VARCHAR(20), -- 'Small', 'Medium', 'Large'
    WardType VARCHAR(50), -- 'Isolation', 'General', 'Adoption'
    KennelStatus VARCHAR(20) -- 'Available', 'Occupied', 'Needs Cleaning'
);

CREATE TABLE Vaccine (
    VaccineID INT identity(1,1) PRIMARY KEY,
    VaccineName VARCHAR(100),
    DiseaseTargeted VARCHAR(100),
    ValidityPeriodMonths INT  
);

-- LEVEL 2

CREATE TABLE ANIMAL (
    AnimalID INT identity(1,1) PRIMARY KEY,
    AnimalName VARCHAR(50),
    Species VARCHAR(50),
    Breed VARCHAR(50),
    Gender VARCHAR(10), -- Added Gender!
    EstimatedDOB DATE, 
    
    -- This is how you do a Derived Attribute in SQL! 
    -- It automatically calculates the difference in years between their DOB and today's date.
    Age AS (DATEDIFF(YEAR, EstimatedDOB, GETDATE())), 

    SystemStatus VARCHAR(20), -- 'Owned', 'Shelter', 'Adopted'
    LatestWeight DECIMAL(5,2),
    
-- ON DELETE SET NULL applied here!
    ClientID INT NULL FOREIGN KEY REFERENCES CLIENT(ClientID) ON DELETE SET NULL,
    KennelID INT NULL FOREIGN KEY REFERENCES Kennel(KennelID) ON DELETE SET NULL
);

CREATE TABLE Bill (
    BillID INT identity(1,1) PRIMARY KEY,
    BillDate DATE,
    Total_Amount DECIMAL(10,2),
    BillStatus VARCHAR(20), -- 'Paid', 'Unpaid'
    ClientID INT NOT NULL FOREIGN KEY REFERENCES CLIENT(ClientID)
);

-- LEVEL 3 & 4  

CREATE TABLE Bill_Item (
    BillID INT  NOT NULL,  -- Parent key comes first
    ItemID INT NOT NULL,  -- Partial key
    ItemDescription VARCHAR(100),
    UnitCost DECIMAL(10,2), -- Good catch!
    Quantity INT,
    Subtotal DECIMAL(10,2),
    
    -- Creating the Composite Primary Key
    PRIMARY KEY (BillID, ItemID), 
    
    -- ON DELETE CASCADE applied to the Weak Entity!
    FOREIGN KEY (BillID) REFERENCES Bill(BillID) ON DELETE CASCADE
);

CREATE TABLE APPOINTMENT (
    AppointmentID INT identity(1,1) PRIMARY KEY,
    AppDate DATE,
    AppTime TIME,
    Purpose VARCHAR(255), -- e.g., "Annual Checkup", "Surgery consult"
    AppStatus VARCHAR(20), -- 'Scheduled', 'Completed', 'Cancelled'
    AnimalID INT NOT NULL FOREIGN KEY REFERENCES ANIMAL(AnimalID),
    EmployeeID INT NOT NULL FOREIGN KEY REFERENCES Employee(EmployeeID)
);

-- This is your Many-to-Many < Receives > Diamond turned into a table!
CREATE TABLE Animal_Vaccine_History (
    AnimalID INT FOREIGN KEY REFERENCES ANIMAL(AnimalID) ON DELETE CASCADE,
    VaccineID INT FOREIGN KEY REFERENCES Vaccine(VaccineID) ON DELETE CASCADE,
    DateAdministered DATE, -- The relationship attribute!
    PRIMARY KEY (AnimalID, VaccineID, DateAdministered) 
);

-- ==========================================
-- LEVEL 1: Independent Pharmacy Table
-- ==========================================

CREATE TABLE Supplier (
    SupplierID INT identity(1,1) PRIMARY KEY,
    SupplierName VARCHAR(100),
    ContactPhone VARCHAR(15),
    SupplierAddress VARCHAR(200),
    Email VARCHAR(100) UNIQUE
);

-- ==========================================
-- LEVEL 2: Medicine (Relies on Supplier)
-- ==========================================

CREATE TABLE Medicine (
    MedicineID INT identity(1,1) PRIMARY KEY,
    MedicineName VARCHAR(100),
    Dosage VARCHAR(50),
    StockQuantity INT,          
    UnitPrice DECIMAL(10,2),    
    ExpiryDate DATE,             
    SupplierID INT NOT NULL FOREIGN KEY REFERENCES Supplier(SupplierID)
);

-- ==========================================
-- LEVEL 3: Medical Record (Relies on Animal & Appointment)
-- ==========================================
-- Remembering Medical Record MUST have an Animal!
CREATE TABLE MEDICAL_RECORD (
    RecordID INT identity(1,1) PRIMARY KEY,
    LastUpdatedDate DATE,
    RecordedWeight  DECIMAL(4,1),
    Diagnosis VARCHAR(255),
    Notes VARCHAR(500),
    AnimalID INT NOT NULL FOREIGN KEY REFERENCES ANIMAL(AnimalID),
    AppointmentID INT NULL FOREIGN KEY REFERENCES APPOINTMENT(AppointmentID) 
);

-- ==========================================
-- LEVEL 4: Lab Tests & Prescriptions (Rely on Medical Record)
-- ==========================================

CREATE TABLE Lab_Test (
    TestID INT identity(1,1) PRIMARY KEY,
    TestType VARCHAR(100),
    TestDate DATE,
    Result VARCHAR(255),
    Cost    Decimal(10,2),
    RecordID INT NOT NULL FOREIGN KEY REFERENCES MEDICAL_RECORD(RecordID) ON DELETE CASCADE
);

CREATE TABLE Prescription (
    PrescriptionID INT identity(1,1) PRIMARY KEY,
    Instructions VARCHAR(255),
    IssueDate DATE,              
    RefillsAllowed INT,         
    DurationInDays INT,          
    RecordID INT NOT NULL FOREIGN KEY REFERENCES MEDICAL_RECORD(RecordID) ON DELETE CASCADE,
    MedicineID INT NOT NULL FOREIGN KEY REFERENCES Medicine(MedicineID),
    EmployeeID INT NOT NULL FOREIGN KEY REFERENCES Employee(EmployeeID) -- The Vet who signed it!
); 

-- ==========================================
-- LEVEL 5: The Adoption Pipeline (Relies on Animal, Client, Employee)
-- ==========================================

CREATE TABLE Adoption (
    AdoptionID INT identity(1,1) PRIMARY KEY,
    ApplicationDate DATE,
    AdoptionStatus VARCHAR(50), -- 'Pending', 'Approved', 'Rejected'
    AdoptionFee DECIMAL(10,2),
    AnimalID INT NOT NULL FOREIGN KEY REFERENCES ANIMAL(AnimalID),
    ClientID INT NOT NULL FOREIGN KEY REFERENCES CLIENT(ClientID),
    EmployeeID INT NOT NULL FOREIGN KEY REFERENCES Employee(EmployeeID)
);

-- ==========================================
-- LEVEL 1: Independent Data
-- ==========================================

-- 1. CLIENT (Covers Active/Inactive, different cities)
INSERT INTO CLIENT (FirstName, LastName, Phone, Email, City, Street, BuildingNumber, PasswordHash, IsActive) VALUES 
('Omar', 'Hassan', '01012345678', 'omar.h@email.com', 'Cairo', 'Talaat Harb', '12B', '$2a$11$xgCqVmpVFRtpU.mJDFHTc.t3Qqe.Qj0JN0AGvY1ivuCp/vRA.8G76', 1), -- 1240124
('Salma', 'Ibrahim', '01198765432', 'salma.i@email.com', 'Giza', 'Dokki St', '45', '$2a$11$Is1CGauDw1xU7YocNsRTWO4WPnE958aRoolauU9I1O1ORrecALary', 1), -- 1234
('Youssef', 'Ali', '01233344455', 'y.ali@email.com', 'Alexandria', 'Corniche', '10', '$2a$11$Qk9u/MNsZXGUpLTpohs6bOkgjdXrTrC32frhVecI663XzAHXL2ppi', 0), -- Inactive -- 987
('Nour', 'Kamal', '01555566677', 'nour.k@email.com', 'Cairo', 'Maadi Rd', '5', '$2a$11$3tjTXy5BXI45BUeTxXkeKusPb.sSl739weV6yXb2BB/9CoEfollUK', 1), -- 654
('Tarek', 'Zaki', '01099887766', 't.zaki@email.com', 'Giza', 'Pyramids St', '99', '$2a$11$.9R1JHNxlmSfQvlAvZNdaeo9cVa9biSce.4EueYRNRCem3g5fei.K', 1), -- 951
('Heba', 'Farid', '01122334455', 'heba.f@email.com', 'Cairo', 'Zamalek St', '1', '$2a$11$kXzKu1HVPOv/.eU8FrRe2etKOi4OEpIDaFPWcAHVq2Ujo3uU3IYNO', 1), -- 852
('Kareem', 'Saeed', '01299988877', 'k.saeed@email.com', 'Alexandria', 'Sporting', '22', '$2a$11$1XXwcSMeakPsEkh/pdsrs.RGpW50s3kbx9VmCx3SKA0uKISAzMLVe', 0); -- Inactive -- 555

-- 2. Employee (Covers Vets, Receptionists, Shelter Staff, Active/Inactive)
INSERT INTO Employee (FirstName, LastName, EmployeeRole, Phone, Email, PasswordHash, HireDate, Salary, IsActive) VALUES 
('Dr. Amina', 'Fawzy', 'Veterinarian', '01011122233', 'amina.vet@pawpulse.com', '$2a$11$xgCqVmpVFRtpU.mJDFHTc.t3Qqe.Qj0JN0AGvY1ivuCp/vRA.8G76', '2020-03-15', 25000.00, 1), -- 1240124
('Dr. Kareem', 'Mostafa', 'Veterinarian', '01122233344', 'kareem.vet@pawpulse.com', '$2a$11$Is1CGauDw1xU7YocNsRTWO4WPnE958aRoolauU9I1O1ORrecALary', '2021-06-01', 23000.00, 1), -- 1234
('Hala', 'Saad', 'Receptionist', '01244455566', 'hala.s@pawpulse.com', '$2a$11$Qk9u/MNsZXGUpLTpohs6bOkgjdXrTrC32frhVecI663XzAHXL2ppi', '2023-01-10', 10000.00, 1), -- 987
('Amr', 'Adel', 'Shelter Staff', '01511223344', 'amr.a@pawpulse.com', '$2a$11$3tjTXy5BXI45BUeTxXkeKusPb.sSl739weV6yXb2BB/9CoEfollUK', '2022-08-20', 12000.00, 1), -- 654
('Dr. Layla', 'Nasser', 'Veterinarian', '01055544433', 'layla.vet@pawpulse.com', '$2a$11$.9R1JHNxlmSfQvlAvZNdaeo9cVa9biSce.4EueYRNRCem3g5fei.K', '2019-11-05', 28000.00, 0), -- Inactive Vet -951
('Mona', 'Galal', 'Shelter Staff', '01166677788', 'mona.g@pawpulse.com', '$2a$11$kXzKu1HVPOv/.eU8FrRe2etKOi4OEpIDaFPWcAHVq2Ujo3uU3IYNO', '2024-02-01', 11000.00, 1), -- 852
('Rami', 'Hussein', 'Manager', '01200011122', 'rami.h@pawpulse.com', '$2a$11$1XXwcSMeakPsEkh/pdsrs.RGpW50s3kbx9VmCx3SKA0uKISAzMLVe', '2018-01-15', 35000.00, 1); -- 555

-- 3. Kennel (Covers all sizes, ward types, and statuses)
INSERT INTO Kennel (Capacity, KennelSize, WardType, KennelStatus) VALUES 
(1, 'Medium', 'Adoption', 'Occupied'),
(2, 'Large', 'General', 'Available'),
(1, 'Small', 'Isolation', 'Needs Cleaning'),
(3, 'Large', 'Adoption', 'Occupied'),
(1, 'Small', 'General', 'Occupied'),
(1, 'Medium', 'Isolation', 'Available'),
(2, 'Medium', 'General', 'Needs Cleaning');

-- 4. Vaccine (Dogs, Cats, and generalized)
INSERT INTO Vaccine (VaccineName, DiseaseTargeted, ValidityPeriodMonths) VALUES 
('Rabies Shot', 'Rabies', 12),
('DAPPv', 'Distemper & Parvo', 36),
('FVRCP', 'Feline Rhinotracheitis', 12),
('Bordetella', 'Kennel Cough', 6),
('FeLV', 'Feline Leukemia', 12),
('Lyme Disease Vaccine', 'Lyme Disease', 12),
('Canine Influenza', 'Dog Flu', 12);

-- 5. Supplier
INSERT INTO Supplier (SupplierName, ContactPhone, SupplierAddress, Email) VALUES 
('PharmaVet Egypt', '0223456789', 'Industrial Zone, 6th of October', 'sales@pharmavet.eg'),
('Global Pet Meds', '0229876543', 'Maadi Tech Park, Cairo', 'orders@globalpet.com'),
('Alexandria Bio', '033445566', 'Borg El Arab, Alexandria', 'supply@alexbio.com'),
('CarePlus Veterinary', '0221122334', 'Nasr City, Cairo', 'contact@careplus.eg'),
('Delta Vet Supplies', '0405566778', 'Tanta, Gharbia', 'info@deltavet.com'),
('MediPet Inc', '0228889990', 'New Cairo', 'sales@medipet.com'),
('SafePaws Distribution', '033112233', 'Smouha, Alexandria', 'logistics@safepaws.com');


-- ==========================================
-- LEVEL 2: Dependent on Level 1
-- ==========================================

-- 6. ANIMAL (Owned vs Shelter vs Adopted. Notice NO 'Age' is inserted!)
INSERT INTO ANIMAL (AnimalName, Species, Breed, Gender, EstimatedDOB, SystemStatus, LatestWeight, ClientID, KennelID) VALUES 
('Rex', 'Dog', 'German Shepherd', 'Male', '2019-05-10', 'Owned', 32.5, 1, NULL),
('Bella', 'Dog', 'Golden Retriever', 'Female', '2022-08-15', 'Shelter', 28.0, NULL, 1),
('Luna', 'Cat', 'Siamese', 'Female', '2023-11-01', 'Owned', 4.2, 2, NULL),
('Max', 'Dog', 'Bulldog', 'Male', '2021-02-20', 'Shelter', 24.5, NULL, 4),
('Milo', 'Cat', 'Persian', 'Male', '2020-07-10', 'Adopted', 5.5, 4, NULL), -- Used to be a shelter cat, now owned!
('Daisy', 'Rabbit', 'Holland Lop', 'Female', '2024-01-05', 'Owned', 1.8, 5, NULL),
('Rocky', 'Dog', 'Husky', 'Male', '2018-09-30', 'Shelter', 29.0, NULL, 5);

-- 7. Bill (Various statuses and clients)
INSERT INTO Bill (BillDate, Total_Amount, BillStatus, ClientID) VALUES 
('2026-04-10', 850.00, 'Paid', 1),
('2026-04-12', 400.00, 'Unpaid', 2),
('2026-04-01', 1200.00, 'Paid', 4),
('2026-04-05', 150.00, 'Paid', 5),
('2026-04-13', 500.00, 'Unpaid', 6),
('2026-03-20', 2000.00, 'Paid', 1),
('2026-02-15', 300.00, 'Paid', 2);

-- 8. Medicine (Inventory for prescriptions)
INSERT INTO Medicine (MedicineName, Dosage, StockQuantity, UnitPrice, ExpiryDate, SupplierID) VALUES 
('Amoxicillin Drops', '5ml', 50, 150.00, '2027-12-01', 1),
('Flea/Tick Preventative', '1 Pipette', 120, 250.00, '2028-06-15', 2),
('Pain Relief Chewables', '1 Tablet', 200, 50.00, '2026-10-30', 1),
('Ear Drops', '3 Drops', 80, 100.00, '2027-05-20', 3),
('Dewormer Liquid', '10ml', 150, 75.00, '2028-01-10', 4),
('Eye Ointment', 'Apply thin layer', 40, 180.00, '2026-11-15', 5),
('Antibiotic Cream', 'Apply topically', 90, 120.00, '2027-08-08', 6);


-- ==========================================
-- LEVEL 3: Dependent on Level 2
-- ==========================================

-- 9. Bill_Item (Demonstrating weak entity composite keys)
INSERT INTO Bill_Item (BillID, ItemID, ItemDescription, UnitCost, Quantity, Subtotal) VALUES 
(1, 1, 'Annual Checkup Fee', 350.00, 1, 350.00),
(1, 2, 'Rabies Vaccine', 250.00, 2, 500.00),
(2, 1, 'Flea Treatment', 400.00, 1, 400.00),
(3, 1, 'X-Ray', 1000.00, 1, 1000.00),
(3, 2, 'Pain Relief', 200.00, 1, 200.00),
(4, 1, 'Nail Trimming', 150.00, 1, 150.00),
(5, 1, 'Blood Test', 500.00, 1, 500.00),
(6, 1, 'Surgery - Spay', 2000.00, 1, 2000.00),
(7, 1, 'Ear Checkup', 300.00, 1, 300.00);

-- 10. APPOINTMENT (Mix of Completed, Scheduled, Cancelled)
INSERT INTO APPOINTMENT (AppDate, AppTime, Purpose, AppStatus, AnimalID, EmployeeID) VALUES 
('2026-04-10', '10:00:00', 'Annual Checkup & Vaccines', 'Completed', 1, 1),
('2026-04-14', '14:30:00', 'Pre-Adoption Health Check', 'Scheduled', 2, 2),
('2026-04-15', '09:00:00', 'Allergic Reaction', 'Scheduled', 3, 1),
('2026-04-01', '11:00:00', 'Limping left leg', 'Completed', 5, 2),
('2026-04-05', '13:00:00', 'Nail Trim', 'Completed', 6, 1),
('2026-04-13', '15:00:00', 'Lethargy', 'Cancelled', 7, 2),
('2026-03-20', '09:30:00', 'Spay Surgery', 'Completed', 1, 5);

-- 11. Animal_Vaccine_History (M:N resolution)
INSERT INTO Animal_Vaccine_History (AnimalID, VaccineID, DateAdministered) VALUES 
(1, 1, '2026-04-10'),
(1, 2, '2026-04-10'),
(2, 1, '2025-12-05'),
(3, 3, '2026-01-15'),
(4, 4, '2026-02-20'),
(5, 5, '2025-11-10'),
(6, 1, '2026-03-05');

-- 12. MEDICAL_RECORD (Tied to animals and specific appointments)
INSERT INTO MEDICAL_RECORD (LastUpdatedDate, RecordedWeight, Diagnosis, Notes, AnimalID, AppointmentID) VALUES 
('2026-04-10', 32.5, 'Healthy', 'Dog is in great condition. Applied flea treatment.', 1, 1),
('2026-04-13', 28.0, 'Mild Ear Infection', 'Shelter dog Bella shows slight redness in left ear.', 2, NULL),
('2026-04-01', 10.1, 'Sprained Paw', 'Prescribed rest and mild pain relief.', 5, 4),
('2026-04-05', 1.8, 'Healthy', 'Routine nail trim done. No issues.', 6, 5),
('2026-03-20', 31.0, 'Post-Op Recovery', 'Spay successful. Needs monitoring for 2 days.', 1, 7),
('2026-02-10', 25.0, 'Intestinal Parasites', 'Administered dewormer.', 4, NULL),
('2026-01-15', 4.0, 'Healthy', 'Routine feline checkup.', 3, NULL);


-- ==========================================
-- LEVEL 4 & 5: Deep Dependencies
-- ==========================================

-- 13. Lab_Test (Linked to records)
INSERT INTO Lab_Test (TestType, TestDate, Result, Cost, RecordID) VALUES 
('Blood Panel', '2026-04-10', 'All levels normal', 450.00, 1),
('Ear Swab Culture', '2026-04-13', 'Positive for yeast', 200.00, 2),
('X-Ray Left Leg', '2026-04-01', 'No fractures seen', 800.00, 3),
('Pre-Op Bloodwork', '2026-03-20', 'Clear for surgery', 500.00, 5),
('Stool Sample', '2026-02-10', 'Positive for Roundworms', 150.00, 6),
('Urinalysis', '2026-01-15', 'Normal', 250.00, 7),
('Skin Scraping', '2026-04-10', 'Negative for mites', 300.00, 1);

-- 14. Prescription (Linking Vets, Meds, and Records)
INSERT INTO Prescription (Instructions, IssueDate, RefillsAllowed, DurationInDays, RecordID, MedicineID, EmployeeID) VALUES 
('Apply 5 drops in left ear twice daily', '2026-04-13', 0, 7, 2, 4, 1),
('Give 1 chewable for joint pain as needed', '2026-04-01', 1, 14, 3, 3, 2),
('Administer post-op antibiotics daily', '2026-03-20', 0, 5, 5, 1, 5),
('Give 10ml orally once', '2026-02-10', 0, 1, 6, 5, 1),
('Apply preventative once a month', '2026-04-10', 3, 30, 1, 2, 1),
('Apply cream to rash area twice daily', '2026-04-10', 1, 7, 1, 7, 1),
('Eye ointment once at night', '2026-01-15', 0, 5, 7, 6, 2);

-- 15. Adoption (The Adoption Pipeline)
INSERT INTO Adoption (ApplicationDate, AdoptionStatus, AdoptionFee, AnimalID, ClientID, EmployeeID) VALUES 
('2026-04-11', 'Pending', 1500.00, 2, 2, 4), -- Salma wants to adopt Bella
('2025-08-20', 'Approved', 1200.00, 5, 4, 6), -- Nour adopted Milo last year
('2026-03-01', 'Rejected', 0.00, 4, 3, 4), -- Youssef's application was rejected
('2026-04-05', 'Pending', 2000.00, 4, 6, 6), -- Heba wants to adopt Max
('2026-02-15', 'Approved', 1800.00, 7, 1, 4), -- Omar adopted Rocky
('2026-04-13', 'Pending', 1500.00, 7, 5, 4), -- Tarek also applying for Rocky (Waitlist)
('2025-11-10', 'Approved', 500.00, 6, 5, 6);  -- Tarek adopted Daisy


-- Step 1: Temporarily remove the derived column
ALTER TABLE ANIMAL DROP COLUMN Age;
-- Step 2: Now SQL will let you alter the DOB column!
ALTER TABLE ANIMAL ALTER COLUMN EstimatedDOB DATE NULL;
-- Step 3: Put the derived column right back
ALTER TABLE ANIMAL ADD Age AS (DATEDIFF(YEAR, EstimatedDOB, GETDATE()));
ALTER TABLE ANIMAL ALTER COLUMN LatestWeight DECIMAL(5,2) NULL;
ALTER TABLE ANIMAL ALTER COLUMN Breed VARCHAR(50) NULL;
ALTER TABLE Employee ALTER COLUMN PasswordHash VARCHAR(255) NULL;
ALTER TABLE Adoption ALTER COLUMN EmployeeID INT NULL;

-- SELECT EmployeeID, FirstName, LastName, EmployeeRole, Phone, Email, HireDate, Salary FROM Employee WHERE IsActive = 1

--DROP TABLE IF EXISTS Adoption; DROP TABLE IF EXISTS Prescription; DROP TABLE IF EXISTS Lab_Test; DROP TABLE IF EXISTS MEDICAL_RECORD; DROP TABLE IF EXISTS Animal_Vaccine_History; DROP TABLE IF EXISTS APPOINTMENT; DROP TABLE IF EXISTS Bill_Item; DROP TABLE IF EXISTS Medicine; DROP TABLE IF EXISTS Bill; DROP TABLE IF EXISTS ANIMAL; DROP TABLE IF EXISTS CLIENT; DROP TABLE IF EXISTS Employee; DROP TABLE IF EXISTS Kennel; DROP TABLE IF EXISTS Vaccine; DROP TABLE IF EXISTS Supplier;

SELECT PasswordHash, 'Client' AS Role, CAST(ClientID AS VARCHAR) AS UserID, FirstName, LastName, IsActive FROM Client WHERE Email = 'omar.h@email.com' UNION SELECT PasswordHash, EmployeeRole AS Role, CAST(EmployeeID AS VARCHAR) AS UserID, FirstName, LastName, IsActive FROM Employee WHERE Email = 'omar.h@email.com';