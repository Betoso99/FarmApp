using Newtonsoft.Json;

namespace FarmApp.Models
{
    public class Review
	{
		[JsonProperty("reviewName")]
		public string Name { get; set; }

		[JsonProperty("reviewDescription")]
		public string Description { get; set; }
	}
}
