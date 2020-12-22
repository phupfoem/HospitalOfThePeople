using System;
using System.Linq;
using System.Data;
using Oracle.DataAccess.Client;

namespace HospitalOfThePeople
{
    static class DBUtils
    {
        public class AttributeType {
            public string Name { get; }
            public OracleDbType Type { get; }
            public int? Size { get; }
            public string Value { get; }
            public ParameterDirection? Direction { get; }

            public AttributeType()
            {

            }

            public AttributeType(string name, OracleDbType type, int? size, string value)
            {
                Name = name;
                Type = type;
                Size = size;
                Value = value;
                Direction = null;
            }

            public AttributeType(string name, OracleDbType type, int? size, string value, ParameterDirection? direction)
            {
                Name = name;
                Type = type;
                Size = size;
                Value = value;
                Direction = direction;
            }
        }

        public static OracleCommand CreateInsertSql(AttributeType[] parms, string table, OracleConnection conn)
        {
            if (parms == null)
                throw new ArgumentNullException("parms");

            if (table == null)
                throw new ArgumentNullException("table");

            if (conn == null)
                throw new ArgumentNullException("conn");

            if (parms.Length == 0)
                throw new ArgumentOutOfRangeException("parms");

            if (table == "")
                throw new ArgumentOutOfRangeException("table");

            if (conn.State != ConnectionState.Open)
                throw new ArgumentOutOfRangeException("conn");

            string val = String.Join(", ", parms.Select(_ => ":" + _.Name).ToArray());

            string sql = $"INSERT INTO {table}\nVALUES({val})";

            OracleCommand cmd = new OracleCommand(sql, conn);

            foreach (var parm in parms)
            {
                AddSqlParm(new AttributeType(":" + parm.Name, parm.Type, parm.Size, parm.Value), ref cmd);
            }

            return cmd;
        }

        public static OracleCommand CreateUpdateSql(AttributeType[] parms, AttributeType[] conds, string table, OracleConnection conn)
        {
            if (parms == null)
                throw new ArgumentNullException("parms");

            if (table == null)
                throw new ArgumentNullException("table");

            if (conn == null)
                throw new ArgumentNullException("conn");

            if (parms.Length == 0)
                throw new ArgumentOutOfRangeException("parms");

            if (table == "")
                throw new ArgumentOutOfRangeException("table");

            if (conn.State != ConnectionState.Open)
                throw new ArgumentOutOfRangeException("conn");

            if (conds == null)
                conds = new AttributeType[0];

            string val = String.Join(", ", parms.Select(_ => _.Name + " = :0" + _.Name).ToArray());
            string sql = $"UPDATE {table}\nSET {val}";

            val = String.Join(" AND ", conds.Select(_ => _.Name + " = :1" + _.Name).ToArray());
            if (val != "")
                sql += $"\nWHERE {val}";

            OracleCommand cmd = new OracleCommand(sql, conn);

            foreach (var parm in parms)
            {
                AddSqlParm(new AttributeType(":0" + parm.Name, parm.Type, parm.Size, parm.Value), ref cmd);
            }

            foreach (var cond in conds)
            {
                AddSqlParm(new AttributeType(":1" + cond.Name, cond.Type, cond.Size, cond.Value), ref cmd);
            }

            return cmd;
        }

        public static OracleCommand CreateDeleteSql(AttributeType[] conds, string table, OracleConnection conn)
        {
            if (conds == null)
                throw new ArgumentOutOfRangeException("conds");

            if (table == null)
                throw new ArgumentNullException("table");

            if (conn == null)
                throw new ArgumentNullException("conn");

            if (conds.Length == 0)
                throw new ArgumentOutOfRangeException("conds");

            if (table == "")
                throw new ArgumentOutOfRangeException("table");

            if (conn.State != ConnectionState.Open)
                throw new ArgumentOutOfRangeException("conn");

            string val = String.Join(" AND ", conds.Select(_ => _.Name + " = :" + _.Name).ToArray());
            string sql = $"DELETE FROM {table}\nWHERE {val}";

            OracleCommand cmd = new OracleCommand(sql, conn);

            foreach (var cond in conds)
            {
                AddSqlParm(new AttributeType(":" + cond.Name, cond.Type, cond.Size, cond.Value), ref cmd);
            }

            return cmd;
        }

