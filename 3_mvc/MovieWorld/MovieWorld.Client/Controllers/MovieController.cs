using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieWorld.Client.Models;

namespace MovieWorld.Client.Controllers
{
  public class MovieController : Controller
  {
    public static readonly List<MovieModel> movies = new List<MovieModel>()
    {
      new MovieModel() { Title = "Super Troopers", Genre = "Comedy" },
      new MovieModel() { Title = "The Matrix", Genre = "SciFi" },
      new MovieModel() { Title = "Ghost In The Shell", Genre = "Anime" }
    };

    [HttpGet]
    public IEnumerable<MovieModel> Get()
    {
      return movies;
    }

    [HttpGet]
    public IActionResult Add()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Add(MovieModel movie)
    {
      if (ModelState.IsValid)
      {
        movies.Add(movie);
        return RedirectToAction("Get");
      }

      return View("Add", movie);
    }

    [HttpPut]
    public void Put()
    {

    }

    [HttpDelete]
    public void Delete()
    {

    }
  }
}