using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <returns></returns>
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
        /// <summary>
        ///     
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="identifiant"></param>
        /// <param name="email"></param>
        /// <param name="telephone"></param>
        /// <returns></returns>
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
        /// <summary>
        /// /
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Utilisateur GetUtilisateurByIdService(int id)
        {
            return BD.Utilisateurs.FirstOrDefault(a => a.IdPersonne == id); 
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <returns></returns>
        public bool UpdateUtilisateurService(Utilisateur utilisateur)
        {
            // Implémentez la logique pour mettre à jour un utilisateur
            try
            {
                BD.Entry(utilisateur).State = EntityState.Modified;
                BD.SaveChanges();
            }
            catch (Exception ex)
            {
                helper.WriteDataError("UtilisateurService-UpdateUtilisateur", ex.ToString());
                return false;
            }
            return true;
        }
    
    
    }
}