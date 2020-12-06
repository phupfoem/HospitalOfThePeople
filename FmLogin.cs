using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace HospitalOfThePeople
{
    public partial class FmLogin : Form
    {
        const string _host = "localhost";
        const int _port = 1521;
        const string _sid = "orcl";
        const string _username = "c##common_user";
        const string _passphrase = "commonpass";
        readonly OracleConnection conn = new OracleConnection(
            $"Data Source = ( DESCRIPTION = ( ADDRESS = (PROTOCOL = TCP)(HOST = {_host})(PORT = {_port}) ) ( CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = {_sid}) ) ); Password = {_passphrase}; User ID = {_username};"
        );

        public FmLogin()
        {
            InitializeComponent();
        }

        private void FmLogin_Load(object sender, EventArgs e)
        {
            conn.Open();
        }

        private void FmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
            conn.Dispose();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("FUN_IS_EMPLOYEE", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                OracleParameter jobTitle = new OracleParameter("@Result", OracleDbType.Varchar2, 200)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(jobTitle);

                cmd.Parameters.Add("@i_username", OracleDbType.Varchar2, 200).Value = txtUsername.Text;
                cmd.Parameters.Add("@i_password", OracleDbType.Varchar2, 200).Value = txtPassword.Text;

                OracleParameter empId = new OracleParameter("@o_emp_id", OracleDbType.Varchar2, 200)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(empId);

                cmd.ExecuteNonQuery();

                string ret = jobTitle.Value.ToString();
                Form fm = null;
                switch (ret)
                {
                    case "Nurse":
                        fm = new FmMainMenu(empId.Value.ToString(), txtUsername.Text, txtPassword.Text);
                        fm.Show();
                        break;
                    case "Doctor":
                        fm = new FmMainMenu(empId.Value.ToString(), txtUsername.Text, txtPassword.Text);
                        fm.Show();
                        break;
                    case "Manager":
                        fm = new FmMainMenu(empId.Value.ToString(), txtUsername.Text, txtPassword.Text);
                        fm.Show();
                        break;
                    default:
                        MessageBox.Show("Invalid Username/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error" + err + err.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSignup_Click(object sender, System.EventArgs e)
        {
            var fm = new FmMainMenu("", "c##common_user", "commonpass");
            fm.Show();
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }
    }
}
