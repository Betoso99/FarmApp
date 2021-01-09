using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Models
{
	public class User
	{
		[JsonProperty("Name")]
		public string Name { get; set; }
		[JsonProperty("Email")]
		public string Email { get; set; }
		[JsonProperty("Password")]
		public string Pass { get; set; }
		[JsonProperty("Confirmation_Password")]
		public string Pass2 { get; set; }
	}
}
