using FirestoreApiExample.Models;
using Google.Cloud.Firestore;

namespace FirestoreApiExample.Clients;
public class FirestoreClient
{
    private readonly FirestoreDb _fireStoreDb = null!;

    public FirestoreClient(FirestoreDb fireStoreDb)
    {
        _fireStoreDb = fireStoreDb;
    }

    public async Task AddOrUpdate<T>(string collectionId, T entity, CancellationToken ct) where T : IFirebaseEntity
    {
        var document = _fireStoreDb.Collection(collectionId).Document(entity.Id);
        await document.SetAsync(entity, cancellationToken: ct);
    }

    public async Task<T> GetById<T>(string collectionId, string id, CancellationToken ct) where T : IFirebaseEntity
    {
        var document = _fireStoreDb.Collection(collectionId).Document(id);
        var snapshot = await document.GetSnapshotAsync(ct);
        return snapshot.ConvertTo<T>();
    }

    public async Task<IReadOnlyCollection<T>> GetAll<T>(string collectionId, CancellationToken ct) where T : IFirebaseEntity
    {
        var collection = _fireStoreDb.Collection(collectionId);
        var snapshot = await collection.GetSnapshotAsync(ct);
        return snapshot.Documents.Select(x => x.ConvertTo<T>()).ToList();
    }

    public async Task<IReadOnlyCollection<T>> WhereEqualTo<T>(string collectionId, string fieldPath, object value, CancellationToken ct) where T : IFirebaseEntity
    {
        return await GetMany<T>(_fireStoreDb.Collection(collectionId).WhereEqualTo(fieldPath, value), ct);
    }

    private static async Task<IReadOnlyCollection<T>> GetMany<T>(Query query, CancellationToken ct) where T : IFirebaseEntity
    {
        var snapshot = await query.GetSnapshotAsync(ct);
        return snapshot.Documents.Select(x => x.ConvertTo<T>()).ToList();
    }
}
