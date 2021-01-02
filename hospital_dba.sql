DROP TABLE MedicinePrescribed;
DROP TABLE Medicine;
DROP TABLE Prescription;
DROP TABLE Examination;
DROP TABLE RoomAllocation;
DROP TABLE Admission;
DROP TABLE SurgeryEquipment;
DROP TABLE Surgeon;
DROP TABLE SurgeryPatient;
DROP TABLE SurgeryAssistant;
DROP TABLE Surgery;
DROP TABLE Guardian;
DROP TABLE Patient;
DROP TABLE Nurse;
DROP TABLE Doctor;
DROP TABLE Employee;
DROP TABLE Equipment;
DROP TABLE Room;
DROP TABLE Department;

CREATE TABLE Department (
		DNo CHAR(2) NOT NULL,
		Name VARCHAR(20) NOT NULL UNIQUE,
		Location VARCHAR(20) NOT NULL,
		
		CONSTRAINT PK_Department PRIMARY KEY (DNo),
        CONSTRAINT CK_Department_Location CHECK (Location LIKE 'Block % Floor %-%')
);

CREATE TABLE Room (
		RNo VARCHAR(5) NOT NULL,
		Block VARCHAR(2) NOT NULL,
		DNo CHAR(2) NOT NULL,
		Type VARCHAR(20) NOT NULL,
		
		CONSTRAINT PK_Room PRIMARY KEY (RNo),
		CONSTRAINT FK_Room_Department FOREIGN KEY (DNo)
		REFERENCES Department(DNo)
);

CREATE TABLE Equipment (
		ENo CHAR(8) NOT NULL,
		Name VARCHAR(20) NOT NULL,
		Quantity INT NOT NULL,
		DNo CHAR(2),
		RNo VARCHAR(5) NOT NULL,
		
		CONSTRAINT PK_Equipment PRIMARY KEY (ENo),
		CONSTRAINT FK_Equipment_Department FOREIGN KEY (DNo)
		REFERENCES Department(DNo),
		CONSTRAINT FK_Equipment_Room FOREIGN KEY (RNo)
		REFERENCES Room(RNo),
		CONSTRAINT CK_Equipment_Quantity CHECK (Quantity >= 0)
);

CREATE TABLE Employee (
		Icn CHAR(8) NOT NULL,
		FName VARCHAR(20) NOT NULL,
		LName VARCHAR(20) NOT NULL,
		BDate DATE NOT NULL,
		Gender CHAR NOT NULL,
		PhoneNo VARCHAR(20) NOT NULL,
		Address VARCHAR(20),
		EmpDate DATE NOT NULL,
		YearsOfExp INTERVAL YEAR(2) TO MONTH,
		Salary DECIMAL(6,2) NOT NULL,
		DNo CHAR(2) NOT NULL,
		Job VARCHAR(20) NOT NULL,
        Username VARCHAR(50) UNIQUE NOT NULL,
		
		CONSTRAINT PK_Employee PRIMARY KEY (Icn),
		CONSTRAINT FK_Employee_Department FOREIGN KEY (DNo)
		REFERENCES Department(DNo),
		CONSTRAINT CK_Employee_Gender CHECK (Gender = 'M' OR Gender = 'F'),
		CONSTRAINT CK_Employee_YearsOfExp CHECK (YearsOfExp >= INTERVAL '0' MONTH),
		CONSTRAINT CK_Employee_Salary CHECK (Salary > 200),
        CONSTRAINT CK_Employee_Username CHECK (LENGTH(Username) >= 8 AND REGEXP_LIKE(Username, '^[[:alpha:]][[:alnum:]_]*$'))
);

CREATE TABLE Doctor (
		Icn CHAR(8) NOT NULL,
		Expertise VARCHAR(20) NOT NULL,
		
		CONSTRAINT PK_Doctor PRIMARY KEY (Icn),
		CONSTRAINT FK_Doctor_Employee FOREIGN KEY (Icn)
		REFERENCES Employee(Icn)
);

CREATE TABLE Nurse (
		Icn CHAR(8) NOT NULL,
		
		CONSTRAINT PK_Nurse PRIMARY KEY (Icn),
		CONSTRAINT FK_Nurse_Employee FOREIGN KEY (Icn)
		REFERENCES Employee(Icn)
);

