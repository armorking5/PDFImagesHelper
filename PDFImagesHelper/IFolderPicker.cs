using System;
using System.Threading.Tasks;

namespace PDFImagesHelper
{
    public interface IFolderPicker
    {
        Task<string> PickFolder();
    }
}

