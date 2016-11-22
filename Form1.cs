using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaSiparis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbPizzalar.Items.Add("Meksika Pizzası 15TL");
            cmbPizzalar.Items.Add("İtalyan Pizzası 13TL");
            cmbPizzalar.Items.Add("Vejeteryan Pizzası 12TL");
            cmbPizzalar.Items.Add("Mangal Pizzası 22TL");
            cmbPizzalar.Items.Add("Etibol Pizza 22TL");
            object[] secimler = { "Hemen", "İleri tarih" };
            cmbSecim.Items.AddRange(secimler);
        }
        decimal tutar = 0;
        private void cmbPizzalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPizzalar.SelectedIndex == -1)
            {
                gbIcecekler.Visible = false;
                gbEkstraMalzeme.Visible = false;
                return;
            }
            gbIcecekler.Visible = true;
            gbEkstraMalzeme.Visible = true;
        }

        private void cmbSecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSecim.SelectedIndex == -1)
            {
                btnHemenSiparis.Visible = false;
                gbIleriTarih.Visible = false;
            }
            else if (cmbSecim.SelectedIndex == 0)
            {
                btnHemenSiparis.Visible = true;
                gbIleriTarih.Visible = false;
            }
            else if (cmbSecim.SelectedIndex == 1)
            {
                btnHemenSiparis.Visible = false;
                gbIleriTarih.Visible = true;
                dtpTarih.MinDate = DateTime.Now.AddMinutes(30);
                dtpTarih.MaxDate = DateTime.Now.AddDays(7);
            }
        }

        void Hesapla()
        {
            switch (cmbPizzalar.SelectedIndex)
            {
                case 0:
                    tutar = 15;
                    break;
                case 1:
                    tutar = 13;
                    break;
                case 2:
                    tutar = 12;
                    break;
                case 3:
                case 4:
                    tutar = 22;
                    break;
                default:
                    tutar = 0;
                    break;
            }
            //if (cbAyran.Checked)
            //    tutar += 2.5m;
            //if (cbKola.Checked)
            //    tutar += 3m;

            tutar += cbSucuk.Checked ? 4 : 0;
            tutar += cbSalam.Checked ? 3 : 0;
            tutar += cbPeynir.Checked ? 2 : 0;
            tutar += cbKola.Checked ? 3 : 0;
            tutar += cbAyran.Checked ? 2.5m : 0;
            tutar += cbSoda.Checked ? 1.5m : 0;
        }

        private void btnHemenSiparis_Click(object sender, EventArgs e)
        {
            Hesapla();
            DialogResult cevap = MessageBox.Show($"Sipariş Tutarı: {tutar:c2}\nTahmini geliş zamanı: {DateTime.Now.AddMinutes(30):dd/MMMM HH:mm}", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
                MessageBox.Show("Sipariş hazırlanıyor...");
            else
                MessageBox.Show("Siparişiniz iptal edildi!");
        }

        private void btnIleriSiparis_Click(object sender, EventArgs e)
        {
            Hesapla();
            DialogResult cevap = MessageBox.Show($"Sipariş Tutarı: {tutar:c2}\nTahmini geliş zamanı: {dtpTarih.Value:dd/MMMM HH:mm}", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
                MessageBox.Show("Sipariş hazırlanıyor...");
            else
                MessageBox.Show("Siparişiniz iptal edildi!");
        }
    }
}
