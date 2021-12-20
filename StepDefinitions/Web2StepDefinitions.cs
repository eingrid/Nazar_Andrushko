using static WebAPI_2.StepDefinitions.API_INT;
namespace WebAPI_2.StepDefinitions
{
    [Binding]
    public sealed class Web2StepDefinitions
    {
        
        private  string  metadata_response;
        API_INT api_interactable = new API_INT(); 
        [Given(@"We have file to upload")]
        public void GivenWeHaveFileToUpload()
        {
             api_interactable.setClientUpload();
        }

        [When(@"We send a request to upload file")]
        public void WhenWeSendARequestToUploadFile()
        {
            api_interactable.sendRequestToUploadFIle();
        }

        [Then(@"File is uploaded to dropbox")]
        public void ThenFileIsUploadedToDropbox()
        {
            api_interactable.CheckFileWasUpploaded();
        }

        [Given(@"We have file to delete")]
        public void GivenWeHaveFileToDelete()
        {
            api_interactable.setClientDelete();
        }

        [When(@"We send a request to delete file")]
        public void WhenWeSendARequestToDeleteFile()
        {
            api_interactable.sendRequestToDeleteFile();
        }

        [Then(@"File is deleted on dropbox")]
        public void ThenFileIsDeletedOnDropbox()
        {
            api_interactable.CheckFileWasDeleted();
        }

        [Given(@"We want to get metadata of the file on dropbox")]
        public void GivenWeWantToGetMetadataOfTheFileOnDropbox()
        {
            api_interactable.prepateToGetMetaData();
    }

        [When(@"We send a request to get metadata")]
        public void WhenWeSendARequestToGetMetadata()
        {
            metadata_response = api_interactable.sendRequestToGetMetadata();
        }

        [Then(@"We get metadata")]
        public void ThenWeGetMetadata()
        {
            api_interactable.checkGetMetadata(metadata_response);
        }

    }
}