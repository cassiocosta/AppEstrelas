using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace AppEstrelinha.Models
{
    [Table]//Tabela do Banco (Alunos).
    public class Alunos
    {
        #region Atributos
        
        private int _idAluno;
        private string _nome;
        private int _idDisc;
        private int _nEstrelas;

        #endregion

        #region Propriedades

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]//Chave primária.
        public int IdAluno
        {
            get { return _idAluno; }
            set { _idAluno = value; }
        }

        [Column(CanBeNull = false)]//Não recebe null.
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        [Column(CanBeNull = false)]//Não recebe null.
        public int IdDisc
        {
            get { return _idDisc; }
            set { _idDisc = value; }
        }

        [Column(CanBeNull = false)]
        public int NEstrelas
        {
            get { return _nEstrelas; }
            set { _nEstrelas = value; }
        }
        
        #endregion
        
    }
}
