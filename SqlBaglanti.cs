using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
     class SqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-125B7F2\SQLEXPRESS;Initial Catalog=DboTicariOtomasyon;Integrated Security=True;");
            conn.Open();
            return conn;
        }
        

        }
    }

