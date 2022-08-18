using BlogAPI.Src.Contextos;
using BlogAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Src.Repositorios.Implementacoes
{
    public class UsuarioRepositorio : IUsuario
    {
        #region Atributos
        private readonly BlogPessoalContexto _contexto;
        #endregion

        #region Contrutores
        public UsuarioRepositorio(BlogPessoalContexto contexto)
        {
            _contexto = contexto;
        }
        #endregion

        #region Metodo
        /// <summary>
        /// <para> Método assincrono para salvar um novo usuario</para>
        /// </summary>
        /// <param name="usuario">Construtor para cadastrar usuario</param>
        public async Task NovoUsuarioAsync(Usuario usuario)
        {
            await _contexto.Usuarios.AddAsync(new Usuario {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Foto = usuario.Foto,
                Tipo = usuario.Tipo
            });
            await _contexto.SaveChangesAsync();
        }

        /// <summary>
        /// <para> Método assíncrono para pegar um usuario pelo email</para>
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <returns>UsuarioModelo</returns>
        public async Task<Usuario> PegarUsuarioPeloEmailAsync(string email)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
        #endregion
    }
}
