using Api.Services;
using Google.Cloud.Firestore;
using FirestoreApiExample.Clients;
using FirestoreApiExample.Models;
using System.Text.Json;

namespace Api.Config.Bootstrapping
{
    public static class ServiceBootstrapper
    {
        public static IServiceCollection AddServices(this IServiceCollection services, ApplicationSettings settings)
        {
            var firebaseJson = File.ReadAllText("firestore-cert.json");

            services.AddSingleton(_ => new FirestoreClient(
                new FirestoreDbBuilder
                {
                    ProjectId = "bullishlife",
                    JsonCredentials = firebaseJson
                }.Build()
            ));

            services.AddScoped<IFirestoreService, FirestoreService>();

            return services;
        }
    }
}