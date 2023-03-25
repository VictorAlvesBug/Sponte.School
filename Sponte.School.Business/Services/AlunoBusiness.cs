using Sponte.School.Business.Services.Interfaces;
using Sponte.School.MOD.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sponte.School.Business.Services
{
	public class AlunoBusiness : IAlunoBusiness
	{
		/*private readonly IAlunoDataAccess _alunoDataAccess;

		public AlunoBusiness(IAlunoDataAccess alunoDataAccess)
		{
			_alunoDataAccess = alunoDataAccess;
		}*/

		public Task<IEnumerable<AlunoMOD>> Listar()
		{
			throw new NotImplementedException();
		}

		public Task<AlunoMOD> Cadastrar(AlunoMOD aluno)
		{
			throw new NotImplementedException();
		}

		public Task<AlunoMOD> Alterar(string id, AlunoMOD aluno)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Desativar(string id)
		{
			throw new NotImplementedException();
		}
	}
}
