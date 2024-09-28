using Microsoft.Azure.Cosmos;
using Zadatak_5.Dal;

namespace Zadatak_5
{
    public class CosmosDbServiceProvider
    {
        private const string DatabaseName = "Persons";
        private const string ContainerName = "Manager";
        private const string Account = "put_your_azure_account_here";
        private const string Key = "your_own_key";


        private static ICosmosDbService? service;

        public static ICosmosDbService Service { get => service; }

        public async static Task Init()
        {
            CosmosClient cosmosClient = new(Account, Key);
            service = new CosmosDbService(cosmosClient, DatabaseName, ContainerName);
            DatabaseResponse databaseResponse = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await databaseResponse.Database.CreateContainerIfNotExistsAsync(ContainerName, "/id");
        }
    }
}
