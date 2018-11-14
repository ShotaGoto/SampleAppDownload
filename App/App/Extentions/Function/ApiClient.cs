namespace KBRMobile.Extensions.Function
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ApiClient
    {
        private static Uri baseUri = new Uri("http://172.18.252.150:58213/");

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class.
        /// コンストラクタ
        /// </summary>
        public ApiClient()
        {
        }

        /// <summary>
        /// Get通信(json)
        /// </summary>
        /// <param name="controlNm"></param>
        /// <param name="actionNm"></param>
        /// <returns></returns>
        public static async Task<System.IO.Stream> GetDownloadAsync()
        {
            try
            {
                var controlNm = "ApkDownload";
                var actionNm = "Get";

                var httpClient = new HttpClient();
                //URL生成
                var WebApiUrl = System.IO.Path.Combine(baseUri.ToString(), controlNm, actionNm);

                //通信開始
                var response = await httpClient.GetStreamAsync(WebApiUrl);

                return response;
            }
            catch (Exception e)
            {
                var tmp = e.Message;
                throw;
            }
        }
    }
}