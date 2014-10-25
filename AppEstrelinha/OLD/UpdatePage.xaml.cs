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
    public partial class UpdatePage : PhoneApplicationPage
    {
        public Models.Alunos aluno;
        public Models.Disciplinas disciplina;

        public UpdatePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(aluno != null)
            {
                txtNome.Text = aluno.Nome;
            }

            if(disciplina != null)
            {
                txtNome.Text = disciplina.Nome;
            }
            desabilitarBotao();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            try
            {
                aluno.Nome = txtNome.Text;
                Models.AlunosDB.update(aluno);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Não foi posivel atualizar o Aluno.","ERRO",MessageBoxButton.OK);
            }
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            //disciplina
            try
            {
                disciplina.Nome = txtNome.Text;
                Models.DisciplinasDB.update(disciplina);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Não foi posivel atualizar a Disciplina.", "ERRO", MessageBoxButton.OK);
            }
        }

        void desabilitarBotao() 
        {
            if (aluno == null)
            {
                ApplicationBarIconButton iconAluno = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
                iconAluno.IsEnabled = false;
            }
            else
            {
                ApplicationBarIconButton iconDisciplina = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
                iconDisciplina.IsEnabled = false;
            }
        }

    }
}