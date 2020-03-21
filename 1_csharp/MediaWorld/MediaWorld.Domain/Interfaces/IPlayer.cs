using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Interfaces
{
  public interface IPlayer
  {
    void Play(AMedia media);
    void Stop(AMedia media);
  }
}
