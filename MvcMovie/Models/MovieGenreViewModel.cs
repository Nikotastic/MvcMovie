using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Models
{
    // modelo de vista del genero de pelicula
    public class MovieGenreViewModel
    {
        // lista de peliculas
        public List<Movie>? Movies { get; set; }
        // lista de generos para el SelectList
        public SelectList? Genres { get; set; }
        // genero de pelicula seleccionado
        public string? MovieGenre { get; set; }
        // cadena de busqueda
        public string? SearchString { get; set; }
    }
}
