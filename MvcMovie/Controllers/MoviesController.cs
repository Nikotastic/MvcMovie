using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    // Andamiaje basico para un controlador MVC con vistas usando Entity Framework. Archivos de razor con CRUD 
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;

        // Constructor que recibe el contexto de la base de datos a traves de inyeccion de dependencias
        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            if (_context.Movie == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }
            // LINQ query para obtener los generos de las peliculas
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            // filtrar por cadena de busqueda
            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
            }
            // filtrar por genero de pelicula

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            // crear el ViewModel
            var movieGenreVM = new MovieGenreViewModel
            {
              
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };
            // devolver la vista con el ViewModel
            return View(movieGenreVM);
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // si no se proporciona un id, devuelve NotFound
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                // selecciona la primera pelicula que coincida con el id proporcionado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            // si se encuentra la pelicula, devuelve la vista de detalles con la pelicula
            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        // Editar una pelicula existente
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        // El metodo Edit recibe el id de la pelicula a editar y un objeto Movie con los datos actualizados
        [HttpPost] // especifica que este metodo responde a solicitudes POST
        [ValidateAntiForgeryToken] // protege contra ataques CSRF (Cross-Site Request Forgery)
        // Bind especifica las propiedades que se deben enlazar desde el formulario
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }


        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
