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
        void ApkSave(Stream stream);
    }

    public class TextFileIO
    {
        public void ApkSave(Stream stream)
        {
            DependencyService.Get<ITextFileIO>().ApkSave(stream);
        }
    }
}
