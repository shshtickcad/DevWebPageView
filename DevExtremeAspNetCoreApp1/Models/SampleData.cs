using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TickToolCloud.Entities.Entity;

namespace DevExtremeAspNetCoreApp1.Models
{

    public class SampleData
    {
        public readonly HttpClient _client;

        public SampleData(HttpClient client)
        {
            _client = client;
        }

        #region GET ALL THE FILES
        public static async Task<List<TickToolCloud.Entities.Entity.FileMaster>> GettingFiles()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://172.16.3.46/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage respN = client.GetAsync("api/Files/").Result;
            var json = await respN.Content.ReadAsStringAsync();

            List<TickToolCloud.Entities.Entity.FileMaster> result = JsonConvert.DeserializeObject<List<TickToolCloud.Entities.Entity.FileMaster>>(json);

            return result;
        }

        internal static IEnumerable<object> GettingFilesList()
        {
            return GettingFiles().Result;
        }
        #endregion

        #region GET FOLDER ON DEMAND
        public static async Task<List<Master>> GetFolder(int masterId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://172.16.3.46/");                                                //new Uri("http://localhost:7700/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (masterId == 0)
            {
                HttpResponseMessage response = client.GetAsync("api/Folders/Top").Result;
                var jsonTop= await response.Content.ReadAsStringAsync();
                List<Master> result = JsonConvert.DeserializeObject<List<Master>>(jsonTop);

                return result;
            }
            else
            {
                HttpResponseMessage respN = client.GetAsync("api/Folders/Folders/"+ masterId +"/").Result;

                var json = await respN.Content.ReadAsStringAsync();
                List<Master> result = JsonConvert.DeserializeObject<List<Master>>(json);

                return result;
            }
        }
        #endregion

        #region GET FILES BY FOLDER
        public static async Task<List<Master>> GetFiles(int folderId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://172.16.3.46/");                                                //new Uri("http://localhost:7700/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage respN = client.GetAsync("/api/Files/files1/" + folderId + "/").Result;

            var data = await respN.Content.ReadAsStringAsync();

            List<Master> result = JsonConvert.DeserializeObject<List<Master>>(data); 

            return result;
        }
        #endregion
       
        //#region GET ALL THE FOLDERS
        //public static async Task<List<TickToolCloud.Entities.Entity.Folder>> GettingFolders()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://172.16.3.46/");
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage respN = client.GetAsync("api/Folders/").Result;
        //    var json = await respN.Content.ReadAsStringAsync();

        //    List<TickToolCloud.Entities.Entity.Folder> result = JsonConvert.DeserializeObject<List<TickToolCloud.Entities.Entity.Folder>>(json);

        //    return result;
        //}

        //internal static IEnumerable<object> GettingFoldersList()
        //{
        //    return GettingFolders().Result;
        //}
        //#endregion
    };
}
