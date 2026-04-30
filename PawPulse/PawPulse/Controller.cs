using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

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

            // We do NOT include ClientID (Identity handles it) or IsActive (Defaults to 1)
            string query = $@"
        INSERT INTO CLIENT (FirstName, LastName, Phone, Email, City, Street, BuildingNumber, PasswordHash) 
        VALUES (
            '{fName}', '{lName}', '{phone}', '{email}', '{city}', '{street}', '{buildingNum}', '{hashedPassword}'
        );
        SELECT SCOPE_IDENTITY();";

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
        WHERE ClientID = {clientID} AND SystemStatus != 'Adopted';"; // Assuming they still own them

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
        SELECT EmployeeID, ('Dr. ' + FirstName + ' ' + LastName) AS VetName 
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

        ///////////////////////////////////////////////////////////////////////////////////
        /// Veterinarian Dashboard


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
                       ISNULL(c.FirstName + ' ' + c.LastName, 'Shelter Animal') AS OwnerName
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
                       p.Instructions, p.RefillsAllowed AS Refills, p.DurationInDays AS Duration
                FROM Prescription p
                JOIN MEDICAL_RECORD mr ON p.RecordID = mr.RecordID
                JOIN ANIMAL an ON mr.AnimalID = an.AnimalID
                JOIN Medicine m ON p.MedicineID = m.MedicineID
                WHERE p.EmployeeID = {vetId}
                ORDER BY p.IssueDate DESC;";
            return dbMan.ExecuteReader(query);
        }

        public bool AddPrescription(int recordId, int medicineId, int vetId, string instructions, int refills, int duration)
        {
            string query = $@"
                INSERT INTO Prescription (Instructions, IssueDate, RefillsAllowed, DurationInDays, RecordID, MedicineID, EmployeeID)
                VALUES ('{instructions}', CAST(GETDATE() AS DATE), {refills}, {duration}, {recordId}, {medicineId}, {vetId});";
            return dbMan.ExecuteNonQuery(query) > 0;
        }

        public DataTable GetLabTests()
        {
            string query = $@"
                SELECT lt.TestID, lt.TestType AS Type, lt.TestDate AS Date, lt.Result, lt.Cost,
                       an.AnimalName
                FROM Lab_Test lt
                JOIN MEDICAL_RECORD mr ON lt.RecordID = mr.RecordID
                JOIN ANIMAL an ON mr.AnimalID = an.AnimalID
                ORDER BY lt.TestDate DESC;";
            return dbMan.ExecuteReader(query);
        }

        public bool AddLabTest(int recordId, string testType, string result, decimal cost)
        {
            string query = $@"
                INSERT INTO Lab_Test (TestType, TestDate, Result, Cost, RecordID)
                VALUES ('{testType}', CAST(GETDATE() AS DATE), '{result}', {cost}, {recordId});";
            return dbMan.ExecuteNonQuery(query) > 0;
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

        public DataTable GetShelterAnimalsForClearance()
        {
            string query = $@"
                SELECT an.AnimalID, an.AnimalName, an.Species, an.Breed, an.Age,
                       ISNULL(mr.Diagnosis, 'No Record') AS LatestDiagnosis,
                       ISNULL(CONVERT(VARCHAR, mr.LastUpdatedDate, 103), 'N/A') AS LastCheckup,
                       ISNULL(k.WardType, 'N/A') AS Ward
                FROM ANIMAL an
                LEFT JOIN Kennel k ON an.KennelID = k.KennelID
                LEFT JOIN (
                    SELECT AnimalID, Diagnosis, LastUpdatedDate,
                           ROW_NUMBER() OVER (PARTITION BY AnimalID ORDER BY LastUpdatedDate DESC) AS rn
                    FROM MEDICAL_RECORD
                ) mr ON an.AnimalID = mr.AnimalID AND mr.rn = 1
                WHERE an.SystemStatus = 'Shelter'
                ORDER BY an.AnimalName;";
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
    }
}
