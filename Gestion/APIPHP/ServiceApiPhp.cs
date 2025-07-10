using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gestion.APIPHP
{
    public class ServiceApiPhp
    {
        private HttpClient client;
        public ServiceApiPhp()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8000/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public List<UtilisateurApi> GetUtilisateurs()
        {
            var response = client.GetAsync("api.php").Result;
            string json = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<UtilisateurApi>>(json);
        }
        public bool AjouterUtilisateur(UtilisateurApi u)
        {
            var json = JsonConvert.SerializeObject(u);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("api.php", content).Result;
            return response.IsSuccessStatusCode;
        }
        public bool ModifierUtilisateur(UtilisateurApi u)
        {
            var json = JsonConvert.SerializeObject(u);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PutAsync("api.php?id=" + u.IdPersonne, content).Result;
            return response.IsSuccessStatusCode;
        }
        public bool SupprimerUtilisateur(int id)
        {
            var response = client.DeleteAsync("api.php?id=" + id).Result;
            return response.IsSuccessStatusCode;
        }
        public UtilisateurApi getUtilisateurByID(int id)
        {
            var response = client.GetAsync("api.php?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<UtilisateurApi>(json);
            }
            return null;
        }
    }
}
