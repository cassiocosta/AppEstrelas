using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AppEstrelinha.ViewModel;
using System.Windows.Media;

namespace AppEstrelinha.Views
{
    public partial class DisciplinasPageCadastro : PhoneApplicationPage
    {
        public DisciplinasPageCadastro()
        {
            InitializeComponent();

                
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
        }

        

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (txtSubjects.Text == string.Empty)
            {
                MessageBox.Show("Nome da Disciplina é obrigatório.", "Ops", MessageBoxButton.OK);
                txtSubjects.Focus();
                return;
            }
            DisciplinasViewModel.Save(txtSubjects.Text);
            NavigationService.GoBack();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            txtSubjects.Focus();
        }

        private void txtSubjects_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Background = new SolidColorBrush(Colors.White);
        }
    }
}