using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet__Partie_1
{
    class Banque
    {
        Dictionary<uint, CompteBancaire> comptes = EntréeSortie.FichierComptes();
    }
}
