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
        const string _sid = "xe";
        const string _username = "c##common_user";
        const string _passphrase = "commonpass";
        readonly OracleConnection conn = new OracleConnection(
            $"Data Source = ( DESCRIPTION = ( ADDRESS = (PROTOCOL = TCP)(HOST = {_host})(PORT = {_port}) ) ( CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = {_sid}) ) ); Password = {_passphrase}; User ID = {_username};"
        );

        public FmLogin()
        {
            InitializeComponent();
        }

        private void FmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
            conn.Dispose();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

        }

        private void BtnSignup_Click(object sender, System.EventArgs e)
        {
            var fm = new FmMainMenu("", "c##common_user", "commonpass");
            fm.Show();
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FmLogin_Load(object sender, EventArgs e)
        {
            conn.Open();
            this.btnLogin.Click += this.BtnLogin_Click;
            this.btnLogin.Click += this.BtnLogin_Click;
            this.btnSignup.Click += this.BtnSignup_Click;
            this.btCancel.Click += this.BtnCancel_Click;
            this.FormClosing += this.FmLogin_FormClosing;
        }
    }
}
