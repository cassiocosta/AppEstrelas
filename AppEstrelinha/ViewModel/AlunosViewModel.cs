using AppEstrelinha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstrelinha.ViewModel
{
    public class AlunosViewModel
    {
        public AlunosViewModel()
        {

        }

        public static List<Alunos>Get(Disciplinas pDisciplina)
        {
            List<Alunos> alunos = AlunosDB.getAlunos(pDisciplina.IdDisc);
            return alunos;
        }

        public static bool Save(string pNome, int pIdDiscipllina)
        {
            Alunos alu = new Alunos();
            alu.Nome = pNome;
            alu.IdDisc = pIdDiscipllina;
            AlunosDB.save(alu);
            return true;
        }
    }
}
