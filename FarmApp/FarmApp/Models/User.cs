using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Models
{
	public class User
	{
		public string Name { get; set; }
		public string Email { get; set; }
		[JsonProperty("Password")]
		public string Pass { get; set; }
		[JsonProperty("Confirmation_Password")]
		public string Pass2 { get; set; }
	}
}
