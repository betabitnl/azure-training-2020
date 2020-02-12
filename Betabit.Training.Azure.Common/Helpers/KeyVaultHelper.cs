using System;

namespace Betabit.Training.Azure.Common
{
    public static class KeyVaultHelper
    {
        /// <summary>
        /// Returns a URI to an Azure Key Vault based on the name of the vault.
        /// </summary>
        /// <param name="vaultName">Name of the Key Vault.</param>
        /// <returns>A <see cref="Uri"/> for the specified <paramref name="vaultName"/>.</returns>
        public static Uri GetVaultUri(string vaultName)
        {
            return new Uri(GetVaultUrl(vaultName));
        }

        /// <summary>
        /// Returns a URL to an Azure Key Vault based on the name of the vault.
        /// </summary>
        /// <param name="vaultName">Name of the Key Vault.</param>
        /// <returns>A URL for the specified <paramref name="vaultName"/>.</returns>
        public static string GetVaultUrl(string vaultName)
        {
            return $"https://{vaultName}.vault.azure.net/";
        }
    }
}