CREATE TABLE Patient (
		Icn CHAR(8) NOT NULL,
		FName VARCHAR(20) NOT NULL,
		LName VARCHAR(20) NOT NULL,
		BDate DATE NOT NULL,
		Gender CHAR NOT NULL,
		PhoneNo VARCHAR(20),
		Address VARCHAR(20),
		
		CONSTRAINT PK_Patient PRIMARY KEY (Icn),
		CONSTRAINT CK_Patient_Gender CHECK (Gender = 'M' OR Gender = 'F')
);

CREATE TABLE Guardian (
		PIcn CHAR(8) NOT NULL,
		FName VARCHAR(20) NOT NULL,
		LName VARCHAR(20) NOT NULL,
		PhoneNo VARCHAR(20) NOT NULL,
		Relationship VARCHAR(20) NOT NULL,
		
		CONSTRAINT PK_Guardian PRIMARY KEY (PIcn, PhoneNo),
		CONSTRAINT FK_Guardian_Patient FOREIGN KEY (PIcn)
		REFERENCES Patient(Icn)
);

CREATE TABLE Surgery (
		SNo CHAR(8) NOT NULL,
		Type VARCHAR(20) NOT NULL,
		Time DATE NOT NULL,
		Fee DECIMAL(6,2) NOT NULL,
		RNo VARCHAR(5) NOT NULL,
		
		CONSTRAINT PK_Surgery PRIMARY KEY (SNo),
		CONSTRAINT FK_Surgery_Room FOREIGN KEY (RNo)
		REFERENCES Room(RNo),
		CONSTRAINT CK_Surgery_Fee CHECK (Fee >= 0)
);

CREATE TABLE SurgeryAssistant (
		SNo CHAR(8) NOT NULL,
		NIcn CHAR(8) NOT NULL,
		
		CONSTRAINT PK_SurgeryAssistant PRIMARY KEY (SNo, NIcn),
		CONSTRAINT FK_SurgeryAssistant_Surgery FOREIGN KEY (SNo)
		REFERENCES Surgery(SNo),
		CONSTRAINT FK_SurgeryAssistant_Nurse FOREIGN KEY (NIcn)
		REFERENCES Nurse(Icn)
);

CREATE TABLE SurgeryPatient (
		SNo CHAR(8) NOT NULL,
		PIcn CHAR(8) NOT NULL,
		
		CONSTRAINT PK_SurgeryPatient PRIMARY KEY (SNo, PIcn),
		CONSTRAINT FK_SurgeryPatient_Surgery FOREIGN KEY (SNo)
		REFERENCES Surgery(SNo),
		CONSTRAINT FK_SurgeryPatient_Patient FOREIGN KEY (PIcn)
		REFERENCES Patient(Icn)
);

CREATE TABLE Surgeon (
		SNo CHAR(8) NOT NULL,
		DIcn CHAR(8) NOT NULL,
		
		CONSTRAINT PK_Surgeon PRIMARY KEY (SNo, DIcn),
		CONSTRAINT FK_Surgeon_Surgery FOREIGN KEY (SNo)
		REFERENCES Surgery(SNo),
		CONSTRAINT FK_Surgeon_Doctor FOREIGN KEY (DIcn)
		REFERENCES Doctor(Icn)
);

CREATE TABLE SurgeryEquipment (
		SNo CHAR(8) NOT NULL,
		ENo CHAR(8) NOT NULL,
		
		CONSTRAINT PK_SurgeryEquipment PRIMARY KEY (SNo, ENo),
		CONSTRAINT FK_SurgeryEquipment_Surgery FOREIGN KEY (SNo)
		REFERENCES Surgery(SNo),
		CONSTRAINT FK_SurgeryEquipment_Equipment FOREIGN KEY (ENo)
		REFERENCES Equipment(ENo)
);

CREATE TABLE Admission (
		PIcn CHAR(8) NOT NULL,
		TimeIn DATE NOT NULL,
		TimeOut DATE,
		NIcn CHAR(8) NOT NULL,
		
		CONSTRAINT PK_Admission PRIMARY KEY (PIcn, TimeIn),
		CONSTRAINT FK_Admission_Patient FOREIGN KEY (PIcn)
		REFERENCES Patient(Icn),
		CONSTRAINT FK_Admission_Nurse FOREIGN KEY (NIcn)
		REFERENCES Nurse(Icn),
		CONSTRAINT CK_Admission_TimeIn_TimeOut CHECK (TimeIn <= TimeOut)
);

