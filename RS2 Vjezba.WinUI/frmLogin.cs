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
    public partial class frmLogin : Form
    {
        private readonly APIService service = new APIService("Korisnici");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            APIService.Username = txtUsername.Text;
            APIService.Password = txtPassword.Text;

            try
            {
               var result = await service.GetData<dynamic>();
               
               frmKorisnici form = new frmKorisnici();

               form.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong username or password");
            }
        }
    }
}
