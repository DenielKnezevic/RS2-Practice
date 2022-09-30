using RS2_Vjezbe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS2_Vjezba.WinUI
{
    public partial class frmKorisnici : Form
    {
        public frmKorisnici()
        {
            InitializeComponent();
            dgvKorisnici.AutoGenerateColumns = false;
        }

        public APIService service = new APIService("Korisnici");

        private void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var user = dgvKorisnici.SelectedRows[0].DataBoundItem as Korisnici;

            frmKorisniciUnos frmKorisniciUnos = new frmKorisniciUnos(user);
            frmKorisniciUnos.ShowDialog();
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            KorisniciSearchObject search = new KorisniciSearchObject();

            search.Ime = txtIme.Text;
            search.Username = txtUsername.Text;
            search.IncludeRoles = true;

            var list = await service.GetData<List<Korisnici>>(search);

            dgvKorisnici.DataSource = list;
        }

        private void frmKorisnici_Load(object sender, EventArgs e)
        {

        }
    }
}
