using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using RS2_Vjezbe.Models;

namespace RS2_Vjezba.WinUI
{
    public partial class frmProizvodi : Form
    {
        public APIService service = new APIService("Proizvodi");
        public frmProizvodi()
        {
            InitializeComponent();
        }

        private async void btnGetData_Click(object sender, EventArgs e)
        {
            var list = await service.GetData<List<Proizvodi>>();

            dataGridView1.DataSource = list;
        }

        private async void btnGetById_Click(object sender, EventArgs e)
        {
            var product = await service.GetById<Proizvodi>(14);

            dataGridView1.DataSource = product;
        }

        private async void btnPost_Click(object sender, EventArgs e)
        {
            var product = await service.Post<Proizvodi>(new Proizvodi());

            dataGridView1.DataSource=product;
        }

        private async void btnPut_Click(object sender, EventArgs e)
        {
            var entity = await service.GetById<Proizvodi>(14);

            entity.Naziv = "WinUI updated";

            var product = await service.Put<Proizvodi>(entity.ProizvodId, entity);

            dataGridView1.DataSource = product;
        }
    }
}
