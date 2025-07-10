using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.APIPHP
{
    public class UtilisateurApi
    {
        public int IdPersonne { get; set; }
        public string NomPrenom { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Identifiant { get; set; }
        public string MotDePasse { get; set; }
        public string Statut { get; set; }
    }
}
