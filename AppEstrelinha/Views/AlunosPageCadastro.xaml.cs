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
using AppEstrelinha.Models;
using System.Windows.Media;

namespace AppEstrelinha.Views
{
   

    public partial class AlunosPageCadastro : PhoneApplicationPage
    {
        public Disciplinas disciplina; 

        public AlunosPageCadastro()
        {
            InitializeComponent();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if(txtStudent.Text == string.Empty)
            {
                MessageBox.Show("O nome do aluno é obrigatório.", "Ops", MessageBoxButton.OK);
                txtStudent.Focus();
                return;
            }

            AlunosViewModel.Save(txtStudent.Text, disciplina.IdDisc);
            NavigationService.GoBack();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            txtStudent.Focus();
        }

        private void txtStudent_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Background = new SolidColorBrush(Colors.White);
        }

    }
}