using DAL;
using SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIFTLIK.Models
{
    public class Kullanici
    {
        //Properties
        public Int32 id { get; set; }
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }
        public Int32 inekSayisi { get; set; }
        public Int32 sutLitresi { get; set; }
        public Int32 skor { get; set; }

        //Global
        Execute _execute = new Execute();
        Sql _sql = new Sql();
        List<SqlParameter> _params = new List<SqlParameter>();


        //Actions
        public void ara()
        {
            DataTable dtResult = new DataTable();
            string _exceptionMessage = "";
            _params.Add(new SqlParameter("@kullaniciAdi", kullaniciAdi));
            _params.Add(new SqlParameter("@sifre", sifre));
            dtResult = _execute.executeDT(_sql.ara(), _params.ToArray(), ref _exceptionMessage);

            if (_exceptionMessage == "" && dtResult.Rows.Count > 0)
            {
                id = int.Parse(dtResult.Rows[0]["id"].ToString());
                kullaniciAdi = dtResult.Rows[0]["kullaniciAdi"].ToString();
                sifre = dtResult.Rows[0]["sifre"].ToString();
                inekSayisi = int.Parse(dtResult.Rows[0]["inekSayisi"].ToString());
                sutLitresi = int.Parse(dtResult.Rows[0]["sutLitresi"].ToString());
                skor = int.Parse(dtResult.Rows[0]["skor"].ToString());

            }

            else
            {
                id = 0;
                kullaniciAdi = "";
                sifre = "";
                inekSayisi = 0;
                sutLitresi = 0;
                skor = 0;

            }
        }
    }
}
