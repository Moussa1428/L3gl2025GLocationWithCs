using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MetierUtilisateur.Model;

namespace MetierUtilisateur
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool AddUtilisateur(Utilisateur utilisateur);
        [OperationContract]
        List<Utilisateur> GetListUtilisateurs(string NomPrenompersonne, string Identifiantpersonne, string Emailpersonner, string Telephonepersonne);
        [OperationContract]
        bool UpdateUtilisateur(Utilisateur utilisateur);
        [OperationContract]
        bool DeleteUtilisateur(Utilisateur utilisateur);
        [OperationContract]
        Utilisateur GetUtilisateurById(int id);
        [OperationContract]
        Utilisateur GetUtilisateursBytel(string tel);
        [OperationContract]
        Utilisateur GetUtilisateursByEmail(string email);
        [OperationContract]
        Utilisateur GetUtilisateursByIdentifiant(string identifiant);



        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

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
