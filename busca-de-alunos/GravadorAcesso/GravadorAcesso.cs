using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace GravadorAcesso
{
	public class GravadorAcesso : IGravadorAcesso
	{
		#region Métodos

		public void GravarAcesso(string fullPath, Acesso acesso)
		{
			List<Acesso> acessos = LerAcessos(fullPath);

			acessos.Add(acesso);

			GravarAcessos(fullPath, acessos);
		}

		private List<Acesso> GravarAcessos(string fullPath, List<Acesso> acessos)
		{
			using (FileStream fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();

				binaryFormatter.Serialize(fileStream, acessos);
			}

			return acessos;
		}

		private List<Acesso> LerAcessos(string fullPath)
		{
			List<Acesso> acessos = new List<Acesso>();

			using (FileStream fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
			{
				if (fileStream.Length > 0)
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();

					acessos = (List<Acesso>)binaryFormatter.Deserialize(fileStream);
				}
			}

			return acessos;
		}

		public List<Acesso> LerUltimosDezAcessos(string fullPath)
		{
			List<Acesso> acessos = LerAcessos(fullPath);

			List<Acesso> ultimosAcessos = acessos
											.OrderByDescending(a => a.DataAcesso)
											.Take(10)
											.ToList();
			return ultimosAcessos;
		}

		#endregion
	}
}