using System;
using System.IO;
using System.Threading.Tasks;
using YooniK.BiometricInThings.Client;
using YooniK.Services.Client.Common;

namespace YooniK.BiometricInThings.Sample
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            string baseUrl = Environment.GetEnvironmentVariable("YK_BIT_BASE_URL");
            string subscriptionKey = Environment.GetEnvironmentVariable("YK_BIT_X_API_KEY");

            try
            {
                var bitInformation = new ConnectionInformation(baseUrl, subscriptionKey);
                var bitClient = new BiometricInThingsClient(bitInformation);
                
                // Validates the availability of the camera
                await bitClient.StatusAsync();
                
                // Captures a live face frame from the camera
                var captured = await bitClient.CaptureAsync(captureTimeOutInSeconds: 5);
                // Saves the captured frame to file
                File.WriteAllBytes($"{nameof(captured)}.jpg", Convert.FromBase64String(captured.Image));
                Console.WriteLine(
                    "Captured \n\t" +
                    $"Status: [{ BiometricInThings.Client.Utils.ListOfStringsToString(captured.CaptureStatus)}]");

                // Compares the live face frame capture from the camera with an Image
                var verified = await bitClient.VerifyAsync(captured.Image, captureTimeOutInSeconds: 5, matchingScoreThreshold: 0.3);
                // Saves the verify frame to file
                File.WriteAllBytes($"{nameof(verified)}.jpg", Convert.FromBase64String(verified.VerifiedImage));
                Console.WriteLine(
                    "Verified \n\t" +
                    $"Status: [{ BiometricInThings.Client.Utils.ListOfStringsToString(verified.VerifyStatus)}] \n\t" +
                    $"MatchingScore: {verified.MatchingScore}"
                    );

                // Compares two face images
                var verifiedImages = await bitClient.VerifyImagesAsync(captured.Image, verified.VerifiedImage, matchingScoreThreshold: 0.8);
                Console.WriteLine(
                    "VerifyImages \n\t" +
                    $"Status: [{ BiometricInThings.Client.Utils.ListOfStringsToString(verifiedImages.VerifyImagesStatus)}] \n\t" +
                    $"MatchingScore: {verifiedImages.MatchingScore}"
                    );

            }
            catch (Exception)
            {

                throw;
            }
            
            return 1;
        }
    }
}
