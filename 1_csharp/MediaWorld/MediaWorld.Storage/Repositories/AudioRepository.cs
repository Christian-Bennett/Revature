using System.Collections.Generic;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Models;
using MediaWorld.Storage.Adapters;

namespace MediaWorld.Storage.Repositories
{
  public class AudioRepository
  {
    private static readonly List<AAudio> _lib = new List<AAudio>()
    {
      new Song() { Title = "Song 1"},
      new Song() { Title = "Song 2"},
      new Book() { Title = "Book 1"},
      new Book() { Title = "Book 2"}
    };

    public AudioRepository()
    {
      
    }

    public IEnumerable<AMedia> List()
    {
      return _lib;
    }
  }
}
