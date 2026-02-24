namespace ApiService
{
    partial class WebMethods
    {
        public  async Task<string> TumMarkaVeAltGruplar()
        {
            return await GetAsyncMethod("TumMarkaVeAltGruplar");
        }
        public static string GetMarka()
        {
            return Get("GetMarka");
        }
        public static string GetMarkaAltGrup()
        {
            return Get("GetMarkaAltGrup");
        }
    }
}
