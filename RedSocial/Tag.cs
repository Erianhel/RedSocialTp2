using System;
using System.Collections.Generic;


namespace RedSocial
{
	public class Tag
	{

		public int id { get; set; }
		public string palabra { get; set; }
		public List<Post> posts { get; set; } = new List<Post>();
		public int idPost { get; set; }

		public Tag(int id, string palabra)
		{
		this.id = id;
		this.palabra = palabra;		
		}

		public Tag(string palabra)
        {
			this.palabra= palabra;
        }
	}
}
