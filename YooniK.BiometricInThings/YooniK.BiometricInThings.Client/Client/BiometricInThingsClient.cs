using System;
using System.Net.Http;
using System.Threading.Tasks;
using YooniK.BiometricInThings.Models.Requests;
using YooniK.BiometricInThings.Models.Responses;
using YooniK.Services.Client;
using YooniK.Services.Client.Common;

namespace YooniK.BiometricInThings.Client
{
    public static class BiometricInThingsEndpoints
    {
        public const string Capture = "bit/capture";
        public const string Status = "bit/status";
        public const string Verify = "bit/verify";
        public const string VerifyImages = "bit/verify_images";
    }

    public enum StatusEnum
    {
        NotAvailable = 0,
        Available = 1
    }

    public class BiometricInThingsClient
    {
        private IServiceClient _serviceClient;

        public BiometricInThingsClient(IConnectionInformation connectionInformation)
        {
            _serviceClient = new ServiceClient(connectionInformation);
        }


        /// <summary>
        ///      Checks for the camera status.
        /// </summary>
        /// <returns><see cref="Task"/></returns>
        public async Task<StatusEnum> StatusAsync()
        {
            try
            {
                   var message = new RequestMessage(
                    httpMethod: HttpMethod.Get,
                    urlRelativePath: BiometricInThingsEndpoints.Status
                );

                await _serviceClient.SendRequestAsync(message);
                return StatusEnum.Available;
            }
            catch (HttpRequestException httpRequestException)
            {
                if (httpRequestException.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
                    return StatusEnum.NotAvailable;
                throw;
            }
            catch (Exception exception)
            {
                throw;
            }
        }


        /// <summary>
        ///     Provides a live captured frame from the devices camera in base 64 format and its quality metrics.
        /// </summary>
        /// <param name="captureTimeOutInSeconds"> Capture timeout in seconds. </param>
        /// <param name="antiSpoofing"> Activates anti-spoofing detection. </param>
        /// <param name="liveQualityAnalysis"> Activate ISO/ICAO-19794-5 face quality compliance checks on the live face images. </param>
        /// <returns><see cref="CaptureResponse"/></returns>
        public async Task<CaptureResponse> CaptureAsync(float captureTimeOutInSeconds = 10, bool antiSpoofing = true, bool liveQualityAnalysis = false)
        {
            try
            {
                if (captureTimeOutInSeconds < 0)
                    throw new ArgumentOutOfRangeException(nameof(captureTimeOutInSeconds), captureTimeOutInSeconds, "Value must be greater then 0");
         
                var capture = new CaptureRequest()
                {
                    CaptureTimeOut = captureTimeOutInSeconds,
                    AntiSpoofing = antiSpoofing,
                    LiveQualityAnalysis = liveQualityAnalysis,
                };

                var message = new RequestMessage(
                    httpMethod: HttpMethod.Post,
                    urlRelativePath: BiometricInThingsEndpoints.Capture,
                    request: capture
                );

                return await _serviceClient.SendRequestAsync<CaptureResponse>(message);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        ///     Captures a live frame from the camera and cross examines with the reference image.
        /// </summary>
        /// <param name="referenceImage"> Image in base 64 format. </param>
        /// <param name="captureTimeOutInSeconds"> Capture timeout in seconds. </param>
        /// <param name="matchingScoreThreshold"> Defines the minimum acceptable score for a positive match. </param>
        /// <param name="antiSpoofing"> Activate anti-spoofing detection. </param>
        /// <param name="liveQualityAnalysis"> Activate ISO/ICAO-19794-5 face quality compliance checks on the live face images. </param>
        /// <param name="referenceQualityAnalysis"> Activate ISO/ICAO-19794-5 face quality compliance checks on the image. </param>
        /// <returns><see cref="VerifyResponse"/></returns>
        public async Task<VerifyResponse> VerifyAsync(string referenceImage, float captureTimeOutInSeconds = 10, double matchingScoreThreshold = 0.4, bool antiSpoofing = true, bool liveQualityAnalysis = false, bool referenceQualityAnalysis = false)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(referenceImage))
                    throw new ArgumentException(nameof(referenceImage));

                if (captureTimeOutInSeconds < 0)
                    throw new ArgumentOutOfRangeException(nameof(captureTimeOutInSeconds), captureTimeOutInSeconds, "Value must be greater then 0");

                var verify = new VerifyRequest()
                {
                    CaptureTimeOut = captureTimeOutInSeconds,
                    ReferenceImage = referenceImage,
                    MatchingScoreThreshold = matchingScoreThreshold,
                    AntiSpoofing = antiSpoofing,
                    LiveQualityAnalysis = liveQualityAnalysis,
                    ReferenceQualityAnalysis = referenceQualityAnalysis,
                };

                var message = new RequestMessage(
                    httpMethod: HttpMethod.Post,
                    urlRelativePath: BiometricInThingsEndpoints.Verify,
                    request: verify
                );

                return await _serviceClient.SendRequestAsync<VerifyResponse>(message);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        ///     Performs face matching between the two provided images.
        /// </summary>
        /// <param name="firstImage"> Image in base 64 format. </param>
        /// <param name="secondImage"> Image in base 64 format. </param>
        /// <param name="matchingScoreThreshold"> Defines the minimum acceptable score for a positive match. </param>
        /// <returns><see cref="VerifyImagesResponse"/></returns>
        public async Task<VerifyImagesResponse> VerifyImagesAsync(string firstImage, string secondImage, double matchingScoreThreshold = 0.4)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(firstImage))
                    throw new ArgumentException(nameof(firstImage));

                if (string.IsNullOrWhiteSpace(secondImage))
                    throw new ArgumentException(nameof(secondImage));

                var verifyImages = new VerifyImagesRequest()
                {
                    ProbeImage = firstImage,
                    ReferenceImage = secondImage,
                    MatchingScoreThreshold = matchingScoreThreshold,
                };

                var message = new RequestMessage(
                    httpMethod: HttpMethod.Post,
                    urlRelativePath: BiometricInThingsEndpoints.VerifyImages,
                    request: verifyImages
                );

                return await _serviceClient.SendRequestAsync<VerifyImagesResponse>(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
