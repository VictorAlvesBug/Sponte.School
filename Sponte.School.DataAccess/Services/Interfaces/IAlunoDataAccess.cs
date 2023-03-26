using Sponte.School.MOD.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.School.DataAccess.Services.Interfaces
{
	public interface IAlunoDataAccess
	{
		public Task<IEnumerable<AlunoMOD>> GetAsync();
		public Task<AlunoMOD> GetAsync(string id);
		public Task<AlunoMOD> CreateAsync(AlunoMOD aluno);
		public Task<AlunoMOD> UpdateAsync(string id, AlunoMOD aluno);
		public Task<bool> RemoveAsync(string id);
	}
}
