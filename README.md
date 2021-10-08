![https://yoonik.me/wp-content/uploads/2019/08/cropped-LogoV4_TRANSPARENT.png](https://yoonik.me/wp-content/uploads/2019/08/cropped-LogoV4_TRANSPARENT.png)

# YK-BiT-DotNetCore-SDK

[![License](https://img.shields.io/pypi/l/yk_face.svg)](https://github.com/dev-yoonik/YK-BiT-SDK-DotNetCore/blob/master/LICENSE)

This repository implements an integration SDK to facilitate the consumption of the YooniK.BiometricInThings API, a [YooniK Services](https://yoonik.me) offering.

For more information please [contact us](mailto:tech@yoonik.me).

## Getting started

To import the latest this solution into your project, enter the following command in the NuGet Package Manager Console in Visual Studio:

For other installation methods, see [YooniK.BiometricInThings.Client Nuget](https://www.nuget.org/packages/YooniK.BiometricInThings.Client/)

```
PM> Install-Package YooniK.BiometricInThings.Client
```



## Example

BiometricInThingsClient methods depend on Yoonik.Services.Client that uses HttpClient to handle the API calls.

For more information feel free to take a look at [YooniK.Services.Client](https://github.com/dev-yoonik/YK-Services-Client-DotNetCore/)

Use it:

Make sure you have added the environment key-values (YK_BIT_BASE_URL and YK_BIT_X_API_KEY). Machine restart could be required.

```csharp

// To read the values from the environment variables
string baseUrl = Environment.GetEnvironmentVariable("YK_BIT_BASE_URL");
string subscriptionKey = Environment.GetEnvironmentVariable("YK_BIT_X_API_KEY");

var bitInformation = new ConnectionInformation(baseUrl, subscriptionKey);
var bitClient = new BiometricInThingsClient(bitInformation);

// Validates the availability of the camera

if(await bitClient.StatusAsync() == BiTStatus.Available){
	// Captures a live face frame from the camera
	var captured = await bitClient.CaptureAsync(captureTimeOutInSeconds: 5);
	Console.WriteLine(captured);

	// Compares the live face frame capture from the camera with an Image
	var verified = await bitClient.VerifyAsync(captured.Image, captureTimeOutInSeconds: 5, matchingScoreThreshold: 0.3);
	Console.WriteLine(verified);

	// Compares two face images
	var verifiedImages = await bitClient.VerifyImagesAsync(captured.Image, verified.VerifiedImage, matchingScoreThreshold: 0.8);
	Console.WriteLine(verifiedImages);
}


```


 If you're interested in using YooniK.BiometricInThings API for identification purposes, please contact us: tech@yoonik.me.
