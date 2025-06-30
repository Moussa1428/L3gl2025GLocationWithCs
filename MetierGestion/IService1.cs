using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MetierGestion.Model;

namespace MetierGestion
{
	// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
	[ServiceContract]
	public interface IService1
	{

		[OperationContract]
		string GetData(int value);

		[OperationContract]
		CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        bool AddAppartement(Appartement appartement);

		[OperationContract]
		bool AddUtilisateur(Utilisateur utilisateur);

        [OperationContract]
        List<Appartement>  GetListeAppartement(string adresse, float? capacite, bool? disponible);
		
		
		[OperationContract]
		List<Utilisateur> GetListUtilisateurs(string nom, string identifiant, string email, string telephone);
       
		
		[OperationContract]
        Appartement GetAppartementById(int? id);

        [OperationContract]
        bool DeleteAppartement(Appartement appartement);

		[OperationContract]
		bool DeleteUtilisateur(Utilisateur utilisateur);
		[OperationContract]
		bool UpdateAppartement(Appartement appartement);
        // TODO: ajoutez vos opérations de service ici
    }


	// Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
	[DataContract]
	public class CompositeType
	{
		bool boolValue = true;
		string stringValue = "Hello ";

		[DataMember]
		public bool BoolValue
		{
			get { return boolValue; }
			set { boolValue = value; }
		}

		[DataMember]
		public string StringValue
		{
			get { return stringValue; }
			set { stringValue = value; }
		}
	}
}
