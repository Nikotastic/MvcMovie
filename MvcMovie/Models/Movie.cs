using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;
    public class Movie
    {
        public int Id { get; set; }
        // DataAnnotations para validacion y formato de datos
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        
        // ReleaseData especifica el dato de Date. No es necesario que ingrese la hora en la fecha. Solo muestra la fecha
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")] // Solo letras y espacios, empieza con mayuscula
    [Required]
        [StringLength(30)]
        public string? Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")] // Empieza con mayuscula, letras, numeros, espacios y algunos caracteres especiales
        [Required]
        [StringLength(5)]
        public string? Rating { get; set; }
}
