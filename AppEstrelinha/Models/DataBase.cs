using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace AppEstrelinha.Models
{
    class DataBase : DataContext
    {
        public static string DBConnectionString = "Data Source='isostore:estrela.sdf'";

        public DataBase()
            : base(DBConnectionString)
        { }

        public Table<Disciplinas> Disciplinas
        {
            get
            {
                return this.GetTable<Disciplinas>();
            }
        }

        public Table<Alunos> Alunos
        {
            get
            {
                return this.GetTable<Alunos>();
            }
        }

        public Table<Estrelas> Estrelas
        {
            get
            {
                return this.GetTable<Estrelas>();
            }
        }
        
    }
}
