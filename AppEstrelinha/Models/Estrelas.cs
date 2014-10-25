using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace AppEstrelinha.Models
{
    [Table]//Tabela do Banco (Estrelas).
    public class Estrelas
    {
        #region Atributos

        private int _idEstrela;
        private int _idDisc;
        private int _idAluno;
        private int _nEstrelas;

        public DateTime data { get; set; }

        public string dataPtbr
        {
            get
            {
                return data.ToString("dd/MM/yyyy");
            }
        }

        #endregion

        #region Propriedades
        /// <summary>
        /// Coloca como chave primaria e como auto encremento
        /// </summary>
        [Column(IsPrimaryKey = true , IsDbGenerated = true)]
        public int IdEstrela
        {
            get { return _idEstrela; }
            set { _idEstrela = value; }
        }

        /// <summary>
        /// Nao pode receber null e
        /// </summary>
        [Column(CanBeNull = false)]//Não recebe null.
        public int IdDisc
        {
            get { return _idDisc; }
            set { _idDisc = value; }
        }

        /// <summary>
        /// Nao pode receber null e 
        /// </summary>
        [Column(CanBeNull = false)]//Não recebe null.
        public int IdAluno
        {
            get { return _idAluno; }
            set { _idAluno = value; }
        }

        [Column(CanBeNull = false)]//Não recebe null.
        public int NEstrelas
        {
            get { return _nEstrelas; }
            set { _nEstrelas = value; }
        }

        #endregion
    }
}
