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

        readonly OracleConnection _conn;

        readonly DBFormHelper _dbPatientHelper;

        public FmMainMenu(string username, string password)
        {
            InitializeComponent();
            this.FormClosing += this.FmMainMenu_FormClosing;

            _conn = new OracleConnection(
                $"Data Source = ( DESCRIPTION = ( ADDRESS = (PROTOCOL = TCP)(HOST = {_host})(PORT = {_port}) ) ( CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = {_sid}) ) ); Password = {password}; User ID = {username}"
            );
            _conn.Open();
        }

        private void FmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            _conn.Close();
            _conn.Dispose();
        }
    }
}
