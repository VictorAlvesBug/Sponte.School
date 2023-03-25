using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sponte.School.MOD.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sponte.School.DataAccess.Services
{
    public class AlunoServices
    {
        private readonly IMongoCollection<AlunoMOD> _alunoCollection;

        public AlunoServices(IOptions<AlunoDatabaseSettings> alunoServices)
        {
            var mongoClient = new MongoClient(alunoServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(alunoServices.Value.DatabaseName);

            _alunoCollection = mongoDatabase.GetCollection<AlunoMOD>
                (alunoServices.Value.AlunoCollectionName);
        }

        public async Task<List<AlunoMOD>> GetAsync() =>
            await _alunoCollection.Find(aluno => true).ToListAsync();

		public async Task<AlunoMOD> GetAsync(string id) =>
			await _alunoCollection.Find(aluno => aluno.Id == id).FirstOrDefaultAsync();

		public async Task CreateAsync(AlunoMOD aluno)
        {
            await _alunoCollection.InsertOneAsync(aluno);
			//return aluno;
		}

		public async Task<AlunoMOD> UpdateAsync(string id, AlunoMOD aluno)
        {
			await _alunoCollection.ReplaceOneAsync(a => a.Id == id, aluno);
            return await GetAsync(id);

		}

		public async Task<bool> RemoveAsync(string id) =>
			(await _alunoCollection.DeleteOneAsync(a => a.Id == id)).DeletedCount > 0;
	}
}