CREATE TABLE RoomAllocation (
		PIcn CHAR(8) NOT NULL,
		AdmitTime DATE NOT NULL,
		RNo VARCHAR(5) NOT NULL,
		TimeIn DATE NOT NULL,
		TimeOut DATE,
		
		CONSTRAINT PK_RoomAllocation PRIMARY KEY (PIcn, AdmitTime, RNo),
		CONSTRAINT FK_RoomAllocation_Admission FOREIGN KEY (PIcn, AdmitTime)
		REFERENCES Admission(PIcn, TimeIn),
		CONSTRAINT FK_RoomAllocation_Room FOREIGN KEY (RNo)
		REFERENCES Room(RNo),
		CONSTRAINT CK_RoomAllocation_AdmitTime_TimeIn CHECK (AdmitTime <= TimeIn),
		CONSTRAINT CK_RoomAllocation_TimeIn_TimeOut CHECK (TimeIn <= TimeOut)
);

CREATE TABLE Examination (
		DIcn CHAR(8) NOT NULL,
		PIcn CHAR(8) NOT NULL,
		Time DATE NOT NULL,
		ReexamTime DATE,
		Fee DECIMAL(6,2) NOT NULL,
		
		CONSTRAINT PK_Examination PRIMARY KEY (DIcn, PIcn, Time),
		CONSTRAINT FK_Examination_Doctor FOREIGN KEY (DIcn)
		REFERENCES Doctor(Icn),
		CONSTRAINT FK_Examination_Patient FOREIGN KEY (PIcn)
		REFERENCES Patient(Icn),
		CONSTRAINT CK_Examination_Time_ReexamTime CHECK (Time <= ReexamTime),
		CONSTRAINT CK_Examination_Fee CHECK (Fee >= 0)
);

CREATE TABLE Prescription (
		PNo CHAR(8) NOT NULL,
		Time DATE NOT NULL,
		DIcn CHAR(8) NOT NULL,
		PIcn CHAR(8) NOT NULL,
		
		CONSTRAINT PK_Prescription PRIMARY KEY (PNo),
		CONSTRAINT FK_Prescription_Doctor FOREIGN KEY (DIcn)
		REFERENCES Doctor(Icn),
		CONSTRAINT FK_Prescription_Patient FOREIGN KEY (PIcn)
		REFERENCES Patient(Icn)
);

CREATE TABLE Medicine (
		MNo CHAR(8) NOT NULL,
		Name VARCHAR(20) NOT NULL,
		Type VARCHAR(20) NOT NULL,
		Quantity INT NOT NULL,
		Expiry DATE NOT NULL,
		Supplier VARCHAR(20) NOT NULL,
		Cost DECIMAL(6,2) NOT NULL,
		
		CONSTRAINT PK_Medicine PRIMARY KEY (MNo),
		CONSTRAINT CK_Medicine_Quantity CHECK (Quantity >= 0),
		CONSTRAINT CK_Medicine_Cost CHECK (Cost >= 0)
);

CREATE TABLE MedicinePrescribed (
		PNo CHAR(8) NOT NULL,
		MNo CHAR(8) NOT NULL,
		Dose VARCHAR(20) NOT NULL,
		Frequency INTERVAL DAY(2) TO SECOND(0),
		
		CONSTRAINT PK_MedicinePrescribed PRIMARY KEY (PNo, MNo),
		CONSTRAINT FK_MedicinePrescribed_Prescription FOREIGN KEY (PNo)
		REFERENCES Prescription(PNo),
		CONSTRAINT FK_MedicinePrescribed_Medicine FOREIGN KEY (MNo)
		REFERENCES Medicine(MNo),
        CONSTRAINT CK_MedicinePrescribed_Frequency CHECK (Frequency >= INTERVAL '1' MINUTE)
);

CREATE OR REPLACE TRIGGER TRIG_Employee_Insert
AFTER INSERT ON Employee
FOR EACH ROW
WHEN (new.Job = 'Doctor' OR new.Job = 'Nurse')
BEGIN
    IF :new.Job = 'Doctor' THEN
        INSERT INTO Doctor
        VALUES (:new.Icn, 'None');
    ELSE
        INSERT INTO Nurse
        VALUES (:new.Icn);
    END IF;
