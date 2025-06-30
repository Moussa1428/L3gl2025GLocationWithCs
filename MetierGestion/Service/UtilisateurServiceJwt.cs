using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetierGestion.Model;
using MetierGestion.Utils;

namespace MetierGestion.Service
{
    public class UtilisateurServiceJwt
    {
        BdAppartementContext BD = new BdAppartementContext();
        Helper helper = new Helper();
        public bool AddUser(Utilisateur utilisateur)
        {
            try
            {
                BD.Utilisateurs.Add(utilisateur);
                BD.SaveChanges();
            }catch (Exception ex)
            {
                helper.WriteDataError("AddUtilisateur_Service",ex.ToString());
            }
            return true;
        }
        public bool DeleteUtilisateurService(Utilisateur utilisateur)
        {
            try
            {
                BD.Entry(utilisateur).State = System.Data.Entity.EntityState.Deleted;
                BD.SaveChanges();
            }
            catch (Exception ex)
            {
                helper.WriteDataError("UtilisateurService-DeleteUtilisateur", ex.ToString());
                return false;
            }
            return true;
        }
        public List<Utilisateur> GetListUtilisateurService(string nom,string identifiant ,string email,string telephone)
        {
            var liste = BD.Utilisateurs.ToList();

            if (!string.IsNullOrEmpty(nom)) { 
               liste = liste.Where(a =>a.NomPrenom.ToLower().Contains(nom.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(identifiant))
            {
                liste = liste.Where(a=> a.IdPersonne.Equals(identifiant)).ToList();
            }
            if (!string.IsNullOrEmpty(email)) { 
                liste = liste.Where(a => a.Email.ToLower().Contains(email.ToLower())).ToList().ToList();
            }
            if (!string.IsNullOrEmpty(telephone))
            {
                liste =liste.Where(a => a.Telephone.ToLower().Contains(telephone.ToLower())).ToList();
            }
            return liste;
        }



    }
}