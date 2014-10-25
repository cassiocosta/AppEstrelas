using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace AppEstrelinha.Models
{
    [Table]//Tabela do Banco (Disciplinas).
    public class Disciplinas
    {
        
        private int _idDisc;

        [Column(IsPrimaryKey = true , IsDbGenerated = true)]//Chave primária.
        public int IdDisc
        {
            get { return _idDisc; }
            set { _idDisc = value; }
        }

        
        private string _nome;

        [Column(CanBeNull = false)]//Não pode recebe null.
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
    }
}
