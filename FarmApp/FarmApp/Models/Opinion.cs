using Newtonsoft.Json;

namespace FarmApp.Models
{
    public class Opinion
	{
		[JsonProperty("userName")]
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
