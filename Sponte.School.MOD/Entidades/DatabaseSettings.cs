using System;
using System.Collections.Generic;
using System.Text;

namespace Sponte.School.MOD.Entidades
{
	public class DatabaseSettings
	{
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
		public Dictionary<string, string> CollectionNames { get; set; }
	}
}
