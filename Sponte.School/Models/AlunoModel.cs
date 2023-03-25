using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Sponte.School.Models
{
    public class AlunoModel
	{
		[RegularExpression(@"^[\da-f]{32}$", ErrorMessage = "O id deve ter exatamente 32 caracteres, entre 0-9 ou a-f")]
		public string Id { get; set; }

		[StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter de 3 a 100 caracteres")]
		public string Nome { get; set; }

		[RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Informe o CPF no formato '000.000.000-00'")]
		public string CPF { get; set; }

		public FileStream Foto { get; set; }

		public DateTime DataNascimento { get; set; }

		[RegularExpression(@"^[a-z0-9.]+@[a-z0-9]+\.[a-z]+(\.[a-z]+)?$", ErrorMessage = "Informe um e-mail válido")]
		public string Email { get; set; }
    }
}
