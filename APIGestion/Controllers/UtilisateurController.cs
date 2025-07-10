using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using APIGestion.Model;
using APIGestion.Models;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;


namespace APIGestion.Controllers
{
    public class UtilisateurController : ApiController
    {
       
        BdAppartementContext context = new BdAppartementContext();

        public bool AjouterUtilisateur(Utilisateur utilisateur)
        {
            if (utilisateur != null)
            {
                context.Utilisateurs.Add(utilisateur);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool SupprimerUtilisateur(int id)
        {
            var utilisateur = context.Utilisateurs.Find(id);
            if (utilisateur != null)
            {
                context.Utilisateurs.Remove(utilisateur);
                context.SaveChanges();
                return true;
            }
            return false;
        }


        public Utilisateur GetUtilisateurById(int id)
        {
            return context.Utilisateurs.Find(id);
        }


        public List<Utilisateur> GetAllUtilisateurs()
        {
            return context.Utilisateurs.ToList();
        }

        [HttpPut]
        public bool ModifierUtilisateur(Utilisateur utilisateur)
        {
            if (utilisateur != null)
            {
                context.Entry(utilisateur).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}