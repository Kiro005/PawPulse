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
            string query = $"SELECT PasswordHash, 'Client' AS Role, CAST(ClientID AS VARCHAR) AS UserID, FirstName, LastName FROM Client WHERE Email = '{email}' " +
                $"UNION " +
                $"SELECT PasswordHash, EmployeeRole AS Role, CAST(EmployeeID AS VARCHAR) AS UserID, FirstName, LastName FROM Employee WHERE Email = '{email}';";
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
            '{fName}', 
            '{lName}', 
            '{phone}', 
            '{email}', 
            '{city}', 
            '{street}', 
            '{buildingNum}', 
            '{hashedPassword}'
        );";

            // Returns the number of rows affected (should be 1 if successful)
            return dbMan.ExecuteNonQuery(query);
        }

        ////////////////////////////////////////////////////////////////////////////////////
        /// Client


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
                INSERT INTO MEDICAL_RECORD (RecordID, LastUpdatedDate, RecordedWeight, Diagnosis, Notes, AnimalID, AppointmentID)
                VALUES ((SELECT ISNULL(MAX(RecordID), 1000) + 1 FROM MEDICAL_RECORD), CAST(GETDATE() AS DATE), {weight}, '{diagnosis}', '{notes}', {animalId}, {apptPart});";
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
                INSERT INTO Prescription (PrescriptionID, Instructions, IssueDate, RefillsAllowed, DurationInDays, RecordID, MedicineID, EmployeeID)
                VALUES ((SELECT ISNULL(MAX(PrescriptionID), 1200) + 1 FROM Prescription), '{instructions}', CAST(GETDATE() AS DATE), {refills}, {duration}, {recordId}, {medicineId}, {vetId});";
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
                INSERT INTO Lab_Test (TestID, TestType, TestDate, Result, Cost, RecordID)
                VALUES ((SELECT ISNULL(MAX(TestID), 1100) + 1 FROM Lab_Test), '{testType}', CAST(GETDATE() AS DATE), '{result}', {cost}, {recordId});";
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
                INSERT INTO MEDICAL_RECORD (RecordID, LastUpdatedDate, RecordedWeight, Diagnosis, Notes, AnimalID, AppointmentID)
                SELECT ISNULL(MAX(RecordID), 1000) + 1, CAST(GETDATE() AS DATE),
                       ISNULL((SELECT LatestWeight FROM ANIMAL WHERE AnimalID = {animalId}), 0),
                       'Cleared for Adoption', 'Animal has been examined and cleared for adoption.', {animalId}, NULL
                FROM MEDICAL_RECORD;";
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
                INSERT INTO ANIMAL (AnimalID, AnimalName, Species, Breed, Gender, EstimatedDOB, SystemStatus, LatestWeight, ClientID, KennelID)
                VALUES ((SELECT ISNULL(MAX(AnimalID), 600) + 1 FROM ANIMAL), '{name}', '{species}', '{breed}', '{gender}', '{dob}', 'Shelter', {weight}, NULL, {kennelId});
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
