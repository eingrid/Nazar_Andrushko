using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace WebAPI_2.StepDefinitions
{
    public class API_INT
    {
        private readonly RestClient clientGetMetadata = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");
        private readonly RestRequest requestGetMeta = new RestRequest(Method.POST);

        private readonly RestClient clientDelete = new RestClient("https://api.dropboxapi.com/2/files/delete_v2");
        private readonly RestRequest requestDelete = new RestRequest(Method.POST);

        private readonly RestClient clientUpload = new RestClient("https://content.dropboxapi.com/2/files/upload");

        private readonly RestRequest requestUpload = new RestRequest(Method.POST);


        private IRestResponse getList_Folder_response(){
            RestClient clientCheck = new RestClient("https://api.dropboxapi.com/2/files/list_folder");
            RestRequest requestCheck = new RestRequest(Method.POST);
            clientCheck.Timeout = -1;
            requestCheck.AddHeader("Authorization", "Bearer sl.A-gV5xx8sXRdMdRUcAF7DJhF_mECZ1b2ay5GnffGQjXiU29Y0Odq8Hh7p5xtXxdgek8H-gHt9qZKhacIF1EnxSmgDonBkLanGXD_l3DGlzf6CQkr_53G6aOlF_cxO_cLZ-FOoU8e4FIl");
            requestCheck.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
            @"    ""path"" : """"" + "\n" +
            @"}";
            requestCheck.AddParameter("application/json", body,  ParameterType.RequestBody);
            return clientCheck.Execute(requestCheck);
        }
        public void setClientUpload()
        {
            clientUpload.Timeout = -1;
        }

        public void sendRequestToUploadFIle()
        {
            requestUpload.AddHeader("Content-Type", "application/octet-stream");
            requestUpload.AddHeader("Dropbox-API-Arg", "{\"path\": \"/NewFile.txt\",\"mode\": \"add\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}");
            requestUpload.AddHeader("Authorization", "Bearer sl.A-gV5xx8sXRdMdRUcAF7DJhF_mECZ1b2ay5GnffGQjXiU29Y0Odq8Hh7p5xtXxdgek8H-gHt9qZKhacIF1EnxSmgDonBkLanGXD_l3DGlzf6CQkr_53G6aOlF_cxO_cLZ-FOoU8e4FIl");
            IRestResponse response = clientUpload.Execute(requestUpload);

        }

        public void CheckFileWasUpploaded()
        {
            var response = getList_Folder_response();

            if (response.Content.IndexOf("NewFile.txt") == -1 ){
                throw new ArgumentException("File wasn't added");
            };
        }




        public void setClientDelete()
        {
            clientDelete.Timeout = -1;
        }


        public void sendRequestToDeleteFile()
        {
            requestDelete.AddHeader("Authorization", "Bearer sl.A-gV5xx8sXRdMdRUcAF7DJhF_mECZ1b2ay5GnffGQjXiU29Y0Odq8Hh7p5xtXxdgek8H-gHt9qZKhacIF1EnxSmgDonBkLanGXD_l3DGlzf6CQkr_53G6aOlF_cxO_cLZ-FOoU8e4FIl");
            requestDelete.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
            @"    ""path"": ""/NewFile.txt""" + "\n" +
            @"}";
            requestDelete.AddParameter("application/json", body,  ParameterType.RequestBody);
            IRestResponse response = clientDelete.Execute(requestDelete);
        }

        public void CheckFileWasDeleted()
        {
         
            var response = getList_Folder_response();

            if (response.Content.IndexOf("NewFile.txt") != -1){
                throw new ArgumentException("File wasn't deleted");
            };
        }


        public void prepateToGetMetaData()
        {
            RestClient clientGetMetadata = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");
            clientGetMetadata.Timeout = -1;
            RestRequest requestGetMeta = new RestRequest(Method.POST);
        }

        public string sendRequestToGetMetadata()
        {
            requestGetMeta.AddHeader("Authorization", "Bearer sl.A-gV5xx8sXRdMdRUcAF7DJhF_mECZ1b2ay5GnffGQjXiU29Y0Odq8Hh7p5xtXxdgek8H-gHt9qZKhacIF1EnxSmgDonBkLanGXD_l3DGlzf6CQkr_53G6aOlF_cxO_cLZ-FOoU8e4FIl");
            requestGetMeta.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
            @"    ""path"": ""/papka""" + "\n" +
            @"}";
            requestGetMeta.AddParameter("application/json", body,  ParameterType.RequestBody);
            IRestResponse response = clientGetMetadata.Execute(requestGetMeta);

            return response.Content;
        }

        public void checkGetMetadata(string metadata_response)
        {
            Console.WriteLine(metadata_response);
        }
    }
}