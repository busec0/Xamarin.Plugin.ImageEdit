namespace MauiSample;

public partial class MainPage : ContentPage
{
    private ImageSource _image;
    public ImageSource Image
    {
        get => _image;
        set
        {
            _image = value;
            OnPropertyChanged();
        }
    }

    private FileResult _imageFile;


    public MainPage()
    {
        InitializeComponent();
    }

    async void Pick_Clicked(System.Object sender, System.EventArgs e)
    {
        _imageFile = await Microsoft.Maui.Media.MediaPicker.PickPhotoAsync();
        var stream = await _imageFile.OpenReadAsync();
        Image = ImageSource.FromStream(() => stream);
    }

    async void ToMonochrome_Clicked(System.Object sender, System.EventArgs e)
    {
        var stream = await _imageFile.OpenReadAsync();

        using (var image = await Plugin.ImageEdit.CrossImageEdit.Current.CreateImageAsync(stream))
        {
            var data = image.ToMonochrome().ToJpeg(100);
            Image = ImageSource.FromStream(() => new MemoryStream(data));
        }
    }

    async void Resize_Clicked(System.Object sender, System.EventArgs e)
    {
        var stream = await _imageFile.OpenReadAsync();

        using (var image = await Plugin.ImageEdit.CrossImageEdit.Current.CreateImageAsync(stream))
        {
            var data = image.Resize(150).ToJpeg(100);
            Image = ImageSource.FromStream(() => new MemoryStream(data));
        }
    }
}


