using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication;
using MvcApplication.Controllers;
using Moq;
using GravadorAcesso;

namespace MvcApplicationTests
{
	[TestClass]
	public class LocalizarAlunoControllerTest
	{
		#region Métodos

		[TestMethod]
		public void IndexTest()
		{
			//Arrange
			var gravadorAcesso = new Mock<GravadorAcesso.IGravadorAcesso>();
			var localizarAlunoController = new LocalizarAlunoController(gravadorAcesso.Object);

			// Act
			ViewResult result = localizarAlunoController.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void ConsultarAlunoTest()
		{
			//Arrange
			var gravadorAcesso = new Mock<GravadorAcesso.IGravadorAcesso>();
			var localizarAlunoController = new LocalizarAlunoController(gravadorAcesso.Object);

			// Act
			ViewResult result = localizarAlunoController.ConsultarAluno() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void ConsultarAlunoComRATest()
		{
			//Arrange
			var gravadorAcesso = new Mock<GravadorAcesso.IGravadorAcesso>();
			var localizarAlunoController = new LocalizarAlunoController(gravadorAcesso.Object);
			int numeroRA = 123;

			// Act
			ViewResult result = localizarAlunoController.ConsultarAluno(numeroRA) as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void ConsultarAlunoSemRATest()
		{
			//Arrange
			var gravadorAcesso = new Mock<GravadorAcesso.IGravadorAcesso>();
			var localizarAlunoController = new LocalizarAlunoController(gravadorAcesso.Object);

			// Act
			ViewResult result = localizarAlunoController.ConsultarAluno() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void ListarConsultaTest()
		{
			//Arrange
			var gravadorAcesso = new Mock<GravadorAcesso.IGravadorAcesso>();
			gravadorAcesso
				.Setup(g => g.LerUltimosDezAcessos(It.IsAny<string>()))
				.Returns(() =>
			{
				return new List<Acesso>();
			});
			var localizarAlunoController = new LocalizarAlunoController(gravadorAcesso.Object);

			// Act
			ViewResult result = localizarAlunoController.ListarConsultas() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GravarAcessoValidoTest()
		{
			//Arrange
			var gravadorAcesso = new Mock<GravadorAcesso.IGravadorAcesso>();
			gravadorAcesso
				.Setup(g => g.GravarAcesso(It.IsAny<string>(), It.IsAny<Acesso>()));
			var localizarAlunoController = new LocalizarAlunoController(gravadorAcesso.Object);

			// Act
			JsonResult jsonResult = localizarAlunoController.GravarAcesso(123, true);

			// Assert
			Assert.IsNotNull(jsonResult);
		}

		[TestMethod]
		public void GravarAcessoInvalidoTest()
		{
			//Arrange
			var gravadorAcesso = new Mock<GravadorAcesso.IGravadorAcesso>();
			gravadorAcesso
				.Setup(g => g.GravarAcesso(It.IsAny<string>(), It.IsAny<Acesso>()));
			var localizarAlunoController = new LocalizarAlunoController(gravadorAcesso.Object);

			// Act
			JsonResult jsonResult = localizarAlunoController.GravarAcesso(0, false);

			// Assert
			Assert.IsNotNull(jsonResult);
		}

		#endregion
	}
}