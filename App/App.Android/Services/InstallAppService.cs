using Android.App;
using Android.Arch.Lifecycle;
using Android.Content;
using Android.Support.V4.Content;
using App.Droid.Services;
using App.Models;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(InstallAppService))]

namespace App.Droid.Services
{
    public class InstallAppService : IInstallApp
    {
        public void Run()
        {
            var Context = Application.Context.ApplicationContext;
            var PackageName = Application.Context.PackageName;
            var FilePath = new FileIODevice().ApkFilePath(PackageName + ".apk");
            var MimeType = "application/vnd.android.package-archive";

            var Uri = new Java.IO.File(FilePath);
            var Url = FileProvider.GetUriForFile(Context, PackageName + ".provider", Uri);

            // Intent生成 MIMEを設定して別タスクで起動する
            Intent intent = new Intent(Intent.ActionView)
            .SetDataAndType(Url,MimeType)
            .SetFlags(ActivityFlags.NewTask)
            .AddFlags(ActivityFlags.NewTask | ActivityFlags.GrantReadUriPermission | ActivityFlags.GrantWriteUriPermission);

            // Intent発行
            Application.Context.StartActivity(intent);

        }
    }
}