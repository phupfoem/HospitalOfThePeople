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
    public partial class FmEmp : Form
    {
        readonly OracleConnection _conn;

        public FmEmp(OracleConnection conn)
        {
            InitializeComponent();
            _conn = conn;
        }

        private void FmEmp_Load(object sender, EventArgs e)
        {
            this.btnHire.Click += this.BtnHire_Click;
            this.btnUpdate.Click += this.BtnUpdate_Click;
            this.btnFire.Click += this.BtnFire_Click;
            this.btnFind.Click += this.BtnFind_Click;
        }

        private void BtnHire_Click(object sender, EventArgs e)
        {
            //Icn CHAR(8) NOT NULL,
            //FName VARCHAR(20) NOT NULL,
            //LName VARCHAR(20) NOT NULL,
            //BDate DATE NOT NULL,
            //Gender CHAR NOT NULL,
            //PhoneNo VARCHAR(20) NOT NULL,
            //Address VARCHAR(20),
            //EmpDate DATE NOT NULL,
            //YearsOfExp INTERVAL YEAR(2) TO MONTH,
            //Salary DECIMAL(6, 2) NOT NULL,
            //DNo CHAR(2) NOT NULL,
            //Job VARCHAR(20) NOT NULL,
            //Username VARCHAR(50) UNIQUE NOT NULL,
            //Password VARCHAR(50) NOT NULL,
            try
            {
                OracleCommand cmd = formInsertSql(
                    new (OracleDbType typ, int? size, string val)[] {
                        (OracleDbType.Char, 8, txtIcn.Text),
                        (OracleDbType.Varchar2, 20, txtFname.Text),
                        (OracleDbType.Varchar2, 20, txtLname.Text),
                        (OracleDbType.Date, null, txtBDate.Text),
                        (OracleDbType.Char, null, txtGender.Text),
                        (OracleDbType.Varchar2, 20, txtPhoneNo.Text),
                        (OracleDbType.Varchar2, 20, txtAddress.Text),
                        (OracleDbType.Date, null, txtEmpDate.Text),
                        (OracleDbType.IntervalYM, null, txtYearsOfExp.Text),
                        (OracleDbType.Decimal, null, txtSalary.Text),
                        (OracleDbType.Char, 2, txtDNo.Text),
                        (OracleDbType.Varchar2, 20, txtJob.Text),
                        (OracleDbType.Varchar2, 50, txtUsername.Text),
                        (OracleDbType.Varchar2, 50, txtPassword.Text),
                    },
                    "c##common_user.Employee",
                    _conn
                );

                int rowCount = cmd.ExecuteNonQuery();

                switch (txtJob.Text)
                {
                    //Icn CHAR(8) NOT NULL,
                    //Expertise VARCHAR(20) NOT NULL,
                    case "Doctor":
                        cmd = formInsertSql(
                            new (OracleDbType typ, int? size, string val)[] {
                                (OracleDbType.Char, 8, txtIcn.Text),
                                (OracleDbType.Varchar2, 20, txtExpertise.Text),
                            },
                            "c##common_user.Doctor",
                            _conn
                        );
                        rowCount += cmd.ExecuteNonQuery();
                        break;
                    case "Nurse":
                    	//Icn CHAR(8) NOT NULL,
                        cmd = formInsertSql(
                            new (OracleDbType typ, int? size, string val)[] {
                                (OracleDbType.Char, 8, txtIcn.Text),
                            },
                            "c##common_user.Nurse",
                            _conn
                        );
                        rowCount += cmd.ExecuteNonQuery();
                        break;
                }

                Console.WriteLine(rowCount + " row(s) inserted.");
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                Console.WriteLine(err.StackTrace);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //Icn CHAR(8) NOT NULL,
            //FName VARCHAR(20) NOT NULL,
            //LName VARCHAR(20) NOT NULL,
            //BDate DATE NOT NULL,
            //Gender CHAR NOT NULL,
            //PhoneNo VARCHAR(20) NOT NULL,
            //Address VARCHAR(20),
            //EmpDate DATE NOT NULL,
            //YearsOfExp INTERVAL YEAR(2) TO MONTH,
            //Salary DECIMAL(6, 2) NOT NULL,
            //DNo CHAR(2) NOT NULL,
            //Job VARCHAR(20) NOT NULL,
            //Username VARCHAR(50) UNIQUE NOT NULL,
            //Password VARCHAR(50) NOT NULL,
            //CONSTRAINT PK_Employee PRIMARY KEY (Icn),
            try
            {
                int rowCount = 0;
                OracleCommand cmd = null;

                switch (txtJob.Text)
                {
                    //Icn CHAR(8) NOT NULL,
                    //Expertise VARCHAR(20) NOT NULL,
                    case "Doctor":
                        cmd = formSelectSql(
                            null,
                            new (string name, OracleDbType typ, int? size, string val)[] {
                                ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                            },
                            "c##common_user.Doctor",
                            _conn
                        );

                        if (cmd.ExecuteReader().HasRows)
                        {
                            cmd = formUpdateSql(
                                new (string name, OracleDbType typ, int? size, string val)[] {
                                    ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                                    ("Expertise", OracleDbType.Varchar2, 20, txtExpertise.Text),
                                },
                                new (string name, OracleDbType typ, int? size, string val)[] {
                                    ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                                },
                                "c##common_user.Doctor",
                                _conn
                            );
                        }
                        else
                        {
                            cmd = formInsertSql(
                                new (OracleDbType typ, int? size, string val)[] {
                                    (OracleDbType.Char, 8, txtIcn.Text),
                                    (OracleDbType.Varchar2, 20, txtExpertise.Text),
                                },
                                "c##common_user.Doctor",
                                _conn
                            );
                        }
                        rowCount += cmd.ExecuteNonQuery();
                        break;
                    case "Nurse":
                        //Icn CHAR(8) NOT NULL,
                        cmd = formSelectSql(
                            null,
                            new (string name, OracleDbType typ, int? size, string val)[] {
                                ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                            },
                            "c##common_user.Nurse",
                            _conn
                        );

                        if (cmd.ExecuteReader().HasRows)
                        {
                            cmd = formUpdateSql(
                                new (string name, OracleDbType typ, int? size, string val)[] {
                                    ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                                },
                                new (string name, OracleDbType typ, int? size, string val)[] {
                                    ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                                },
                                "c##common_user.Nurse",
                                _conn
                            );
                        }
                        else
                        {
                            cmd = formInsertSql(
                                new (OracleDbType typ, int? size, string val)[] {
                                    (OracleDbType.Char, 8, txtIcn.Text),
                                },
                                "c##common_user.Nurse",
                                _conn
                            );
                        }
                        rowCount += cmd.ExecuteNonQuery();
                        break;
                    default:
                        cmd = formDeleteSql(
                            new (string name, OracleDbType typ, int? size, string val)[] {
                                ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                            },
                            "c##common_user.Doctor",
                            _conn
                        );
                        rowCount += cmd.ExecuteNonQuery();
                        cmd = formDeleteSql(
                            new (string name, OracleDbType typ, int? size, string val)[] {
                                ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                            },
                            "c##common_user.Nurse",
                            _conn
                        );
                        rowCount += cmd.ExecuteNonQuery();
                        break;
                }

                cmd = formUpdateSql(
                    new (string name, OracleDbType typ, int? size, string val)[] {
                        ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                        ("FName", OracleDbType.Varchar2, 20, txtFname.Text),
                        ("LName", OracleDbType.Varchar2, 20, txtLname.Text),
                        ("BDate", OracleDbType.Date, null, txtBDate.Text),
                        ("Gender", OracleDbType.Char, null, txtGender.Text),
                        ("PhoneNo", OracleDbType.Varchar2, 20, txtPhoneNo.Text),
                        ("Address", OracleDbType.Varchar2, 20, txtAddress.Text),
                        ("EmpDate", OracleDbType.Date, null, txtEmpDate.Text),
                        ("YearsOfExp", OracleDbType.IntervalYM, null, txtYearsOfExp.Text),
                        ("Salary", OracleDbType.Decimal, null, txtSalary.Text),
                        ("DNo", OracleDbType.Char, 2, txtDNo.Text),
                        ("Job", OracleDbType.Varchar2, 20, txtJob.Text),
                        ("Username", OracleDbType.Varchar2, 50, txtUsername.Text),
                        ("Password", OracleDbType.Varchar2, 50, txtPassword.Text),
                    },
                    new (string name, OracleDbType typ, int? size, string val)[] {
                        ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                    },
                    "c##common_user.Employee",
                    _conn
                );

                rowCount += cmd.ExecuteNonQuery();

                

                Console.WriteLine(rowCount + " row(s) affected.");
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                Console.WriteLine(err.StackTrace);
            }
        }

        private void BtnFire_Click(object sender, EventArgs e)
        {
            try
            {
                int rowCount = 0;
                OracleCommand cmd = null;
                
                //Icn CHAR(8) NOT NULL,
                //Expertise VARCHAR(20) NOT NULL,
                cmd = formDeleteSql(
                    new (string name, OracleDbType typ, int? size, string val)[] {
                        ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                    },
                    "c##common_user.Doctor",
                    _conn
                );
                rowCount += cmd.ExecuteNonQuery();

                //Icn CHAR(8) NOT NULL,
                rowCount += cmd.ExecuteNonQuery();
                cmd = formDeleteSql(
                    new (string name, OracleDbType typ, int? size, string val)[] {
                                ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                    },
                    "c##common_user.Nurse",
                    _conn
                );
                rowCount += cmd.ExecuteNonQuery();

                //Icn CHAR(8) NOT NULL,
                //FName VARCHAR(20) NOT NULL,
                //LName VARCHAR(20) NOT NULL,
                //BDate DATE NOT NULL,
                //Gender CHAR NOT NULL,
                //PhoneNo VARCHAR(20) NOT NULL,
                //Address VARCHAR(20),
                //EmpDate DATE NOT NULL,
                //YearsOfExp INTERVAL YEAR(2) TO MONTH,
                //Salary DECIMAL(6, 2) NOT NULL,
                //DNo CHAR(2) NOT NULL,
                //Job VARCHAR(20) NOT NULL,
                //Username VARCHAR(50) UNIQUE NOT NULL,
                //Password VARCHAR(50) NOT NULL,
                //CONSTRAINT PK_Employee PRIMARY KEY (Icn),
                cmd = formDeleteSql(
                    new (string name, OracleDbType typ, int? size, string val)[] {
                        ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                    },
                    "c##common_user.Employee",
                    _conn
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

        private void BtnFind_Click(object sender, EventArgs e)
        {
            //Icn CHAR(8) NOT NULL,
            //FName VARCHAR(20) NOT NULL,
            //LName VARCHAR(20) NOT NULL,
            //BDate DATE NOT NULL,
            //Gender CHAR NOT NULL,
            //PhoneNo VARCHAR(20) NOT NULL,
            //Address VARCHAR(20),
            //EmpDate DATE NOT NULL,
            //YearsOfExp INTERVAL YEAR(2) TO MONTH,
            //Salary DECIMAL(6, 2) NOT NULL,
            //DNo CHAR(2) NOT NULL,
            //Job VARCHAR(20) NOT NULL,
            //Username VARCHAR(50) UNIQUE NOT NULL,
            //Password VARCHAR(50) NOT NULL,
            //CONSTRAINT PK_Employee PRIMARY KEY (Icn),
            try
            {
                OracleCommand cmd = formSelectSql(
                    null,
                    new (string name, OracleDbType typ, int? size, string val)[] {
                        ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                    },
                    "c##common_user.Employee",
                    _conn
                );

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                        MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK);
                    else
                    {
                        reader.Read();
                        txtIcn.Text = reader.GetString(0);
                        txtFname.Text = reader.GetString(1);
                        txtLname.Text = reader.GetString(2);
                        txtBDate.Text = Convert.ToString(reader.GetDateTime(3));
                        txtGender.Text = reader.GetString(4);
                        txtPhoneNo.Text = reader.GetString(5);
                        txtAddress.Text = reader.IsDBNull(6)? "": reader.GetString(6);
                        txtEmpDate.Text = Convert.ToString(reader.GetDateTime(7));
                        txtYearsOfExp.Text = reader.IsDBNull(8) ? "" : Convert.ToString(reader.GetInt64(8) / 12);
                        txtSalary.Text = Convert.ToString(reader.GetDecimal(9));
                        txtDNo.Text = reader.GetString(10);
                        txtJob.Text = reader.GetString(11);
                        txtUsername.Text = reader.GetString(12);
                        txtPassword.Text = reader.GetString(13);
                    }
                }

                if (txtJob.Text == "Doctor")
                {
                    cmd = formSelectSql(
                        new string[] {
                            "Expertise",
                        },
                        new (string name, OracleDbType typ, int? size, string val)[] {
                            ("Icn", OracleDbType.Char, 8, txtIcn.Text),
                        },
                        "c##common_user.Doctor",
                        _conn
                    );

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                            MessageBox.Show("Doctor details not found.", "Error", MessageBoxButtons.OK);
                        else
                        {
                            reader.Read();
                            txtExpertise.Text = reader.GetString(0);
                        }
                    }
                }
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
                sql += parms[i].name + $" = :{2*i},\n";
            }

            sql = sql.Substring(0, sql.Length - 2);


            if (conds.Length != 0)
            {
                sql += "WHERE ";
                for (int i = 0; i < conds.Length; ++i)
                {
                    sql += conds[i].name + $" = :{2*i+1} AND\n";
                }

                sql = sql.Substring(0, sql.Length - 5);
            }

            OracleCommand cmd = new OracleCommand(sql, conn);

            for (int i = 0; i < parms.Length; ++i)
            {
                try
                {
                    addSqlParm(($":{2*i}", parms[i].typ, parms[i].size, parms[i].val), ref cmd);
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
                    addSqlParm(($":{2*i+1}", conds[i].typ, conds[i].size, conds[i].val), ref cmd);
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
                    sql += conds[i].name + $" = :{2*i + 1} AND\n";
                }

                sql = sql.Substring(0, sql.Length - 5);
            }

            OracleCommand cmd = new OracleCommand(sql, conn);

            for (int i = 0; i < conds.Length; ++i)
            {
                try
                {
                    addSqlParm(($":{2*i + 1}", conds[i].typ, conds[i].size, conds[i].val), ref cmd);
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
                        cmd.Parameters.Add(parm.name, parm.typ, parm.size?? 0).Value = parm.val;
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
    }
}
