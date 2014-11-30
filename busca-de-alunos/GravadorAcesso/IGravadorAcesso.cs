using System.Collections.Generic;

namespace GravadorAcesso
{
	public interface IGravadorAcesso
	{
		/// <summary>
		/// Grava uma instância de um objeto do tipo acesso em um arquivo de texto
		/// </summary>
		/// <param name="fullPath"></param>
		/// <param name="acesso"></param>
		void GravarAcesso(string fullPath, Acesso acesso);

		/// <summary>
		/// Lê os últimos dez registros do tipo acesso em um arquivo de texto e retorna-os em uma lista
		/// </summary>
		/// <param name="fullPath"></param>
		/// <returns></returns>
		List<Acesso> LerUltimosDezAcessos(string fullPath);
	}
}