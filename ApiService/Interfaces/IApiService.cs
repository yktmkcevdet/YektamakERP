namespace ApiService.Interfaces
{
    public interface IApiService
    {
        /// <summary>
        /// Model nesnesini json formatına çevirip post eder ve sonucu json string olarak döner.
        /// Asenkron olarak çalışır.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="apiAdres"></param>
        /// <returns></returns>
        public Task<string> PostAsync<T>(T entity, string apiAdres) where T : class;
        public Task<string> PostAsync(MultipartFormDataContent content, string apiAdres);
        /// <summary>
        /// Model nesnesini json formatına çevirip post eder ve sonucu json string olarak döner.
        /// Senkron olarak çalışır.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="apiAdres"></param>
        /// <returns></returns>
        public string Post<T>(T entity, string apiAdres) where T : class;
        /// <summary>
        /// Get işlemi yapar ve sonucu json string olarak döner.
        /// </summary>
        /// <param name="apiAdres"></param>
        /// <returns></returns>
        public Task<string> GetAsync(string apiAdres);
        public Task<byte[]> GetAsyncByte(string apiAdres);
        /// <summary>
        /// Get işlemi yapar ve sonucu json string olarak döner.
        /// </summary>
        /// <param name="apiAdres"></param>
        /// <returns></returns>
        public string Get(string apiAdres);
        /// <summary>
        /// Delete işlemi yapar ve sonucu json string olarak döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiAdres"></param>
        /// <returns></returns>
        public Task<string> DeleteAsync(string apiAdres);
    }
}
