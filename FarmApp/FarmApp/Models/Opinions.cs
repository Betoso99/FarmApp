using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Models
{
	public class Opinions
	{
		[JsonProperty("User_Name")]
		public string Name { get; set; }
		[JsonProperty("Opinion")]
		public string Opinion { get; set; }
	}
}
