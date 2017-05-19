namespace Application2.Domain.Services
{
	public enum TokenState
	{
		TokenInvalido,
		NaoAutorizado
	}

	public enum EmailState
	{
		EmailInvalido,
		EmailEnviadoComSucesso,
		EmailJaCadastrado
	}

	public enum SenhaState
	{
		SenhaAlteradaComSucesso,
		ErroAoAlterarSenha
	}

	public enum UsuarioState
	{
		UsuarioInvalido
	}

	public enum UsuarioSenhaState
	{
		UsuarioOuSenhasInvalido,
		UsuarioCriadoComSucesso
	}
}
