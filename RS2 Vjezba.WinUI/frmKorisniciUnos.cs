using RS2_Vjezbe.Models;
using RS2_Vjezbe.Models.Requests;
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
    public partial class frmKorisniciUnos : Form
    {
        public Korisnici _user;
        public APIService service = new APIService("Korisnici");
        public APIService ulogeService = new APIService("Uloge");
        public frmKorisniciUnos(Korisnici user = null)
        {
            InitializeComponent();
            _user = user;
        }

        private async void frmKorisniciUnos_Load(object sender, EventArgs e)
        {
            await LoadRoles();

            if(_user != null)
            {
                txtIme.Text = _user.Ime;
                txtPrezime.Text = _user.Prezime;
                txtEmail.Text = _user.Email;
                txtUsername.Text = _user.KorisnickoIme;
                cbStatus.Checked = _user.Status.Value;
            }
        }

        public async Task LoadRoles()
        {
            clbRoles.DataSource = await ulogeService.GetData<List<Uloge>>();
            clbRoles.DisplayMember = "Naziv";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
           if(ValidateChildren())
            {
                if (_user != null)
                {
                    KorisniciUpdateRequest request = new KorisniciUpdateRequest()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        Email = txtEmail.Text,
                        Status = cbStatus.Checked,
                        PasswordConfirmation = txtPasswordConfirmation.Text,
                        Password = txtPassword.Text,
                    };

                    var updateUser = await service.Put<Korisnici>(_user.KorisnikId, request);

                }
                else
                {
                    var uloge = clbRoles.CheckedItems.Cast<Uloge>().ToList();
                    var ulogeList = uloge.Select(x => x.UlogaId).ToList();

                    KorisniciInsertRequest request = new KorisniciInsertRequest()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        Email = txtEmail.Text,
                        KorisnickoIme = txtUsername.Text,
                        PasswordConfirmation = txtPasswordConfirmation.Text,
                        Password = txtPassword.Text,
                        Status = cbStatus.Checked,
                        UlogeID = ulogeList
                    };

                    var insertUser = await service.Post<Korisnici>(request);

                }
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIme.Text))
            {
                e.Cancel = true;
                txtIme.Focus();
                errorProvider.SetError(txtIme, "Ime ne smije ostati prazno polje");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtIme, "");
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrezime.Text))
            {
                e.Cancel = true;
                txtIme.Focus();
                errorProvider.SetError(txtPrezime, "Ime ne smije ostati prazno polje");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtPrezime, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = true;
                txtIme.Focus();
                errorProvider.SetError(txtEmail, "Email ne smije ostati prazno polje");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtEmail, "");
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                e.Cancel = true;
                txtIme.Focus();
                errorProvider.SetError(txtUsername, "Email ne smije ostati prazno polje");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtIme.Focus();
                errorProvider.SetError(txtPassword, "Email ne smije ostati prazno polje");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtPassword, "");
            }
        }

        private void txtPasswordConfirmation_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPasswordConfirmation.Text))
            {
                e.Cancel = true;
                txtIme.Focus();
                errorProvider.SetError(txtPasswordConfirmation, "Email ne smije ostati prazno polje");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtPasswordConfirmation, "");
            }
        }
    }
}
