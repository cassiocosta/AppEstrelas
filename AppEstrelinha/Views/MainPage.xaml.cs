using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using AppEstrelinha.ViewModel;
using AppEstrelinha.Models;
using AppEstrelinha.Views;

namespace AppEstrelinha
{
    public partial class MainPage : PhoneApplicationPage
    {

        #region Atributos

        Disciplinas disciplina;

        #endregion

        #region Construtores

        // Constructor
        public MainPage()
        {
            InitializeComponent();

        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            GetDisciplinas();
            lbxDisciplinas.SelectionChanged+=lbxDisciplinas_SelectionChanged;            
        }


        #endregion

        #region Metodos

        public void AbrePagina(string destino)
        {
            this.NavigationService.Navigate(new Uri(destino, UriKind.Relative));

        }

        public void GetDisciplinas()
        {
            lbxDisciplinas.ItemsSource = DisciplinasViewModel.Get();
        }

        #endregion

        #region Eventos
        private void lbxDisciplinas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            disciplina = (sender as ListBox).SelectedItem as Models.Disciplinas;

            

            AbrePagina("/Views/AlunosPage.xaml");
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            AlunosPage page = e.Content as AlunosPage;
            
            if (page != null)
            {
                page.disciplina = disciplina;

            }
            lbxDisciplinas.SelectionChanged -= lbxDisciplinas_SelectionChanged;

        }


        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Fazer uma tabela login e senha, para poder validar essa função de exclui o banco de dados.", "ATENÇÃO", MessageBoxButton.OK);
        }

        private void MenuItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            disciplina = (sender as MenuItem).DataContext as Models.Disciplinas;
            AbrePagina("/UpdatePage.xaml");
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            AbrePagina("/Views/DisciplinasPageCadastro.xaml");
        }

        #endregion

        private void Config_click(object sender, EventArgs e)
        {
            AbrePagina("/Views/ConfigPage.xaml");
        }

        private void Sobre_click(object sender, EventArgs e)
        {
            AbrePagina("/Views/InfoPage.xaml");
        }

        private void TextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBlock).Foreground = new SolidColorBrush(Colors.Yellow);
        }
                
    }
}