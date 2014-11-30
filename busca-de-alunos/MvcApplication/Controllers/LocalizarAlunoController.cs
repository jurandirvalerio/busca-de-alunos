using GravadorAcesso;
using MvcApplication.Infra;
using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class LocalizarAlunoController : Controller
    {
		#region Ações
		
		public ActionResult Index()
		{
			ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

			return View("ConsultarAluno");
		}

		public ActionResult ConsultarAluno(int numeroRA = 0)
		{
			ViewBag.Layout = "";

			if(numeroRA != 0)
			{
				ViewBag.NumeroRA = numeroRA;
			}

			return View();
		}

		[HttpPost]
		public JsonResult GravarAcesso(int ra, bool alunoEncontrado)
		{
			Acesso acesso = new Acesso();
			acesso.NumeroRA = ra;
			acesso.DataAcesso = DateTime.Now;
			acesso.AlunoEncontrado = alunoEncontrado;

			iGravadorAcesso.GravarAcesso(PATH, acesso);

			return Json(true);
		}

		public ActionResult ListarConsultas()
		{
			List<Acesso> acessos = iGravadorAcesso.LerUltimosDezAcessos(PATH);

			AcessoMapper acessoMapper = new AcessoMapper();

			List<AcessoViewModel> acessosViewModel = acessoMapper.Mapear(acessos);

			return View(acessosViewModel);
		}

		#endregion

		#region Campos

		private const string PATH = "c:\\temp\\logAcesso.txt";

		private IGravadorAcesso iGravadorAcesso;

		#endregion

		#region Construtor

		public LocalizarAlunoController(IGravadorAcesso iGravadorAcesso)
		{
			this.iGravadorAcesso = iGravadorAcesso;
		}

		#endregion
    }
}