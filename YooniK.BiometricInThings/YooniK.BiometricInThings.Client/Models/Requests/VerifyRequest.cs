using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using YooniK.Services.Client.Common;

namespace YooniK.BiometricInThings.Models.Requests {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class VerifyRequest : IRequest{
    /// <summary>
    /// Capture timeout in seconds.
    /// </summary>
    /// <value>Capture timeout in seconds.</value>
    [DataMember(Name="capture_time_out", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "capture_time_out")]
    public float? CaptureTimeOut { get; set; }

    /// <summary>
    /// JPG base 64 string reference face image obtained from identification document or any other source.
    /// </summary>
    /// <value>JPG base 64 string reference face image obtained from identification document or any other source.</value>
    [DataMember(Name="reference_image", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reference_image")]
    public string ReferenceImage { get; set; }

    /// <summary>
    /// Matching score threshold used to verify matching between live and reference image.
    /// </summary>
    /// <value>Matching score threshold used to verify matching between live and reference image.</value>
    [DataMember(Name="matching_score_threshold", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "matching_score_threshold")]
    public double? MatchingScoreThreshold { get; set; }

    /// <summary>
    /// Activate anti-spoofing detection.
    /// </summary>
    /// <value>Activate anti-spoofing detection.</value>
    [DataMember(Name="anti_spoofing", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "anti_spoofing")]
    public bool? AntiSpoofing { get; set; }

    /// <summary>
    /// Activate ISO/ICAO-19794-5 face quality compliance checks on the live face images.
    /// </summary>
    /// <value>Activate ISO/ICAO-19794-5 face quality compliance checks on the live face images.</value>
    [DataMember(Name="live_quality_analysis", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "live_quality_analysis")]
    public bool? LiveQualityAnalysis { get; set; }

    /// <summary>
    /// Activate ISO/ICAO-19794-5 face quality compliance checks on the reference_image.
    /// </summary>
    /// <value>Activate ISO/ICAO-19794-5 face quality compliance checks on the reference_image.</value>
    [DataMember(Name="reference_quality_analysis", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reference_quality_analysis")]
    public bool? ReferenceQualityAnalysis { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class VerifyRequest {\n");
      sb.Append("  CaptureTimeOut: ").Append(CaptureTimeOut).Append("\n");
      sb.Append("  ReferenceImage: ").Append(ReferenceImage).Append("\n");
      sb.Append("  MatchingScoreThreshold: ").Append(MatchingScoreThreshold).Append("\n");
      sb.Append("  AntiSpoofing: ").Append(AntiSpoofing).Append("\n");
      sb.Append("  LiveQualityAnalysis: ").Append(LiveQualityAnalysis).Append("\n");
      sb.Append("  ReferenceQualityAnalysis: ").Append(ReferenceQualityAnalysis).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
