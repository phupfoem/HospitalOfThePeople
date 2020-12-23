using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace HospitalOfThePeople
{
    public partial class FmLogin : Form
    {
        const string _host = "localhost";
        const int _port = 1521;
        const string _sid = "orcl";
        const string _username = "gate_keeper";
        const string _passphrase = "p1234567";
        readonly OracleConnection _conn = new OracleConnection(
            $"Data Source = ( DESCRIPTION = ( ADDRESS = (PROTOCOL = TCP)(HOST = {_host})(PORT = {_port}) ) ( CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = {_sid}) ) ); Password = {_passphrase}; User ID = {_username};"
        );

        public FmLogin()
        {
            InitializeComponent();
            this.btnLogin.Click += this.BtnLogin_Click;
            this.btCancel.Click += this.BtnCancel_Click;
            this.FormClosing += this.FmLogin_FormClosing;
            this.txtPassword.KeyPress += this.TxtPassword_KeyPressed;

            _conn.Open();
        }

        private void FmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            _conn.Close();
            _conn.Dispose();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string funcName = "hospital_dba.FUN_Is_Employee";


            var parms = new DBUtils.AttributeType[]
            {
                new DBUtils.AttributeType(":Result", OracleDbType.Varchar2, 200, null, ParameterDirection.ReturnValue),
                new DBUtils.AttributeType(":i_username", OracleDbType.Varchar2, 200, txtUsername.Text.Trim(), ParameterDirection.Input)
            };

            OracleCommand cmd;

            try
            {
                cmd = DBUtils.CreateFunctionCallSql(funcName, parms, _conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error" + err + err.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = cmd.Parameters[":Result"].Value;
            if (result == DBNull.Value)
            {
                MessageBox.Show("Invalid Username/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string jobTitle = result.ToString();

            OracleConnection conn = new OracleConnection($"Data Source = ( DESCRIPTION = ( ADDRESS = (PROTOCOL = TCP)(HOST = {_host})(PORT = {_port}) ) ( CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = {_sid}) ) ); Password = {txtPassword.Text.Trim()}; User ID = {txtUsername.Text.Trim()};");
            try
            {
                conn.Open();
            }
            catch
            {
                MessageBox.Show("Invalid Username/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form fm = null;
            switch (jobTitle)
            {
                case "Nurse":
                    fm = new FmNurseMainMenu(conn);
                    break;
                case "Doctor":
                    fm = new FmDoctorMainMenu(conn);
                    fm.Show();
                    break;
                case "DBA":
                    fm = new FmDbaMainMenu(conn);
                    break;
                default:
                    MessageBox.Show("Login success but interface unknown.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            if (fm != null)
            {
                this.Hide();
                fm.ShowDialog();
                txtUsername.Text = txtPassword.Text = "";
                this.Show();
            }

            conn.Close();
            conn.Dispose();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtPassword_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                this.BtnLogin_Click(null, null);
        }
    }
}
