using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace App.Models
{

    public interface ITextFileIO
    {
        void Save(string fileName, string text);
        string Read(string fileName);
        void ApkSave(Stream stream);
    }

    public class TextFileIO
    {
        public void Save(string fileName, string text)
        {
            DependencyService.Get<ITextFileIO>().Save(fileName, text);
        }

        public string Read(string fileName)
        {
            return DependencyService.Get<ITextFileIO>().Read(fileName);

        }
        public void ApkSave(Stream stream)
        {
            DependencyService.Get<ITextFileIO>().ApkSave(stream);
        }
    }
}
