using System;
using System.Threading.Tasks;
using Betabit.Training.Azure.Common;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace Betabit.Training.Azure.KeyVault.Old
{
    class Program
    {
        #region Constants

        const string SECRET_NAME = "<YOUR-SECRET-NAME>";
        const string VAULT_NAME = "<YOUR-VAULT-NAME>";

        #endregion

        static async Task Main(string[] args)
        {
            var tokenProvider = new AzureServiceTokenProvider();
            var callback = new KeyVaultClient.AuthenticationCallback(tokenProvider.KeyVaultTokenCallback);
            var client = new KeyVaultClient(callback);

            var secret = await client.GetSecretAsync(KeyVaultHelper.GetVaultUrl(VAULT_NAME), SECRET_NAME);

            Console.WriteLine($"The secret value I retrieved from Key Vault: {secret.Value}!");
        }
    }
}
