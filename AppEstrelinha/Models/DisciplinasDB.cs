using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace AppEstrelinha.Models
{
    class DisciplinasDB
    {
        public static DataBase getDataBase()
        {
            DataBase db = new DataBase();
            if(db.DatabaseExists() == false)
            {
                db.CreateDatabase();
            }
            return db;
        }

        public static string save(Disciplinas pDisc) 
        {
            if (pDisc.Nome != "")
            {
                DataBase db = getDataBase();
                db.Disciplinas.InsertOnSubmit(pDisc);
                db.SubmitChanges();
            }
            else
            {
                return "Preencha o campo Nome.";
            }
            return pDisc.Nome+" cadastrado com Sucesso!";
        }

        public static string update(Disciplinas pDisc) 
        {
            DataBase db = getDataBase();
            Disciplinas disciplina = (from d in db.Disciplinas
                                      where d.IdDisc == pDisc.IdDisc
                                      select d).First();
            disciplina.Nome = pDisc.Nome;
            db.SubmitChanges();

            return "Update feito com Sucesso!";
        }

        public static List<Disciplinas> getDisciplinas()
        {
            DataBase db = getDataBase();
            var query = from d in db.Disciplinas orderby d.Nome select d;
            List<Disciplinas> disciplinas = new List<Disciplinas>(query.AsEnumerable());
            return disciplinas;
        }

        public static Disciplinas getDisciplina()
        {
            DataBase db = getDataBase();
            var query = (from d in db.Disciplinas select d).First();
            return query;
        }


        public static void deleteAll()
        {
            DataBase db = getDataBase();
            var query = from d in db.Disciplinas select d;
            db.Disciplinas.DeleteAllOnSubmit(query);
            db.SubmitChanges();
        }
    }
}
