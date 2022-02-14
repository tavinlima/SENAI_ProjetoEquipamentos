using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.Utils;

namespace Patrimonio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private readonly IEquipamentoRepository _equipamentoRepository;

        public EquipamentosController(IEquipamentoRepository repo)
        {
            _equipamentoRepository = repo;
        }

        // GET: api/Equipamentos
        [HttpGet]
        public IActionResult GetEquipamentos()
        {
            return Ok(_equipamentoRepository.Listar());
        }

        // GET: api/Equipamentos/5
        [HttpGet("{id}")]
        public IActionResult GetEquipamento(int id)
        {
            var equipamento =  _equipamentoRepository.BuscarPorID(id);

            if (equipamento == null)
            {
                return NotFound();
            }

            return Ok(equipamento);
        }

        // PUT: api/Equipamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutEquipamento(int id, Equipamento equipamento)
        {
            if (id != equipamento.Id)
            {
                return BadRequest();
            }


            try
            {
                _equipamentoRepository.Alterar(equipamento);
                return Ok();
            }
            catch (Exception erro)
            {
                if (equipamento.Id == 0 || equipamento.NomePatrimonio == null)
                {
                    return NotFound(erro);
                }
                else
                {
                    throw;
                }
            }

        }

        // POST: api/Equipamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostEquipamento([FromForm] Equipamento equipamento, IFormFile arquivo)
        {

            #region Upload da Imagem com extensões permitidas apenas
                string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
                string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);

                if (uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado");
                }

                if (uploadResultado == "Extensão não permitida")
                {
                    return BadRequest("Extensão de arquivo não permitida");
                }

                equipamento.Imagem = uploadResultado; 
            #endregion

            // Pegando o horário do sistema
            equipamento.DataCadastro = DateTime.Now;

            _equipamentoRepository.Cadastrar(equipamento);
            

            return Created("Equipamento", equipamento);
        }

        // DELETE: api/Equipamentos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEquipamento(int id)
        {
            var equipamentoBuscado = _equipamentoRepository.BuscarPorID(id);
            if (equipamentoBuscado == null)
            {
                return NotFound();
            }

            _equipamentoRepository.Excluir(equipamentoBuscado);

            // Removendo Arquivo do servidor
            Upload.RemoverArquivo(equipamentoBuscado.Imagem);

            return Ok();
        }

    }
}
