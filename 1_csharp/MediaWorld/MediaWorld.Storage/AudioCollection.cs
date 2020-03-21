using System.Collections.Generic;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Models;

namespace MediaWorld.Storage
{
  public class AudioCollection
  {
    private AMedia[] _audioArray;
    private List<AMedia> _audioList; // List<T>
    private Dictionary<string, AMedia> _audioDictionary;

    public AudioCollection()
    {
      // _audioArray = new AMedia[1];
      _audioArray = new AMedia[]{ new Song() };
    }

    public IEnumerable<AMedia> Playlist()
    {
      return _audioArray;
    }
  }
}
