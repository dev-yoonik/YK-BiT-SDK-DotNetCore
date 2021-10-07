using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using YooniK.Services.Client.Common;
using YooniK.BiometricInThings.Tests.DataExamples;

namespace YooniK.BiometricInThings.Client.Tests
{
    public class BiometricInThingsTests
    {
        private BiometricInThingsClient bitClient;

        private string baseUrl = Valid.BaseUrl;
        private string subscritionKey = Valid.SubscriptionKey;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var connectionInformation = new ConnectionInformation(baseUrl, subscritionKey);
            bitClient = new BiometricInThingsClient(connectionInformation);
        }

        [Test]
        public async Task CaptureAsync_ValidParameters_Success()
        {
            var captured = await bitClient.CaptureAsync();
            Assert.IsNotNull(captured.Image);
        }

        [Test]
        public void CaptureAsync_InvalidCaptureTimeOutParameters_ThrownsException()
        {
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await bitClient.CaptureAsync(captureTimeOutInSeconds: -10.0f));
        }

        [Test]
        public void StatusAsync_CurrentCameraStatus_NotFixedOutput()
        {
            Assert.DoesNotThrowAsync(async() => await bitClient.StatusAsync());
        }

        [Test]
        public async Task VerifyAsync_ValidParameters_Success()
        {
            var response = await bitClient.VerifyAsync(Valid.Base64Image);
            Assert.IsNotNull(response.MatchingScore);
        }
        
        [Test]
        public void VerifyAsync_InvalidParameters_Success()
        {
            var httpException = Assert.ThrowsAsync<HttpRequestException>(async () => await bitClient.VerifyAsync(Invalid.Base64Image));
            Assert.AreEqual(httpException.StatusCode, HttpStatusCode.BadRequest);

        }

        [Test]
        public async Task VerifyImagesAsync_ValidParameters_Success()
        {
            var response = await bitClient.VerifyImagesAsync(Valid.Base64Image, Valid.Base64Image, 0.9f);
            Assert.IsNotNull(response.MatchingScore);
        }

        [Test]
        public void VerifyImagesAsync_InvalidParameters_Success()
        {
            Assert.ThrowsAsync<HttpRequestException>( async () =>
                await bitClient.VerifyImagesAsync(Valid.Base64Image, Invalid.Base64Image, 0.7f)
            );
        }

    }
}