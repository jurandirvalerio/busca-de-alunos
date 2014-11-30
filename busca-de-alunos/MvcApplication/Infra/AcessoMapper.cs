using GravadorAcesso;
using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Infra
{
	public class AcessoMapper
	{
		#region Métodos

		public AcessoViewModel Mapear(Acesso acesso)
		{
			AcessoViewModel acessoViewModel = new AcessoViewModel();

			acessoViewModel.NumeroRA = acesso.NumeroRA;

			acessoViewModel.DataAcesso = acesso.DataAcesso;

			acessoViewModel.AlunoEncontrado = acesso.AlunoEncontrado;

			return acessoViewModel;
		}

		public List<AcessoViewModel> Mapear(List<Acesso> acessos)
		{
			List<AcessoViewModel> acessosViewModel = new List<AcessoViewModel>();

			foreach (var acesso in acessos)
			{
				acessosViewModel.Add(Mapear(acesso));
			}

			return acessosViewModel;
		}

		#endregion
	}
}