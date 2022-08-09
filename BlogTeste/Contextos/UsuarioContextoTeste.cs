using BlogAPI.Src.Contextos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogTeste.Contextos
{
    ///<summary>
    ///
    /// </summary>
    [TestClass]
    public class UsuarioContextoTeste
    {
        #region Atributos

        private BlogPessoalContexto _contexto;

        #endregion

        #region Métodos
        [TestMethod]
        public void InserirNovoUsuarioRetornaUsuarioInserido()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT1")
                .Options;

            _contexto = new BlogPessoalContexto(opt);

            // DADO - Dado que adiciono um usuario no sistema
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Rafael Candeias",
                Email = "rafael@email.com",
                Senha = "1234",
                Foto = "UrlFotoRafael",
            });
            _contexto.SaveChanges();

            // QUANDO - Quando eu pesquiso pelo e-mail do usuario adicionado
            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Email == "rafael@email.com");

            // ENTÃO - Então deve retornar resultado não nulo
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void LerListaDeUsuariosRetornaTresUsuarios()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT2")
                .Options;

            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Beah",
                Email = "beah@email.com",
                Senha = "1234",
                Foto = "UrlFotoBeah"
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Mauricio",
                Email = "mauricio@email.com",
                Senha = "1234",
                Foto = "UrlFotoMau"
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Jesus",
                Email = "jesus@email.com",
                Senha = "1234",
                Foto = "UrlFotoJesus"
            });
            _contexto.SaveChanges();

            var resultado = _contexto.Usuarios.ToList();

            Assert.AreEqual(3, resultado.Count);
        }

        [TestMethod]
        public void AtualizarUsuarioRetornaUsuarioAtualizado()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT3")
                .Options;

            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Rafael Candeias",
                Email = "rafael@email.com",
                Senha = "1234",
                Foto = "UrlFotoRafael"
            });
            _contexto.SaveChanges();

            var auxiliar = _contexto.Usuarios.FirstOrDefault(u => u.Email == "rafael@email.com");
            auxiliar.Nome = "Rafael Carmo";
            _contexto.Usuarios.Update(auxiliar);
            _contexto.SaveChanges();

            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Nome == "Rafael Carmo");

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void DeletaUsurarioRetornaUsuarioInserido()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT4")
                .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Rafael Candeias",
                Email = "rafael@email.com",
                Senha = "1234",
                Foto = "UrlFotoRafael"
            });
            _contexto.SaveChanges();

            var auxiliar = _contexto.Usuarios.FirstOrDefault(u => u.Email == "rafael@email.com");
            _contexto.Usuarios.Remove(auxiliar);
            _contexto.SaveChanges();

            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Nome == "Rafael Candeias");

            Assert.IsNull(resultado);
        }
        #endregion
    }
}