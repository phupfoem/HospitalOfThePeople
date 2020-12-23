using System;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace HospitalOfThePeople
{
    public partial class FmDbaMainMenu : Form
    {
        readonly OracleConnection _conn;

        public FmDbaMainMenu(OracleConnection conn)
        {
            InitializeComponent();
            this.btnDepartment.Click += this.BtnDepartment_Click;
            this.btnEquipment.Click += this.BtnEquipment_Click;
            this.btnEmployee.Click += this.BtnEmployee_Click;
            this.btnRoom.Click += this.BtnRoom_Click;

            _conn = conn;
        }

        private void BtnDepartment_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fm = new FmDepartment(_conn);
            fm.ShowDialog();
            this.Show();
        }

        private void BtnEquipment_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fm = new FmEquipment(_conn);
            fm.ShowDialog();
            this.Show();
        }

        private void BtnEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fm = new FmEmployee(_conn);
            fm.ShowDialog();
            this.Show();
        }

        private void BtnRoom_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fm = new FmRoom(_conn);
            fm.ShowDialog();
            this.Show();
        }
    }
}
