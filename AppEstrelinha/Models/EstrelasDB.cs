using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace AppEstrelinha.Models
{
    class EstrelasDB
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

        public static string save(Estrelas pEstrela)
        {
                DataBase db = getDataBase();
                db.Estrelas.InsertOnSubmit(pEstrela);
                db.SubmitChanges();
            return "Cadastrado com Sucesso!";
        }

        public static string update(Estrelas pEstrela)
        {
            DataBase db = getDataBase();
            Estrelas update = (from d in db.Estrelas
                             where d.IdAluno == pEstrela.IdAluno && d.IdDisc == pEstrela.IdDisc
                             select d).First();
            update.NEstrelas = update.NEstrelas + pEstrela.NEstrelas;
            db.SubmitChanges();

            return "Update salvo com Sucesso!";
        }

        public static List<Estrelas> getEstrelas(int pIdAluno, int pIdDisc)
        {
            DataBase db = getDataBase();
            var query = from d in db.Estrelas
                        where d.IdDisc.Equals(pIdDisc) && d.IdAluno.Equals(pIdAluno)
                        orderby d.IdEstrela
                        select d;
            List<Estrelas> estrelas = new List<Estrelas>(query.AsEnumerable());
            return estrelas;
        }

        //public static List<Estrelas> getEstrelas2(int pIdAluno, int pIdDisc)
        //{
        //    DataBase db = getDataBase();
        //    var query = from a in db.Alunos
        //                join e in db.Estrelas
        //                on a.IdAluno equals(e.IdAluno)
        //                select new { 
        //                    a.IdAluno,
        //                    a.IdDisc,
        //                    a.Nome,
        //                    e.NEstrelas
        //                };
        //    List<Estrelas> estrelas = new List<Estrelas>(query.ToList());
        //    return estrelas;
        //}

        public static Estrelas getNEstrelas(int pIdAluno , int pIdDisc) 
        {
            DataBase db = getDataBase();
            Estrelas estrelas = (from d in db.Estrelas
                        where d.IdDisc.Equals(pIdDisc) && d.IdAluno.Equals(pIdAluno)
                        select d).First();
            return estrelas;
        }

        public static void delet(Models.Alunos pAluno)
        {
            DataBase db = getDataBase();
            var query = from e in db.Estrelas where e.IdAluno == pAluno.IdAluno select e;
            db.Estrelas.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void deleteAll()
        {
            DataBase db = getDataBase();
            var query = from e in db.Estrelas select e;
            db.Estrelas.DeleteAllOnSubmit(query);
            db.SubmitChanges();
        }
    }
}
