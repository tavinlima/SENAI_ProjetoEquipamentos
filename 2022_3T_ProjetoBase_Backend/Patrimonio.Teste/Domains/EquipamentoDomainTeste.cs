using Patrimonio.Domains;
using System;
using Xunit;

namespace Patrimonio.Teste.Domains
{
    public class EquipamentoDomainTeste
    {
        [Fact] // Descrição
        public void Deve_Retornar_Equipamento()
        {
            //Pré-Condição / Arrange
            Equipamento equipamento = new();
            equipamento.Ativo = true;
            equipamento.NomePatrimonio = "Televisão";
            equipamento.Descricao = "123456789";
            equipamento.Imagem = "cc822da5-3731-45eb-be5e-0610970209f6.png";
            equipamento.DataCadastro = DateTime.Now;

            // Procedimento / Act
            bool resultado;

            if (equipamento.NomePatrimonio == null || equipamento.Descricao == null);
            {
                resultado = true;
            }

            // Resultado Esperado / Assert
            Assert.True(resultado);

        }
    }
}
