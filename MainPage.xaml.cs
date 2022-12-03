namespace PDFImagesHelper;

public partial class MainPage : ContentPage
{
    private readonly IFolderPicker _folderPicker;
    PickOptions _filePickerOptions;
    string _pickedFolder = "";
    FileResult _pickedFile;

    public MainPage(IFolderPicker folderPicker)
    {
        InitializeComponent();
        _folderPicker = folderPicker;

        var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "com.adobe.pdf" } }, // UTType values
                    { DevicePlatform.WinUI, new[] { ".pdf" } }, // file extension
                    { DevicePlatform.macOS, new[] { "com.adobe.pdf" } }, // UTType values
                });

        _filePickerOptions = new()
        {
            PickerTitle = "Seleziona un pdf",
            FileTypes = customFileType,
        };
    }

    private async void ChooseDirectory(object sender, EventArgs e)
    {
        var pickedFolder = await _folderPicker.PickFolder();

        DirectoryLabel.Text = _pickedFolder = pickedFolder;

        SemanticScreenReader.Announce(DirectoryLabel.Text);
    }

    private async void ChooseFile(object sender, EventArgs e)
    {
        var pickedFile = await PickFile(_filePickerOptions);

        _pickedFile = pickedFile;
        FileLabel.Text = pickedFile.FullPath;

        SemanticScreenReader.Announce(FileLabel.Text);
    }

    public async Task<FileResult> PickFile(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);

            return result;
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }

        return null;
    }

}