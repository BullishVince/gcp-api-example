using Google.Cloud.Firestore;

namespace FirestoreApiExample.Models
{
    [FirestoreData()]
    public class CryptoOverview : IFirebaseEntity
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public double Price{ get; set; }
        [FirestoreProperty]
        public double AthPrice { get; set; }
        [FirestoreProperty]
        public double AtlPrice { get; set; }
        [FirestoreProperty]
        public double PercentageToAth { get; set; }
        [FirestoreProperty]
        public double PercentageToAtl { get; set; }
        [FirestoreProperty]
        public double CirculatingSupply { get; set; }
        [FirestoreProperty]
        public DateTime FirstTradableDate { get; set; }
        [FirestoreProperty]
        public double Marketcap { get; set; }

        public CryptoOverview()
        {
            
        }

        public CryptoOverview(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}