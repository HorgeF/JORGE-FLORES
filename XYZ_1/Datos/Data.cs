using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Datos
{
    public static  class Data
    {

        private static Dictionary<string, int> ordinales_;
        private static string prefijo_;
        private static SqlDataReader reader_;
        public static IConfiguration Configuration { get; set; }
        private static string stNombreConexion = GetConnectionString();// ConfigurationManager.ConnectionStrings["ConnectionStrings:ConnectionBD"].ToString();
        public static SqlDatabase CnGeneral = new SqlDatabase(stNombreConexion);


        private static string GetConnectionString()
        {
            return "Server=DESKTOP-3OU2IV8\\SQLEXPRESS;Database=XYZ;Integrated Security=True;MultipleActiveResultSets=True;";
        }

        public static Boolean ColumnExists(IDataReader dr, String ColumnName)
        {
            for (Int32 i = 0; i < dr.FieldCount; i++)
                if (dr.GetName(i).Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
                    return true;

            return false;
        }
        public static string reader(IDataReader Reader, string stColumna)
        {
            return reader(Reader, stColumna, DbType.String).ToString();
        }

        public static K? readerNull<K>(IDataReader Reader, string stColumna, K? inVariable) where K : struct
        {
            return (K)reader(Reader, stColumna, DbType.Int32);
        }

        public static void reader1(IDataReader Reader, string stColumna, ref string stVariable)
        {
            stVariable = reader(Reader, stColumna, DbType.String).ToString();
        }

        public static Int32 reader(IDataReader Reader, string stColumna, int? inVariable)
        {
            return Convert.ToInt32(reader(Reader, stColumna, DbType.Int32));
        }

        public static Int64 reader(IDataReader Reader, string stColumna, long? inVariable)
        {
            return Convert.ToInt64(reader(Reader, stColumna, DbType.Int64));
        }

        public static K? readerNull<K>(IDataReader Reader, string stColumna, int? daVariable) where K : struct
        {
            return (K)reader(Reader, stColumna, DbType.Int32);
        }

        public static DateTime reader(IDataReader Reader, string stColumna, DateTime? daVariable)
        {
            return Convert.ToDateTime(reader(Reader, stColumna, DbType.DateTime));
        }

        public static DateTime? readerNull(IDataReader Reader, string stColumna, DateTime? daVariable)
        {
            if (daVariable == null && string.IsNullOrEmpty(reader(Reader, stColumna)))
            {
                return null;
            }
            return Convert.ToDateTime(reader(Reader, stColumna, DbType.DateTime));
        }

        public static K? readerNull<K>(IDataReader Reader, string stColumna, DateTime? daVariable) where K : struct
        {
            return (K)reader(Reader, stColumna, DbType.DateTime);
        }

        public static DateTime reader(IDataReader Reader, string stColumna, TimeSpan daVariable)
        {
            return Convert.ToDateTime(reader(Reader, stColumna, DbType.Time));
        }

        public static Decimal reader(IDataReader Reader, string stColumna, Decimal? deVariable)
        {
            return Convert.ToDecimal(reader(Reader, stColumna, DbType.Decimal));
        }

        public static K? readerNull<K>(IDataReader Reader, string stColumna, Decimal? deVariable) where K : struct
        {
            return (K)reader(Reader, stColumna, DbType.Decimal);
        }

        public static Double reader(IDataReader Reader, string stColumna, Double? doVariable)
        {
            return Convert.ToDouble(reader(Reader, stColumna, DbType.Double));
        }

        public static K? readerNull<K>(IDataReader Reader, string stColumna, Double? doVariable) where K : struct
        {
            return (K)reader(Reader, stColumna, DbType.Double);
        }

        public static bool reader(IDataReader Reader, string stColumna, bool? boVariable)
        {
            return Convert.ToBoolean(reader(Reader, stColumna, DbType.Boolean));
        }

        public static K? readerNull<K>(IDataReader Reader, string stColumna, bool? boVariable) where K : struct
        {
            return (K)reader(Reader, stColumna, DbType.Boolean);
        }

        public static Object reader(IDataReader Reader, string stColumna, DbType dbType = DbType.String)
        {
            bool boExisteColumna = ColumnExists(Reader, stColumna);

            switch (dbType)
            {
                case DbType.String:
                    if (boExisteColumna == false) return "";
                    if (Reader[stColumna] == null || Reader[stColumna] == DBNull.Value)
                        return "";
                    else
                        return Reader[stColumna].ToString();

                case DbType.Boolean:
                    if (boExisteColumna == false) return false;
                    if (Reader[stColumna] == null || Reader[stColumna] == DBNull.Value)
                        return false;
                    else
                        return Convert.ToBoolean(Reader[stColumna]);

                case DbType.Int32:
                    if (boExisteColumna == false) return null;
                    if (Reader[stColumna] == null || Reader[stColumna] == DBNull.Value)
                        return null;
                    else
                        return Convert.ToInt32(Reader[stColumna]);

                case DbType.Decimal:
                    if (boExisteColumna == false) return null;
                    if (Reader[stColumna] == null || Reader[stColumna] == DBNull.Value)
                        return null;
                    else
                        return Convert.ToDecimal(Reader[stColumna]);

                case DbType.Double:
                    if (boExisteColumna == false) return null;
                    if (Reader[stColumna] == null || Reader[stColumna] == DBNull.Value)
                        return null;
                    else
                        return Convert.ToDouble(Reader[stColumna]);

                case DbType.DateTime:
                    if (boExisteColumna == false) return null;
                    if (Reader[stColumna] == null || Reader[stColumna] == DBNull.Value)
                        return null;
                    else
                        return Convert.ToDateTime(Reader[stColumna]);

                case DbType.Time:
                    if (boExisteColumna == false) return null;
                    if (Reader[stColumna] == null || Reader[stColumna] == DBNull.Value)
                        return null;
                    else
                        return Convert.ToDateTime(Reader[stColumna]);
            }

            return null;
        }

        public static string ToXml<T>(T obj)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T), new XmlRootAttribute("tabla"));

            string x = typeof(T).AssemblyQualifiedName.ToString();

            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create((TextWriter)stringWriter, new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "\t"
                }))
                {
                    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                    namespaces.Add(string.Empty, string.Empty);
                    xml.Serialize(xmlWriter, (object)obj, namespaces);
                    xmlWriter.Close();
                }

                return stringWriter.ToString().Replace("-05:00\"", "\"");
            }
        }

        public static T XmlToEntity<T>(string xmlText)
        {
            if (String.IsNullOrWhiteSpace(xmlText)) return default(T);
            //xmlText = xmlText.Replace("\"", "-05:00\"");

            using (StreamReader stringReader = new System.IO.StreamReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
        }

        public static T GetXml<T>(string columna)
        {
            int ordinal = GetOrdinal(columna);
            if (ordinal >= 0)
            {
                string campo = reader_[ordinal] as string;
                XmlTextReader xmlReader = new XmlTextReader(new StringReader(campo));
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(xmlReader);
            }
            else if (ordinal == -1)
            {
                return default(T);
            }
            else if (ordinal == -2)
            {
                return default(T);
            }
            else
            {
                throw new ApplicationException();
            }
        }

        private static int GetOrdinal(string columna)
        {
            int index = -1;
            columna = prefijo_ + columna;

            if (ordinales_.ContainsKey(columna))
            {
                index = ordinales_[columna];

                if (!reader_.IsDBNull(index))
                {
                    return index;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -2;
            }
        }
    }
}
