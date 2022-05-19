

namespace RedSocial
{
	public class Comentario


	{
		public int id { get; set; }
		public Post post { get; set; }
		public Usuario usuario { get; set; }
		public string contenido { get; set; }
		public DateTime fecha { get; set; }

		static public int cantidadComentario = 0;

		public Comentario(Post post, Usuario usuario, string contenido, DateTime fecha)
		{

			this.id = cantidadComentario;
			this.post = post;
			this.usuario = usuario;
			this.contenido = contenido;
			this.fecha = fecha;

			cantidadComentario++;

		}


	}
}
