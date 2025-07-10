using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MetierGestion.Model;
using MetierGestion.Utils;

namespace MetierGestion.Service
{
    public class AppartementServicejwt
    {
        BdAppartementContext db = new BdAppartementContext();
        Helper helper = new Helper();

        /// <summary>
        /// Cette methode permet d'enregistrer un nouveau appartement
        /// </summary>
        /// <param name="appartement">un appartement</param>
        /// <returns>true si fait; sinon false;</returns>
        public bool AddAppartementService(Appartement appartement)
        {
            try
            {
                db.appartements.Add(appartement);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                helper.WriteDataError("Service1-AddAppartement", ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// Mise a jour d'un appartement
        /// </summary>
        /// <param name="appartement">Objet Appartement</param>
        /// <returns>Oui, si fait</returns>
        public bool UpdateAppartementService(Appartement appartement)
        {
            try
            {
                db.Entry(appartement).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                helper.WriteDataError("Service1-UpdateAppartement", ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// Methode pour supprimer un appartement
        /// </summary>
        /// <param name="appartement">objet appartement</param>
        /// <returns>true, si fait</returns>
        public bool DeleteAppartementService(Appartement appartement)
        {
            try
            {
                db.Entry(appartement).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                helper.WriteDataError("Service1-DeleteAppartement", ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// cette methode permet de recuperer la liste des appartements
        /// </summary>
        /// <param name="adresse">adresse de recherche</param>
        /// <param name="capacite">capacite de recherche</param>
        /// <param name="disponible">disponibilite de recherche</param>
        /// <returns>liste des appartements respectant les criteres</returns>
        public List<Appartement> GetListeAppartementService(string adresse, float? capacite, bool? disponible)
        {
            var query = db.appartements
                .Include(a => a.Proprietaire)
                .Include(a => a.TypeAppartement)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(adresse))
            {
                query = query.Where(a =>
                    a.AdresseAppartement != null &&
                    a.AdresseAppartement.ToLower().Contains(adresse.ToLower()));
            }

            if (capacite.HasValue)
            {
                query = query.Where(a => a.Capacite == capacite.Value);
            }

            if (disponible.HasValue)
            {
                query = query.Where(a => a.Disponible == disponible.Value);
            }
            return query.ToList();
        }


        /// <summary>
        /// renvoie un appartement
        /// </summary>
        /// <param name="id">identifiant appartement</param>
        /// <returns>objet appartement</returns>
        public Appartement GetAppartementByIdService(int? id)
        {
            return db.appartements.Find(id);
        }
    }
}