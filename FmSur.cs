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
    public partial class FmSur : Form
    {
        const string _host = "localhost";
        const int _port = 1521;
        const string _sid = "xe";

        readonly string _username;
        readonly string _passphrase;
        readonly OracleConnection conn;

        public FmSur(string username, string passphrase)
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
            string sql = "INSERT INTO c##common_user.Admission SELECT :SNo, :Type, :Time, :Fee, :RNo FROM DUAL";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                if (txtSNo.Text.Trim() != "")
                {
                    cmd.Parameters.Add(":SNo", OracleDbType.Char, 8).Value = txtSNo.Text.Trim();
                }

                if (txtType.Text.Trim() != "")
                {
                    cmd.Parameters.Add(":Type", OracleDbType.Char, 20).Value = txtType.Text.Trim();
                }

                if (txtTime.Text.Trim() != "")
                {
                    cmd.Parameters.Add(":Time", OracleDbType.Date).Value = txtTime.Text.Trim();
                }
                               

                if (txtRNo.Text.Trim() != "")
                {
                    cmd.Parameters.Add(":RNo", OracleDbType.Char, 5).Value = txtRNo.Text.Trim();
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
                if (txtSNo.Text.Trim() != "")
                {
                    cmd.CommandText += " AND SNo = :SNo";
                    cmd.Parameters.Add(":SNo", OracleDbType.Char, 8).Value = txtSNo.Text.Trim();
                }

                if (txtTime.Text.Trim() != "")
                {
                    cmd.CommandText += " AND Time = :Time";
                    cmd.Parameters.Add(":Time", OracleDbType.Date).Value = Convert.ToDateTime(txtTime.Text.Trim());
                }

                using (DbDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string SNo = reader.GetString(0);
                        string RNo = reader.GetString(3);
                        DateTime time = reader.GetDateTime(1);
                        

                        Console.WriteLine(" debug " + SNo + " yup ");

                        txtSNo.Text = SNo;
                        txtRNo.Text = RNo;
                        txtTime.Text = Convert.ToString(time);
                        

                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Error" + err + err.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, System.EventArgs e)
        {
            OracleCommand cmd = formSelectSql(
                null,
                new (string name, OracleDbType typ, int? size, string val)[] {
                    ("SNo", OracleDbType.Char, 8, txtSNo.Text),
                    ("Time", OracleDbType.Date, null, txtTime.Text),
                },
                "c##common_user.Admission",
                conn
            );
            if (cmd.ExecuteReader().HasRows)
            {
                cmd = formUpdateSql(
                    new (string name, OracleDbType typ, int? size, string val)[] {
                                    ("SNo", OracleDbType.Char, 8, txtSNo.Text),
                                    ("Time", OracleDbType.Date, null, txtTime.Text),

                    },
                    new (string name, OracleDbType typ, int? size, string val)[] {
                                    ("SNo", OracleDbType.Char, 8, txtSNo.Text),
                                    ("Time", OracleDbType.Date, null, txtTime.Text),
                    },
                    "c##common_user.Admission",
                    conn
                );
            }
            int rowCount = cmd.ExecuteNonQuery();
            Console.WriteLine(rowCount + " row(s) affected.");
        }
        private void BtnDelete_Click(object sender, System.EventArgs e)
        {
            try
            {
                int rowCount = 0;
                OracleCommand cmd = null;

                cmd = formDeleteSql(
                    new (string name, OracleDbType typ, int? size, string val)[] {
                        ("SNo", OracleDbType.Char, 8, txtSNo.Text),
                        ("Time", OracleDbType.Date, null, txtTime.Text),
                    },
                    "c##common_user.Admission",
                    conn
                );
                rowCount += cmd.ExecuteNonQuery();
                Console.WriteLine(rowCount + " row(s) deleted.");
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                Console.WriteLine(err.StackTrace);
            }
        }

        static OracleCommand formInsertSql(
            (OracleDbType typ, int? size, string val)[] parms,
            string table,
            OracleConnection conn
        )
        {
            if (parms == null || table == null || conn == null)
            {
                throw new ArgumentNullException("Null argument(s) in formInsertSql.");
            }

            if (parms.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Argument passed to formInsertSql.parms must not be empty.");
            }

            if (table == "")
            {
                throw new ArgumentOutOfRangeException("Argument passed to formInsertSql.table must not be empty.");
            }

            if (conn.State != ConnectionState.Open)
            {
                throw new ArgumentOutOfRangeException("Argument passed to formInsertSql.conn must be opened Oracle connection.");
            }

            string val = "";
            for (int i = 0; i < parms.Length; ++i)
            {
                val += $":{i}, ";
            }

            string sql = $@"
            INSERT INTO {table}
            VALUES({val.Substring(0, val.Length - 2)})
            ";

            OracleCommand cmd = new OracleCommand(sql, conn);

            for (int i = 0; i < parms.Length; ++i)
            {
                try
                {
                    addSqlParm(($":{i}", parms[i].typ, parms[i].size, parms[i].val), ref cmd);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                    Console.WriteLine(err.StackTrace);
                }
            }

            return cmd;
        }

        static OracleCommand formUpdateSql(
            (string name, OracleDbType typ, int? size, string val)[] parms,
            (string name, OracleDbType typ, int? size, string val)[] conds,
            string table,
            OracleConnection conn
        )
        {
            if (parms == null || table == null || conn == null)
            {
                throw new ArgumentNullException("Null argument(s) in formUpdateSql.");
            }

            if (parms.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Argument passed to formUpdateSql.parms must not be empty.");
            }

            if (table == "")
            {
                throw new ArgumentOutOfRangeException("Argument passed to formUpdateSql.table must not be empty.");
            }

            if (conn.State != ConnectionState.Open)
            {
                throw new ArgumentOutOfRangeException("Argument passed to formUpdateSql.conn must be opened Oracle connection.");
            }

            if (conds == null)
                conds = new (string name, OracleDbType typ, int? size, string val)[0];

            string sql = $@"
            UPDATE {table}
            SET
            ";

            for (int i = 0; i < parms.Length; ++i)
            {
                sql += parms[i].name + $" = :{2 * i},\n";
            }

            sql = sql.Substring(0, sql.Length - 2);


            if (conds.Length != 0)
            {
                sql += "WHERE ";
                for (int i = 0; i < conds.Length; ++i)
                {
                    sql += conds[i].name + $" = :{2 * i + 1} AND\n";
                }

                sql = sql.Substring(0, sql.Length - 5);
            }

            OracleCommand cmd = new OracleCommand(sql, conn);

            for (int i = 0; i < parms.Length; ++i)
            {
                try
                {
                    addSqlParm(($":{2 * i}", parms[i].typ, parms[i].size, parms[i].val), ref cmd);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                    Console.WriteLine(err.StackTrace);
                }
            }

            for (int i = 0; i < conds.Length; ++i)
            {
                try
                {
                    addSqlParm(($":{2 * i + 1}", conds[i].typ, conds[i].size, conds[i].val), ref cmd);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                    Console.WriteLine(err.StackTrace);
                }
            }

            return cmd;
        }

        static OracleCommand formDeleteSql(
            (string name, OracleDbType typ, int? size, string val)[] conds,
            string table,
            OracleConnection conn
        )
        {
            if (conds == null || table == null || conn == null)
            {
                throw new ArgumentNullException("Null argument(s) in formDeleteSql.");
            }

            if (conds.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Argument passed to formDeleteSql.conds must not be empty.");
            }

            if (table == "")
            {
                throw new ArgumentOutOfRangeException("Argument passed to formDeleteSql.table must not be empty.");
            }

            if (conn.State != ConnectionState.Open)
            {
                throw new ArgumentOutOfRangeException("Argument passed to formDeleteSql.conn must be opened Oracle connection.");
            }

            string sql = $@"
            DELETE FROM {table}
            WHERE ";

            for (int i = 0; i < conds.Length; ++i)
            {
                sql += conds[i].name + $" = :{2 * i + 1} AND\n";
            }

            sql = sql.Substring(0, sql.Length - 5);

            OracleCommand cmd = new OracleCommand(sql, conn);

            for (int i = 0; i < conds.Length; ++i)
            {
                try
                {
                    addSqlParm(($":{2 * i + 1}", conds[i].typ, conds[i].size, conds[i].val), ref cmd);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                    Console.WriteLine(err.StackTrace);
                }
            }

            return cmd;
        }

        static OracleCommand formSelectSql(
            string[] parms,
            (string name, OracleDbType typ, int? size, string val)[] conds,
            string table,
            OracleConnection conn
        )
        {
            if (table == null || conn == null)
            {
                throw new ArgumentNullException("Null argument(s) in formSelectSql.");
            }

            if (parms != null && parms.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Argument passed to formSelectSql.parms must not be empty.");
            }

            if (table == "")
            {
                throw new ArgumentOutOfRangeException("Argument passed to formSelectSql.table must not be empty.");
            }

            if (conn.State != ConnectionState.Open)
            {
                throw new ArgumentOutOfRangeException("Argument passed to formSelectSql.conn must be opened Oracle connection.");
            }

            if (conds == null)
                conds = new (string name, OracleDbType typ, int? size, string val)[0];

            string sql = "";
            if (parms == null)
            {
                sql = $"SELECT * FROM {table} ";
            }
            else
            {
                sql = $"SELECT {String.Join(", ", parms)} FROM {table} ";
            }

            if (conds.Length != 0)
            {
                sql += "WHERE ";
                for (int i = 0; i < conds.Length; ++i)
                {
                    sql += conds[i].name + $" = :{2 * i + 1} AND\n";
                }

                sql = sql.Substring(0, sql.Length - 5);
            }

            OracleCommand cmd = new OracleCommand(sql, conn);

            for (int i = 0; i < conds.Length; ++i)
            {
                try
                {
                    addSqlParm(($":{2 * i + 1}", conds[i].typ, conds[i].size, conds[i].val), ref cmd);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                    Console.WriteLine(err.StackTrace);
                }
            }

            return cmd;
        }

        static void addSqlParm((string name, OracleDbType typ, int? size, string val) parm, ref OracleCommand cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException("Null argument(s) in formInsertSql.");
            }

            if (!parm.name.StartsWith(":"))
            {
                throw new ArgumentOutOfRangeException("Argument passed to addSqlParm.parm.name must start with :.");
            }

            switch (parm.typ)
            {
                case OracleDbType.Char:
                    if (parm.size == null)
                        cmd.Parameters.Add(parm.name, parm.typ).Value = parm.val;
                    else
                        cmd.Parameters.Add(parm.name, parm.typ, parm.size ?? 0).Value = parm.val;
                    return;
                case OracleDbType.Varchar2:
                    if (parm.size == null)
                        cmd.Parameters.Add(parm.name, parm.typ).Value = parm.val;
                    else
                        cmd.Parameters.Add(parm.name, parm.typ, parm.size ?? 0).Value = parm.val;
                    return;
                case OracleDbType.Int16:
                case OracleDbType.Int32:
                case OracleDbType.Int64:
                    if (parm.val == "")
                        cmd.Parameters.Add(parm.name, parm.typ).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(parm.name, parm.typ).Value = Convert.ToInt64(parm.val);
                    return;
                case OracleDbType.IntervalYM:
                    if (parm.val == "")
                        cmd.Parameters.Add(parm.name, parm.typ).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(parm.name, parm.typ).Value = Convert.ToInt64(parm.val) * 12;
                    return;
                case OracleDbType.Date:
                    if (parm.val == "")
                        cmd.Parameters.Add(parm.name, parm.typ).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(parm.name, parm.typ).Value = Convert.ToDateTime(parm.val);
                    return;
                case OracleDbType.Decimal:
                    if (parm.val == "")
                        cmd.Parameters.Add(parm.name, parm.typ).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(parm.name, parm.typ).Value = Convert.ToDecimal(parm.val);
                    return;
                default:
                    throw new ArgumentOutOfRangeException("Argument passed to addSqlParm.parm.typ is not recognizable.");
            }
        }
        private void FmSur_Load(object sender, System.EventArgs e)
        {
            conn.Open();
            this.btnAdmit.Click += this.BtnAdmit_Click;
            this.btnCheck.Click += this.BtnCheck_Click;
            this.btnUpdate.Click += this.BtnUpdate_Click;
            this.btnDelete.Click += this.BtnDelete_Click;
        }
    }
}