using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Security;
using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Repository;
using Application2.Domain.Interfaces.Service;
using RestSharp;

namespace Application2.Domain.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly ICriptografia _criptografia;
		private readonly IGerenciadorEmail _gerenciadorEmail;
		private readonly IConfiguration _configuration;
		private readonly IEnviadorEmail _enviadorEmail;
		private readonly IRestClientDomain _restClient;
	

		public UsuarioService(IUsuarioRepository usuarioRepository, ICriptografia criptografia,
			IGerenciadorEmail gerenciadorEmail, IConfiguration configuration, IEnviadorEmail enviadorEmail,
			IRestClientDomain restClient)
		{
			_usuarioRepository = usuarioRepository;
			_criptografia = criptografia;
			_gerenciadorEmail = gerenciadorEmail;
			_configuration = configuration;
			_enviadorEmail = enviadorEmail;
			_restClient = restClient;
		}

		public void Dispose()
		{
			_usuarioRepository.Dispose();
			GC.SuppressFinalize(this);
		}

		public Usuario Adicionar(Usuario obj)
		{
			return _usuarioRepository.Adicionar(obj);
		}

		public Usuario ObterPorId(Guid id)
		{
			return _usuarioRepository.ObterPorId(id);
		}

		public IEnumerable<Usuario> ObterTodos()
		{
			return _usuarioRepository.ObterTodos();
		}

		public Usuario Atualizar(Usuario obj)
		{
			return _usuarioRepository.Atualizar(obj);
		}

		public void Remover(Guid id)
		{
			_usuarioRepository.Remover(id);
		}

		public int SaveChanges()
		{
			return _usuarioRepository.SaveChanges();
		}

		public string ValidarToken(string token, string id)
		{
			var usuario = _usuarioRepository.ObterPorId(new Guid(id));
			return ValidadorToken(token, usuario, _configuration.ObterTempoLogado());
		}

		public string ValidadorToken(string token, Usuario usuario, int tempologado)
		{
			var retorno = "";
			var verificadoNaoAutorizado = new VerificaNaoAutorizado();
			var retornaValidacao = new RetornoValidacao();
			verificadoNaoAutorizado.Proximo = retornaValidacao;

			return verificadoNaoAutorizado.Validacao(token, usuario, retorno, tempologado);
		}

		public bool VerificarEmail(string email)
		{
			return _usuarioRepository.Get(f => f.Email.Equals(email)) != null;
		}

		public bool VerificarEmailESenha(string loginEmail, string hash)
		{
			return _usuarioRepository.Get(f => f.Email.Equals(loginEmail) && f.Senha.Equals(hash)) != null;
		}

		public bool Autenticar(string loginEmail, string hash)
		{
			var usuario = _usuarioRepository.Get(f => f.Email.Equals(loginEmail) && f.Senha.Equals(hash));
			if (usuario == null) return false;
			var token = AutalizarToken(usuario);
			if (string.IsNullOrEmpty(token))
				return false;
			FormsAuthentication.SetAuthCookie(token, false);
			return true;
		}

		public string AutalizarToken(Usuario usuario)
		{
			var token = ObterToken(usuario);
			usuario.Token = token;
			_usuarioRepository.Atualizar(usuario);
			return token;
		}

		public string ObterToken(Usuario usuario)
		{
			var client = _restClient.NovaConexao();
			var request = new RestRequest("api/security/token", Method.POST);
			request.AddParameter("grant_type", "password");


			var response = client.Execute<TokenData>(request);
			var token = response.Data.AccessToken;

			if (!string.IsNullOrEmpty(token))
				FormsAuthentication.SetAuthCookie(token, false);
			return token;
		}

		public Usuario Get(Func<Usuario, bool> func)
		{
			return _usuarioRepository.Get(func);
		}

		public Usuario EnviarToken(string loginEmail, string token)
		{
			var usuario = _usuarioRepository.Get(f => f.Email.Equals(loginEmail));
			var dadosEmail = _gerenciadorEmail.EnviarEmail(usuario, token);
			_enviadorEmail.EnviarTokenPorEmail(dadosEmail);
			return usuario;
		}

		public bool NovaSenha(Usuario usuario, string token)
		{
			try
			{
				var usuario2 = CriarSenhaHash(usuario.UsuarioId.ToString(), usuario.Senha);
				usuario2.Token = token;
				_usuarioRepository.Atualizar(usuario2);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private Usuario CriarSenhaHash(string id, string senha)
		{
			var usuario = _usuarioRepository.ObterPorId(new Guid(id));
			usuario.Senha = _criptografia.Hash(senha);
			return usuario;
		}
	}
}