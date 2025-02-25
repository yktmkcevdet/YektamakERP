using Models;

namespace ApiService
{
    partial class WebMethods
    {
        public static async Task<string> SaveSatisSiparisTeklifTalep(SatisTeklifTalep satisSiparisTeklifTalep)
        {
            return await PostAsyncMethod(satisSiparisTeklifTalep, "SaveSatisSiparisTeklifTalep");
        }
        public static string GetSatisTeklifTalep(SatisTeklifTalep satisSiparisTeklifTalep)
        {
            return Post(satisSiparisTeklifTalep, "GetSatisTeklifTalep");
        }
        public static string DeleteSatisSiparisTeklifTalep(SatisTeklifTalep satisSiparisTeklifTalep)
        {
            return Post(satisSiparisTeklifTalep, "DeleteSiparisTeklifTalep");
        }
    }
}
