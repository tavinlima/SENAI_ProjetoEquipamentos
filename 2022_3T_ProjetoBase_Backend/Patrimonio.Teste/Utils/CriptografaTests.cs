using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Patrimonio.Teste.Utils
{
    public class CriptografaTests
    {
        [Fact]
        public void Deve_Retornar_Hash_Em_BCrypt()
        {
            // Pré-Condição / Arrange
            var senha = Criptografia.GerarHash("NaoSeiOquePor12344");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");

            // Procedimento / Act
            var retorno = regex.IsMatch(senha);

            // Resultado esperado / Assert
            Assert.True(retorno);

        }

        [Fact]
        public void Deve_Retornar_Comparacao_Valida()
        {
            // Pré-Condição
            var senha = "123456789";
            var hashBanco = "$2a$11$gjQuTcaVQ8E/CiAqy0YCcugSy33H.Fp3mgnJ1TVTA2UQpI4g9X7DW";

            // Procedimento
            var comparacao = Criptografia.Comparar(senha, hashBanco);

            // Resultado esperado
            Assert.True(comparacao);

        }
    }
}
