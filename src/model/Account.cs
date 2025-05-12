using applicationOccasAuto.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace applicationOccasAuto
{
    using tValue = Dictionary<string, object>;
    using tData = List<Dictionary<string, object>>;

    public class CAccount
    {
        public int Id { get; set; }
        public int IdConces { get; set; }
        public int Level { get; set; }

        public CAccount(int l_iId, int l_iIdConces, int l_iLevel)
        {
            this.Id         = l_iId;
            this.IdConces   = l_iIdConces;
            this.Level      = l_iLevel;
        }

        public static Tuple<string, bool> F_bIsAccountCreated(string l_sNom, string l_sPrenom)
        {
            CDBManager l_cManager = new CDBManager("localhost", "dboccasauto");
            string     l_sQuery   = $"SELECT A.`id` FROM `concessionnaire` C INNER JOIN `account` A ON A.`idConces` = C.`idConces`  WHERE C.`nom` = '{l_sNom}' AND C.`prenom` = '{l_sPrenom}';";
            tData      l_lTable   = l_cManager.F_lExecuteQuery(l_sQuery);

            if (l_lTable == null)
                return Tuple.Create<string, bool>("Erreur de connexion à la base de donnée.", false);

            if (l_lTable.Count == 1)
                return Tuple.Create<string, bool>("", true);
            return Tuple.Create<string, bool>("", false);
        }

        public static Tuple<string, bool> F_bIsConsesExist(string l_sNom, string l_sPrenom)
        {
            CDBManager l_cManager = new CDBManager("localhost", "dboccasauto");
            string     l_sQuery   = $"SELECT `idConces` FROM `concessionnaire`  WHERE `nom` = '{l_sNom}' AND `prenom` = '{l_sPrenom}';";
            tData      l_lTable   = l_cManager.F_lExecuteQuery(l_sQuery);

            if (l_lTable == null)
                return Tuple.Create<string, bool>("Erreur de connexion à la base de donnée.", false);

            if (l_lTable.Count == 1)
                return Tuple.Create<string, bool>("", true);
            return Tuple.Create<string, bool>("", false);
        }

        public static bool F_vCreateAccount(string l_sNom, string l_sPrenom, string l_sPass, int l_iLevel=10)
        {
            CDBManager l_cManger = new CDBManager("localhost", "dboccasauto");

            string l_sQuery = $"INSERT INTO `account` (`idConces`, `passwd`, `level`) VALUE ((SELECT `idConces` FROM `concessionnaire` WHERE `nom` = '{l_sNom}' AND `prenom` = '{l_sPrenom}'), '{l_sPass}', '{l_iLevel}');";
            return l_cManger.F_iExecuteNonQuery(l_sQuery) == -1 ? false : true;
        }
    }
}
