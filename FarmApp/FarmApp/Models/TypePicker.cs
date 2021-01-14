using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Models
{
	public class TypePicker
	{
		public string Gender { get; set; }
		public string Selected { get; set; }
	}

	public class CustomDatePicker
	{
		public DateTime? Date { get; set; }
		public string Selected { get; set; }
	}
}
