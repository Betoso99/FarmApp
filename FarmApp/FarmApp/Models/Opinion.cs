using Newtonsoft.Json;

namespace FarmApp.Models
{
    public class Opinion
	{
		[JsonProperty("User_Name")]
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
