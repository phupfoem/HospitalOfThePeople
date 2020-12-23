using System;
using System.Windows.Forms;
using System.Data.Common;
using Oracle.DataAccess.Client;

namespace HospitalOfThePeople
{
    public partial class FmEmployee : Form
    {
        readonly OracleConnection _conn;

        readonly DBFormHelper _dbEmployeeHelper;
        readonly DBFormHelper _dbDoctorHelper;
        readonly DBFormHelper _dbNurseHelper;

        public FmEmployee(OracleConnection conn)
        {
            InitializeComponent();
            this.btnHire.Click += this.BtnHire_Click;
            this.btnUpdate.Click += this.BtnUpdate_Click;
            this.btnFire.Click += this.BtnFire_Click;
            this.btnFind.Click += this.BtnFind_Click;

            _conn = conn;

            _dbEmployeeHelper = new DBFormHelper(
                /*
                    Icn CHAR(8) NOT NULL,
                    FName VARCHAR(20) NOT NULL,
                    LName VARCHAR(20) NOT NULL,
                    BDate DATE NOT NULL,
                    Gender CHAR NOT NULL,
                    PhoneNo VARCHAR(20) NOT NULL,
                    Address VARCHAR(20),
                    EmpDate DATE NOT NULL,
                    YearsOfExp INTERVAL YEAR(2) TO MONTH,
                    Salary DECIMAL(6, 2) NOT NULL,
                    DNo CHAR(2) NOT NULL,
                    Job VARCHAR(20) NOT NULL,
                    Username VARCHAR(50) UNIQUE NOT NULL,
                */
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("Icn", OracleDbType.Char, 8, txtIcn),
                    new DBFormHelper.AttributeType("FName", OracleDbType.Varchar2, 20, txtFname),
                    new DBFormHelper.AttributeType("LName", OracleDbType.Varchar2, 20, txtLname),
                    new DBFormHelper.AttributeType("BDate", OracleDbType.Date, null, txtBDate),
                    new DBFormHelper.AttributeType("Gender", OracleDbType.Char, null, txtGender),
                    new DBFormHelper.AttributeType("PhoneNo", OracleDbType.Varchar2, 20, txtPhoneNo),
                    new DBFormHelper.AttributeType("Address", OracleDbType.Varchar2, 20, txtAddress),
                    new DBFormHelper.AttributeType("EmpDate", OracleDbType.Date, null, txtEmpDate),
                    new DBFormHelper.AttributeType("YearsOfExp", OracleDbType.IntervalYM, null, txtYearsOfExp),
                    new DBFormHelper.AttributeType("Salary", OracleDbType.Decimal, null, txtSalary),
                    new DBFormHelper.AttributeType("DNo", OracleDbType.Char, 2, txtDNo),
                    new DBFormHelper.AttributeType("Job", OracleDbType.Varchar2, 20, txtJob),
                    new DBFormHelper.AttributeType("Username", OracleDbType.Varchar2, 50, txtUsername)
                },
                //CONSTRAINT PK_Employee PRIMARY KEY(Icn),
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("Icn", OracleDbType.Char, 8, txtIcn)
                },
                //hospital_dba.Employee
                "hospital_dba.Employee"
            );

            _dbDoctorHelper = new DBFormHelper(
                /*
                    Icn CHAR(8) NOT NULL,
                    Expertise VARCHAR(20) NOT NULL,
                */
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("Icn", OracleDbType.Char, 8, txtIcn),
                    new DBFormHelper.AttributeType("Expertise", OracleDbType.Varchar2, 20, txtExpertise)
                },
                //CONSTRAINT PK_Doctor PRIMARY KEY(Icn),
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("Icn", OracleDbType.Char, 8, txtIcn)
                },
                //hospital_dba.Doctor
                "hospital_dba.Doctor"
            );

            _dbNurseHelper = new DBFormHelper(
                /*
                    Icn CHAR(8) NOT NULL,
                */
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("Icn", OracleDbType.Char, 8, txtIcn)
                },
                //CONSTRAINT PK_Nurse PRIMARY KEY(Icn),
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("Icn", OracleDbType.Char, 8, txtIcn)
                },
                //hospital_dba.Nurse
                "hospital_dba.Nurse"
            );
        }

        private void BtnHire_Click(object sender, EventArgs e)
        {
            try
            {
                _dbEmployeeHelper.Insert(_conn);

                if (txtJob.Text.Trim() == "Doctor")
                    _dbDoctorHelper.Update(_conn);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                Console.WriteLine(err.StackTrace);
            }
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            try
            {
                using (DbDataReader reader = _dbEmployeeHelper.Find(_conn))
                {
                    if (!reader.HasRows)
                        MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK);
                    else
                        _dbEmployeeHelper.Read(reader);
                }

                if (txtJob.Text.Trim() == "Doctor")
                {
                    using (DbDataReader reader = _dbDoctorHelper.Find(_conn))
                    {
                        if (!reader.HasRows)
                            MessageBox.Show("Doctor details not found.", "Error", MessageBoxButtons.OK);
                        else
                        {
                            _dbDoctorHelper.Read(reader);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                Console.WriteLine(err.StackTrace);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _dbEmployeeHelper.Update(_conn);

                if (txtJob.Text.Trim() == "Doctor")
                    _dbDoctorHelper.Update(_conn);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                Console.WriteLine(err.StackTrace);
            }
        }

        private void BtnFire_Click(object sender, EventArgs e)
        {
            try
            {
                _dbEmployeeHelper.Delete(_conn);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                Console.WriteLine(err.StackTrace);
            }
        }
    }
}
