using System;
using System.Data.Common;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace HospitalOfThePeople
{
    public partial class FmRoom : Form
    {
        readonly OracleConnection _conn;

        readonly DBFormHelper _dbHelper;

        public FmRoom(OracleConnection conn)
        {
            InitializeComponent();
            this.btnAdd.Click += this.BtnAdd_Click;
            this.btnFind.Click += this.BtnFind_Click;
            this.btnUpdate.Click += this.BtnUpdate_Click;
            this.btnDelete.Click += this.BtnDelete_Click;

            _conn = conn;

            _dbHelper = new DBFormHelper(
                /*
		            RNo VARCHAR(5) NOT NULL,
		            Block VARCHAR(2) NOT NULL,
		            DNo CHAR(2) NOT NULL,
		            Type VARCHAR(20) NOT NULL,
                */
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("RNo", OracleDbType.Char, 5, txtRNo),
                    new DBFormHelper.AttributeType("Block", OracleDbType.Varchar2, 2, txtBlock),
                    new DBFormHelper.AttributeType("DNo", OracleDbType.Char, 2, txtDNo),
                    new DBFormHelper.AttributeType("Type", OracleDbType.Varchar2, 20, txtType)
                },
                //CONSTRAINT PK_Room PRIMARY KEY (RNo),
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("RNo", OracleDbType.Char, 5, txtRNo)
                },
                //c##common_user.Room
                "c##common_user.Room"
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
