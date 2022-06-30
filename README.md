# Image Edit Plugin for Xamarin

This plugin will enable you to manipulate(resize,crop,rotate) and filter(monochrome) a image(png,jpg).

### Setup

* Available on NuGet: https://www.nuget.org/packages/Xamarin.Plugin.ImageEdit.NET/2.0.0-alpha1
* Install into your .Net6 Projects - MAUI (iOS and Android)


**Platform Support**

|Platform|Supported|Version|
| ------------------- | :-----------: | :------------------: |
|net6.0-ios|Yes||
|net6.0-android|Yes||
|Windows 10 UWP|No||
|MacoS|No||

## Usage example

Image crop and rotate and resize and get png data.

### Using as plugin

```cs
using (var image = await CrossImageEdit.Current.CreateImageAsync(imageByteArray)) {
	var croped = await Task.Run(() =>
			image.Crop(10, 20, 250, 100)
				 .Rotate(180)
				 .Resize(100, 0)
				 .ToPng()
	);
}
```

### Using as IPlatformInitializer(prism.unity.forms)

```cs
//View model constructor
public ViewModel(IImageEdit imageEdit){

	using (var image = await imageEdit.CreateImageAsync(imageByteArray)) {
		var croped = await Task.Run(() =>
				image.Crop(10, 20, 250, 100)
					 .Rotate(180)
					 .Resize(100, 0)
					 .ToPng()
		);
	}
}


//on platform
public class iOSInitializer : IPlatformInitializer
{
	public void RegisterTypes(IUnityContainer container)
	{
		container.RegisterType<IImageEdit,ImageEdit>();
	}
}
```

### Sample project

https://github.com/muak/PanPinchSample

**movie**
https://twitter.com/muak_x/status/837266085405573120

## API Usage

### Get EditableImage

```cs
//from byte[]
var image = await CrossImageEdit.Current.CreateImageAsync(imageByteArray);
```
```cs
//from stream
var image = await CrossImageEdit.Current.CreateImageAsync(imageStream);
```
It is able to manipulate a image using this object.

### Resize

```cs
var width = 200;
var height = 150;
image.Resize(width, height);
image.Resize(width, 0); //auto height
image.Resize(0, height); //auto width

image.Resize(50); //specify max length of long side. other side auto size.
```

### Crop

```cs
var x = 10;
var y = 10;
var width = 50;
var height = 50;
image.Crop(10, 10, 50, 50);
```

### Rotate

```cs
var degree = 90; // 0-360;
image.Rotate(degree);
```

### ToMonochrome

The image will convert to monochrome.

```cs
image.ToMonochrome();
```

### ToPng

```cs
var pngBytes = image.ToPng();
```

### ToJpeg

```cs
var jpgBytes = image.ToJpeg(90); // quality(0-100)
```

### ToArgbPixels

Get image ARGB infomation.

for example when 0xFF00F090

|A|R|G|B|
| :--- | :--- | :--- | :--- |
|FF|00|F0|90|


```cs
var pixels = image.ToArgbPixels();

var pixel = pixels[10];
var r = pixel & 0x00FF0000 >> 16; //Get R
var g = pixel & 0x0000FF00 >> 8;  //Get G
var b = pixel & 0x000000FF;       //Get B
```

## GetNativeImage

Get native image on platform. 
if platform is iOS, return UIImage; otherwise return Bitmap.

## License

MIT Licensed.
