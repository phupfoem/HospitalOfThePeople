using System;
using System.Data.Common;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace HospitalOfThePeople
{
    public partial class FmEquipment : Form
    {
        readonly OracleConnection _conn;

        readonly DBFormHelper _dbHelper;

        public FmEquipment(OracleConnection conn)
        {
            InitializeComponent();
            this.btnAdd.Click += this.BtnAdd_Click;
            this.btnFind.Click += this.BtnFind_Click;
            this.btnUpdate.Click += this.BtnUpdate_Click;
            this.btnDelete.Click += this.BtnDelete_Click;

            _conn = conn;

            _dbHelper = new DBFormHelper(
                /*
		            ENo CHAR(8) NOT NULL,
		            Name VARCHAR(20) NOT NULL,
		            Quantity INT NOT NULL,
		            DNo CHAR(2),
		            RNo VARCHAR(5) NOT NULL,
                */
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("ENo", OracleDbType.Char, 8, txtENo),
                    new DBFormHelper.AttributeType("Name", OracleDbType.Varchar2, 20, txtName),
                    new DBFormHelper.AttributeType("Quantity", OracleDbType.Int32, null, txtQuantity),
                    new DBFormHelper.AttributeType("DNo", OracleDbType.Char, 2, txtDNo),
                    new DBFormHelper.AttributeType("RNo", OracleDbType.Char, 5, txtRNo)
                },
                //CONSTRAINT PK_Equipment PRIMARY KEY (ENo),
                new DBFormHelper.AttributeType[] {
                    new DBFormHelper.AttributeType("ENo", OracleDbType.Char, 8, txtENo),
                },
                //c##common_user.Equipment
                "c##common_user.Equipment"
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
