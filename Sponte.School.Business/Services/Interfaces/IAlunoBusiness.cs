using Sponte.School.MOD.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sponte.School.Business.Services.Interfaces
{
	public interface IAlunoBusiness
	{
		Task<IEnumerable<AlunoMOD>> Listar();
		Task<AlunoMOD> Cadastrar(AlunoMOD aluno);
		Task<AlunoMOD> Alterar(string id, AlunoMOD aluno);
		Task<bool> Desativar(string id);
	}
}
