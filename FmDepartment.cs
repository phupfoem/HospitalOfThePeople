using System;
using System.Data.Common;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace HospitalOfThePeople
{
    public partial class FmDepartment : Form
    {
        readonly OracleConnection _conn;

        readonly DBFormHelper _dbHelper;

        public FmDepartment(OracleConnection conn)
        {
            InitializeComponent();
            this.btnAdd.Click += this.BtnAdd_Click;
            this.btnFind.Click += this.BtnFind_Click;
            this.btnUpdate.Click += this.BtnUpdate_Click;
            this.btnDelete.Click += this.BtnDelete_Click;

            _conn = conn;

            _dbHelper = new DBFormHelper(
                /*
		            DNo CHAR(2) NOT NULL,
		            Name VARCHAR(20) NOT NULL UNIQUE,
		            Location VARCHAR(20) NOT NULL,
                */
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("DNo", OracleDbType.Char, 2, txtDNo),
                    new DBFormHelper.AttributeType("Name", OracleDbType.Varchar2, 20, txtName),
                    new DBFormHelper.AttributeType("Location", OracleDbType.Varchar2, 20, txtLocation)
                },
                //CONSTRAINT PK_Department PRIMARY KEY (DNo),
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("DNo", OracleDbType.Char, 2, txtDNo)
                },
                //c##common_user.Department
                "c##common_user.Department"
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
