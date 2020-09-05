using devboost.Domain.Entities;
using Xunit;

namespace devboost.Test.Domain.Entities
{
    public class GEOCalculaDistanciaTest
    {
        [Theory]
        [InlineData(-23.5880684, -46.6564195, -23.5990684, -46.6784195, 2.5536463859394547)]
        [InlineData(-23.5880684, -46.6564195, -23.6990684, -46.6684195, 12.402418218511896)]
        [InlineData(-23.5880684, -46.6564195, -23.5990684, -46.6684195, 1.7294595390139109)]
        public void TestaCalculaDistancia(double latitudeOrigem, double longitudeOrigem, double latitudeDestino, double longitudeDestino, double resultado)
        {
            var result = GEOCalculaDistancia.CalculaDistanciaEmKM(new GEOParams(latitudeOrigem, longitudeOrigem, latitudeDestino, longitudeDestino));
            Assert.Equal(resultado, result);
        }
    }
}
