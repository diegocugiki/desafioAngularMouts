using System;
using System.Threading.Tasks;
using BackEnd.Data.Interfaces;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioRepositorio _repositorio;
        public MunicipioController(IMunicipioRepositorio repositorio)
        {
            _repositorio = repositorio;
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
                return BadRequest($"Ao obter todos os Municípios, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("{municipioId}")]
        public async Task<IActionResult> ObterPeloId(int municipioId)
        {
            try
            {
                return Ok(await _repositorio.ObterPeloId(municipioId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter o estado pelo ID, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("estadoId={estadoId}")]
        public async Task<IActionResult> ObterPeloEstadoId(int estadoId)
        {
            try
            {
                return Ok(await _repositorio.ObterTodosPeloEstadoId(estadoId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter os municípios pelo estado, ocorreu o erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Salvar(Municipio municipio)
        {
            try
            {
                _repositorio.Adcionar(municipio);
                if (await _repositorio.EfetuouAlteracaoNaBase())
                {
                    return Ok(municipio);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao salvar o município, ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{municipioId}")]
        public async Task<IActionResult> Editar(int municipioId, Municipio municipio)
        {
            try
            {
                var municipioCadastrado = await _repositorio.ObterPeloId(municipioId);

                if (municipioCadastrado == null)
                {
                    return NotFound();
                }

                _repositorio.Atualizar(municipio);

                if (await _repositorio.EfetuouAlteracaoNaBase())
                {
                    return Ok(municipio);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao editar o municipio ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{municipioId}")]
        public async Task<IActionResult> Remover(int municipioId)
        {
            try
            {
                var municipioCadastrado = await _repositorio.ObterPeloId(municipioId);

                if (municipioCadastrado == null)
                {
                    return NotFound();
                }

                _repositorio.Remover(municipioCadastrado);

                if (await _repositorio.EfetuouAlteracaoNaBase())
                {
                    return Ok(
                        new { 
                            message = "Município removido com sucesso!"
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao remover o município ocorreu o erro: {ex.Message}");
            }
            return BadRequest();
        }
    }
}