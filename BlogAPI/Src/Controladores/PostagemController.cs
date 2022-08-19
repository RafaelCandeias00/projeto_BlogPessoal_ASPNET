﻿using BlogAPI.Src.Repositorios;
using BlogAPI.Src.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BlogAPI.Src.Controladores
{
    [ApiController]
    [Route("api/Postagens")]
    [Produces("application/json")]
    public class PostagemController : ControllerBase
    {
        #region Atributos
        private readonly IPostagem _repositorio;
        #endregion

        #region Construtores
        public PostagemController(IPostagem repositorio) 
        { 
            _repositorio = repositorio; 
        }
        #endregion

        #region Métodos
        /// <summary> 
        /// Pegar todas as postagens
        /// </summary> 
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> PegarTodasPostagemAsync()
        {
            var lista = await _repositorio.PegarTodasPostagemAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        /// <summary> 
        /// Pegar postagem pelo Id
        /// </summary> 
        [HttpGet("id/{idPostagem}")]
        [Authorize]
        public async Task<ActionResult> PegarPostagemPeloIdAsync([FromRoute] int idPostagem)
        {
            try
            {
                return Ok(await _repositorio.PegarPostagemPeloIdAsync(idPostagem));
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

        /// <summary> 
        /// Criar nova postagem
        /// </summary> 
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> NovaPostagemAsync([FromRoute] Postagem postagem)
        {
            try
            {
                await _repositorio.NovaPostagemAsync(postagem);
                return Created($"api/Postagens", postagem);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        /// <summary> 
        /// Atualizar Postagem
        /// </summary> 
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> AtualizarPostagemAsync([FromRoute] Postagem postagem)
        {
            try
            {
                await _repositorio.AtualizarPostagemAsync(postagem);
                return Ok(postagem);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        /// <summary> 
        /// Deletar postagem
        /// </summary> 
        [HttpDelete("deletar/{idPostagem}")]
        [Authorize]
        public async Task<ActionResult> DeletarPostagemAsync([FromRoute] int idPostagem)
        {
            try
            {
                await _repositorio.DeletarPostagemAsync(idPostagem);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }
        #endregion
    }
}
