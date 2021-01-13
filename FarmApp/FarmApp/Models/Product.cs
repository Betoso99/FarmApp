using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Models
{
	public class Product
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
		
		[JsonProperty("quantity")]
		public string Quantity { get; set; }
		
		[JsonProperty("price")]
		public string Price { get; set; }
	}
}
