using System;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Interfaces;

namespace MediaWorld.Domain.Singletons
{
  // middle step to single object
  // public static class AudioPlayer
  // {
  //   public static void Play()
  //   {
  //     Console.WriteLine("blah");
  //   }
  // }

  public class AudioPlayer : APlayer
  {
    private static AudioPlayer _ap = new AudioPlayer();

    private AudioPlayer() {}

    // final-ish step
    // public static AudioPlayer GetInstance()
    // {
    //   return _ap;
    // }

    // the csharp way
    public static AudioPlayer Instance
    {
      get
      {
        return _ap;
      }
    }
  }
}
