using Api.Messages;
using FirestoreApiExample.Clients;
using FirestoreApiExample.Models;
using Google.Apis.Auth.OAuth2;

namespace Api.Services
{
    public interface IAuthService
    {
        public Task<IResponseMessage<string>> GetJwt();
        
    }
    public class AuthService : IAuthService
    {
        public FirestoreClient _firestoreClient { get; set; }
        public AuthService(FirestoreClient firestoreClient) {
            _firestoreClient = firestoreClient;
        }

        public async Task<IResponseMessage<string>> GetJwt()
        {
            // Load the service account credentials
            var credential = GoogleCredential.FromFile("firestore-cert.json")
                .CreateScoped(new[] { "https://www.googleapis.com/auth/cloud-platform" });

            // Generate the JWT
            var jwt = await credential.UnderlyingCredential.GetAccessTokenForRequestAsync();


            return new ResponseMessage<string>(Status.Success, null, jwt);
        }
    }
}