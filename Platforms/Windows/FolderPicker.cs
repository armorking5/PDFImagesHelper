using System;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace PDFImagesHelper.Platforms.Windows
{
    public class MAUIFolderPicker : IFolderPicker
    {
        public async Task<string> PickFolder()
        {
            var folderPicker = new FolderPicker();
            // Make it work for Windows 10
            folderPicker.FileTypeFilter.Add("*");
            // Get the current window's HWND by passing in the Window object
            var hwnd = ((MauiWinUIWindow)App.Current.Windows[0].Handler.PlatformView).WindowHandle;

            // Associate the HWND with the file picker
            WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

            var result = await folderPicker.PickSingleFolderAsync();

            return result.Path;
        }
    }
}

