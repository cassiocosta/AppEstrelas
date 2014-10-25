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
    public partial class DeletaPage : PhoneApplicationPage
    {
        public DeletaPage()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (disciplinas.IsChecked == true)
            {
                if (MessageBox.Show("Tem certeza que deseja limpar todos os dados do Professor Stars?", "Atenção", MessageBoxButton.OKCancel)
                            == MessageBoxResult.Cancel)
                    return;

                Models.AlunosDB.deleteAll();
                Models.DisciplinasDB.deleteAll();
                Models.EstrelasDB.deleteAll();

                NavigationService.GoBack();
            }
        }

        
    }
}