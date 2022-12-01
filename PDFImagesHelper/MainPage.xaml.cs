namespace PDFImagesHelper;

public partial class MainPage : ContentPage
{
    private readonly IFolderPicker _folderPicker;
    string _pickedFolder = "";

    public MainPage(IFolderPicker folderPicker)
	{
		InitializeComponent();
		_folderPicker = folderPicker;
	}

	private async void ChooseDirectory(object sender, EventArgs e)
	{
        var pickedFolder = await _folderPicker.PickFolder();

        DirectoryLabel.Text = pickedFolder;

        SemanticScreenReader.Announce(DirectoryLabel.Text);
    }
}