using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sponte.School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sponte.School.Controllers
{
    [ApiController]
	[Route("alunos")]
	public class AlunoController : ControllerBase
	{
		private readonly ILogger<AlunoController> _logger;

		private List<AlunoModel> _itemsMock;

		public AlunoController(ILogger<AlunoController> logger)
		{
			_logger = logger;

			var rng = new Random();

			_itemsMock = Enumerable.Range(1, 2).Select(index => new AlunoModel
			{
				Id = Guid.NewGuid().ToString().Replace("-", ""),
				Nome = $"Aluno N°{index}",
				Email = $"email{index}@gmail.com",
				CPF = $"{rng.Next(0, 999):000}.{rng.Next(0, 999):000}.{rng.Next(0, 999):000}-{rng.Next(0, 99):00}",
				DataNascimento = DateTime.Now.AddMonths(-rng.Next(5 * 12, 18 * 12)),
				Foto = null
			}).ToList();
		}

		[HttpGet]
		public async Task<ActionResult> Get()
		{
			return StatusCode(StatusCodes.Status200OK, _itemsMock.ToArray());
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] AlunoModel aluno)
		{
			if (ModelState.IsValid)
			{
				_itemsMock.Add(aluno);
				var alunoSalvo = aluno;
				return StatusCode(StatusCodes.Status201Created, alunoSalvo);
			}

			return StatusCode(StatusCodes.Status400BadRequest, null);
		}

		[Route("{id}")]
		[HttpPut]
		public async Task<ActionResult> Put(string id, [FromBody] AlunoModel aluno)
		{
			if (ModelState.IsValid)
			{
				_itemsMock = _itemsMock.Select(item => item.Id == id ? aluno : item).ToList();
				var alunoSalvo = aluno;
				return StatusCode(StatusCodes.Status200OK, alunoSalvo);
			}

			return StatusCode(StatusCodes.Status400BadRequest, null);
		}

		[Route("{id}")]
		[HttpDelete]
		public async Task<ActionResult> Delete(string id)
		{
			_itemsMock = _itemsMock.Where(item => item.Id != id).ToList();
			return StatusCode(StatusCodes.Status200OK);

			//return StatusCode(StatusCodes.Status400BadRequest, null);
		}
	}
}
