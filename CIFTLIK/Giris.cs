using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIFTLIK
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        //Global 
        Models.Kullanici _kullanici = new Models.Kullanici();
        Anasayfa _anasayfa= new Anasayfa();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            _kullanici.kullaniciAdi = textBox1.Text;
            _kullanici.sifre = textBox2.Text;

            _kullanici.ara();

            if (_kullanici.id > 0)
            {
                _anasayfa.kullanici = _kullanici;
                _anasayfa.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Girilen Değerler Hatalı");
            }
        }
    }
}
