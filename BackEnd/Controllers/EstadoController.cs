using System;
using System.Threading.Tasks;
using BackEnd.Data.Interfaces;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EstadoController : ControllerBase
    {
        private readonly IEstadoRepositorio _repositorio;
        public EstadoController(IEstadoRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                return Ok(await _repositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos os Estados, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("{estadoId}")]
        public async Task<IActionResult> ObterPeloId(int estadoId)
        {
            try
            {
                return Ok(await _repositorio.ObterPeloId(estadoId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter o estado pelo ID, ocorreu o erro: {ex.Message}");
            }
        }

         [HttpGet("municipioId={municipioId}")]
        public async Task<IActionResult> ObterPeloMunicipioId(int municipioId)
        {
            try
            {
                return Ok(await _repositorio.ObterPeloMunicipioId(municipioId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter o estado pelo municipio, ocorreu o erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Salvar(Estado estado)
        {
            try
            {
                _repositorio.Adcionar(estado);
                if (await _repositorio.EfetuouAlteracaoNaBase())
                {
                    return Ok(estado);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao salvar o estado, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{estadoId}")]
        public async Task<IActionResult> Editar(int estadoId, Estado estado)
        {
            try
            {
                var estadoCadastrado = await _repositorio.ObterPeloId(estadoId);

                if (estadoCadastrado == null)
                {
                    return NotFound();
                }

                _repositorio.Atualizar(estado);

                if (await _repositorio.EfetuouAlteracaoNaBase())
                {
                    return Ok(estado);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao editar o estado ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{estadoId}")]
        public async Task<IActionResult> Remover(int estadoId)
        {
            try
            {
                var estadoCadastrado = await _repositorio.ObterPeloId(estadoId);

                if (estadoCadastrado == null)
                {
                    return NotFound();
                }

                _repositorio.Remover(estadoCadastrado);

                if (await _repositorio.EfetuouAlteracaoNaBase())
                {
                    return Ok(
                        new { 
                            message = "Estado removido com sucesso!"
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao remover o estado ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }
    }
}