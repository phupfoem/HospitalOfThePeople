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
        const string _username = "c##common_user";
        const string _passphrase = "commonpass";
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
            string funcName = "c##common_user.FUN_IS_EMPLOYEE";
            var parms = new DBUtils.AttributeType[]
            {
                new DBUtils.AttributeType(":Result", OracleDbType.Varchar2, 200, null, ParameterDirection.ReturnValue),
                new DBUtils.AttributeType(":i_username", OracleDbType.Varchar2, 200, txtUsername.Text, ParameterDirection.Input),
                new DBUtils.AttributeType(":i_password", OracleDbType.Varchar2, 200, txtPassword.Text, ParameterDirection.Input),
                new DBUtils.AttributeType(":o_emp_id", OracleDbType.Varchar2, 200, null, ParameterDirection.Output),
            };

            try
            {
                OracleCommand cmd = DBUtils.CreateFunctionCallSql(funcName, parms, _conn);
                cmd.ExecuteNonQuery();
                
                string jobTitle = cmd.Parameters[":Result"].Value.ToString();
                string empId = cmd.Parameters[":o_emp_id"].Value.ToString();

                if (jobTitle == "")
                {
                    MessageBox.Show("Invalid Username/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                OracleConnection conn = new OracleConnection($"Data Source = ( DESCRIPTION = ( ADDRESS = (PROTOCOL = TCP)(HOST = {_host})(PORT = {_port}) ) ( CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = {_sid}) ) ); Password = {txtPassword.Text}; User ID = {txtUsername.Text};");
                conn.Open();

                Form fm = null;
                switch (jobTitle)
                {
                    case "Nurse":
                        fm = new FmAdmission(conn);
                        break;
                    case "Doctor":
                        fm = new FmMainMenu(txtUsername.Text, txtPassword.Text);
                        fm.Show();
                        break;
                    case "Manager":
                        fm = new FmEmployee(conn);
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
            }
            catch (Exception err)
            {
                MessageBox.Show("Error" + err + err.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
