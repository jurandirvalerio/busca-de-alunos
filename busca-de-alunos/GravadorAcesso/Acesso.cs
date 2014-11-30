using System;

namespace GravadorAcesso
{
	[Serializable]
	public class Acesso
	{
		#region Propriedades

		public bool AlunoEncontrado { get; set; }

		public DateTime DataAcesso { get; set; }

		public int NumeroRA { get; set; }

		#endregion
	}
}