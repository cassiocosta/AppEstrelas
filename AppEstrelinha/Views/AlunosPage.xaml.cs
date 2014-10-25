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
    public partial class AlunosPage : PhoneApplicationPage
    {

        #region Atributos

        private enum etipoOperacao
        {
            cadastro,
            stars
        }
        private etipoOperacao tipoOperacao; 

        public Disciplinas disciplina;
        public Alunos aluno;

        AlunosPageCadastro pageCadastro;
        AlunosPageStars pageStars;

        #endregion

        public AlunosPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GetAlunos();
            lstAlunos.SelectionChanged += lstAlunos_SelectionChanged;
        }

        private void GetAlunos()
        {
            lstAlunos.ItemsSource = AlunosViewModel.Get(disciplina);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {

            switch (tipoOperacao)
            {
                case etipoOperacao.cadastro:
                     pageCadastro = e.Content as AlunosPageCadastro;

                    if (pageCadastro != null)                    
                        pageCadastro.disciplina = disciplina;
                    
                    break;
                case etipoOperacao.stars:
                    pageStars = e.Content as AlunosPageStars;

                    if (pageStars != null)
                        pageStars.aluno = aluno;
                    break;
                default:
                    break;
            }
            lstAlunos.SelectionChanged -= lstAlunos_SelectionChanged;
           
        }

        #region Metodos

        public void AbrePagina(string destino)
        {
            this.NavigationService.Navigate(new Uri(destino, UriKind.Relative));

        }

        #endregion

        #region Eventos

        private void AddStar_Click(object sender, EventArgs e)
        {
            if (aluno == null)
            {
                MessageBox.Show("Selecione um aluno.", "Atenção", MessageBoxButton.OK);
                return;
            }


        }
        private void AddAluno_Click(object sender, EventArgs e)
        {
            tipoOperacao = etipoOperacao.cadastro;
            AbrePagina("/Views/AlunosPageCadastro.xaml");
        }
        #endregion

        private void lstAlunos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            aluno = (sender as ListBox).SelectedItem as Models.Alunos;
            tipoOperacao = etipoOperacao.stars;
            AbrePagina("/Views/AlunosPageStars.xaml");
        }

        private void DelAluno_Click(object sender, EventArgs e)
        {

            if (lstAlunos.Items.Count == 0)
                return;

            if (aluno == null)
            {
                MessageBox.Show("Selecione um aluno.", "Ops", MessageBoxButton.OK);
                return;
            }
            
            if (MessageBox.Show("Tem certeza que deseja excluir o Aluno selecionado?", "Atenção", MessageBoxButton.OKCancel)
                           == MessageBoxResult.Cancel)
                return;            
            
            AlunosDB.delet(aluno);

            GetAlunos();
        }

        private void DelAllAluno_Click(object sender, EventArgs e)
        {

            if (lstAlunos.Items.Count == 0)
                return;
            if (MessageBox.Show("Tem certeza que deseja excluir todos os Alunos desta disciplina?", "Atenção", MessageBoxButton.OKCancel)
                           == MessageBoxResult.Cancel)
                return;

            AlunosDB.deleteAll();

            

            GetAlunos();
        }

      


    }
}