using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ApkDownloadController : ApiController
    {
        //APKファイルを格納するフォルダのパス
        private readonly string path = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ApkDirName"];
        private readonly string ApkName = ConfigurationManager.AppSettings["ApkName"];

        /// <summary>
        /// APKファイルをダウンロードする
        /// </summary>
        /// <param name="updateTime">端末の更新日(yyyy/MM/dd hh:mi:ss)</param>
        /// <returns>APKファイル</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            long updateTime = 20181104121500;
            var FileUpTime = long.Parse(File.GetCreationTime(Path.Combine(path, ApkName)).ToString("yyyyMMddHHmmss"));

            //端末の更新日と端末の更新日を比較して更新済みなら処理終了
            if (updateTime >= FileUpTime) return null;

            FileStream Filestream = null;
            try
            {
                Filestream = File.Open(Path.Combine(path, ApkName), FileMode.Open);
            }
            catch (FileNotFoundException)
            {
                //APKファイルが存在しない
                return null;
            }

            var response = new HttpResponseMessage();
            response.Content = new StreamContent(Filestream);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = ApkName;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            return response;
        }
    }
}