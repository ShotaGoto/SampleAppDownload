using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using App.Droid;
using App.Models;
using Android.App;

[assembly: Xamarin.Forms.Dependency(typeof(FileIODevice))]
namespace App.Droid
{
    public class FileIODevice : ITextFileIO
    {
        public void ApkSave(Stream stream)
        {
            var FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            Application.Context.PackageName + ".apk");

            var fileStream = File.Create(FilePath);
            stream.CopyTo(fileStream);
            fileStream.Close();
        }

        public string ApkFilePath(string fileName)
        {
            return Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.Personal),
                fileName);
        }
    }
}
    

