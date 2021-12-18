using RestSharp;

namespace WebAPI_2.StepDefinitions
{
    [Binding]
    public sealed class Web2StepDefinitions
    {
        private readonly RestClient clientGetMetadata = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");
        private readonly RestRequest requestGetMeta = new RestRequest(Method.POST);

        private readonly RestClient clientDelete = new RestClient("https://api.dropboxapi.com/2/file_requests/delete");
        private readonly RestRequest requestDelete = new RestRequest(Method.POST);

        private readonly RestClient clientUpload = new RestClient("https://content.dropboxapi.com/2/files/upload");
        
        private readonly RestRequest requestUpload = new RestRequest(Method.POST);

        [Given(@"We have file to upload")]
        public void GivenWeHaveFileToUpload()
        {
             clientUpload.Timeout = -1;
        }

        [When(@"We send a request to upload file")]
        public void WhenWeSendARequestToUploadFile()
        {
            requestUpload.AddHeader("Dropbox-API-Arg", "{\\\"path\\\": \\\"/New.txt\\\",\\\"mode\\\": \\\"add\\\",\\\"autorename\\\": true,\\\"mute\\\": false,\\\"strict_conflict\\\": false}");
            requestUpload.AddHeader("Authorization", "Bearer sl.A-Zzuh4QNNfZ_Ukqc_Qz1sV4Are7yMdSUt5oxoQJSpYhTMd7S9JoUCUcXutolccbUVfY8CcfxE0iLe2EQ3duNB1yic235FJpgpVzSU7L7Yek-jBmqRWMMB4VjHQGob7YCfY0qX6vdvMK");
            requestUpload.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
            @"    ""Content-Type"" : ""application/octet-stream""" + "\n" +
            @"}";
            requestUpload.AddParameter("application/json", body, ParameterType.RequestBody);
        }

        [Then(@"File is uploaded to dropbox")]
        public void ThenFileIsUploadedToDropbox()
        {
            IRestResponse response = clientUpload.Execute(requestUpload);
            Console.WriteLine(response.Content);
        }

        [Given(@"We have file to delete")]
        public void GivenWeHaveFileToDelete()
        {
            clientDelete.Timeout = -1;
        }

        [When(@"We send a request to delete file")]
        public void WhenWeSendARequestToDeleteFile()
        {
            requestDelete.AddHeader("Authorization", "Bearer sl.A-Zzuh4QNNfZ_Ukqc_Qz1sV4Are7yMdSUt5oxoQJSpYhTMd7S9JoUCUcXutolccbUVfY8CcfxE0iLe2EQ3duNB1yic235FJpgpVzSU7L7Yek-jBmqRWMMB4VjHQGob7YCfY0qX6vdvMK");
            requestDelete.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
            @"    ""path"": ""Document.docx""" + "\n" +
            @"}";
            requestDelete.AddParameter("application/json", body, ParameterType.RequestBody);
        }

        [Then(@"File is deleted on dropbox")]
        public void ThenFileIsDeletedOnDropbox()
        {
            IRestResponse response = clientDelete.Execute(requestDelete);
            Console.WriteLine(response.Content);
        }

        [Given(@"We want to get metadata of the file on dropbox")]
        public void GivenWeWantToGetMetadataOfTheFileOnDropbox()
        {
            RestClient clientGetMetadata = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");
            clientGetMetadata.Timeout = -1;
            RestRequest requestGetMeta = new RestRequest(Method.POST);
    }

        [When(@"We send a request to get metadata")]
        public void WhenWeSendARequestToGetMetadata()
        {
            requestGetMeta.AddHeader("Authorization", "Bearer sl.A-Zzuh4QNNfZ_Ukqc_Qz1sV4Are7yMdSUt5oxoQJSpYhTMd7S9JoUCUcXutolccbUVfY8CcfxE0iLe2EQ3duNB1yic235FJpgpVzSU7L7Yek-jBmqRWMMB4VjHQGob7YCfY0qX6vdvMK");
            requestGetMeta.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
            @"    ""path"": ""/New.txt""" + "\n" +
            @"}";
            requestGetMeta.AddParameter("application/json", body, ParameterType.RequestBody);
        }

        [Then(@"We get metadata")]
        public void ThenWeGetMetadata()
        {
            IRestResponse response = clientGetMetadata.Execute(requestGetMeta);
            Console.WriteLine(response.Content);
        }

    }
}