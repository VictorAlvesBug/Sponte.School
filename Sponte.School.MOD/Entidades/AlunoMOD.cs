using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Sponte.School.MOD.Entidades
{
    public class AlunoMOD
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("nome")]
		public string Nome { get; set; }

		[BsonElement("cpf")]
		public string CPF { get; set; }

		[BsonElement("foto")]
		public string FotoBase64 { get; set; }

		[BsonElement("dataNascimento")]
		public DateTime DataNascimento { get; set; }

		[BsonElement("email")]
		public string Email { get; set; }
	}
}
