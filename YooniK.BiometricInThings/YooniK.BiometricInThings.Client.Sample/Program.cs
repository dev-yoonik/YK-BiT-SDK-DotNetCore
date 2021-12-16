using System;
using System.IO;
using System.Threading.Tasks;
using YooniK.BiometricInThings.Client;
using YooniK.Services.Client.Common;


/* 
 * First time running:
 *  - Run the BiT App
 *  - Run this SDK App
 *  - If the setup was successful:
 *      - Comment the "setup" block
*/

namespace YooniK.BiometricInThings.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string baseUrl = "YOUR-API-ENDPOINT";
            string subscriptionKey = "YOUR-X-API-KEY";

            try
            {
                var bitInformation = new ConnectionInformation(baseUrl, subscriptionKey);
                var bitClient = new BiometricInThingsClient(bitInformation);

                // Setup
                {
                    bool setup_successful = true;
                    try
                    {
                        await bitClient.SetupAsync();
                    }
                    catch (Exception ex)
                    {
                        setup_successful = false;
                        Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                    }
                    finally
                    {
                        Console.WriteLine($"BiT setup successful: {setup_successful}");
                    }
                    return;
                }

                // Validates the availability of the camera
                var status = await bitClient.StatusAsync();
                if (status == BiTStatus.Available)
                {

                    // Captures a live face frame from the camera
                    var captured = await bitClient.CaptureAsync(captureTimeOutInSeconds: 5);
                    Console.WriteLine(
                            "Captured \n\t" +
                            $"Status: [{ BiometricInThings.Client.Utils.ListOfStringsToString(captured.CaptureStatus)}]");
                    if (!string.IsNullOrEmpty(captured.Image))
                    {
                        // Saves the captured frame to file
                        File.WriteAllBytes($"{nameof(captured)}.jpg", Convert.FromBase64String(captured.Image));
                        
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
                }
                else
                    Console.WriteLine($"BiT Camera Status: {status}");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
