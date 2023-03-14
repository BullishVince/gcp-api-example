using Api.Services;
using Bogus;
using FakeItEasy;

namespace Api.Config.Mocks {
    public static class FirestoreServiceMock {
        public static IFirestoreService Get() {
            var fakeService = A.Fake<IFirestoreService>();
            return fakeService;
        }
    }
}