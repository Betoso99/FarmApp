using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Models
{
	public class Products
	{
		[JsonProperty("ProductName")]
		public string ProductName { get; set; }
		[JsonProperty("Quantity")]
		public string Quantity { get; set; }
		[JsonProperty("Price")]
		public string Price { get; set; }
	}
}
