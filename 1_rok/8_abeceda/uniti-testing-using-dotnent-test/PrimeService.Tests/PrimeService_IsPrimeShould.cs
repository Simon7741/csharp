using Xunit;
using Prime.Services;
namespace Prime.UnitTest.Services {
    public class PrimeService_IsPrimeShould{
      [Fact]
      public void IsPrime_InputIs1_RetusnFalse(){
        var primeService = new primeService();
        bool result = primeService.IsPrime(1);

        Assert.False(result, "1 shouln't be prime ");
      }
    }
}
