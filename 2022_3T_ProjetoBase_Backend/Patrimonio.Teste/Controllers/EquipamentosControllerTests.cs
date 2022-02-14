using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace Patrimonio.Teste.Controllers
{
    public class EquipamentosControllerTests
    {
        [Fact]
        public void Deve_Retornar_Lista_De_Equipamentos()
        {
            // Pré-Condição / Arrange
            List<Equipamento> listaEquipamentoFake = new List<Equipamento>();
            Equipamento equipamentofake = new Equipamento();

            equipamentofake.Ativo = true;
            equipamentofake.NomePatrimonio = "Teste";
            equipamentofake.Descricao = "NãoSeiOQuePor";
            equipamentofake.Imagem = "cc822da5-3731-45eb-be5e-0610970209f6.png";
            equipamentofake.DataCadastro = DateTime.Now;

            listaEquipamentoFake.Add(equipamentofake);

            var fakeRepo = new Mock<IEquipamentoRepository>();
            fakeRepo.Setup(x => x.Listar())
                .Returns(listaEquipamentoFake);

            var controller = new EquipamentosController(fakeRepo.Object);

            // Procedimento / Act
            var resultado = controller.GetEquipamentos();

            // Resultado Esperado / Assert
            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}
