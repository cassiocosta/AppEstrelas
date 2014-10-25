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
    public partial class AlunoPage : PhoneApplicationPage
    {
        public Models.Disciplinas disciplina{get;set;}
        public Models.Alunos alunos;
        public bool aux2 = true;
        public bool aux3 = true;
        int aux;

        public AlunoPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            listarAlunos(disciplina);

            txtTitulo.Text = "STARS - " + disciplina.Nome;
        }

        public void novo() 
        {
            try
            {
                if (ptxtAluno.Text != string.Empty)
                {
                    Models.Alunos alu = new Models.Alunos();
                    alu.Nome = ptxtAluno.Text;
                    alu.IdDisc = disciplina.IdDisc;
                    alu.NEstrelas = 0;
                    Models.AlunosDB.save(alu);
                }
                else
                {
                    MessageBox.Show("Preencha o campo Nome do Aluno.");
                }
            }
            catch
            {
                MessageBox.Show("Não foi possivel salvar o aluno.","ERRO",MessageBoxButton.OK);
            }
        }


        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            
            
        }

        private void lbxAlunos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (aux2 == true)
            {
                aux = 1;//para quando eu entrar em outra pagina o aux2 nao recebe false;
                alunos = (sender as ListBox).SelectedItem as Models.Alunos;
                AbrePagina("/BuscaPage.xaml");
                
            }
            else 
            {
                aux2 = true;
            }
            
        }

        public void AbrePagina(string destino)
        {
            this.NavigationService.Navigate(new Uri(destino, UriKind.Relative));
        }

        private void listarAlunos(Models.Disciplinas disc)
        {
            List<Models.Alunos> alunos = Models.AlunosDB.getAlunos(disciplina.IdDisc);
            if (alunos.Count != 0)
            {
                lbxAlunos.ItemsSource = alunos;
            }
            else
            {
                lbxAlunos.ItemsSource = null;
            }
        }

        private void ptxtAluno_ActionIconTapped(object sender, EventArgs e)
        {
            try
            {
                novo();
                listarAlunos(disciplina);
                ptxtAluno.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("Não foi possivel adicionar aluno","ERRO", MessageBoxButton.OK);
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            UpdatePage update = e.Content as UpdatePage;
            BuscaPage page = e.Content as BuscaPage;
            if (page != null)
            {
                page.aluno = alunos;
                page.disciplina = disciplina;
            }

            if(update != null)
            {
                update.aluno = alunos;
            }

            if(aux != 0)
            {
                aux2 = false;
            }
            
        }

        private void MenuItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            aux = 0;
            alunos = (sender as MenuItem).DataContext as Models.Alunos;
            AbrePagina("/UpdatePage.xaml");

        }

        private void MenuItem_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            aux = 0;
            alunos = (sender as MenuItem).DataContext as Models.Alunos;
            if (MessageBox.Show("Tem certeza em excluir esse Aluno ? ", "Confirmação", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {

                if (Models.EstrelasDB.getEstrelas(alunos.IdAluno, disciplina.IdDisc).Count > 0)
                {
                    Models.EstrelasDB.delet(alunos);
                }

                Models.AlunosDB.delet(alunos);

                listarAlunos(disciplina);

            }
            
        }
    }
}