        public static OracleCommand CreateSelectSql(string[] parms, AttributeType[] conds, string table, OracleConnection conn)
        {
            if (table == null)
                throw new ArgumentNullException("table");

            if (conn == null)
                throw new ArgumentNullException("conn");

            if (parms != null && parms.Length == 0)
                throw new ArgumentOutOfRangeException("parms");

            if (table == "")
                throw new ArgumentOutOfRangeException("table");

            if (conn.State != ConnectionState.Open)
                throw new ArgumentOutOfRangeException("conn");

            if (conds == null)
                conds = new AttributeType[0];

            string selectedAttr = parms == null? "*": String.Join(", ", parms);
            string sql = $"SELECT {selectedAttr}\nFROM {table}";

            string val = String.Join(" AND ", conds.Select(_ => _.Name + " = :" + _.Name).ToArray());
            if (conds.Length != 0)
                sql += $"\nWHERE {val}";

            OracleCommand cmd = new OracleCommand(sql, conn);

            foreach (var cond in conds)
            {
                AddSqlParm(new AttributeType(":" + cond.Name, cond.Type, cond.Size, cond.Value), ref cmd);
            }

            return cmd;
        }

        public static OracleCommand CreateFunctionCallSql(string funcName, AttributeType[] parms, OracleConnection conn)
        {
            if (funcName == null)
                throw new ArgumentNullException("funcName");

            if (parms == null)
                throw new ArgumentNullException("parms");

            if (conn == null)
                throw new ArgumentNullException("conn");

            if (funcName == "")
                throw new ArgumentOutOfRangeException("funcName");

            if (parms.Length == 0)
                throw new ArgumentOutOfRangeException("parms");

            if (parms[0].Direction != ParameterDirection.ReturnValue)
                throw new ArgumentOutOfRangeException("parms");

            if (conn.State != ConnectionState.Open)
                throw new ArgumentOutOfRangeException("conn");

            OracleCommand cmd = new OracleCommand(funcName, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            foreach (var parm in parms)
            {
                AddSqlParm(new AttributeType(parm.Name, parm.Type, parm.Size, parm.Value, parm.Direction), ref cmd);
            }

            return cmd;
        }

        static void AddSqlParm(AttributeType parm, ref OracleCommand cmd)
        {
            if (parm == null)
                throw new ArgumentNullException("parm");

            if (cmd == null)
                throw new ArgumentNullException("cmd");

            if (!parm.Name.StartsWith(":"))
                throw new ArgumentOutOfRangeException("parm");

            switch (parm.Type)
            {
                case OracleDbType.Char:
                    if (parm.Size == null)
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = parm.Value;
                    else
                        cmd.Parameters.Add(parm.Name, parm.Type, parm.Size ?? default).Value = parm.Value;
                    break;
                case OracleDbType.Varchar2:
                    if (parm.Size == null)
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = parm.Value;
                    else
                        cmd.Parameters.Add(parm.Name, parm.Type, parm.Size ?? default).Value = parm.Value;
                    break;
                case OracleDbType.Int16:
                    if (parm.Value == "")
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = Convert.ToInt16(parm.Value);
                    break;
                case OracleDbType.Int32:
                    if (parm.Value == "")
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = Convert.ToInt32(parm.Value);
                    break;
                case OracleDbType.Int64:
                    if (parm.Value == "")
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = Convert.ToInt64(parm.Value);
                    break;
                case OracleDbType.IntervalYM:
                    if (parm.Value == "")
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = Convert.ToInt64(parm.Value) * 12;
                    break;
                case OracleDbType.Date:
                    if (parm.Value == "")
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = Convert.ToDateTime(parm.Value);
                    break;
                case OracleDbType.Decimal:
                    if (parm.Value == "")
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(parm.Name, parm.Type).Value = Convert.ToDecimal(parm.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("parm");
            }

            if (parm.Direction != null)
                cmd.Parameters[parm.Name].Direction = parm.Direction?? default;
        }
    }
}
