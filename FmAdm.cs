using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalOfThePeople
{
    public partial class FmAdm : Form
    {
        const string _host = "localhost";
        const int _port = 1521;
        const string _sid = "xe";

        readonly string _username;
        readonly string _passphrase;
        readonly OracleConnection conn;

        public FmAdm(string username, string passphrase)
        {
            InitializeComponent();
            _username = username;
            _passphrase = passphrase;
            conn = new OracleConnection(
                $"Data Source = ( DESCRIPTION = ( ADDRESS = (PROTOCOL = TCP)(HOST = {_host})(PORT = {_port}) ) ( CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = {_sid}) ) ); Password = {_passphrase}; User ID = {_username}"
            );
        }

        private void BtnAdmit_Click(object sender, System.EventArgs e)
        {
            string sql = "INSERT INTO c##common_user.Admission SELECT :PIcn, :TimeIn, :TimeOut, :NIcn FROM DUAL";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                if (txtPIcn.Text.Trim() != "")
                {
                    cmd.Parameters.Add(":PIcn", OracleDbType.Char, 8).Value = txtPIcn.Text.Trim();
                }

                if (txtTimeIn.Text.Trim() != "")
                {
                    cmd.Parameters.Add(":TimeIn", OracleDbType.Date).Value = Convert.ToDateTime(txtTimeIn.Text.Trim());
                }

                if (txtTimeOut.Text.Trim() != "")
                {
                    cmd.Parameters.Add(":TimeOut", OracleDbType.Date).Value = Convert.ToDateTime(txtTimeOut.Text.Trim());
                }
                else
                {
                    cmd.Parameters.Add(":TimeOut", OracleDbType.Date).Value = Convert.ToDateTime("04-15-2990");
                }

                if (txtNIcn.Text.Trim() != "")
                {
                    cmd.Parameters.Add(":NIcn", OracleDbType.Char, 8).Value = txtNIcn.Text.Trim();
                }

                int rowCount = cmd.ExecuteNonQuery();
                Console.WriteLine(rowCount + " row(s) inserted.");
            }
            catch (Exception err)
            {
                MessageBox.Show("Error" + err + err.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCheck_Click(object sender, System.EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("SELECT * FROM c##common_user.Admission WHERE 1=1", conn);
            try
            {
                if (txtPIcn.Text.Trim() != "")
                {
                    cmd.CommandText += " AND PIcn = :PIcn";
                    cmd.Parameters.Add(":PIcn", OracleDbType.Char, 8).Value = txtPIcn.Text.Trim();
                }

                if (txtTimeIn.Text.Trim() != "")
                {
                    cmd.CommandText += " AND TimeIn = :TimeIn";
                    cmd.Parameters.Add(":TimeIn", OracleDbType.Date).Value = Convert.ToDateTime(txtTimeIn.Text.Trim());
                }

                if (txtNIcn.Text.Trim() != "")
                {
                    cmd.CommandText += " AND NIcn = :NIcn";
                    cmd.Parameters.Add(":NIcn", OracleDbType.Char, 8).Value = txtNIcn.Text.Trim();
                }

                using (DbDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string picn = reader.GetString(0);
                        string nicn = reader.GetString(3);
                        DateTime timein = reader.GetDateTime(1);
                        DateTime timeout = reader.GetDateTime(2);

                        txtPIcn.Text = picn;
                        txtNIcn.Text = nicn;
                        txtTimeIn.Text = Convert.ToString(timein);
                        txtTimeOut.Text = Convert.ToString(timeout);
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Error" + err + err.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FmAdm_Load(object sender, System.EventArgs e)
        {
            conn.Open();
            this.btnAdmit.Click += this.BtnAdmit_Click;
            this.btnCheck.Click += this.BtnCheck_Click;
        }
    }
}
