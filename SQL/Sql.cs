using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public class Sql
    {
        public string ara()
        {
            return "select * from kullanici where kullaniciAdi=@kullaniciAdi and sifre=@sifre";
        }
    }
}
