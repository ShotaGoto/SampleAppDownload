using App.Models;
using KBRMobile.Extensions.Function;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ダウンロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Download_Click(object sender, EventArgs e)
        {
            var TextFileIO = new TextFileIO();

            //fileを取得
            using (var Apk = await ApiClient.GetDownloadAsync())
            {
                //APｋファイルを保存
                TextFileIO.ApkSave(Apk);
            }
            //APKファイル実行
            DependencyService.Get<IInstallApp>().Run();
        }

        /// <summary>
        /// 例外発生処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exception_Click(object sender, EventArgs e)
        {
            throw new Exception();
        }
    }
}