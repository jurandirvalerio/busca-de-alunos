using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Infra
{
	public static class Util
	{
		#region Métodos
		
		public static string MontarUrl(int numeroRA)
		{
			string condicaoNumeroRA = "RA_Aluno=" + numeroRA;

			condicaoNumeroRA = Uri.EscapeUriString(condicaoNumeroRA);

			string url = string.Format("https://www.googleapis.com/mapsengine/v1/tables/16301484656389751053-01619059540675406410/features?where={0}&version=published&key=AIzaSyAsrcj7OColofVBkQHQOJDL0_dIQxGjyjY&limit=1", condicaoNumeroRA);

			return url;
		} 

		#endregion
	}
}