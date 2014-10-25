using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace AppEstrelinha
{
    public partial class AddPage : PhoneApplicationPage
    {
        public AddPage()
        {
            InitializeComponent();
        }


        private void novo()
        {
            try
            {
                if (txtSubjects.Text != string.Empty)
                {
                    Models.Disciplinas disc = new Models.Disciplinas();
                    disc.Nome = txtSubjects.Text;
                    Models.DisciplinasDB.save(disc);
                }
                else
                {
                    MessageBox.Show("Preencha o campo disciplina.");
                }
            }
            catch
            {
                MessageBox.Show("Não foi possivel salvar a disciplina.", "ERRO", MessageBoxButton.OK);
            }

        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            novo();
            NavigationService.GoBack();
        }
    }
}