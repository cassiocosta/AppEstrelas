using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppEstrelinha.Models
{
    class AlunosDB
    {
        public static DataBase getDataBase()
        {
            DataBase db = new DataBase();
            if (db.DatabaseExists() == false)
            {
                db.CreateDatabase();
            }
            return db;
        }

        public static string save(Alunos pAlu)
        {
            if (pAlu.Nome != "")
            {
                DataBase db = getDataBase();
                db.Alunos.InsertOnSubmit(pAlu);
                db.SubmitChanges();
            }
            else
            {
                return "Preencha o campo Nome.";
            }
            return pAlu.Nome + " cadastrado com Sucesso";
        }

        

        public static string update(Alunos pAlu) 
        {
            DataBase db = getDataBase();
            Alunos update = (from d in db.Alunos
                             where d.IdAluno == pAlu.IdAluno && d.IdDisc == pAlu.IdDisc
                             select d).First();
            update.Nome = pAlu.Nome;
            db.SubmitChanges();

            return "Update feito com Sucesso!";
        }

        public static string updateEstrelas(Alunos pAlu)
        {
            DataBase db = getDataBase();
            Alunos update = (from d in db.Alunos
                             where d.IdAluno == pAlu.IdAluno && d.IdDisc == pAlu.IdDisc
                             select d).First();
            update.NEstrelas = pAlu.NEstrelas + update.NEstrelas;
            db.SubmitChanges();

            return "Update feito com Sucesso!";
        }

        public static List<Alunos> getAlunos()
        {
            DataBase db = getDataBase();
            var query = from d in db.Alunos orderby d.Nome select d;
            List<Alunos> alunos = new List<Alunos>(query.AsEnumerable());
            return alunos;
        }

        public static List<Alunos> getAlunos(int pDisc)
        {
            DataBase db = getDataBase();
            var query = from d in db.Alunos
                        where d.IdDisc.Equals(pDisc)
                        orderby d.Nome
                        select d;
            List<Alunos> alunos = new List<Alunos>(query.AsEnumerable());
            return alunos;
        }

        public static void delet(Models.Alunos pAluno) 
        {
            DataBase db = getDataBase();
            var query = from a in db.Alunos where a.IdAluno == pAluno.IdAluno select a;
            db.Alunos.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
            
        }

        public static void deleteAll()
        {
            DataBase db = getDataBase();
            var query = from a in db.Alunos select a;
            db.Alunos.DeleteAllOnSubmit(query);
            db.SubmitChanges();
        }

    }
}
