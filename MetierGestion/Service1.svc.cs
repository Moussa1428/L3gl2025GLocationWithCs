using MetierGestion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MetierGestion.Utils;
using System.Data.Entity;
using MetierGestion.Service;

namespace MetierGestion
{
	// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
	// REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
	public class Service1 : IService1
	{
		AppartementServicejwt Servicejwt = new AppartementServicejwt();
		UtilisateurServiceJwt ServiceJwtUtilisateur = new UtilisateurServiceJwt();

        public bool AddAppartement(Appartement appartement)
        {
            return Servicejwt.AddAppartementService(appartement);
        }
        public bool DeleteAppartement(Appartement appartement)
        {
            return Servicejwt.DeleteAppartementService(appartement);
        }
        public Appartement GetAppartementById(int? id)
        {
           return Servicejwt.GetAppartementByIdService(id);
        }
        public List<Appartement> GetListeAppartement(string adresse, float? capacite, bool? disponible)
        {
            return Servicejwt.GetListeAppartementService(adresse, capacite, disponible);    
        }
        public bool UpdateAppartement(Appartement appartement)
        {
            return Servicejwt.UpdateAppartementService(appartement);
        }
        public bool AddUtilisateur(Utilisateur utilisateur)
        {
            return ServiceJwtUtilisateur.AddUser(utilisateur);
        }
        public bool DeleteUtilisateur(Utilisateur utilisateur)
        {
            return ServiceJwtUtilisateur.DeleteUtilisateurService(utilisateur);
        }
        public List<Utilisateur> GetListUtilisateurs(string nom, string identifiant, string email, string telephone)
        {
            return ServiceJwtUtilisateur.GetListUtilisateurService(nom, identifiant, email, telephone);
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
