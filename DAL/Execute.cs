using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Execute
    {
            //connection string global sabit olarak tanimlandi (user/windows auth.)
            public const string _cs = @"Server=DESKTOP-NA24S3Q;Database=CIFTLIK;User Id=sa;Password=12345678;";
            //public const string _cs = @"Server=Z36-HOCA\SQLEXPRESS;Database=OKUL;Trusted_Connection=True;";

            /// <summary>
            /// CRUD işlemlerinden Read işlemi için kodlanmıştır.
            /// </summary>
            /// <param name="_sql">Çalıştırılacak olan SELECT cümlesidir.</param>
            /// <param name="_exceptionMessage">Hatanın okunacağı değişkendir.</param>
            /// <returns></returns>
            public DataTable executeDT(string _sql, SqlParameter[] _params, ref string _exceptionMessage)
            {
                //return edilecek degisken olusturuluyor
                DataTable dtResult = new DataTable();

                //hata mesaji degiskeni bosaltiliyor
                _exceptionMessage = "";

                try
                {
                    //server baglanti satiri
                    SqlConnection _con = new SqlConnection(_cs);

                    //server da isletiecek sql metni
                    SqlCommand _cmd = new SqlCommand(_sql, _con);

                    //sql parameters dolu ise command veriliyor
                    if (_params != null) _cmd.Parameters.AddRange(_params);



                    //veriyi aktarma (adapter)
                    SqlDataAdapter _adapter = new SqlDataAdapter(_cmd);

                    //adapter kullanilarak veri DT' a dolduruluyor
                    _adapter.Fill(dtResult);
                }
                catch (Exception ex)
                {
                    dtResult = null;
                    _exceptionMessage = "Bir hata oluştu. Lütfen sistem yöneticinize haber veriniz! \n [ " + ex.Message + " ]";
                }

                //return data
                return dtResult;
            }

            /// <summary>
            /// CRUD işlemlerinden Create, Update, Delete işlemi için kodlanmıştır.
            /// </summary>
            /// <param name="_sql">Çalıştırılacak olan sorgu cümlesidir.</param>
            /// <param name="_exceptionMessage">Hatanın okunacağı değişkendir.</param>
            /// <returns></returns>
            public bool execute(string _sql, SqlParameter[] _params, ref string _exceptionMessage)
            {
                //return edilecek degisken tanimlaniyor
                bool result = true;

                //hata mesaji bosaltiliyor
                _exceptionMessage = "";

                //server baglanti satiri
                SqlConnection _con = new SqlConnection(_cs);

                try
                {
                    //connection aciliyor
                    _con.Open();

                    //server da isletiecek sql metni
                    SqlCommand _cmd = new SqlCommand(_sql, _con);

                    //sql parameters null degilse command e ekleniyor
                    if (_params != null) _cmd.Parameters.AddRange(_params);



                    //sql metnini calistirma
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    result = false;
                    _exceptionMessage = "Bir hata oluştu. Lütfen sistem yöneticinize haber veriniz! \n [ " + ex.Message + " ]";
                }
                finally
                {
                    //connection kapatiliyor
                    _con.Close();
                }

                //return
                return result;
            }
    }
}
