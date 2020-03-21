using System.Collections.Generic;
using System.Linq;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Storage.Adapters;
using Xunit;

namespace MediaWorld.Testing.AudioTests
{
  public class ReadUnit
  {
    private IEnumerable<AMedia> fa = FileAdapter.Read("../../../../medialib.xml");

    [Fact]
    public void Test_ReturnsList()
    {
      // arrange
      var sut = new FileAdapter();
      var expected = 0;

      // act
      var actual = fa;

      // assert
      Assert.True(expected <= actual.Count());
    }

    [Fact]
    public void Test_ReturnsNull()
    {
      var actual = fa;

      Assert.False(actual == null);
    }
  }
}
