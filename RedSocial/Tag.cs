using System;
using System.Collections.Generic;


namespace RedSocial
{
	public class Tag
	{

		public int id { get; set; }

		public string palabra { get; set; }

		public List<Post> posts { get; set; } = new List<Post>();

		static public int cantidadTag = 0;

		public Tag(string palabra)
		{
			this.id = cantidadTag;
			this.palabra = palabra;
			cantidadTag++;
		}
	}
}
