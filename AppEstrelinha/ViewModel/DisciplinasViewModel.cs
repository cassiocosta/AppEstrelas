using AppEstrelinha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstrelinha.ViewModel
{
    public class DisciplinasViewModel
    {

        public static List<Disciplinas>Get()
        {
            List<Disciplinas> lista = DisciplinasDB.getDisciplinas();
            return lista;
        }

        public static  bool Save(string pDisciplina)
        {
            Disciplinas disc = new Disciplinas();
            disc.Nome = pDisciplina;
            DisciplinasDB.save(disc);

            return true;
        }

    }
}
