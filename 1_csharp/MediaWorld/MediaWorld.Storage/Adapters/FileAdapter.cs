using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Models;

namespace MediaWorld.Storage.Adapters
{
  public class FileAdapter
  {
    private static string _path = @"../medialib.xml";
    
    public static IEnumerable<AMedia> Read(string path = null)
    {
      var p = path ?? _path; 

      // path = path == null ? _path : path;

      // if (path == null) {
      //   path = _path;
      // }

      var reader = new StreamReader(p);
      var xml = new XmlSerializer(typeof(List<AMedia>), new []{typeof(Book), typeof(Song)});

      return xml.Deserialize(reader) as List<AMedia>;
    }

    public static bool Write(List<AMedia> lib)
    {
      using(var writer = new StreamWriter(_path))
      {
        var xml = new XmlSerializer(typeof(List<AMedia>), new []{typeof(Book), typeof(Song)});

        xml.Serialize(writer, lib);
        return true;
      }
    }
  }
}
