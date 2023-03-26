using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sponte.School.DataAccess.Services.Interfaces;
using Sponte.School.MOD.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sponte.School.DataAccess.Services
{
    public class AlunoDataAccess : IAlunoDataAccess
	{
        private readonly IMongoCollection<AlunoMOD> _alunoCollection;

        public AlunoDataAccess(IOptions<DatabaseSettings> alunoDataAccess)
        {
            var mongoClient = new MongoClient(alunoDataAccess.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(alunoDataAccess.Value.DatabaseName);

            _alunoCollection = mongoDatabase.GetCollection<AlunoMOD>
                (alunoDataAccess.Value.CollectionNames["AlunoMOD"]);
        }

        public async Task<IEnumerable<AlunoMOD>> GetAsync() =>
            await _alunoCollection.Find(aluno => true).ToListAsync();

		public async Task<AlunoMOD> GetAsync(string id) =>
			await _alunoCollection.Find(aluno => aluno.Id == id).FirstOrDefaultAsync();

		public async Task<AlunoMOD> CreateAsync(AlunoMOD aluno)
        {
            await _alunoCollection.InsertOneAsync(aluno);
			return aluno;
		}

		public async Task<AlunoMOD> UpdateAsync(string id, AlunoMOD aluno)
        {
            aluno.Id = id;
			await _alunoCollection.ReplaceOneAsync(a => a.Id == id, aluno);
            return await GetAsync(id);

		}

		public async Task<bool> RemoveAsync(string id) =>
			(await _alunoCollection.DeleteOneAsync(a => a.Id == id)).DeletedCount > 0;
	}
}
