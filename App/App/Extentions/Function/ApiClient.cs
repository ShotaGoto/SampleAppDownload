namespace KBRMobile.Extensions.Function
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ApiClient
    {
        private static Uri baseUri = new Uri("http://172.18.252.150:58213/");

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ApiClient()
        {
        }

        /// <summary>
        /// 非同期Get通信(Stream)
        /// </summary>
        /// <returns></returns>
        public static async Task<Stream> GetDownloadAsync()
        {
            try
            {
                var controlNm = "ApkDownload";
                var actionNm = "Get";
                var httpClient = new HttpClient();
                var WebApiUrl = Path.Combine(baseUri.ToString(), controlNm, actionNm);

                //通信開始
                var response = await httpClient.GetStreamAsync(WebApiUrl);

                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}