using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetierGestion.Model;
using MetierGestion.Utils;

namespace MetierGestion.Service
{
    public class ProprietaireServicejwt
    {
        BdAppartementContext BD = new BdAppartementContext();
        Helper helper = new Helper();
        // <summary>
        /// <summary>
        /// /   
        /// </summary>
        /// <param name="proprietaire"></param>
        /// <returns></returns>
        public bool AddProprietaireService(Proprietaire proprietaire)
        {
            try
            {
                BD.proprietaires.Add(proprietaire);
                BD.SaveChanges();
            }
            catch (Exception ex)
            {
                helper.WriteDataError("AddProprietaire_Service", ex.ToString());
                return false;
            }
            return true;
        }
        // <summary>
        /// <summary>
        ///     
        /// </summary>
        /// <param name="proprietaire"></param>
        /// <returns></returns>
        public bool DeleteProprietaireService(Proprietaire proprietaire)
        {
            try
            {
                BD.Entry(proprietaire).State = System.Data.Entity.EntityState.Deleted;
                BD.SaveChanges();
            }
            catch (Exception ex)
            {
                helper.WriteDataError("ProprietaireService-DeleteProprietaire", ex.ToString());
                return false;
            }
            return true;
        }
        // <summary>
        /// <summary>
        ///     
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="telephone"></param>
        /// <param name="email"></param>
        /// <param name="ninea"></param>
        /// <param name="rccm"></param>
        /// <returns></returns>
        public List<Proprietaire> GetListProprietaireService(string nom, string telephone, string email, string ninea,string rccm)
        {
            var liste = BD.proprietaires.ToList();
            if (!string.IsNullOrEmpty(nom))
            {
                liste = liste.Where(a => a.NomPrenom.ToLower().Contains(nom.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(telephone))
            {
                liste = liste.Where(a => a.Telephone.ToLower().Contains(telephone.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(telephone))
            {
                liste = liste.Where(a => a.IdPersonne.Equals(telephone)).ToList();
            }
            if (!string.IsNullOrEmpty(email))
            {
                liste = liste.Where(a => a.Email.ToLower().Contains(email.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(ninea))
            {
                liste = liste.Where(a => a.Ninea.ToLower().Contains(ninea.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(rccm))
            {
                liste = liste.Where(a => a.Rccm.ToLower().Contains(rccm.ToLower())).ToList();
            }
            
            return liste;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Proprietaire GetProprietaireByIdService(int id)
        {
            return BD.proprietaires.FirstOrDefault(a => a.IdPersonne == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="proprietaire"></param>
        /// <returns></returns>
        public bool UpdateProprietaireService(Proprietaire proprietaire)
        {
            try
            {
                BD.Entry(proprietaire).State = System.Data.Entity.EntityState.Modified;
                BD.SaveChanges();
            }
            catch (Exception ex)
            {
                helper.WriteDataError("UpdateProprietaire_Service", ex.ToString());
                return false;
            }
            return true;
        }











        }
}