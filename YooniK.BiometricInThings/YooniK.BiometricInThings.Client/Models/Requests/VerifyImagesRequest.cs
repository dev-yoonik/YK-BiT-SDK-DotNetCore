using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using YooniK.Services.Client.Common;

namespace YooniK.BiometricInThings.Models.Requests {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class VerifyImagesRequest : IRequest {
    /// <summary>
    /// JPG base 64 string face image to be matched against reference image.
    /// </summary>
    /// <value>JPG base 64 string face image to be matched against reference image.</value>
    [DataMember(Name="probe_image", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "probe_image")]
    public string ProbeImage { get; set; }

    /// <summary>
    /// JPG base 64 string reference face image.
    /// </summary>
    /// <value>JPG base 64 string reference face image.</value>
    [DataMember(Name="reference_image", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reference_image")]
    public string ReferenceImage { get; set; }

    /// <summary>
    /// Matching score threshold used to verify matching between probe and reference image.
    /// </summary>
    /// <value>Matching score threshold used to verify matching between probe and reference image.</value>
    [DataMember(Name="matching_score_threshold", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "matching_score_threshold")]
    public double? MatchingScoreThreshold { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class VerifyImagesRequest {\n");
      sb.Append("  ProbeImage: ").Append(ProbeImage).Append("\n");
      sb.Append("  ReferenceImage: ").Append(ReferenceImage).Append("\n");
      sb.Append("  MatchingScoreThreshold: ").Append(MatchingScoreThreshold).Append("\n");
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
