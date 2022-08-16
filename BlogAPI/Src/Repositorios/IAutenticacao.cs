using BlogAPI.Src.Modelos;
using System.Threading.Tasks;

namespace BlogAPI.Src.Repositorios
{
    /// <summary>
    /// <para>Resumo: Interface responsável por representar ações de autenticação</para>
    /// <para>Criado por: Generation</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/05/2022</para>
    /// </summary>
    public interface IAutenticacao
    {
        string CodificarSenha(string senha);
        Task CriarUsuarioSemDuplicarAsync(Usuario usuario);
        string GerarToken(Usuario usuario);
    }
}
