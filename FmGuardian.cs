using System;
using System.Data.Common;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace HospitalOfThePeople
{
    public partial class FmGuardian : Form
    {
        readonly OracleConnection _conn;

        readonly DBFormHelper _dbHelper;

        public FmGuardian(OracleConnection conn)
        {
            InitializeComponent();
            this.btnAdd.Click += this.BtnAdd_Click;
            this.btnFind.Click += this.BtnFind_Click;
            this.btnUpdate.Click += this.BtnUpdate_Click;
            this.btnDelete.Click += this.BtnDelete_Click;

            _conn = conn;

            _dbHelper = new DBFormHelper(
                /*
		            PIcn CHAR(8) NOT NULL,
		            FName VARCHAR(20) NOT NULL,
		            LName VARCHAR(20) NOT NULL,
		            PhoneNo VARCHAR(20) NOT NULL,
		            Relationship VARCHAR(20) NOT NULL,
                */
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("PIcn", OracleDbType.Char, 8, txtPIcn),
                    new DBFormHelper.AttributeType("FName", OracleDbType.Varchar2, 20, txtFName),
                    new DBFormHelper.AttributeType("LName", OracleDbType.Varchar2, 20, txtLName),
                    new DBFormHelper.AttributeType("PhoneNo", OracleDbType.Varchar2, 20, txtPhoneNo),
                    new DBFormHelper.AttributeType("Relationship", OracleDbType.Varchar2, 20, txtRelationship)
                },
                //CONSTRAINT PK_Guardian PRIMARY KEY (PIcn, PhoneNo),
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("PIcn", OracleDbType.Char, 8, txtPIcn),
                    new DBFormHelper.AttributeType("PhoneNo", OracleDbType.Varchar2, 20, txtPhoneNo)
                },
                //c##common_user.Guardian
                "c##common_user.Guardian"
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
