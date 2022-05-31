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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        public Models.Kullanici kullanici;


        public void skor()
        {
            lblSkor.Text = (int.Parse(lblInekSayisi.Text) * 5 + int.Parse(lblSutLitresi.Text) * 2).ToString();
        }

        private async void btnInekAl_Click(object sender, EventArgs e)
        {
            btnInekAl.Enabled = false;

            for (int i = 4; i >= 0; i--)
            {
                lblInekSuresi.Text = i.ToString();

                await Task.Run(() => System.Threading.Thread.Sleep(1000));
                if (i == 0)
                {
                    lblInekSayisi.Text = (int.Parse(lblInekSayisi.Text) + 1).ToString();
                    skor();
                    btnInekAl.Enabled = true;
                }
            }

        }

        private async void btnSutAl_Click(object sender, EventArgs e)
        {
            btnSutAl.Enabled = false;

            for (int i = 4; i >= 0; i--)
            {
                lblSutSuresi.Text = i.ToString();

                await Task.Run(() => System.Threading.Thread.Sleep(1000));
                if (i == 0)
                {
                    lblSutLitresi.Text = (int.Parse(lblSutLitresi.Text) + (int.Parse(lblInekSayisi.Text) * 5)).ToString();
                    skor();
                    btnSutAl.Enabled = true;
                }
            }
        }
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            lblKullaniciAdi.Text = kullanici.kullaniciAdi;
            lblKullaniciID.Text = kullanici.id.ToString();
        }

       
    }
}
