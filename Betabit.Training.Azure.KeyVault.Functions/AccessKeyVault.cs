using System.Threading.Tasks;

using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Betabit.Training.Azure.Common;

namespace Betabit.Training.Azure.KeyVault.Functions
{
    public static class AccessKeyVault
    {
        #region Constants

        const string SECRET_NAME = "<YOUR-SECRET-NAME>";
        const string VAULT_NAME = "<YOUR-VAULT-NAME>";

        #endregion

        [FunctionName(nameof(AccessKeyVault))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var client = new SecretClient(KeyVaultHelper.GetVaultUri(VAULT_NAME), new DefaultAzureCredential());
            var secret = (await client.GetSecretAsync(SECRET_NAME)).Value;

            return new OkObjectResult($"The secret value I retrieved from Key Vault: {secret.Value}!");
        }
    }
}
