using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Common;
using Oracle.DataAccess.Client;


namespace HospitalOfThePeople
{
    public class DBFormHelper
    {
        public class AttributeType
        {
            public string Name { get; }
            public OracleDbType Type { get; }
            public int? Size { get; }
            public TextBox TextHolder { get; }

            public AttributeType(string name, OracleDbType type, int? size, TextBox textHolder)
            {
                Name = name;
                Type = type;
                Size = size;
                TextHolder = textHolder;
            }
        }

        readonly AttributeType[] _attrs;
        readonly AttributeType[] _keyAttrs;
        readonly string _tableName;

        public DBFormHelper(AttributeType[] attrs, AttributeType[] keyAttrs, string tableName)
        {
            if (attrs == null)
                throw new ArgumentNullException("attrs");

            if (keyAttrs == null)
                throw new ArgumentNullException("keyAttrs");

            if (tableName == null)
                throw new ArgumentNullException("tableName");

            if (attrs.Length == 0)
                throw new ArgumentOutOfRangeException("attrs");

            if (keyAttrs.Length == 0)
                throw new ArgumentOutOfRangeException("keyAttrs");

            if (tableName == "")
                throw new ArgumentOutOfRangeException("tableName");

            if (!keyAttrs.Except(attrs).Any())
                throw new ArgumentException("keyAttrs");

            _attrs = attrs;
            _keyAttrs = keyAttrs;
            _tableName = tableName;
        }

        private DBUtils.AttributeType[] ApplyValue(AttributeType[] attrs)
        {
            return attrs.Select(_ => new DBUtils.AttributeType(_.Name, _.Type, _.Size, _.TextHolder.Text.Trim())).ToArray();
        }

        public DbDataReader Find(OracleConnection conn)
        {
            return DBUtils.CreateSelectSql(null, ApplyValue(_attrs).Where(_ => _.Value != "").ToArray(), _tableName, conn).ExecuteReader();
        }

        public void Read(DbDataReader reader)
        {
            reader.Read();
            foreach (var item in _attrs.Select((attr, idx) => (idx, attr)))
            {
                int idx = item.idx;
                AttributeType attr = item.attr;

                if (reader.IsDBNull(idx))
                {
                    attr.TextHolder.Text = "";
                    continue;
                }

                switch (attr.Type)
                {
                    case OracleDbType.Char:
                    case OracleDbType.Varchar2:
                        attr.TextHolder.Text = reader.GetString(idx);
                        break;
                    case OracleDbType.Int16:
                        attr.TextHolder.Text = Convert.ToString(reader.GetInt16(idx));
                        break;
                    case OracleDbType.Int32:
                        attr.TextHolder.Text = Convert.ToString(reader.GetInt32(idx));
                        break;
                    case OracleDbType.Int64:
                        attr.TextHolder.Text = Convert.ToString(reader.GetInt64(idx));
                        break;
                    case OracleDbType.IntervalYM:
                        attr.TextHolder.Text = Convert.ToString(reader.GetInt64(idx) / 12);
                        break;
                    case OracleDbType.Date:
                        attr.TextHolder.Text = Convert.ToString(reader.GetDateTime(idx));
                        break;
                    case OracleDbType.Decimal:
                        attr.TextHolder.Text = Convert.ToString(reader.GetDecimal(idx));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Argument passed to AddSqlParm.parm.Type is not recognizable.");
                }
            }
        }

        public int Insert(OracleConnection conn)
        {
            return DBUtils.CreateInsertSql(ApplyValue(_attrs), _tableName, conn).ExecuteNonQuery();
        }

        public int Update(OracleConnection conn)
        {
            return DBUtils.CreateUpdateSql(ApplyValue(_attrs), ApplyValue(_keyAttrs), _tableName, conn).ExecuteNonQuery();
        }

        public int Delete(OracleConnection conn)
        {
            return DBUtils.CreateDeleteSql(ApplyValue(_keyAttrs), _tableName, conn).ExecuteNonQuery();
        }
    }
}
