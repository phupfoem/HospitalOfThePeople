using System;
using System.Data.Common;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace HospitalOfThePeople
{
    public partial class FmAdmission : Form
    {
        readonly OracleConnection _conn;

        readonly DBFormHelper _dbHelper;

        public FmAdmission(OracleConnection conn)
        {
            InitializeComponent();
            this.btnAdmit.Click += this.BtnAdmit_Click;
            this.btnCheck.Click += this.BtnCheck_Click;
            this.btnUpdate.Click += this.BtnUpdate_Click;
            this.btnDelete.Click += this.BtnDelete_Click;

            _conn = conn;

            _dbHelper = new DBFormHelper(
                /*
		            PIcn CHAR(8) NOT NULL,
		            TimeIn DATE NOT NULL,
		            TimeOut DATE,
		            NIcn CHAR(8) NOT NULL,
                */
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("PIcn", OracleDbType.Char, 8, txtPIcn),
                    new DBFormHelper.AttributeType("TimeIn", OracleDbType.Date, null, txtTimeIn),
                    new DBFormHelper.AttributeType("TimeOut", OracleDbType.Date, null, txtTimeOut),
                    new DBFormHelper.AttributeType("NIcn", OracleDbType.Char, 8, txtNIcn)
                },
                //CONSTRAINT PK_Admission PRIMARY KEY(PIcn, TimeIn),
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("PIcn", OracleDbType.Char, 8, txtPIcn),
                    new DBFormHelper.AttributeType("TimeIn", OracleDbType.Date, null, txtTimeIn)
                },
                //hospital_dba.Admission
                "hospital_dba.Admission"
            );
        }

        private void BtnAdmit_Click(object sender, EventArgs e)
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

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                using (DbDataReader reader = _dbHelper.Find(_conn))
                {
                    if (!reader.HasRows)
                        MessageBox.Show("Admission not found.", "Error", MessageBoxButtons.OK);
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
