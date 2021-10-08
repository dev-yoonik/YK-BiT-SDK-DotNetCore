using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using YooniK.BiometricInThings.Client;

namespace YooniK.BiometricInThings.Models.Responses {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class VerifyImagesResponse {
    /// <summary>
    /// Face matching confidence. Varies between -1 (totally different) to 1 (totally equal).
    /// </summary>
    /// <value>Face matching confidence. Varies between -1 (totally different) to 1 (totally equal).</value>
    [DataMember(Name="matching_score", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "matching_score")]
    public double? MatchingScore { get; set; }

    /// <summary>
    /// Face matching status
    /// </summary>
    /// <value>Face matching status</value>
    [DataMember(Name="verify_images_status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "verify_images_status")]
    public List<string> VerifyImagesStatus { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class VerifyImagesResponse {\n");
      sb.Append("  MatchingScore: ").Append(MatchingScore).Append("\n");
      sb.Append("  VerifyImagesStatus: ").Append(Utils.ListOfStringsToString(VerifyImagesStatus)).Append("\n");
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
