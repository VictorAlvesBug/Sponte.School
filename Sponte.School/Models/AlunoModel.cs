using Sponte.School.MOD.Entidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security.Cryptography;

namespace Sponte.School.Models
{
	public class AlunoModel
	{
		public string Id { get; set; }

		[StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter de 3 a 100 caracteres")]
		public string Nome { get; set; }

		[RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Informe o CPF no formato '000.000.000-00'")]
		public string CPF { get; set; }

		public string FotoBase64 { get; set; }

		public DateTime DataNascimento { get; set; }

		[RegularExpression(@"^[a-z0-9.]+@[a-z0-9]+\.[a-z]+(\.[a-z]+)?$", ErrorMessage = "Informe um e-mail válido")]
		public string Email { get; set; }

		public AlunoMOD ToMod()
		{
			string cpf = null;

			if (!string.IsNullOrEmpty(CPF))
			{
				cpf = CPF.Replace(".", "").Replace("-", "");
			}

			return new AlunoMOD
			{
				Id = Id,
				Nome = Nome,
				CPF = cpf,
				DataNascimento = DataNascimento,
				Email = Email,
				FotoBase64 = FotoBase64
			};
		}

		public AlunoModel() { }

		public AlunoModel(AlunoMOD mod)
		{
			if (mod != null)
			{
				string cpf = Convert.ToUInt64(mod.CPF).ToString(@"000\.000\.000\-00");

				Id = mod.Id;
				Nome = mod.Nome;
				CPF = cpf;
				DataNascimento = mod.DataNascimento;
				Email = mod.Email;
				FotoBase64 = mod.FotoBase64;
			}
		}
	}
}
