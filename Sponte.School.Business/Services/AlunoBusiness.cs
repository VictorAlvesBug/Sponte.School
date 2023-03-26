using Sponte.School.Business.Services.Interfaces;
using Sponte.School.DataAccess.Services.Interfaces;
using Sponte.School.MOD.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sponte.School.Business.Services
{
	public class AlunoBusiness : IAlunoBusiness
	{
		private readonly IAlunoDataAccess _alunoDataAccess;

		public AlunoBusiness(IAlunoDataAccess alunoDataAccess)
		{
			_alunoDataAccess = alunoDataAccess;
		}

		public Task<IEnumerable<AlunoMOD>> GetAsync()
		{
			return _alunoDataAccess.GetAsync();
		}

		public Task<AlunoMOD> GetAsync(string id)
		{
			return _alunoDataAccess.GetAsync(id);
		}

		public Task<AlunoMOD> CreateAsync(AlunoMOD aluno)
		{
			return _alunoDataAccess.CreateAsync(aluno);
		}

		public Task<AlunoMOD> UpdateAsync(string id, AlunoMOD aluno)
		{
			return _alunoDataAccess.UpdateAsync(id, aluno);
		}

		public Task<bool> RemoveAsync(string id)
		{
			return _alunoDataAccess.RemoveAsync(id);
		}
	}
}
