using MvcApplication.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
	public class AcessoViewModel
	{
		#region Propriedades

		public bool AlunoEncontrado { get; set; }

		public DateTime DataAcesso { get; set; }

		public int NumeroRA { get; set; }

		public string Url
		{
			get
			{
				return Util.MontarUrl(this.NumeroRA);
			}
		}

		#endregion
	}
}