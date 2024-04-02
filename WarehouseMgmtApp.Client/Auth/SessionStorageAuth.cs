using Blazored.SessionStorage;
using System.Text.Json;
using WarehouseMgmtApp;

namespace WarehouseMgmtApp.Client.Auth
{
    public static class SesionStorageAuth
    {
        public static async Task SaveStorage<T>(
            this ISessionStorageService sessionStorageService,
            string key, T item
            ) where T : class
        {

            var itemJson = JsonSerializer.Serialize(item);
            await sessionStorageService.SetItemAsStringAsync(key, itemJson);

        }

        public static async Task<T?> GetStorage<T>(
        this ISessionStorageService sessionStorageService,
        string key
        ) where T : class
        {
            var itemJson = await sessionStorageService.GetItemAsStringAsync(key);

            if (itemJson != null)
            {
                var item = JsonSerializer.Deserialize<T>(itemJson);
                return item;
            }
            else
                return null;
        }


    }
}