END;
/
CREATE OR REPLACE TRIGGER TRIG_Employee_Update
AFTER UPDATE OF Job ON Employee
FOR EACH ROW
WHEN (old.Job != new.Job)
BEGIN
    IF :old.Job = 'Doctor' THEN
        DELETE FROM Doctor
        WHERE Icn = :old.Icn;
    ELSIF :old.Job = 'Nurse' THEN
        DELETE FROM Nurse
        WHERE Icn = :old.Icn;
    END IF;
    
    IF :new.Job = 'Doctor' THEN
        INSERT INTO Doctor
        VALUES (:new.Icn, 'None');
    ELSIF :new.Job = 'Nurse' THEN
        INSERT INTO Nurse
        VALUES (:new.Icn);
    END IF;
END;
/
CREATE OR REPLACE TRIGGER TRIG_Employee_Delete
BEFORE DELETE ON Employee
FOR EACH ROW
WHEN (old.Job = 'Doctor' OR old.Job = 'Nurse')
BEGIN
    IF :old.Job = 'Doctor' THEN
        DELETE FROM Doctor
        WHERE Icn = :old.Icn;
    ELSE
        DELETE FROM Nurse
        WHERE Icn = :old.Icn;
    END IF;
END;
/


CREATE OR REPLACE FUNCTION FUN_Is_Employee (
    i_username IN VARCHAR2
)
RETURN VARCHAR2
IS
    ret VARCHAR2(200) := '';
BEGIN
    SELECT Job INTO ret
    FROM (
            SELECT Employee.Job
            FROM Employee
            WHERE Employee.username = i_username
        UNION ALL
            SELECT ''
            FROM Dual
    ) tmp
    WHERE rownum = 1;
    
    RETURN ret;
END;
/

INSERT INTO Department
VALUES ('AD', 'Administration', 'Block B Floor 1-4');
INSERT INTO Department
VALUES ('CC', 'Critical Care', 'Block C Floor 3-4');
INSERT INTO Department
VALUES ('DI', 'Diagnostic Imaging', 'Block A Floor 4-5');
INSERT INTO Department
VALUES ('EN', 'Ear Nose and Throat', 'Block A Floor 1-3');
INSERT INTO Department
VALUES ('GS', 'General Surgery', 'Block C Floor 5-6');
INSERT INTO Department
VALUES ('OP', 'Ophthalmology', 'Block C Floor 1-2');

