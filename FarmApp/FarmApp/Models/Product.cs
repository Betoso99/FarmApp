﻿using Newtonsoft.Json;
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

		[JsonProperty("mg")]
		public int? Mg { get; set; }

		[JsonProperty("administrationForm")]
		public string AdministrationForm { get; set; }

		[JsonProperty("administrationVia")]
		public string AdministrationVia { get; set; }
	}
}
