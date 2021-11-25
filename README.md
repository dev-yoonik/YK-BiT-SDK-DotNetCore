![https://yk-website-images.s3.eu-west-1.amazonaws.com/LogoV4_TRANSPARENT.png](https://yk-website-images.s3.eu-west-1.amazonaws.com/LogoV4_TRANSPARENT.png)

# YK-BiT-DotNetCore-SDK

[![License](https://img.shields.io/github/license/dev-yoonik/YK-BiT-SDK-DotNetCore)](https://github.com/dev-yoonik/YK-BiT-SDK-DotNetCore/blob/master/LICENSE)
[![Version](https://img.shields.io/nuget/v/YooniK.BiometricInThings.Client)](https://www.nuget.org/packages/YooniK.BiometricInThings.Client/)

This repository implements an integration SDK to facilitate the consumption of the YooniK.BiometricInThings API, a [YooniK Services](https://www.yoonik.me) offering.

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

You can also use environment variables (YK_BIT_BASE_URL and YK_BIT_X_API_KEY) to authenticate. Machine restart could be required.

```csharp

// Edit your access credentials
string baseUrl = "YOUR-API-ENDPOINT";
string subscriptionKey = "YOUR-X-API-KEY";
var bitInformation = new ConnectionInformation(baseUrl, subscriptionKey);

// If you have the environment variables set, remove the above and use "var bitClient = new BiometricInThingsClient()"
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

 If you're interested in using YooniK.BiometricInThings API for identification purposes, please contact us.

## YooniK BiT API Details

For a complete specification of our BiT API please check the [swagger file](https://dev-yoonik.github.io/YK-BiT-Documentation/).

## Contact & Support

For more information and trial licenses please [contact us](mailto:tech@yoonik.me) or join us at our [discord community](https://discord.gg/SqHVQUFNtN).

