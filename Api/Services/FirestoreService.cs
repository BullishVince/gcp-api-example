using Api.Messages;
using FirestoreApiExample.Clients;
using FirestoreApiExample.Models;

namespace Api.Services
{
    public interface IFirestoreService
    {
        public Task<IResponseMessage<IReadOnlyCollection<CryptoOverview>>> GetData();
        public Task<IResponseMessage<CryptoOverview>> PostData(CryptoOverview cryptoOverview);
        
    }
    public class FirestoreService : IFirestoreService
    {
        public FirestoreClient _firestoreClient { get; set; }
        public FirestoreService(FirestoreClient firestoreClient) {
            _firestoreClient = firestoreClient;
        }

        public async Task<IResponseMessage<IReadOnlyCollection<CryptoOverview>>> GetData()
        {
            var result = await _firestoreClient.GetAll<CryptoOverview>("sincealltimehigh.crypto.overview", new CancellationToken());
            return new ResponseMessage<IReadOnlyCollection<CryptoOverview>>(Status.Success, null, result);
        }

        public async Task<IResponseMessage<CryptoOverview>> PostData(CryptoOverview cryptoOverview)
        {
            await _firestoreClient.AddOrUpdate("sincealltimehigh.crypto.overview", cryptoOverview, new CancellationToken());
            return new ResponseMessage<CryptoOverview>(Status.Success, null, null);
        }
    }
}