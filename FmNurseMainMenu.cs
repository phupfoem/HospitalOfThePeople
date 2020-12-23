using System;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace HospitalOfThePeople
{
    public partial class FmNurseMainMenu : Form
    {
        readonly OracleConnection _conn;

        public FmNurseMainMenu(OracleConnection conn)
        {
            InitializeComponent();
            this.btnAdmission.Click += this.BtnAdmission_Click;
            this.btnGuardian.Click += this.BtnGuardian_Click;
            this.btnPatient.Click += this.BtnPatient_Click;

            _conn = conn;
        }

        private void BtnAdmission_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fm = new FmAdmission(_conn);
            fm.ShowDialog();
            this.Show();
        }

        private void BtnGuardian_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fm = new FmGuardian(_conn);
            fm.ShowDialog();
            this.Show();
        }

        private void BtnPatient_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fm = new FmPatient(_conn);
            fm.ShowDialog();
            this.Show();
        }
    }
}
