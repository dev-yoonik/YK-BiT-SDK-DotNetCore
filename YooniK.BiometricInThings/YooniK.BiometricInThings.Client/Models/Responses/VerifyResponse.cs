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
  public class VerifyResponse {
    /// <summary>
    /// Face matching confidence. Varies between -1 (totally different) to 1 (totally equal). 
    /// </summary>
    /// <value>Face matching confidence. Varies between -1 (totally different) to 1 (totally equal). </value>
    [DataMember(Name="matching_score", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "matching_score")]
    public double? MatchingScore { get; set; }

    /// <summary>
    /// JPG base 64 string thumbnail of the live matched image
    /// </summary>
    /// <value>JPG base 64 string thumbnail of the live matched image</value>
    [DataMember(Name="verified_image", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "verified_image")]
    public string VerifiedImage { get; set; }

    /// <summary>
    /// Face verification status
    /// </summary>
    /// <value>Face verification status</value>
    [DataMember(Name="verify_status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "verify_status")]
    public List<string> VerifyStatus { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class VerifyResponse {\n");
      sb.Append("  MatchingScore: ").Append(MatchingScore).Append("\n");
      sb.Append("  VerifiedImage: ").Append(VerifiedImage).Append("\n");
      sb.Append("  VerifyStatus: ").Append(Utils.ListOfStringsToString(VerifyStatus)).Append("\n");
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
