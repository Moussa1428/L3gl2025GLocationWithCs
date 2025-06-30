using System;
using MetierUtilisateur.Model;
using System.Data.Entity;
using MetierUtilisateur.Utils;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;

namespace MetierUtilisateur
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        BdAppartementContext db = new BdAppartementContext();
        Helper helper = new Helper();
        public bool AddUtilisateur(Utilisateur utilisateur)
        {
            try
            {
                db.Utilisateurs.Add(utilisateur);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                helper.WriteDataError("Service1-AddUtilisateur", ex.ToString());
                return false;
            }
            return true;
        }

        public List<Utilisateur> GetListUtilisateurs(string NomPrenompersonne, string Identifiantpersonne, string Emailpersonner, string Telephonepersonne)
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();
            try
            {
                //utilisateurs = db.Utilisateurs.Include("Personne").ToList();
                if (!string.IsNullOrEmpty(NomPrenompersonne))
                {
                    utilisateurs = utilisateurs.Where(u => u.NomPrenom.Contains(NomPrenompersonne)).ToList();
                }
                if (!string.IsNullOrEmpty(Identifiantpersonne))
                {
                    utilisateurs = utilisateurs.Where(u => u.Identifiant.Contains(Identifiantpersonne)).ToList();
                }
                if (!string.IsNullOrEmpty(Emailpersonner))
                {
                    utilisateurs = utilisateurs.Where(u => u.Email.Contains(Emailpersonner)).ToList();
                }
                if (!string.IsNullOrEmpty(Telephonepersonne))
                {
                    utilisateurs = utilisateurs.Where(u => u.Telephone.Contains(Telephonepersonne)).ToList();
                }
            }
            catch (Exception ex)
            {
                helper.WriteDataError("Service1-GetListUtilisateurs", ex.ToString());
            }
            return utilisateurs;
        }

        public bool UpdateUtilisateur(Utilisateur utilisateur)
        {
            try
            {
                db.Entry(utilisateur).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                helper.WriteDataError("Service1-UpdateUtilisateur", ex.ToString());
                return false;
            }
            return true;
        }

        public bool DeleteUtilisateur(Utilisateur utilisateur)
        {
            try
            {
                db.Entry(utilisateur).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                helper.WriteDataError("Service1-DeleteUtilisateur", ex.ToString());
                return false;
            }
            return true;
        }

        public Utilisateur GetUtilisateurById(int id)
        {
            Utilisateur utilisateur = new Utilisateur();
            try
            {
                utilisateur = db.Utilisateurs.Include("Personne").FirstOrDefault(u => u.IdPersonne == id);
            }
            catch (Exception ex)
            {
                helper.WriteDataError("Service1-GetUtilisateurById", ex.ToString());
            }
            return utilisateur;
        }

        public Utilisateur GetUtilisateursByEmail(string email)
        {
            Utilisateur utilisateur = new Utilisateur();
            try
            {
                utilisateur = db.Utilisateurs.Include("Personne").FirstOrDefault(u => u.Email == email);
            }
            catch (Exception ex)
            {
                helper.WriteDataError("Service1-GetUtilisateursByEmail", ex.ToString());
            }
            return utilisateur;
        }
        public Utilisateur GetUtilisateursBytel(string tel)
        {
            Utilisateur utilisateur = new Utilisateur();
            try
            {
                utilisateur = db.Utilisateurs.Include("Personne").FirstOrDefault(u => u.Telephone == tel);
            }
            catch (Exception ex)
            {
                helper.WriteDataError("Service1-GetUtilisateursBytel", ex.ToString());
            }
            return utilisateur;
        }
        public Utilisateur GetUtilisateursByIdentifiant(string identifiant)
        {
            Utilisateur utilisateur = new Utilisateur();
            try
            {
                utilisateur = db.Utilisateurs.Include("Personne").FirstOrDefault(u => u.Identifiant == identifiant);
            }
            catch (Exception ex)
            {
                helper.WriteDataError("Service1-GetUtilisateursByIdentifiant", ex.ToString());
            }
            return utilisateur;
        }


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
