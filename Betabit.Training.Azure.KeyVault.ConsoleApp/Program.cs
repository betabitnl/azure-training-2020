using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Betabit.Training.Azure.Common;

namespace Betabit.Training.Azure.KeyVault
{
    public class Program
    {
        #region Constants

        const string SECRET_NAME = "<YOUR-SECRET-NAME>";
        const string VAULT_NAME = "<YOUR-VAULT-NAME>";

        #endregion

        static async Task Main(string[] args)
        {
            var client = new SecretClient(KeyVaultHelper.GetVaultUri(VAULT_NAME), new DefaultAzureCredential());
            var secret = await client.GetSecretAsync(SECRET_NAME);

            Console.WriteLine($"The secret value I retrieved from Key Vault: {secret.Value}!");
        }
    }
}