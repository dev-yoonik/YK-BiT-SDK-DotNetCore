using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace YooniK.BiometricInThings.Models.Responses {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class CaptureResponse {
    /// <summary>
    /// JPG Base 64 string face crop according to ISO/ICAO 19794-5 Token.
    /// </summary>
    /// <value>JPG Base 64 string face crop according to ISO/ICAO 19794-5 Token.</value>
    [DataMember(Name="image", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "image")]
    public string Image { get; set; }

    /// <summary>
    /// Face capture result status
    /// </summary>
    /// <value>Face capture result status</value>
    [DataMember(Name="capture_status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "capture_status")]
    public List<string> CaptureStatus { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CaptureResponse {\n");
      sb.Append("  Image: ").Append(Image).Append("\n");
      sb.Append("  CaptureStatus: ").Append(BiometricInThings.Client.Utils.ListOfStringsToString(CaptureStatus)).Append("\n");
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
