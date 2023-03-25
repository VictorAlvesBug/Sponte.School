using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Sponte.School.MOD.Entidades
{
    public class AlunoMOD
    {
		public string Id { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public FileStream Foto { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Email { get; set; }
	}
}