INSERT INTO Room
VALUES ('A101', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A102', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A103', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A104', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A105', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A106', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A201', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A202', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A203', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A204', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A205', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A206', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A207', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A208', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A209', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A210', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A211', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A212', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A301', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A302', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A303', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A304', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A305', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A306', 'A', 'EN', 'Public');
INSERT INTO Room
VALUES ('A307', 'A', 'EN', 'Semi-Private');
INSERT INTO Room
VALUES ('A308', 'A', 'EN', 'Semi-Private');
INSERT INTO Room
VALUES ('A309', 'A', 'EN', 'Semi-Private');
INSERT INTO Room
VALUES ('A310', 'A', 'EN', 'Semi-Private');
INSERT INTO Room
VALUES ('A311', 'A', 'EN', 'Semi-Private');
INSERT INTO Room
VALUES ('A312', 'A', 'EN', 'Semi-Private');
INSERT INTO Room
VALUES ('A401', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A402', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A403', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A404', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A405', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A406', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A407', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A408', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A409', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A410', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A411', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A412', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A501', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A502', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A503', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A504', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A505', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A506', 'A', 'DI', 'Public');
INSERT INTO Room
VALUES ('A507', 'A', 'DI', 'Semi-Private');
INSERT INTO Room
VALUES ('A508', 'A', 'DI', 'Semi-Private');
INSERT INTO Room
VALUES ('A509', 'A', 'DI', 'Semi-Private');
INSERT INTO Room
VALUES ('A510', 'A', 'DI', 'Semi-Private');
INSERT INTO Room
VALUES ('A511', 'A', 'DI', 'Reserved');
INSERT INTO Room
VALUES ('A512', 'A', 'DI', 'Reserved');
INSERT INTO Room
VALUES ('C101', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C102', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C103', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C104', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C105', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C106', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C201', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C202', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C203', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C204', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C205', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C206', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C207', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C208', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C209', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C210', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C211', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C212', 'C', 'OP', 'Public');
INSERT INTO Room
VALUES ('C301', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C302', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C303', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C304', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C305', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C306', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C307', 'C', 'CC', 'Semi-Private');
INSERT INTO Room
VALUES ('C308', 'C', 'CC', 'Semi-Private');
INSERT INTO Room
VALUES ('C309', 'C', 'CC', 'Semi-Private');
INSERT INTO Room
VALUES ('C310', 'C', 'CC', 'Semi-Private');
INSERT INTO Room
VALUES ('C311', 'C', 'CC', 'Semi-Private');
INSERT INTO Room
VALUES ('C312', 'C', 'CC', 'Semi-Private');
INSERT INTO Room
VALUES ('C401', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C402', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C403', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C404', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C405', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C406', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C407', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C408', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C409', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C410', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C411', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C412', 'C', 'CC', 'Semi-private');
INSERT INTO Room
VALUES ('C501', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C502', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C503', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C504', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C505', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C506', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C507', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C508', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C509', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C510', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C511', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C512', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C601', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C602', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C603', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C604', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C605', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C606', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C607', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C608', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C609', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C610', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C611', 'C', 'GS', 'Reserved');
INSERT INTO Room
VALUES ('C612', 'C', 'GS', 'Reserved');

INSERT INTO Equipment
VALUES ('ENSTH', 'Stethoscope', 100, 'EN', 'A212');
INSERT INTO Equipment
VALUES ('ENTHE', 'Thermometer', 100, 'EN', 'A212');
INSERT INTO Equipment
VALUES ('OPSTH', 'Stethoscope', 100, 'OP', 'A212');
INSERT INTO Equipment
VALUES ('OPTHE', 'Thermometer', 100, 'OP', 'A212');
INSERT INTO Equipment
VALUES ('DIRAD', 'Radiography', 20, 'DI', 'A412');
INSERT INTO Equipment
VALUES ('CCVEN', 'Ventilator', 20, 'CC', 'C412');
INSERT INTO Equipment
VALUES ('CCOXY', 'Oxygen mask - tubes', 20, 'CC', 'C412');
INSERT INTO Equipment
VALUES ('GSSCI', 'Surgical scissors', 100, 'GS', 'C612');

--ALTER SESSION SET "_oracle_script"=True;

INSERT INTO Employee
VALUES ('74251068', 'Phu', 'Nguyen', TO_DATE('1980-02-19', 'YYYY-MM-DD'), 'M', '01623235454', NULL, TO_DATE('2020-08-15', 'YYYY-MM-DD'), INTERVAL '0' YEAR, 500, 'AD', 'DBA', 'hospital_dba');

INSERT INTO Employee
VALUES ('29100569', 'Bach', 'Nguyen', TO_DATE('1978-12-25', 'YYYY-MM-DD'), 'M', '016545454', '77 Nguyen Trai', TO_DATE('2018-08-15', 'YYYY-MM-DD'), INTERVAL '2' YEAR, 1000, 'OP', 'Nurse',  'PfoemPfoem1');
CREATE USER PfoemPfoem1 IDENTIFIED BY p1234567;
GRANT CREATE SESSION TO PfoemPfoem1;
GRANT ALL ON Admission TO PfoemPfoem1;
GRANT ALL ON Patient TO PfoemPfoem1;
GRANT ALL ON Guardian TO PfoemPfoem1;
GRANT ALL ON RoomAllocation TO PfoemPfoem1;

INSERT INTO Employee
VALUES ('82339743', 'Nhan', 'Nguyen', TO_DATE('1980-11-14', 'YYYY-MM-DD'), 'F', '01627984', NULL, TO_DATE('2007-08-15', 'YYYY-MM-DD'), INTERVAL '15' YEAR, 2500, 'CC', 'Doctor', 'PfoemPfoem2');
CREATE USER PfoemPfoem2 IDENTIFIED BY p1234567;
GRANT CREATE SESSION TO PfoemPfoem2;
GRANT ALL ON Admission TO PfoemPfoem2;
GRANT ALL ON Patient TO PfoemPfoem2;
GRANT ALL ON Guardian TO PfoemPfoem2;
GRANT ALL ON RoomAllocation TO PfoemPfoem2;
GRANT ALL ON Examination TO PfoemPfoem2;
GRANT ALL ON Prescription TO PfoemPfoem2;
GRANT ALL ON MedicinePrescribed TO PfoemPfoem2;
GRANT ALL ON Surgery TO PfoemPfoem2;
GRANT ALL ON Surgeon TO PfoemPfoem2;
GRANT ALL ON SurgeryAssistant TO PfoemPfoem2;
GRANT ALL ON SurgeryPatient TO PfoemPfoem2;
GRANT ALL ON SurgeryEquipment TO PfoemPfoem2;

INSERT INTO Employee
VALUES ('00111592', 'Phuc', 'Nguyen', TO_DATE('1973-05-15', 'YYYY-MM-DD'), 'F', '0146435454', NULL, TO_DATE('2010-12-28', 'YYYY-MM-DD'), INTERVAL '12' YEAR, 1500, 'OP', 'Nurse', 'PfoemPfoem3');
CREATE USER PfoemPfoem3 IDENTIFIED BY p1234567;
GRANT CREATE SESSION TO PfoemPfoem3;
GRANT ALL ON Admission TO PfoemPfoem3;
GRANT ALL ON Patient TO PfoemPfoem3;
GRANT ALL ON Guardian TO PfoemPfoem3;
GRANT ALL ON RoomAllocation TO PfoemPfoem3;

INSERT INTO Employee
VALUES ('01118337', 'Huyen', 'Nguyen', TO_DATE('1989-07-09', 'YYYY-MM-DD'), 'F', '013568994', '123 Vo Van Kiet', TO_DATE('2020-12-28', 'YYYY-MM-DD'), INTERVAL '0' YEAR, 1500, 'EN','Nurse',  'PfoemPfoem4');
CREATE USER PfoemPfoem4 IDENTIFIED BY p1234567;
GRANT CREATE SESSION TO PfoemPfoem4;
GRANT ALL ON Admission TO PfoemPfoem4;
GRANT ALL ON Patient TO PfoemPfoem4;
GRANT ALL ON Guardian TO PfoemPfoem4;
GRANT ALL ON RoomAllocation TO PfoemPfoem4;

INSERT INTO Employee
VALUES ('11567371', 'Huyen', 'Nguyen', TO_DATE('1995-03-09', 'YYYY-MM-DD'), 'F', '(+028) 323 5454', NULL, TO_DATE('2020-01-03', 'YYYY-MM-DD'), INTERVAL '0' YEAR, 1000, 'DI', 'Nurse', 'PfoemPfoem5');
CREATE USER PfoemPfoem5 IDENTIFIED BY p1234567;
GRANT CREATE SESSION TO PfoemPfoem5;
GRANT ALL ON Admission TO PfoemPfoem5;
GRANT ALL ON Patient TO PfoemPfoem5;
GRANT ALL ON Guardian TO PfoemPfoem5;
GRANT ALL ON RoomAllocation TO PfoemPfoem5;

INSERT INTO Employee
VALUES ('71638093', 'Dan', 'Nguyen', TO_DATE('1968-01-18', 'YYYY-MM-DD'), 'M', '012232 35499', NULL, TO_DATE('2008-05-02', 'YYYY-MM-DD'), INTERVAL '20' YEAR, 5000, 'EN', 'Doctor', 'PfoemPfoem6');
CREATE USER PfoemPfoem6 IDENTIFIED BY p1234567;
GRANT CREATE SESSION TO PfoemPfoem6;
GRANT ALL ON Admission TO PfoemPfoem6;
GRANT ALL ON Patient TO PfoemPfoem6;
GRANT ALL ON Guardian TO PfoemPfoem6;
GRANT ALL ON RoomAllocation TO PfoemPfoem6;
GRANT ALL ON Examination TO PfoemPfoem6;
GRANT ALL ON Prescription TO PfoemPfoem6;
GRANT ALL ON MedicinePrescribed TO PfoemPfoem6;
GRANT ALL ON Surgery TO PfoemPfoem6;
GRANT ALL ON Surgeon TO PfoemPfoem6;
GRANT ALL ON SurgeryAssistant TO PfoemPfoem6;
GRANT ALL ON SurgeryPatient TO PfoemPfoem6;
GRANT ALL ON SurgeryEquipment TO PfoemPfoem6;

INSERT INTO Employee
VALUES ('38895424', 'Thai', 'Nguyen', TO_DATE('1971-01-29', 'YYYY-MM-DD'), 'M', '0124123456', NULL, TO_DATE('2005-06-02', 'YYYY-MM-DD'), INTERVAL '20' YEAR, 6500, 'GS', 'Doctor', 'PfoemPfoem7');
CREATE USER PfoemPfoem7 IDENTIFIED BY p1234567;
GRANT CREATE SESSION TO PfoemPfoem7;
GRANT ALL ON Admission TO PfoemPfoem7;
GRANT ALL ON Patient TO PfoemPfoem7;
GRANT ALL ON Guardian TO PfoemPfoem7;
GRANT ALL ON RoomAllocation TO PfoemPfoem7;
GRANT ALL ON Examination TO PfoemPfoem7;
GRANT ALL ON Prescription TO PfoemPfoem7;
GRANT ALL ON MedicinePrescribed TO PfoemPfoem7;
GRANT ALL ON Surgery TO PfoemPfoem7;
GRANT ALL ON Surgeon TO PfoemPfoem7;
GRANT ALL ON SurgeryAssistant TO PfoemPfoem7;
GRANT ALL ON SurgeryPatient TO PfoemPfoem7;
GRANT ALL ON SurgeryEquipment TO PfoemPfoem7;

UPDATE Doctor
SET Expertise = 'Radiology'
WHERE Icn = '82339743';
UPDATE Doctor
SET Expertise = 'Otolaryngology'
WHERE Icn = '71638093';
UPDATE Doctor
SET Expertise = 'Cardiology'
WHERE Icn = '38895424';

INSERT INTO Patient
VALUES ('82859990', 'Phuong', 'Vo', TO_DATE('1970-05-09', 'YYYY-MM-DD'), 'F', NULL, '25 Hoa Binh');
INSERT INTO Patient
VALUES ('94598651', 'Han', 'Nguyen', TO_DATE('1985-03-05', 'YYYY-MM-DD'), 'F', NULL, NULL);
INSERT INTO Patient
VALUES ('92056050', 'Nhat', 'Nguyen', TO_DATE('1980-11-24', 'YYYY-MM-DD'), 'M', NULL, NULL);
INSERT INTO Patient
VALUES ('52550112', 'Phuoc', 'Tran', TO_DATE('1986-06-30', 'YYYY-MM-DD'), 'F', NULL, NULL);
INSERT INTO Patient
VALUES ('42646917', 'Nguyen', 'Nguyen', TO_DATE('1999-07-07', 'YYYY-MM-DD'), 'F', NULL, NULL);
INSERT INTO Patient
VALUES ('44436143', 'Khang', 'Nguyen', TO_DATE('1995-03-09', 'YYYY-MM-DD'), 'M', '(+028) 589 8968', NULL);
INSERT INTO Patient
VALUES ('99392761', 'Doan', 'Nguyen', TO_DATE('1985-01-11', 'YYYY-MM-DD'), 'M', '016 232 349 966', NULL);
INSERT INTO Patient
VALUES ('00520224', 'Thuong', 'Nguyen', TO_DATE('2008-02-29', 'YYYY-MM-DD'), 'F', NULL, NULL);

INSERT INTO Guardian
VALUES ('00520224', 'Tuyen', 'Vu', '(+54) 456 465 8868', 'Mother');
INSERT INTO Guardian
VALUES ('44436143', 'Huong', 'Nguyen', '(+028) 589 8968', 'Wife');
INSERT INTO Guardian
VALUES ('00520224', 'Tien', 'Nguyen', '(+54) 456 465 88686', 'Father');
INSERT INTO Guardian
VALUES ('82859990', 'Hien', 'Vo', '0356568425', 'Daughter');

INSERT INTO Surgery
VALUES ('70353086', 'Keyhole Appendectomy', TO_DATE('2020-10-10 15:34:16', 'YYYY-MM-DD HH24:MI:SS'), 558.52, 'C508');
INSERT INTO Surgery
VALUES ('27622371', 'Caesarean Section', TO_DATE('2020-11-22 05:32:58', 'YYYY-MM-DD HH24:MI:SS'), 253.82, 'C511');
INSERT INTO Surgery
VALUES ('86703827', 'Gastric Bypass', TO_DATE('2020-08-15 22:14:08', 'YYYY-MM-DD HH24:MI:SS'), 365.14, 'C606');
INSERT INTO Surgery
VALUES ('80876168', 'Cataract Surgery', TO_DATE('2020-05-14 18:36:51', 'YYYY-MM-DD HH24:MI:SS'), 1200.67, 'A512');
INSERT INTO Surgery
VALUES ('90746163', 'Keyhole Appendectomy', TO_DATE('2020-11-25 17:42:26', 'YYYY-MM-DD HH24:MI:SS'), 625.52, 'C508');

INSERT INTO SurgeryAssistant
VALUES ('70353086', '00111592');
INSERT INTO SurgeryAssistant
VALUES ('70353086', '01118337');
INSERT INTO SurgeryAssistant
VALUES ('27622371', '29100569');
INSERT INTO SurgeryAssistant
VALUES ('27622371', '00111592');
INSERT INTO SurgeryAssistant
VALUES ('86703827', '11567371');
INSERT INTO SurgeryAssistant
VALUES ('90746163', '11567371');
INSERT INTO SurgeryAssistant
VALUES ('70353086', '11567371');

INSERT INTO SurgeryPatient
VALUES ('70353086', '92056050');
INSERT INTO SurgeryPatient
VALUES ('27622371', '82859990');
INSERT INTO SurgeryPatient
VALUES ('86703827', '99392761');
INSERT INTO SurgeryPatient
VALUES ('90746163', '42646917');
INSERT INTO SurgeryPatient
VALUES ('80876168', '52550112');

INSERT INTO Surgeon
VALUES ('70353086', '38895424');
INSERT INTO Surgeon
VALUES ('27622371', '82339743');
INSERT INTO Surgeon
VALUES ('86703827', '82339743');
INSERT INTO Surgeon
VALUES ('90746163', '82339743');
INSERT INTO Surgeon
VALUES ('80876168', '71638093');

INSERT INTO SurgeryEquipment
VALUES ('70353086', 'DIRAD');
INSERT INTO SurgeryEquipment
VALUES ('70353086', 'CCVEN');
INSERT INTO SurgeryEquipment
VALUES ('70353086', 'GSSCI');
INSERT INTO SurgeryEquipment
VALUES ('27622371', 'GSSCI');
INSERT INTO SurgeryEquipment
VALUES ('27622371', 'DIRAD');
INSERT INTO SurgeryEquipment
VALUES ('27622371', 'CCVEN');
INSERT INTO SurgeryEquipment
VALUES ('27622371', 'CCOXY');
INSERT INTO SurgeryEquipment
VALUES ('86703827', 'DIRAD');
INSERT INTO SurgeryEquipment
VALUES ('86703827', 'GSSCI');
INSERT INTO SurgeryEquipment
VALUES ('80876168', 'GSSCI');
INSERT INTO SurgeryEquipment
VALUES ('90746163', 'DIRAD');
INSERT INTO SurgeryEquipment
VALUES ('90746163', 'CCVEN');
INSERT INTO SurgeryEquipment
VALUES ('90746163', 'GSSCI');

INSERT INTO Admission
VALUES ('52550112', TO_DATE('2020-08-15 11:24', 'YYYY-MM-DD HH24:MI'), TO_DATE('2020-08-17 9:00', 'YYYY-MM-DD HH24:MI'), '29100569');
INSERT INTO Admission
VALUES ('82859990', TO_DATE('2020-11-20 08:15', 'YYYY-MM-DD HH24:MI'), NULL, '11567371');
INSERT INTO Admission
VALUES ('94598651', TO_DATE('2020-07-05 13:57', 'YYYY-MM-DD HH24:MI'), TO_DATE('2020-07-21 15:00', 'YYYY-MM-DD HH24:MI'), '29100569');
INSERT INTO Admission
VALUES ('92056050', TO_DATE('2020-10-10 05:23', 'YYYY-MM-DD HH24:MI'), NULL, '01118337');
INSERT INTO Admission
VALUES ('52550112', TO_DATE('2020-05-10 11:56', 'YYYY-MM-DD HH24:MI'), TO_DATE('2020-05-13 9:00', 'YYYY-MM-DD HH24:MI'), '29100569');
INSERT INTO Admission
VALUES ('42646917', TO_DATE('2020-11-24 23:21', 'YYYY-MM-DD HH24:MI'), NULL, '11567371');
INSERT INTO Admission
VALUES ('44436143', TO_DATE('2020-10-15 15:14', 'YYYY-MM-DD HH24:MI'), TO_DATE('2020-10-20 17:00', 'YYYY-MM-DD HH24:MI'), '11567371');
INSERT INTO Admission
VALUES ('99392761', TO_DATE('2020-08-15 20:14', 'YYYY-MM-DD HH24:MI'), TO_DATE('2020-08-20 9:00', 'YYYY-MM-DD HH24:MI'), '01118337');
INSERT INTO Admission
VALUES ('00520224', TO_DATE('2020-09-07 6:52', 'YYYY-MM-DD HH24:MI'), TO_DATE('2020-09-09 9:00', 'YYYY-MM-DD HH24:MI'), '11567371');

GRANT EXECUTE ON FUN_Is_Employee TO gate_keeper;