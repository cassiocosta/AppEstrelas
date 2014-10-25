using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Devices;

namespace AppEstrelinha
{
    public partial class BuscaPage : PhoneApplicationPage
    {

        #region Atributos

        public Models.Disciplinas disciplina { get; set; }
        public Models.Alunos aluno{get;set;}
        int rating = 0;
        int maxHeight = 64;
        int maxWidth = 64;
        int minHeight = 46;
        int minWidth = 46;

        double initialScale = 0.5d;
        double finalScale = 1d;
        VibrateController iVibrateController = VibrateController.Default;

        #endregion

        public BuscaPage()
        {
            InitializeComponent();
            txtNomeAluno.IsEnabled = false;
            displayRatingStar();
        }

        //private void retornaEstrela()
        //{
        //    //Se nao tiver aluno cadastrado da erro aqui, pois o idAluno é null.
            
        //    if(aluno != null)
        //    {
        //    estrela = Class.EstrelasDB.getEstrelas(aluno.IdAluno, disciplina.IdDisc);

        //    if (estrela.Count() == 0)
        //    {
        //        rating = 0;
        //    }
        //    else
        //    {
        //        objEstrela = estrela.ElementAt(0);
        //        rating = objEstrela.NEstrelas;
        //    }
        //    }
            
            
        //}

        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(aluno != null)
            {
            txtNomeAluno.Text = aluno.Nome;
            txtTitulo.Text = "STARS - " + disciplina.Nome;
            
            //mostrando quantas estrelas o aluno tem na pagina de adicionar estrela pro aluno.
            txtNEstrela.Text = aluno.NEstrelas.ToString();
            
            }
            
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            novo();
            NavigationService.GoBack();
        }

        public IEnumerable<Models.Disciplinas> disciplinas { get; set; }

        #region EventClick Stars

        private void star1_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            rating = 1;
            displayRatingStar();
        }

        private void star2_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            rating = 2;
            displayRatingStar();
        }

        private void star3_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            rating = 3;
            displayRatingStar();
        }

        private void star4_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            rating = 4;
            displayRatingStar();
        }

        private void star5_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            rating = 5;
            displayRatingStar();
        }

        #endregion

        #region Function

        void displayRatingStar()
        {
            iVibrateController.Start(TimeSpan.FromMilliseconds(100));

            if (rating >= 1)
            {
                star1.Opacity = 1;
                star1.Height = maxHeight;
                star1.Width = maxWidth;
                star1.Stretch = Stretch.UniformToFill;
                star1.Margin = new Thickness(0, 0, 20, 0);
                initialScale = ((CompositeTransform)star1.RenderTransform).ScaleX;
                var transform = (CompositeTransform)star1.RenderTransform;
                transform.ScaleX = finalScale;
                transform.ScaleY = transform.ScaleX;
            }

            else
            {
                star1.Opacity = 0.4;
                star1.Height = minHeight;
                star1.Width = minWidth;
                star1.Stretch = Stretch.UniformToFill;
                star1.Margin = new Thickness(0, 0, 40, 0);
                initialScale = ((CompositeTransform)star1.RenderTransform).ScaleX;
                var transform = (CompositeTransform)star1.RenderTransform;
                transform.ScaleX = initialScale;
                transform.ScaleY = transform.ScaleX;

            }

            if (rating >= 2)
            {
                star2.Opacity = 1;
                star2.Height = maxHeight;
                star2.Width = maxWidth;
                star2.Stretch = Stretch.UniformToFill;
                star2.Margin = new Thickness(0, 0, 20, 0);
                initialScale = ((CompositeTransform)star2.RenderTransform).ScaleX;
                var transform = (CompositeTransform)star2.RenderTransform;
                transform.ScaleX = finalScale;
                transform.ScaleY = transform.ScaleX;
            }

            else
            {
                star2.Opacity = 0.4;
                star2.Height = minHeight;
                star2.Width = minWidth;
                star2.Stretch = Stretch.UniformToFill;
                star2.Margin = new Thickness(0, 0, 40, 0);
                initialScale = ((CompositeTransform)star2.RenderTransform).ScaleX;
                var transform = (CompositeTransform)star2.RenderTransform;
                transform.ScaleX = initialScale;

                transform.ScaleY = transform.ScaleX;

            }

            if (rating >= 3)
            {
                star3.Opacity = 1;
                star3.Height = maxHeight;
                star3.Width = maxWidth;
                star3.Stretch = Stretch.UniformToFill;
                star3.Margin = new Thickness(0, 0, 20, 0);

                initialScale = ((CompositeTransform)star3.RenderTransform).ScaleX;
                var transform = (CompositeTransform)star3.RenderTransform;
                transform.ScaleX = finalScale;
                transform.ScaleY = transform.ScaleX;
            }

            else
            {
                star3.Opacity = 0.4;
                star3.Height = minHeight;
                star3.Width = minWidth;
                star3.Stretch = Stretch.UniformToFill;
                star3.Margin = new Thickness(0, 0, 40, 0);

                initialScale = ((CompositeTransform)star3.RenderTransform).ScaleX;
                var transform = (CompositeTransform)star3.RenderTransform;
                transform.ScaleX = initialScale;
                transform.ScaleY = transform.ScaleX;

            }

            if (rating >= 4)
            {
                star4.Opacity = 1;
                star4.Height = maxHeight;
                star4.Width = maxWidth;
                star4.Stretch = Stretch.UniformToFill;
                star4.Margin = new Thickness(0, 0, 20, 0);

                initialScale = ((CompositeTransform)star4.RenderTransform).ScaleX;
                var transform = (CompositeTransform)star4.RenderTransform;
                transform.ScaleX = finalScale;
                transform.ScaleY = transform.ScaleX;
            }

            else
            {
                star4.Opacity = 0.4;
                star4.Height = minHeight;
                star4.Width = minWidth;
                star4.Stretch = Stretch.UniformToFill;
                star4.Margin = new Thickness(0, 0, 40, 0);
                initialScale = ((CompositeTransform)star4.RenderTransform).ScaleX;
                var transform = (CompositeTransform)star4.RenderTransform;
                transform.ScaleX = initialScale;
                transform.ScaleY = transform.ScaleX;

            }

            if (rating >= 5)
            {
                star5.Opacity = 1;
                star5.Height = maxHeight;
                star5.Width = maxWidth;
                star5.Stretch = Stretch.UniformToFill;
                star5.Margin = new Thickness(0, 0, 20, 0);

                initialScale = ((CompositeTransform)star5.RenderTransform).ScaleX;
                var transform = (CompositeTransform)star5.RenderTransform;
                transform.ScaleX = finalScale;
                transform.ScaleY = transform.ScaleX;
            }

            else
            {
                star5.Opacity = 0.4;
                star5.Height = minHeight;
                star5.Width = minWidth;
                star5.Stretch = Stretch.UniformToFill;
                star5.Margin = new Thickness(0, 0, 40, 0);

                initialScale = ((CompositeTransform)star5.RenderTransform).ScaleX;
                var transform = (CompositeTransform)star5.RenderTransform;
                transform.ScaleX = initialScale;
                transform.ScaleY = transform.ScaleX;
            }
        }

        public void AbrePagina(string destino)
        {
            this.NavigationService.Navigate(new Uri(destino, UriKind.Relative));
        }

        private void novo()
        {
            //só chamar o método update e manda o objeto aluno publico que está lá em cima.
            aluno.NEstrelas = rating;
            Models.AlunosDB.updateEstrelas(aluno);
        }

        #endregion
    }
}