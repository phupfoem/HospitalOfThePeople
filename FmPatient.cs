using System;
using System.Data.Common;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace HospitalOfThePeople
{
    public partial class FmPatient : Form
    {
        readonly OracleConnection _conn;

        readonly DBFormHelper _dbHelper;

        public FmPatient(OracleConnection conn)
        {
            InitializeComponent();
            this.btnAdd.Click += this.BtnAdd_Click;
            this.btnFind.Click += this.BtnFind_Click;
            this.btnUpdate.Click += this.BtnUpdate_Click;
            this.btnDelete.Click += this.BtnDelete_Click;

            _conn = conn;

            _dbHelper = new DBFormHelper(
                /*
		            Icn CHAR(8) NOT NULL,
		            FName VARCHAR(20) NOT NULL,
		            LName VARCHAR(20) NOT NULL,
		            BDate DATE NOT NULL,
		            Gender CHAR NOT NULL,
		            PhoneNo VARCHAR(20),
		            Address VARCHAR(20),
                */
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("Icn", OracleDbType.Char, 8, txtIcn),
                    new DBFormHelper.AttributeType("FName", OracleDbType.Varchar2, 20, txtFName),
                    new DBFormHelper.AttributeType("LName", OracleDbType.Varchar2, 20, txtLName),
                    new DBFormHelper.AttributeType("BDate", OracleDbType.Date, null, txtBDate),
                    new DBFormHelper.AttributeType("Gender", OracleDbType.Char, null, txtGender),
                    new DBFormHelper.AttributeType("PhoneNo", OracleDbType.Varchar2, 20, txtPhoneNo),
                    new DBFormHelper.AttributeType("Address", OracleDbType.Varchar2, 20, txtAddress)
                },
                //CONSTRAINT PK_Patient PRIMARY KEY(Icn),
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("Icn", OracleDbType.Char, 8, txtIcn)
                },
                //c##common_user.Patient
                "c##common_user.Patient"
            );
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _dbHelper.Insert(_conn);
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
                using (DbDataReader reader = _dbHelper.Find(_conn))
                {
                    if (!reader.HasRows)
                        MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK);
                    else
                    {
                        _dbHelper.Read(reader);
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
                _dbHelper.Update(_conn);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                Console.WriteLine(err.StackTrace);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _dbHelper.Delete(_conn);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                Console.WriteLine(err.StackTrace);
            }
        }
    }
}
