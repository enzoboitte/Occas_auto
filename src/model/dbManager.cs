using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace applicationOccasAuto.src.model
{
    using tValue = Dictionary<string, object>;
    using tData  = List<Dictionary<string, object>>;

    public class CDBManager
    {
        private string          G_sConnection;

        public CDBManager(string l_sHost, string l_sDBName, string l_sUser="root", string l_sPass="")
        {
            string l_sFormat = string.Format("SERVER={0};DATABASE={1};USERID={2};PASSWORD={3};", l_sHost, l_sDBName, l_sUser, l_sPass);
            this.G_sConnection = l_sFormat;
        }

        public MySqlConnection F_vGetConnection()
        {
            MySqlConnection l_cConnection = new MySqlConnection(this.G_sConnection);
            try
            {
                l_cConnection.Open();
            } catch (MySqlException e) 
            {
                l_cConnection = null;
            }

            return l_cConnection;
        }

        public int F_iExecuteNonQuery(string l_sQuery, params MySqlParameter[] l_lParameters)
        {
            MySqlConnection l_cConnection = this.F_vGetConnection();
            if (l_cConnection == null)
                return -1;

            MySqlCommand l_cCommand = new MySqlCommand(l_sQuery, l_cConnection);
            if (l_lParameters != null)
                l_cCommand.Parameters.AddRange(l_lParameters);

            return l_cCommand.ExecuteNonQuery();
        }

        public object F_oExecuteScalar(string l_sQuery, params MySqlParameter[] l_lParameters)
        {
            MySqlConnection l_cConnection = this.F_vGetConnection();
            if (l_cConnection == null)
                return null;

            MySqlCommand    l_cCommand = new MySqlCommand(l_sQuery, l_cConnection);
            
            if (l_lParameters != null)
                l_cCommand.Parameters.AddRange(l_lParameters);

            return l_cCommand.ExecuteScalar();
        }

        public tData F_lExecuteQuery(string l_sQuery, params MySqlParameter[] l_lParameters)
        {
            MySqlConnection l_cConnection = this.F_vGetConnection();
            if(l_cConnection == null)
                return null;

            MySqlCommand l_cCommand = new MySqlCommand(l_sQuery, l_cConnection);
            if (l_lParameters != null)
                l_cCommand.Parameters.AddRange(l_lParameters);

            Console.WriteLine(l_cCommand.CommandText);

            MySqlDataReader l_cDataReader = l_cCommand.ExecuteReader();
            tData l_lResult = new tData();

            while(l_cDataReader.Read())
            {
                tValue l_mValue = new tValue();

                for (int i = 0; i < l_cDataReader.FieldCount; i++) 
                {
                    string l_sNameColumn = l_cDataReader.GetName(i);
                    object l_oValue      = l_cDataReader.GetValue(i);

                    l_mValue.Add(l_sNameColumn, l_oValue);
                }

                l_lResult.Add(l_mValue);
            }

            l_cDataReader.Close();
            l_cConnection.Close();

            return l_lResult;
        }
    }
}
