using PawPulse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBapplication
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }

        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
        //////////////////////////////////////////////////////////////////////////////////
        /// Login and Registration
        public DataTable GetUserLoginInfo(string email)
        {
            string query = $"SELECT PasswordHash, 'Client' AS Role, CAST(ClientID AS VARCHAR) AS UserID, FirstName, LastName, IsActive FROM Client WHERE Email = '{email}' " +
                $"UNION " +
                $"SELECT PasswordHash, EmployeeRole AS Role, CAST(EmployeeID AS VARCHAR) AS UserID, FirstName, LastName, IsActive FROM Employee WHERE Email = '{email}';";
            return dbMan.ExecuteReader(query);
        }

        // 1. Check if they are a valid new employee
        public DataTable VerifyFirstTimeEmployee(string email, string phone)
        {
            // Returns the EmployeeID ONLY if they exist, are active, and haven't set a password yet!
            string query = $@"
        SELECT EmployeeID 
        FROM Employee 
        WHERE Email = '{email}' 
        AND Phone = '{phone}' 
        AND PasswordHash IS NULL 
        AND IsActive = 1;";

            return dbMan.ExecuteReader(query);
        }

        // 2. Save their new password
        public int SetEmployeePassword(int employeeId, string hashedPassword)
        {
            string query = $@"
        UPDATE Employee 
        SET PasswordHash = '{hashedPassword}' 
        WHERE EmployeeID = {employeeId};";

            return dbMan.ExecuteNonQuery(query);
        }

        public bool CheckIfUserExists(string email, string phone)
        {
            // A simple query to count if any rows match this email or phone
            string query = $@"
        SELECT COUNT(*) 
        FROM CLIENT 
        WHERE Email = '{email}' OR Phone = '{phone}';";

            // Assuming ExecuteScalar returns an object that can be cast to an int.
            // If the count is greater than 0, the user exists!
            int count = Convert.ToInt32(dbMan.ExecuteScalar(query));
            return count > 0;
        }

        public int SignUpClient(string fName, string lName, string phone, string email, string city, string street, string buildingNum, string rawPassword)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(rawPassword);

            fName = fName.Replace("'", "''");
            lName = lName.Replace("'", "''");
            city = city.Replace("'", "''");
            street = street.Replace("'", "''");

            // We do NOT include ClientID (Identity handles it) or IsActive (Defaults to 1)
            string query = $@"
        INSERT INTO CLIENT (FirstName, LastName, Phone, Email, City, Street, BuildingNumber, PasswordHash) 
        VALUES (
            '{fName}', '{lName}', '{phone}', '{email}', '{city}', '{street}', '{buildingNum}', '{hashedPassword}'
        );
            SELECT SCOPE_IDENTITY(); ";

            object result = dbMan.ExecuteScalar(query);

            // Convert it to an integer and return it
            if (result != null)
            {
                return Convert.ToInt32(result);
            }

            return 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////
        /// Client
        ///////////////////////////////////////////////////////////////////////////////////
        /////////////////   DashBoard   /////////////////
        
        public int getPetsNumber(int clientID)
        {
            string query = $"SELECT COUNT(*) FROM ANIMAL WHERE ClientID = {clientID};";
            object result = dbMan.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public object GetNextAppointment(int clientID)
        {
            string query = $@"
        SELECT TOP 1 app.AppDate 
        FROM APPOINTMENT app
        INNER JOIN ANIMAL an ON app.AnimalID = an.AnimalID
        WHERE an.ClientID = {clientID} 
          AND app.AppDate >= CAST(GETDATE() AS DATE) 
          AND app.AppStatus = 'Scheduled' 
        ORDER BY app.AppDate ASC;";
            return dbMan.ExecuteScalar(query);
        }

        public decimal GetTotalDept(int clientID)
        {
            string query = $"Select sum(Total_Amount) " +
                $"from Bill " +
                $"where ClientID = {clientID} " +
                $"And BillStatus = 'Unpaid';";
            object result = dbMan.ExecuteScalar(query);
            if (result != DBNull.Value && result != null)
            {
                return Convert.ToDecimal(result);
            }
            return 0m;
        }

        //////////////////////// Animals /////////////////////////////////////
        public DataTable GetClientPets(int clientID)
        {
            string query = $@"
        SELECT AnimalID, AnimalName, Species, Breed, Age, LatestWeight 
        FROM ANIMAL 
        WHERE ClientID = {clientID};"; // Assuming they still own them

            return dbMan.ExecuteReader(query);
        }

        // Medical Things //
        public DataTable GetPetVisits(int animalID)
        {
            string query = $@"
        SELECT LastUpdatedDate AS 'Date', 
               Diagnosis, 
               Notes,
               RecordedWeight AS 'Weight (kg)'
        FROM MEDICAL_RECORD 
        WHERE AnimalID = {animalID} 
        ORDER BY LastUpdatedDate DESC;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetPetPrescriptions(int animalID)
        {
            // We JOIN Prescription -> Medicine (to get the name) -> Medical_Record (to check the AnimalID)
            string query = $@"
        SELECT p.IssueDate AS 'Date Issued', 
               m.MedicineName AS 'Medication', 
               p.Instructions, 
               p.RefillsAllowed AS 'Refills'
        FROM Prescription p
        INNER JOIN Medicine m ON p.MedicineID = m.MedicineID
        INNER JOIN MEDICAL_RECORD mr ON p.RecordID = mr.RecordID
        WHERE mr.AnimalID = {animalID}
        ORDER BY p.IssueDate DESC;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetPetVaccines(int animalID)
        {
            // We JOIN the History diamond table -> Vaccine table
            string query = $@"
        SELECT avh.DateAdministered AS 'Date Given', 
               v.VaccineName AS 'Vaccine', 
               v.DiseaseTargeted AS 'Target Disease'
        FROM Animal_Vaccine_History avh
        INNER JOIN Vaccine v ON avh.VaccineID = v.VaccineID
        WHERE avh.AnimalID = {animalID}
        ORDER BY avh.DateAdministered DESC;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetPetLabTests(int animalID)
        {
            // JOIN Lab_Test -> Medical_Record to ensure we match the specific AnimalID
            string query = $@"
        SELECT lt.TestDate AS 'Date', 
               lt.TestType AS 'Test', 
               lt.Result
        FROM Lab_Test lt
        INNER JOIN MEDICAL_RECORD mr ON lt.RecordID = mr.RecordID
        WHERE mr.AnimalID = {animalID}
        ORDER BY lt.TestDate DESC;";

            return dbMan.ExecuteReader(query);
        }

        // requestig an Appointment //
        public DataTable GetActiveVets()
        {
            string query = @"
        SELECT EmployeeID, (FirstName + ' ' + LastName) AS VetName 
        FROM Employee 
        WHERE EmployeeRole = 'Veterinarian' AND IsActive = 1;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetBookedTimes(int vetID, string date)
        {
            // We only care about appointments that are actually happening
            string query = $@"
        SELECT AppTime 
        FROM APPOINTMENT 
        WHERE EmployeeID = {vetID} 
        AND AppDate = '{date}' 
        AND AppStatus != 'Cancelled';";
            return dbMan.ExecuteReader(query);
        }

        public int BookAppointment(string date, string time, string purpose, int animalID, int vetID)
        {
            string safePurpose = purpose.Replace("'", "''");
            string query = $@"
        INSERT INTO APPOINTMENT (AppDate, AppTime, Purpose, AppStatus, AnimalID, EmployeeID)
        VALUES ('{date}', '{time}', '{purpose}', 'Scheduled', {animalID}, {vetID});";
            return dbMan.ExecuteNonQuery(query);
        }

        // Adding new Pet
        public int AddNewPet(string name, string species, string breed, string gender, string dobValue, string weightValue, int clientID)
        {
            name = name.Replace("'", "''");
            breed = breed.Replace("'", "''");
            species = species.Replace("'", "''");

            string query = $@"
        INSERT INTO ANIMAL (AnimalName, Species, Breed, Gender, EstimatedDOB, SystemStatus, LatestWeight, ClientID, KennelID) 
        VALUES ('{name}', '{species}', '{breed}', '{gender}', {dobValue}, 'Owned', {weightValue}, {clientID}, NULL);";

            return dbMan.ExecuteNonQuery(query);
        }

        // Editing a Pet
        public int UpdatePet(int animalID, string name, string species, string breed, string gender, string dobValue, string weightValue)
        {
            name = name.Replace("'", "''");
            breed = breed.Replace("'", "''");
            species = species.Replace("'", "''");

            string query = $@"
        UPDATE ANIMAL 
        SET AnimalName = '{name}', 
            Species = '{species}', 
            Breed = '{breed}', 
            Gender = '{gender}', 
            EstimatedDOB = {dobValue}, 
            LatestWeight = {weightValue}
        WHERE AnimalID = {animalID};";

            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable GetPetDetails(int animalID)
        {
            string query = $"SELECT AnimalName, Species, Breed, Gender, EstimatedDOB, LatestWeight FROM ANIMAL WHERE AnimalID = {animalID};";
            return dbMan.ExecuteReader(query);
        }

        // Delete a pet .. make SystemStatus "Archived"
        public int RemovePetFromClient(int animalID)
        {
            // Detach the pet from the client and mark it as 'Archived'
            // This keeps all Medical Records and Bills perfectly intact!
            string query = $@"
        UPDATE ANIMAL 
        SET ClientID = NULL, 
            SystemStatus = 'Archived' 
        WHERE AnimalID = {animalID};";

            return dbMan.ExecuteNonQuery(query);
        }


        //////////////////////      Appointments Client     ///////////////////////////////
        // 1. Fetch the appointments for the Grid
        public DataTable GetClientAppointments(int clientID)
        {
            string query = $@"
        SELECT 
            app.AppointmentID, 
            anim.AnimalName AS [Pet Name], 
            app.AppDate AS [Date], 
            app.AppTime AS [Time], 
            emp.FirstName AS [Vet Name], 
            app.Purpose, 
            app.AppStatus AS [Status]
        FROM APPOINTMENT app
        JOIN ANIMAL anim ON app.AnimalID = anim.AnimalID
        JOIN Employee emp ON app.EmployeeID = emp.EmployeeID
        WHERE anim.ClientID = {clientID}
        AND anim.SystemStatus != 'Archived'
        ORDER BY app.AppDate DESC, app.AppTime DESC;";

            return dbMan.ExecuteReader(query);
        }

        // 2. Soft-Delete (Cancel) the appointment
        public int CancelAppointment(int appointmentID)
        {
            // The WHERE clause ensures it ONLY updates if it is currently 'Scheduled'
            string query = $@"
        UPDATE APPOINTMENT 
        SET AppStatus = 'Cancelled' 
        WHERE AppointmentID = {appointmentID} AND AppStatus = 'Scheduled';";

            return dbMan.ExecuteNonQuery(query);
        }

        ////////////////////////////    ClientBilling   /////////////////////////////

        // 1. Get the summary of bills for the client
        public DataTable GetClientBills(int clientID)
        {
            string query = $@"
        SELECT 
            BillID, 
            BillDate AS [Date], 
            Total_Amount AS [Total Amount], 
            BillStatus AS [Status]
        FROM Bill
        WHERE ClientID = {clientID}
        ORDER BY BillDate DESC;";

            return dbMan.ExecuteReader(query);
        }

        // 2. Get the specific line items for a clicked bill
        public DataTable GetBillItems(int billID)
        {
            string query = $@"
        SELECT 
            ItemDescription AS [Item / Service], 
            UnitCost AS [Unit Price], 
            Quantity AS [Qty], 
            Subtotal AS [Subtotal]
        FROM Bill_Item
        WHERE BillID = {billID};";

            return dbMan.ExecuteReader(query);
        }

        ///////////////////////////     Adoption Client     //////////////////////////////


        public DataTable GetAvailablePets()
        {
            string query = @"
        SELECT AnimalID, AnimalName, Species, Breed, Gender, Age, LatestWeight 
        FROM ANIMAL 
        WHERE SystemStatus = 'Shelter'
        AND AnimalID NOT IN (
            SELECT AnimalID 
            FROM Adoption 
            WHERE AdoptionStatus IN ('Pending', 'Approved')
        );";

            return dbMan.ExecuteReader(query);
        }

        // For Tab 2: Get the client's specific requests
        public DataTable GetMyAdoptionRequests(int clientID)
        {
            // We join Adoption and ANIMAL to get the pet's details along with the request status!
            string query = $@"
        SELECT 
            adp.AdoptionID, 
            adp.ApplicationDate, 
            adp.AdoptionStatus, 
            adp.AdoptionFee, 
            anim.AnimalName, 
            anim.Species, 
            anim.Breed,
            adp.AnimalID,
            anim.Gender,
            anim.Age,
            anim.LatestWeight
        FROM Adoption adp
        JOIN ANIMAL anim ON adp.AnimalID = anim.AnimalID
        WHERE adp.ClientID = {clientID}
        ORDER BY adp.ApplicationDate DESC;";

            return dbMan.ExecuteReader(query);
        }

        public int SubmitAdoptionRequest(int animalID, int clientID)
        {
            // Inserts the pending request. EmployeeID is NULL because no admin has reviewed it yet!
            string query = $@"
        INSERT INTO Adoption (ApplicationDate, AdoptionStatus, AdoptionFee, AnimalID, ClientID, EmployeeID) 
        VALUES (CAST(GETDATE() AS DATE), 'Pending', 0.00, {animalID}, {clientID}, NULL);";

            return dbMan.ExecuteNonQuery(query);
        }

        public int CancelAdoptionRequest(int animalID, int clientID)
        {
            // The "AND AdoptionStatus = 'Pending'" is a safety net! 
            // Even if a user somehow clicks cancel on an approved request, the database will refuse to delete it.
            string query = $@"
        DELETE FROM Adoption 
        WHERE AnimalID = {animalID} 
        AND ClientID = {clientID} 
        AND AdoptionStatus = 'Pending';";

            return dbMan.ExecuteNonQuery(query);
        }

        ///////////////////////////////////////////////////////////////////////////////////
        /// Veterinarian Dashboard
        /// ///////////////////////////////////////////////////////////////////////////////


        public DataTable GetActiveEmployees()
        {
            string query = "SELECT EmployeeID, FirstName, LastName, EmployeeRole, Phone, Email, HireDate, Salary FROM Employee WHERE IsActive = 1;";
            return dbMan.ExecuteReader(query);
        }

        
        public DataTable GetVetAppointments(int vetId)
        {
            string query = $@"
                SELECT a.AppointmentID, a.AppDate AS Date, a.AppTime AS Time, a.Purpose, a.AppStatus AS Status,
                       an.AnimalName, an.Species,
                       ISNULL(c.FirstName + ' ' + c.LastName, 'Shelter Animal') AS OwnerName
                FROM APPOINTMENT a
                JOIN ANIMAL an ON a.AnimalID = an.AnimalID
                LEFT JOIN CLIENT c ON an.ClientID = c.ClientID
                WHERE a.EmployeeID = {vetId}
                ORDER BY a.AppDate DESC, a.AppTime DESC;";
            return dbMan.ExecuteReader(query);
        }

        public bool UpdateAppointmentStatus(int appointmentId, string status)
        {
            string query = $"UPDATE APPOINTMENT SET AppStatus = '{status}' WHERE AppointmentID = {appointmentId};";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public DataTable GetMedicalRecords()
        {
            string query = $@"
                SELECT mr.RecordID, mr.LastUpdatedDate AS Date, mr.RecordedWeight AS Weight,
                       mr.Diagnosis, mr.Notes, an.AnimalName, an.Species,
                       ISNULL(c.FirstName + ' ' + c.LastName, 'Shelter Animal') AS OwnerName,
                       mr.AnimalID, mr.AppointmentID
                FROM MEDICAL_RECORD mr
                JOIN ANIMAL an ON mr.AnimalID = an.AnimalID
                LEFT JOIN CLIENT c ON an.ClientID = c.ClientID
                ORDER BY mr.LastUpdatedDate DESC;";
            return dbMan.ExecuteReader(query);
        }

        public bool AddMedicalRecord(int animalId, string diagnosis, string notes, decimal weight, int? appointmentId)
        {
            string apptPart = appointmentId.HasValue ? appointmentId.Value.ToString() : "NULL";
            string query = $@"
                INSERT INTO MEDICAL_RECORD (LastUpdatedDate, RecordedWeight, Diagnosis, Notes, AnimalID, AppointmentID)
                VALUES (CAST(GETDATE() AS DATE), {weight}, '{diagnosis}', '{notes}', {animalId}, {apptPart});";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public DataTable GetPrescriptions(int vetId)
        {
            string query = $@"
                SELECT p.PrescriptionID, p.IssueDate AS Date, m.MedicineName, an.AnimalName,
                       p.Instructions, p.RefillsAllowed AS Refills, p.DurationInDays AS Duration,
                       p.RecordID, p.MedicineID
                FROM Prescription p
                JOIN MEDICAL_RECORD mr ON p.RecordID = mr.RecordID
                JOIN ANIMAL an ON mr.AnimalID = an.AnimalID
                JOIN Medicine m ON p.MedicineID = m.MedicineID
                WHERE p.EmployeeID = {vetId}
                ORDER BY p.IssueDate DESC;";
            return dbMan.ExecuteReader(query);
        }

        public bool AddPrescription(int recordId, int medicineId, int vetId, string instructions, int refills, int duration, bool paidInCash = false)
        {
            string query = $@"
                INSERT INTO Prescription (Instructions, IssueDate, RefillsAllowed, DurationInDays, RecordID, MedicineID, EmployeeID)
                VALUES ('{instructions}', CAST(GETDATE() AS DATE), {refills}, {duration}, {recordId}, {medicineId}, {vetId});";
            bool ok = dbMan.ExecuteNonQuery(query) > 0;
            if (ok)
            {
                int? clientId = GetClientIdFromRecord(recordId);
                if (clientId.HasValue)
                {
                    var medDt = dbMan.ExecuteReader($"SELECT MedicineName, UnitPrice FROM Medicine WHERE MedicineID = {medicineId};");
                    if (medDt != null && medDt.Rows.Count > 0)
                    {
                        string medName = medDt.Rows[0]["MedicineName"].ToString();
                        decimal unitPrice = Convert.ToDecimal(medDt.Rows[0]["UnitPrice"]);
                        decimal totalCost = unitPrice * (refills + 1);
                        int billId = GetOrCreateOpenBill(clientId.Value, paidInCash);
                        if (billId > 0)
                            AddBillItem(billId, $"Prescription: {medName} x{refills + 1}", totalCost);
                    }
                }
            }
            return ok;
        }

        public DataTable GetLabTests()
        {
            string query = $@"
                SELECT lt.TestID, lt.TestType AS Type, lt.TestDate AS Date, lt.Result, lt.Cost,
                       an.AnimalName, lt.RecordID
                FROM Lab_Test lt
                JOIN MEDICAL_RECORD mr ON lt.RecordID = mr.RecordID
                JOIN ANIMAL an ON mr.AnimalID = an.AnimalID
                ORDER BY lt.TestDate DESC;";
            return dbMan.ExecuteReader(query);
        }

        public bool AddLabTest(int recordId, string testType, string result, decimal cost, bool paidInCash = false)
        {
            string query = $@"
                INSERT INTO Lab_Test (TestType, TestDate, Result, Cost, RecordID)
                VALUES ('{testType}', CAST(GETDATE() AS DATE), '{result}', {cost}, {recordId});";
            bool ok = dbMan.ExecuteNonQuery(query) > 0;
            if (ok)
            {
                int? clientId = GetClientIdFromRecord(recordId);
                if (clientId.HasValue)
                {
                    int billId = GetOrCreateOpenBill(clientId.Value, paidInCash);
                    if (billId > 0)
                        AddBillItem(billId, $"Lab Test: {testType}", cost);
                }
            }
            return ok;
        }

        public DataTable GetVaccinations()
        {
            string query = $@"
                SELECT an.AnimalName, v.VaccineName, v.DiseaseTargeted, avh.DateAdministered AS Date,
                       avh.AnimalID, avh.VaccineID
                FROM Animal_Vaccine_History avh
                JOIN ANIMAL an ON avh.AnimalID = an.AnimalID
                JOIN Vaccine v ON avh.VaccineID = v.VaccineID
                ORDER BY avh.DateAdministered DESC;";
            return dbMan.ExecuteReader(query);
        }

        public bool AddVaccination(int animalId, int vaccineId, DateTime date)
        {
            string dateStr = date.ToString("yyyy-MM-dd");
            string query = $"INSERT INTO Animal_Vaccine_History (AnimalID, VaccineID, DateAdministered) VALUES ({animalId}, {vaccineId}, '{dateStr}');";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public DataTable GetShelterAnimals()
        {
            string query = @"
        SELECT 
            A.AnimalID AS [ID],
            A.AnimalName AS [Name],
            A.Species,
            A.Breed,
            A.Age,
            A.SystemStatus AS [System Status],
            ISNULL(K.WardType + ' (Cage ' + CAST(K.KennelID AS VARCHAR) + ')', 'Unassigned') AS [Current Location]
        FROM ANIMAL A
        LEFT JOIN Kennel K ON A.KennelID = K.KennelID
        ORDER BY 
            CASE A.SystemStatus 
                WHEN 'Shelter' THEN 1 
                WHEN 'Adopted' THEN 2 
                ELSE 3 END, 
            A.AnimalName;";

            return dbMan.ExecuteReader(query);
        }

        public bool IssueClearance(int animalId)
        {
            string query = $@"
                INSERT INTO MEDICAL_RECORD (LastUpdatedDate, RecordedWeight, Diagnosis, Notes, AnimalID, AppointmentID)
                VALUES (CAST(GETDATE() AS DATE),
                       ISNULL((SELECT LatestWeight FROM ANIMAL WHERE AnimalID = {animalId}), 0),
                       'Cleared for Adoption', 'Animal has been examined and cleared for adoption.', {animalId}, NULL);";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public DataTable GetAllAnimals()
        {
            string query = "SELECT AnimalID, AnimalName + ' (' + Species + ')' AS Display FROM ANIMAL ORDER BY AnimalName;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetMedicines()
        {
            string query = "SELECT MedicineID, MedicineName AS Display FROM Medicine ORDER BY MedicineName;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetVaccines()
        {
            string query = "SELECT VaccineID, VaccineName AS Display FROM Vaccine ORDER BY VaccineName;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetAvailableKennels()
        {
            string query = "SELECT KennelID, KennelSize + ' - ' + WardType + ' (ID: ' + CAST(KennelID AS VARCHAR) + ')' AS Display FROM Kennel WHERE KennelStatus = 'Available';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetMedicalRecordsDropdown()
        {
            string query = $@"
                SELECT mr.RecordID, an.AnimalName + ' - ' + mr.Diagnosis AS Display
                FROM MEDICAL_RECORD mr
                JOIN ANIMAL an ON mr.AnimalID = an.AnimalID
                ORDER BY mr.LastUpdatedDate DESC;";
            return dbMan.ExecuteReader(query);
        }

        public bool RegisterAnimal(string name, string species, string breed, string gender, string dob, decimal weight, int kennelId)
        {
            string query = $@"
                INSERT INTO ANIMAL (AnimalName, Species, Breed, Gender, EstimatedDOB, SystemStatus, LatestWeight, ClientID, KennelID)
                VALUES ('{name}', '{species}', '{breed}', '{gender}', '{dob}', 'Shelter', {weight}, NULL, {kennelId});
                UPDATE Kennel SET KennelStatus = 'Occupied' WHERE KennelID = {kennelId};";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public bool UpdateMedicalRecord(int recordId, int animalId, string diagnosis, string notes, decimal weight, int? appointmentId)
        {
            string apptPart = appointmentId.HasValue ? appointmentId.Value.ToString() : "NULL";
            string query = $"UPDATE MEDICAL_RECORD SET AnimalID={animalId}, Diagnosis='{diagnosis}', Notes='{notes}', RecordedWeight={weight}, AppointmentID={apptPart}, LastUpdatedDate=CAST(GETDATE() AS DATE) WHERE RecordID={recordId};";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public bool DeleteMedicalRecord(int recordId)
        {
            string query = $"DELETE FROM MEDICAL_RECORD WHERE RecordID={recordId};";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public bool UpdatePrescription(int prescriptionId, int recordId, int medicineId, string instructions, int refills, int duration)
        {
            string query = $"UPDATE Prescription SET RecordID={recordId}, MedicineID={medicineId}, Instructions='{instructions}', RefillsAllowed={refills}, DurationInDays={duration} WHERE PrescriptionID={prescriptionId};";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public bool DeletePrescription(int prescriptionId)
        {
            string query = $"DELETE FROM Prescription WHERE PrescriptionID={prescriptionId};";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public bool UpdateLabTest(int testId, int recordId, string testType, string result, decimal cost)
        {
            string query = $"UPDATE Lab_Test SET RecordID={recordId}, TestType='{testType}', Result='{result}', Cost={cost} WHERE TestID={testId};";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public bool DeleteLabTest(int testId)
        {
            string query = $"DELETE FROM Lab_Test WHERE TestID={testId};";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public bool DeleteVaccination(int animalId, int vaccineId, string date)
        {
            string query = $"DELETE FROM Animal_Vaccine_History WHERE AnimalID={animalId} AND VaccineID={vaccineId} AND DateAdministered='{date}';";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public DataTable GetAnimalById(int animalId)
        {
            string query = $"SELECT AnimalID, AnimalName, Species, Breed, Gender, EstimatedDOB, LatestWeight FROM ANIMAL WHERE AnimalID={animalId};";
            return dbMan.ExecuteReader(query);
        }

        public bool UpdateShelterAnimal(int animalId, string name, string species, string breed, string gender, string dob, decimal weight)
        {
            string query = $"UPDATE ANIMAL SET AnimalName='{name}', Species='{species}', Breed='{breed}', Gender='{gender}', EstimatedDOB='{dob}', LatestWeight={weight} WHERE AnimalID={animalId};";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public bool DeleteAnimal(int animalId)
        {
            string query = $@"
                UPDATE Kennel SET KennelStatus='Available' WHERE KennelID=(SELECT KennelID FROM ANIMAL WHERE AnimalID={animalId} AND KennelID IS NOT NULL);
                UPDATE ANIMAL SET SystemStatus='Archived', ClientID=NULL, KennelID=NULL WHERE AnimalID={animalId};";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public int GetTodayAppointmentsCount(int vetId)
        {
            string query = $"SELECT COUNT(*) FROM APPOINTMENT WHERE EmployeeID = {vetId} AND AppDate = CAST(GETDATE() AS DATE);";
            object result = dbMan.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public int GetScheduledAppointmentsCount(int vetId)
        {
            string query = $"SELECT COUNT(*) FROM APPOINTMENT WHERE EmployeeID = {vetId} AND AppStatus = 'Scheduled';";
            object result = dbMan.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public int GetTotalPatientsCount(int vetId)
        {
            string query = $"SELECT COUNT(DISTINCT AnimalID) FROM APPOINTMENT WHERE EmployeeID = {vetId};";
            object result = dbMan.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }


        // Get all employees from database
        public DataTable GetAllEmployees()
        {
            string query = "SELECT EmployeeID, FirstName + ' ' + LastName AS FullName, EmployeeRole AS [Role] , Email AS [Work Email], Phone AS [Contact Number], Salary [Monthly Salary], IsActive FROM Employee";
            return dbMan.ExecuteReader(query); // Assuming dbManager handles the connection
        }
        // Update employee active status in DB
        // 


        public int UpdateEmployeeStatus(int id, int status)
        {
            string query = $"UPDATE Employee SET IsActive = {status} WHERE EmployeeID = {id}";
            return dbMan.ExecuteNonQuery(query);
        }
        // Insert a new employee into the database
        public int InsertEmployee(string fName, string lName, string role, string email, string phone, decimal salary)
        {
            // SQL query with formatted values
            string query = "INSERT INTO Employee (FirstName, LastName, EmployeeRole, Email, PasswordHash, Phone, HireDate, Salary, IsActive) " +
                           $"VALUES ('{fName}', '{lName}', '{role}', '{email}', null, '{phone}', CAST(GETDATE() AS DATE), {salary}, 1)";

            return dbMan.ExecuteNonQuery(query); // Returns rows affected
        }
        // Get distinct employee roles for the dropdown
        // Retrieves distinct employee roles excluding the 'Manager' role
        public DataTable GetEmployeeRoles()
        {
            string query = "SELECT DISTINCT EmployeeRole FROM Employee WHERE EmployeeRole != 'Manager'";
            return dbMan.ExecuteReader(query);
        }
        // Get a single employee's data by ID
        public DataTable GetEmployeeByID(int empID)
        {
            string query = $"SELECT * FROM Employee WHERE EmployeeID = {empID}";
            return dbMan.ExecuteReader(query);
        }

        // Update existing employee data
        public int UpdateEmployee(int empID, string txtFName, string txtLName, string cmbRole, string txtEmail, string txtphone, decimal txtSalary)
        {
            string query = $@"UPDATE Employee 
                      SET FirstName = '{txtFName}', 
                          LastName = '{txtLName}', 
                          EmployeeRole = '{cmbRole}', 
                          Email = '{txtEmail}', 
                          Phone = '{txtphone}', 
                          Salary = {txtSalary} 
                      WHERE EmployeeID = {empID}";

            return dbMan.ExecuteNonQuery(query);
        }

        // Delete an employee permanently from the database
        public int DeleteEmployee(int empID)
        {
            // SQL query to remove the record based on its unique ID
            string query = $"DELETE FROM Employee WHERE EmployeeID = {empID}";

            // Execute and return the number of affected rows
            return dbMan.ExecuteNonQuery(query);
        }

       

        // Update existing client information
        public int UpdateClient(int clientID, string txtFName, string txtLName, string txtPhone, string txtEmail,
                                string txtCity, string txtStreet, string txtBuilding)
        {
            string query = $@"UPDATE Client 
                      SET FirstName = '{txtFName}', 
                          LastName = '{txtLName}', 
                          Phone = '{txtPhone}', 
                          Email = '{txtEmail}', 
                          City = '{txtCity}', 
                          Street = '{txtStreet}', 
                          BuildingNumber = '{txtBuilding}' 
                      WHERE ClientID = {clientID}";

            return dbMan.ExecuteNonQuery(query);
        }
        // Retrieve a single client record by ID for editing purposes
        public DataTable GetClientById(int clientId)
        {
            // SQL query to fetch all details for the specified client
            string query = $"SELECT * FROM Client WHERE ClientID = {clientId}";

            // Execute the query and return the resulting data table
            return dbMan.ExecuteReader(query);
        }

        // Update only the activation status of a client
        public int UpdateClientStatus(int clientId, int newStatusValue)
        {
            // SQL query to update the IsActive bit (0 or 1)
            string query = $"UPDATE Client SET IsActive = {newStatusValue} WHERE ClientID = {clientId}";

            return dbMan.ExecuteNonQuery(query);
        }
        // Delete a client record permanently from the database
        public int DeleteClient(int clientID)
        {
            // SQL query targeting the Clients table and its Primary Key
            string query = $"DELETE FROM Client WHERE ClientID = {clientID}";

            // Execute the non-query and return rows affected
            return dbMan.ExecuteNonQuery(query);
        }

        // Retrieve all client details excluding sensitive PasswordHash
        public DataTable GetAllClients()
        {
            // Selecting columns based on the schema in image_67d47a.png
            string query = @"SELECT ClientID, FirstName, LastName, Phone, Email, 
                            City, Street, BuildingNumber, IsActive 
                    FROM Client";

            return dbMan.ExecuteReader(query);
        }

        // --- Medicines & Suppliers Logic ---

        // 1.GET all medicines with supplier names for display in the DataGridView
        public DataTable GetAllMedicines()
        {
            // English comments: Joining Medicine and Supplier to show names instead of IDs
            string query = @"SELECT M.MedicineID, M.MedicineName, M.Dosage, M.StockQuantity, 
                            M.UnitPrice, M.ExpiryDate, S.SupplierName 
                     FROM Medicine M 
                     JOIN Supplier S ON M.SupplierID = S.SupplierID";
            return dbMan.ExecuteReader(query);
        }

        // 2. GET all suppliers for the dropdown when adding/editing medicines
        public DataTable GetAllSuppliers()
        {
            string query = "SELECT * FROM Supplier";
            return dbMan.ExecuteReader(query);
        }

        // 3. Search medicines by name or supplier name using a single query with JOIN and LIKE
        public DataTable SearchMedicines(string term)
        {
            string query = $@"SELECT M.MedicineID, M.MedicineName, M.Dosage, M.StockQuantity, 
                             M.UnitPrice, M.ExpiryDate, S.SupplierName 
                      FROM Medicine M 
                      JOIN Supplier S ON M.SupplierID = S.SupplierID
                      WHERE M.MedicineName LIKE '%{term}%' OR S.SupplierName LIKE '%{term}%'";
            return dbMan.ExecuteReader(query);
        }
        // Retrieves all medicines joined with their supplier names
        public DataTable GetAllMedicinesWithSuppliers()
        {
            string query = @"SELECT M.MedicineID, M.MedicineName, M.Dosage, M.StockQuantity, 
                            M.UnitPrice, M.ExpiryDate, S.SupplierName 
                     FROM Medicine M 
                     JOIN Supplier S ON M.SupplierID = S.SupplierID";
            return dbMan.ExecuteReader(query);
        }

        

        // Deletes a medicine record by ID
        public int DeleteMedicine(int medicineID)
        {
            string query = $"DELETE FROM Medicine WHERE MedicineID = {medicineID}";
            return dbMan.ExecuteNonQuery(query);
        }

        // Retrieve distinct species from the ANIMAL table for the ComboBox suggestions
        public DataTable GetDistinctSpecies()
        {
            string query = "SELECT DISTINCT Species FROM ANIMAL WHERE Species IS NOT NULL";
            return dbMan.ExecuteReader(query);
        }

        // Retrieve current adoption fees configuration
        public DataTable GetAdoptionSettings()
        {
            string query = "SELECT SettingID, Species, BaseFee FROM AdoptionSettings";
            return dbMan.ExecuteReader(query);
        }

        // Insert or Update the adoption fee for a specific species
        public int SetAdoptionFee(string species, decimal fee)
        {
            // Check if the species already exists in the settings
            string checkQuery = $"SELECT COUNT(*) FROM AdoptionSettings WHERE Species = '{species}'";
            int count = (int)dbMan.ExecuteScalar(checkQuery);

            string query;
            if (count > 0)
            {
                query = $"UPDATE AdoptionSettings SET BaseFee = {fee} WHERE Species = '{species}'";
            }
            else
            {
                query = $"INSERT INTO AdoptionSettings (Species, BaseFee) VALUES ('{species}', {fee})";
            }

            return dbMan.ExecuteNonQuery(query);
        }
        // 1. Get total revenue for a specific month
        public decimal GetMonthlyRevenue(int month, int year)
        {
            string query = $@"SELECT SUM(Total_Amount) FROM Bill 
                      WHERE MONTH(BillDate) = {month} 
                      AND YEAR(BillDate) = {year} 
                      AND BillStatus = 'Paid'";
            object result = dbMan.ExecuteScalar(query);
            return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
        }
        // 1. Detailed Animals Report (Using existing columns only)
        public DataTable GetDetailedAnimalsReport()
        {
            string query = @"SELECT 
                        A.AnimalName AS [Name], 
                        A.Species, 
                        A.Breed, 
                        A.Gender,
                        A.Age,
                        ISNULL(S.BaseFee, 0) AS [Base Adoption Fee],
                        A.SystemStatus AS [Current Status]
                     FROM ANIMAL A
                     LEFT JOIN AdoptionSettings S ON A.Species = S.Species";
            return dbMan.ExecuteReader(query);
        }

        // 2. Managerial Report (Financials and HR summaries)
        public DataTable GetManagerialReport(int month, int year)
        {
            // English comments: Aggregating stats from Employee, Medicine, and Bill tables
            string query = $@"
        SELECT 'Total Staff' AS [Category], CAST(COUNT(*) AS VARCHAR) AS [Stats] 
        FROM Employee WHERE IsActive = 1
        
        UNION ALL
        
        SELECT 'Monthly Payroll (Salaries)', CAST(SUM(Salary) AS VARCHAR) 
        FROM Employee WHERE IsActive = 1
        
        UNION ALL
        
        SELECT 'Unique Medicines in Stock', CAST(COUNT(*) AS VARCHAR) 
        FROM Medicine
        
        UNION ALL
        
        SELECT 'Total Inventory Value (Meds)', CAST(SUM(StockQuantity * UnitPrice) AS VARCHAR) 
        FROM Medicine
        
        UNION ALL
        
        SELECT 'Monthly Revenue', CAST(ISNULL(SUM(Total_Amount), 0) AS VARCHAR) 
        FROM Bill 
        WHERE MONTH(BillDate) = {month} AND YEAR(BillDate) = {year} AND BillStatus = 'Paid'";

            return dbMan.ExecuteReader(query);
        }

        // Retrieves the total count of all animals in the database
        public int GetTotalAnimals()
        {
            string query = "SELECT COUNT(*) FROM ANIMAL";
            object result = dbMan.ExecuteScalar(query);
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        // 2. Get animal species distribution for the Pie Chart
        public DataTable GetSpeciesDistribution()
        {
            
            string query = "SELECT Species, COUNT(*) AS SpeciesCount FROM ANIMAL GROUP BY Species";
            return dbMan.ExecuteReader(query);
        }
        // ==========================================
        // Dashboard & Reports Data Retrieval
        // ==========================================

        // Retrieves the total count of animals currently in the shelter
        public int GetTotalShelterAnimals()
        {
            string query = "SELECT COUNT(*) FROM ANIMAL WHERE SystemStatus = 'Shelter'";
            object result = dbMan.ExecuteScalar(query);
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        // Retrieves the total revenue from paid bills for the current month
        public decimal GetCurrentMonthRevenue()
        {
            string query = @"SELECT SUM(Total_Amount) FROM Bill 
                     WHERE MONTH(BillDate) = MONTH(GETDATE()) 
                     AND YEAR(BillDate) = YEAR(GETDATE()) 
                     AND BillStatus = 'Paid'";
            object result = dbMan.ExecuteScalar(query);
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
        }

        // Retrieves the count of pending adoption requests
        public int GetPendingAdoptionsCount()
        {
            string query = "SELECT COUNT(*) FROM Adoption WHERE AdoptionStatus = 'Pending'";
            object result = dbMan.ExecuteScalar(query);
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        // Retrieves the count of medicines with stock below 10
        public int GetLowStockMedicineCount()
        {
            string query = "SELECT COUNT(*) FROM Medicine WHERE StockQuantity < 10";
            object result = dbMan.ExecuteScalar(query);
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        // Retrieves monthly revenue trend for the Column Chart (Last 6 months)
        public DataTable GetRevenueTrend()
        {
            string query = @"SELECT FORMAT(BillDate, 'MMM yyyy') AS MonthName, SUM(Total_Amount) AS Revenue 
                     FROM Bill 
                     WHERE BillStatus = 'Paid' AND BillDate >= DATEADD(month, -6, GETDATE())
                     GROUP BY FORMAT(BillDate, 'MMM yyyy'), YEAR(BillDate), MONTH(BillDate)
                     ORDER BY YEAR(BillDate), MONTH(BillDate)";
            return dbMan.ExecuteReader(query);
        }
        // 1. Get total number of active employees
        public int GetTotalActiveEmployees()
        {
            string query = "SELECT COUNT(*) FROM Employee WHERE IsActive = 1";
            object result = dbMan.ExecuteScalar(query);
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        // 2. Get total monthly salaries for active staff
        public decimal GetTotalSalaries()
        {
            string query = "SELECT SUM(Salary) FROM Employee WHERE IsActive = 1";
            object result = dbMan.ExecuteScalar(query);
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }

        // 3. Get total types of medicine in stock
        public int GetMedicineCount()
        {
            string query = "SELECT COUNT(*) FROM Medicine";
            object result = dbMan.ExecuteScalar(query);
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        // 4. Get total monetary value of medicine inventory
        public decimal GetTotalInventoryValue()
        {
            string query = "SELECT SUM(StockQuantity * UnitPrice) FROM Medicine";
            object result = dbMan.ExecuteScalar(query);
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }

        // 5. Get distribution of employee roles for Pie Chart
        public DataTable GetEmployeeRoleDist()
        {
            string query = "SELECT EmployeeRole, COUNT(*) AS Count FROM Employee WHERE IsActive = 1 GROUP BY EmployeeRole";
            return dbMan.ExecuteReader(query);
        }

        // 6. Get a summary of Revenue vs Salaries for the Column Chart
        public DataTable GetFinancialSummary(int month, int year)
        {
            string query = $@"
        SELECT 'Revenue' AS Category, ISNULL(SUM(Total_Amount), 0) AS Amount 
        FROM Bill 
        WHERE MONTH(BillDate) = {month} AND YEAR(BillDate) = {year} AND BillStatus = 'Paid'
        UNION ALL
        SELECT 'Salaries', ISNULL(SUM(Salary), 0) 
        FROM Employee 
        WHERE IsActive = 1";
            return dbMan.ExecuteReader(query);
        }
        // Retrieves all kennels and the names of assigned animals
        public DataTable GetAllKennelsWithAnimals()
        {
            string query = @"SELECT 
                K.KennelID, 
                K.KennelSize AS [Size], 
                K.WardType AS [Ward], 
                K.Capacity, 
                K.KennelStatus AS [Status],
                ISNULL(A.AnimalName, 'Empty') AS [Occupied By],
                A.AnimalID  -- WE MUST ADD THIS LINE SO THE GRID HAS THE ID
             FROM Kennel K
             LEFT JOIN ANIMAL A ON K.KennelID = A.KennelID";
            return dbMan.ExecuteReader(query);
        }

        // Updates the status of a specific kennel
        public int UpdateKennelStatus(int kennelId, string newStatus)
        {
            string query = $"UPDATE Kennel SET KennelStatus = '{newStatus}' WHERE KennelID = {kennelId}";
            return dbMan.ExecuteNonQuery(query);
        }

        // Deletes a kennel from the database
        public int DeleteKennel(int kennelId)
        {
            string query = $"DELETE FROM Kennel WHERE KennelID = {kennelId}";
            return dbMan.ExecuteNonQuery(query);
        }



        //Shelter staff stuff

        // 1. Get shelter animals that are NOT in a kennel yet
        public DataTable GetUnassignedShelterAnimals()
        {
            string query = "SELECT AnimalID, AnimalName FROM ANIMAL WHERE SystemStatus = 'Shelter' AND KennelID IS NULL;";
            return dbMan.ExecuteReader(query);
        }

        // 2. Assign an animal to a kennel
        public int AssignAnimalToKennel(int animalId, int kennelId)
        {
            // 1. Assign the animal
            string query1 = $"UPDATE ANIMAL SET KennelID = {kennelId} WHERE AnimalID = {animalId};";
            dbMan.ExecuteNonQuery(query1);

            // 2. Dynamically check if the kennel is full now, and update status accordingly
            string query2 = $@"
        IF (SELECT COUNT(*) FROM ANIMAL WHERE KennelID = {kennelId}) >= (SELECT Capacity FROM Kennel WHERE KennelID = {kennelId})
            UPDATE Kennel SET KennelStatus = 'Occupied' WHERE KennelID = {kennelId};
        ELSE
            UPDATE Kennel SET KennelStatus = 'Available' WHERE KennelID = {kennelId};";

            return dbMan.ExecuteNonQuery(query2);
        }

        // 3. Clear a kennel (Removes the animal and marks kennel for cleaning)
        // Removes a specific animal from a kennel and marks the kennel for cleaning
        // Removes a specific animal from a kennel and marks the kennel for cleaning
        public int RemoveAnimalFromKennel(int animalId, int kennelId)
        {
            // 1. Remove ONLY the specific animal we clicked on (Notice: WHERE AnimalID = ...)
            string query1 = $"UPDATE ANIMAL SET KennelID = NULL WHERE AnimalID = {animalId};";
            dbMan.ExecuteNonQuery(query1);

            // 2. Check if the kennel is NOW completely empty
            string query2 = $@"
        IF (SELECT COUNT(*) FROM ANIMAL WHERE KennelID = {kennelId}) = 0
            UPDATE Kennel SET KennelStatus = 'Needs Cleaning' WHERE KennelID = {kennelId};
        ELSE
            UPDATE Kennel SET KennelStatus = 'Available' WHERE KennelID = {kennelId};";

            return dbMan.ExecuteNonQuery(query2);
        }





        ///////////////////////////////////////////////////////////////////////////////////
        /// Shelter Staff: Process Adoptions
        ///////////////////////////////////////////////////////////////////////////////////

        // 1. Get all Pending Adoptions for the staff to review
        // 1. Get all Pending Adoptions for the staff to review
        public DataTable GetPendingAdoptions()
        {
            // We JOIN Adoption, ANIMAL, and CLIENT to get a complete picture
            string query = @"
        SELECT 
            adp.AdoptionID, 
            adp.ApplicationDate, 
            adp.AdoptionStatus AS [Status], -- WE ADDED THIS LINE!
            adp.AdoptionFee,
            anim.AnimalID,
            anim.AnimalName, 
            anim.Species, 
            c.ClientID,
            c.FirstName + ' ' + c.LastName AS ClientName,
            c.Phone
        FROM Adoption adp
        JOIN ANIMAL anim ON adp.AnimalID = anim.AnimalID
        JOIN CLIENT c ON adp.ClientID = c.ClientID
        WHERE adp.AdoptionStatus = 'Pending'
        ORDER BY adp.ApplicationDate ASC;";

            return dbMan.ExecuteReader(query);
        }

        // 2. Reject an Adoption
        public int RejectAdoption(int adoptionId, int employeeId)
        {
            // Update the status and record WHICH staff member rejected it
            string query = $@"
                UPDATE Adoption 
                SET AdoptionStatus = 'Rejected', EmployeeID = {employeeId} 
                WHERE AdoptionID = {adoptionId};";

            return dbMan.ExecuteNonQuery(query);
        }

        // 3. Approve an Adoption (Complex transaction!)
        public int ApproveAdoption(int adoptionId, int animalId, int clientId, int employeeId)
        {
            /* 
             * When an adoption is approved:
             * 1. Update the Adoption record (Approved, mark the employee).
             * 2. Free up the Kennel (Only affects the kennel if the animal actually had one).
             * 3. Update the Animal record (SystemStatus = 'Adopted', assign ClientID, clear KennelID).
             */
            string query = $@"
                UPDATE Adoption 
                SET AdoptionStatus = 'Approved', EmployeeID = {employeeId} 
                WHERE AdoptionID = {adoptionId};

                UPDATE Kennel 
                SET KennelStatus = 'Needs Cleaning' 
                WHERE KennelID = (SELECT KennelID FROM ANIMAL WHERE AnimalID = {animalId});

                UPDATE ANIMAL 
                SET SystemStatus = 'Adopted', ClientID = {clientId}, KennelID = NULL 
                WHERE AnimalID = {animalId};";

            return dbMan.ExecuteNonQuery(query);
        }

        // Checks if the kennel has reached its maximum capacity
        public bool IsKennelFull(int kennelId)
        {
            string query = $@"
        SELECT 
            (SELECT Capacity FROM Kennel WHERE KennelID = {kennelId}) - 
            (SELECT COUNT(*) FROM ANIMAL WHERE KennelID = {kennelId})";

            object result = dbMan.ExecuteScalar(query);
            int freeSpace = result != DBNull.Value ? Convert.ToInt32(result) : 0;

            return freeSpace <= 0; // Returns true if there is 0 or less free space
        }



        ///////////////////////////////////////////////////////////////////////////////////
        /// Shelter Staff: Register Animal
        ///////////////////////////////////////////////////////////////////////////////////

        // 1. Get Kennels that actually have space (Capacity > current occupants)
        public DataTable GetKennelsWithSpace()
        {
            string query = @"
        SELECT 
            K.KennelID, 
            K.KennelSize + ' - ' + K.WardType + ' (ID: ' + CAST(K.KennelID AS VARCHAR) + ')' AS Display 
        FROM Kennel K
        WHERE (SELECT COUNT(*) FROM ANIMAL A WHERE A.KennelID = K.KennelID) < K.Capacity
        AND K.KennelStatus != 'Needs Cleaning';";

            return dbMan.ExecuteReader(query);
        }

        // 2. Register the Animal (Smart enough to handle NULL kennels)
        public bool ShelterRegisterAnimal(string name, string species, string breed, string gender, string dob, decimal weight, int? kennelId)
        {
            // Handle the NULL value for SQL if they leave the kennel blank
            string kennelPart = kennelId.HasValue ? kennelId.Value.ToString() : "NULL";

            // Insert the animal
            string query1 = $@"
                INSERT INTO ANIMAL (AnimalName, Species, Breed, Gender, EstimatedDOB, SystemStatus, LatestWeight, ClientID, KennelID)
                VALUES ('{name}', '{species}', '{breed}', '{gender}', '{dob}', 'Shelter', {weight}, NULL, {kennelPart});";

            dbMan.ExecuteNonQuery(query1);

            // ONLY update kennel capacity if a kennel was actually selected
            if (kennelId.HasValue)
            {
                string query2 = $@"
                    IF (SELECT COUNT(*) FROM ANIMAL WHERE KennelID = {kennelId.Value}) >= (SELECT Capacity FROM Kennel WHERE KennelID = {kennelId.Value})
                        UPDATE Kennel SET KennelStatus = 'Occupied' WHERE KennelID = {kennelId.Value};
                    ELSE
                        UPDATE Kennel SET KennelStatus = 'Available' WHERE KennelID = {kennelId.Value};";

                dbMan.ExecuteNonQuery(query2);
            }

            return true;
        }

        // Fetches a unique list of species currently in the database
        //For animal data entry
        public DataTable GetExistingSpecies()
        {
            string query = "SELECT DISTINCT Species FROM ANIMAL WHERE Species IS NOT NULL AND Species != ''";
            return dbMan.ExecuteReader(query);
        }

        // Processes an adoption approval: updates adoption status, animal status, and frees up the kennel
        public bool ApproveAdoptionApplication(int adoptionId, int animalId)
        {
            // We will use a transaction to ensure all these steps happen together, 
            // or none of them happen if something fails.
            string query = $@"
        BEGIN TRANSACTION;
        BEGIN TRY
            -- 1. Update the Adoption record
            UPDATE ADOPTION SET AdoptionStatus = 'Approved' WHERE AdoptionID = {adoptionId};

            -- 2. Find which kennel the animal is currently in
            DECLARE @KennelID INT;
            SELECT @KennelID = KennelID FROM ANIMAL WHERE AnimalID = {animalId};

            -- 3. Update the Animal record (status to Adopted, remove from kennel)
            UPDATE ANIMAL SET SystemStatus = 'Adopted', KennelID = NULL WHERE AnimalID = {animalId};

            -- 4. Update the Kennel capacity status (only if it was in a kennel)
            IF @KennelID IS NOT NULL
            BEGIN
                IF (SELECT COUNT(*) FROM ANIMAL WHERE KennelID = @KennelID) = 0
                    UPDATE Kennel SET KennelStatus = 'Needs Cleaning' WHERE KennelID = @KennelID;
                ELSE
                    UPDATE Kennel SET KennelStatus = 'Available' WHERE KennelID = @KennelID;
            END

            COMMIT TRANSACTION;
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION;
            -- You could log the error here if needed
        END CATCH;";

            return dbMan.ExecuteNonQuery(query) > 0;
        }
        // Calculates total medicine prescription expenses for a specific month and year
        

        // Calculates total laboratory test expenses for a specific month and year
        public decimal GetLabExpenses(int month, int year)
        {
            // Sums the cost from the Lab_Test table (exact schema match)
            string query = $"SELECT SUM(Cost) FROM Lab_Test WHERE MONTH(TestDate) = {month} AND YEAR(TestDate) = {year}";

            object result = dbMan.ExecuteScalar(query);
            return result == DBNull.Value || result == null ? 0 : Convert.ToDecimal(result);
        }

        // Retrieves list of all suppliers for dropdown
        public DataTable GetSuppliers()
        {
            string query = "SELECT SupplierID, SupplierName FROM Supplier";
            return dbMan.ExecuteReader(query);
        }

        // Retrieves full details for a specific supplier
        public DataTable GetSupplierDetails(int id)
        {
            string query = $"SELECT ContactPhone, SupplierAddress, Email FROM Supplier WHERE SupplierID = {id}";
            return dbMan.ExecuteReader(query);
        }

        // Inserts a new supplier record
        public int InsertSupplier(string name, string phone, string address, string email)
        {
            string query = $"INSERT INTO Supplier (SupplierName, ContactPhone, SupplierAddress, Email) VALUES ('{name}', '{phone}', '{address}', '{email}')";
            return dbMan.ExecuteNonQuery(query);
        }

        // Updates an existing supplier record
        public int UpdateSupplier(int id, string name, string phone, string address, string email)
        {
            string query = $"UPDATE Supplier SET SupplierName = '{name}', ContactPhone = '{phone}', SupplierAddress = '{address}', Email = '{email}' WHERE SupplierID = {id}";
            return dbMan.ExecuteNonQuery(query);
        }

        // Inserts a new medicine record into the database
        public int InsertMedicine(string name, string dosage, int quantity, decimal price, DateTime expiry, int supplierId)
        {
            // Format date for SQL compatibility
            string formattedDate = expiry.ToString("yyyy-MM-dd");

            string query = $@"INSERT INTO Medicine (MedicineName, Dosage, StockQuantity, UnitPrice, ExpiryDate, SupplierID) 
                      VALUES ('{name}', '{dosage}', {quantity}, {price}, '{formattedDate}', {supplierId})";

            return dbMan.ExecuteNonQuery(query);
        }

        // Retrieves a single medicine record by its ID
        public DataTable GetMedicineByID(int medicineId)
        {
            string query = $"SELECT * FROM Medicine WHERE MedicineID = {medicineId}";
            return dbMan.ExecuteReader(query);
        }

        // Updates an existing medicine record
        public int UpdateMedicine(int medicineId, string name, string dosage, int quantity, decimal price, DateTime expiry, int supplierId)
        {
            string formattedDate = expiry.ToString("yyyy-MM-dd");

            string query = $@"UPDATE Medicine 
                      SET MedicineName = '{name}', 
                          Dosage = '{dosage}', 
                          StockQuantity = {quantity}, 
                          UnitPrice = {price}, 
                          ExpiryDate = '{formattedDate}', 
                          SupplierID = {supplierId} 
                      WHERE MedicineID = {medicineId}";

            return dbMan.ExecuteNonQuery(query);
        }
        // Increments existing stock quantity and updates unit price for a medicine
        // Increments the existing stock quantity for a specific medicine
        // Increments stock, updates price, and logs the purchase transaction with today's date
        public int ResupplyMedicine(int medicineId, int addedQuantity, decimal purchaseCost)
        {
            // 1. Update main Medicine table
            string updateQuery = $@"UPDATE Medicine 
                            SET StockQuantity = StockQuantity + {addedQuantity}, 
                                UnitPrice = {purchaseCost} 
                            WHERE MedicineID = {medicineId}";
            dbMan.ExecuteNonQuery(updateQuery);

            // 2. Log purchase with current timestamp
            string logQuery = $@"INSERT INTO Medicine_Purchase (MedicineID, Quantity, UnitPrice, PurchaseDate) 
                         VALUES ({medicineId}, {addedQuantity}, {purchaseCost}, '{DateTime.Now:yyyy-MM-dd}')";

            return dbMan.ExecuteNonQuery(logQuery);
        }

        // Calculates total medicine purchase expenses for reports based on transaction logs
        public decimal GetMedicineExpenses(int month, int year)
        {
            // Sums (Qty * UnitPrice) from the purchase logs
            string query = $@"SELECT SUM(Quantity * UnitPrice) 
                      FROM Medicine_Purchase 
                      WHERE MONTH(PurchaseDate) = {month} AND YEAR(PurchaseDate) = {year}";

            object result = dbMan.ExecuteScalar(query);
            return result == DBNull.Value || result == null ? 0 : Convert.ToDecimal(result);
        }

        // Retrieves a single kennel details by its ID
        public DataTable GetKennelByID(int kennelId)
        {
            string query = $"SELECT Capacity, KennelSize, WardType, KennelStatus FROM Kennel WHERE KennelID = {kennelId}";
            return dbMan.ExecuteReader(query);
        }

        // Inserts a new kennel record
        public int InsertKennel(int capacity, string size, string ward, string status)
        {
            string query = $@"INSERT INTO Kennel (Capacity, KennelSize, WardType, KennelStatus) 
                      VALUES ({capacity}, '{size}', '{ward}', '{status}')";
            return dbMan.ExecuteNonQuery(query);
        }

        // Updates an existing kennel record
        public int UpdateKennel(int id, int capacity, string size, string ward, string status)
        {
            string query = $@"UPDATE Kennel 
                      SET Capacity = {capacity}, 
                          KennelSize = '{size}', 
                          WardType = '{ward}', 
                          KennelStatus = '{status}' 
                      WHERE KennelID = {id}";
            return dbMan.ExecuteNonQuery(query);
        }





        // Simple method to update adoption status (used for Rejecting)
        //public bool UpdateAdoptionStatus(int adoptionId, string status)
        //{
        //    string query = $"UPDATE Adoption SET AdoptionStatus = '{status}' WHERE AdoptionID = {adoptionId};";
        //    return dbMan.ExecuteNonQuery(query) > 0;
        //}

        // Fetch a list of all unique species currently in the shelter system

        public int? GetClientIdFromRecord(int recordId)
        {
            string query = $"SELECT a.ClientID FROM MEDICAL_RECORD mr JOIN ANIMAL a ON mr.AnimalID = a.AnimalID WHERE mr.RecordID = {recordId};";
            object result = dbMan.ExecuteScalar(query);
            if (result == null || result == DBNull.Value) return null;
            return Convert.ToInt32(result);
        }

        private int GetOrCreateOpenBill(int clientId, bool paidInCash = false)
        {
            string status = paidInCash ? "Paid" : "Unpaid";
            string createQuery = $"INSERT INTO Bill (BillDate, Total_Amount, BillStatus, ClientID) VALUES (CAST(GETDATE() AS DATE), 0, '{status}', {clientId}); SELECT SCOPE_IDENTITY();";
            object newId = dbMan.ExecuteScalar(createQuery);
            return newId != null ? Convert.ToInt32(newId) : 0;
        }

        private void AddBillItem(int billId, string description, decimal unitCost)
        {
            string safeDesc = description.Replace("'", "''");
            string query = $@"
                DECLARE @NextID INT = ISNULL((SELECT MAX(ItemID) FROM Bill_Item), 0) + 1;
                INSERT INTO Bill_Item (ItemID, ItemDescription, UnitCost, Quantity, Subtotal, BillID)
                VALUES (@NextID, '{safeDesc}', {unitCost}, 1, {unitCost}, {billId});
                UPDATE Bill SET Total_Amount = Total_Amount + {unitCost} WHERE BillID = {billId};";
            dbMan.ExecuteNonQuery(query);
        }

        // Approves the adoption, updates the animal's owner, and adds the fee to the Bill and Bill_Item tables
        public bool ApproveAdoptionAndBillClient(int adoptionId, int clientId, int animalId, string species)
        {
            try
            {
                // 1. Get the exact fee that was saved on this specific Adoption application
                string getFeeQuery = $"SELECT AdoptionFee FROM Adoption WHERE AdoptionID = {adoptionId};";
                object result = dbMan.ExecuteScalar(getFeeQuery);
                decimal fee = (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0;

                // 2. Create the Parent Bill and grab the new BillID using SCOPE_IDENTITY()
                string insertBillQuery = $@"
            INSERT INTO Bill (BillDate, Total_Amount, BillStatus, ClientID)
            VALUES (GETDATE(), {fee}, 'Unpaid', {clientId});
            SELECT SCOPE_IDENTITY();";

                int newBillId = Convert.ToInt32(dbMan.ExecuteScalar(insertBillQuery));

                // 3. Insert the specific charge into the Bill_Item weak entity table
                string insertBillItemQuery = $@"
            INSERT INTO Bill_Item (BillID, ItemID, ItemDescription, UnitCost, Quantity, Subtotal)
            VALUES ({newBillId}, 1, 'Adoption Fee - {species}', {fee}, 1, {fee});";
                dbMan.ExecuteNonQuery(insertBillItemQuery);

                // 4. Update the Adoption Status
                string approveAppQuery = $"UPDATE Adoption SET AdoptionStatus = 'Approved' WHERE AdoptionID = {adoptionId};";
                dbMan.ExecuteNonQuery(approveAppQuery);

                // 5. Update the Animal: Set to Adopted, clear the Kennel, and assign the ClientID
                string updateAnimalQuery = $@"
            UPDATE ANIMAL 
            SET SystemStatus = 'Adopted', KennelID = NULL, ClientID = {clientId} 
            WHERE AnimalID = {animalId};";

                int rowsAffected = dbMan.ExecuteNonQuery(updateAnimalQuery);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



    }
}
