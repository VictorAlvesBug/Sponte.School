using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sponte.School.Business.Services.Interfaces;
using Sponte.School.DataAccess.Services;
using Sponte.School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sponte.School.Controllers
{
	[Route("alunos")]
	[ApiController]
	public class AlunoController : ControllerBase
	{
		private readonly AlunoServices _alunoServices;

		public AlunoController(AlunoServices alunoServices)
		{
			_alunoServices = alunoServices;
		}

		[HttpGet]
		public async Task<ActionResult> Get()
		{
			var listaAlunos = (await _alunoServices.GetAsync()).Select(aluno => new AlunoModel(aluno)).ToList();
			return StatusCode(StatusCodes.Status200OK, listaAlunos);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] AlunoModel aluno)
		{
			if (ModelState.IsValid)
			{
				await _alunoServices.CreateAsync(aluno.ToMod());
				return StatusCode(StatusCodes.Status201Created, aluno);
			}

			return StatusCode(StatusCodes.Status400BadRequest);
		}

		[Route("{id}")]
		[HttpPut]
		public async Task<ActionResult> Put(string id, [FromBody] AlunoModel aluno)
		{
			if (ModelState.IsValid)
			{
				var alunoSalvo = new AlunoModel(await _alunoServices.UpdateAsync(id, aluno.ToMod()));
				return StatusCode(StatusCodes.Status200OK, alunoSalvo);
			}

			return StatusCode(StatusCodes.Status400BadRequest);
		}

		[Route("{id}")]
		[HttpDelete]
		public async Task<ActionResult> Delete(string id)
		{
			bool sucesso = await _alunoServices.RemoveAsync(id);

			if (sucesso)
			{
				return StatusCode(StatusCodes.Status204NoContent);
			}

			return StatusCode(StatusCodes.Status400BadRequest);
		}
	}
}
