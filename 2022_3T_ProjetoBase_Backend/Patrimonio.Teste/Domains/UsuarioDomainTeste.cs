using Patrimonio.Domains;
using Xunit;

namespace Patrimonio.Teste.Domains
{
    public class UsuarioDomainTeste
    {
        [Fact] // Descrição
        public void Deve_Retornar_Usuario()
        {
            // Pré-Condição
            Usuario usuario = new Usuario();
            usuario.Email = "paulo@email.com";
            usuario.Senha = "123456789";

            // Procedimento
            bool resultado = true;

            if (usuario.Senha == null || usuario.Email == null)
            {
                resultado = false;
            }

            // Resultado
            Assert.True(resultado);
        }

    }
}
