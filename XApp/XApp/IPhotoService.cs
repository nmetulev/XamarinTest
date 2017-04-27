using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XApp
{
    public interface IPhotoService
    {
        Task<ImageSource> TakePhotoAsync();
    }
}
