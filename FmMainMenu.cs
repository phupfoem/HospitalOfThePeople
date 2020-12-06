using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;

namespace HospitalOfThePeople
{
    public partial class FmMainMenu : Form
    {
        const string _host = "localhost";
        const int _port = 1521;
        const string _sid = "orcl";

        readonly string _username;
        readonly string _passphrase;
        readonly OracleConnection conn;
        readonly string _empId;

        public FmMainMenu(string empId, string username, string passphrase)
        {
            InitializeComponent();

            _username = username;
            _passphrase = passphrase;
            conn = new OracleConnection(
                $"Data Source = ( DESCRIPTION = ( ADDRESS = (PROTOCOL = TCP)(HOST = {_host})(PORT = {_port}) ) ( CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = {_sid}) ) ); Password = {_passphrase}; User ID = {_username}"
            );

            _empId = empId;
        }

        private void FmMainMenu_Load(object sender, EventArgs e)
        {
            conn.Open();
        }
        private void FmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
            conn.Dispose();
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            //Icn CHAR(8) NOT NULL,
            //FName VARCHAR(20) NOT NULL,
            //LName VARCHAR(20) NOT NULL,
            //BDate DATE NOT NULL,
            //Gender CHAR NOT NULL,
            //PhoneNo VARCHAR(20),
            //Address VARCHAR(20),
            string sql = "INSERT INTO c##common_user.Patient SELECT :Icn, :Fname, :LName, :BDate, :Gender, :PhoneNo, :Address FROM DUAL";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                if (txtIcn.Text.Trim() != "")
                {
                    cmd.Parameters.Add(":Icn", OracleDbType.Char, 8).Value = txtIcn.Text.Trim();
                }

                if (txtFname.Text.Trim() != "")
                {
                    cmd.Parameters.Add(":Fname", OracleDbType.Varchar2, 20).Value = txtFname.Text.Trim();
                }

                if (txtLname.Text.Trim() != "")
                {
                    cmd.Parameters.Add(":Lname", OracleDbType.Varchar2, 20).Value = txtLname.Text.Trim();
                }

                if (txtBdate.Text.Trim() != "")
                {
                    cmd.Parameters.Add(":BDate", OracleDbType.Date).Value = Convert.ToDateTime(txtBdate.Text.Trim());
                }

                if (txtGen.Text.Trim() != "")
                {
                    cmd.Parameters.Add(":Gender", OracleDbType.Char).Value = txtGen.Text.Trim()[0];
                }

                cmd.Parameters.Add(":PhoneNo", OracleDbType.Varchar2, 20).Value = "";
                cmd.Parameters.Add(":Address", OracleDbType.Varchar2, 20).Value = "";

                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine(rowCount + " row(s) inserted.");
            }
            catch (Exception err)
            {
                MessageBox.Show("Error" + err + err.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdmit_Click(object sender, System.EventArgs e)
        {
            //Icn CHAR(8) NOT NULL,
            //FName VARCHAR(20) NOT NULL,
            //LName VARCHAR(20) NOT NULL,
            //BDate DATE NOT NULL,
            //Gender CHAR NOT NULL,
            //PhoneNo VARCHAR(20),
            //Address VARCHAR(20),
            OracleCommand cmd = new OracleCommand("SELECT * FROM c##common_user.Patient WHERE 1=1", conn);
            try
            {
                if (txtIcn.Text.Trim() != "")
                {
                    cmd.CommandText += " AND Icn = :Icn";
                    cmd.Parameters.Add(":Icn", OracleDbType.Char, 8).Value = txtIcn.Text.Trim();
                }

                if (txtBdate.Text.Trim() != "")
                {
                    cmd.CommandText += " AND BDate = :BDate";
                    cmd.Parameters.Add(":BDate", OracleDbType.Date).Value = Convert.ToDateTime(txtBdate.Text.Trim());
                }

                if (txtGen.Text.Trim() != "")
                {
                    cmd.CommandText += " AND Gender = :Gender";
                    cmd.Parameters.Add(":Gender", OracleDbType.Char);
                    cmd.Parameters[":Gender"].Value = txtGen.Text.Trim()[0];
                }

                using (DbDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string icn = reader.GetString(0);
                        string fname = reader.GetString(1);
                        string lname = reader.GetString(2);
                        DateTime bdate = reader.GetDateTime(3);
                        string gender = reader.GetString(4);
                        string phone = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        string address = reader.IsDBNull(6) ? "" : reader.GetString(6);

                        txtIcn.Text = icn;
                        txtFname.Text = fname;
                        txtLname.Text = lname;
                        txtBdate.Text = Convert.ToString(bdate);
                        txtGen.Text = gender;
                        txtPhone.Text = phone;
                        txtAddr.Text = address;
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Error" + err + err.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLogout_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

    }
}
