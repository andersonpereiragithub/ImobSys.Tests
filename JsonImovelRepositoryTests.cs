using ImobSys.Infrastructure.Repositories;
using ImobSys.Domain;
using Xunit;
using System.IO;

namespace ImobSys.Tests
{
    public class JsonImovelRepositoryTests
    {
        private readonly JsonImovelRepository _repository;

        public JsonImovelRepositoryTests()
        {
            _repository = new JsonImovelRepository("temp_imoveis.json");
        }

        [Fact]
        public void Salvar_DeveAdicionarImovelAoArquivo()
        {
            var imovel = new Imovel
            {
                Id = Guid.NewGuid(),
                InscricaoIPTU = "123456",
                TipoImovel = "Residencial",
                DetalhesTipoImovel = "Casa",
                AreaUtil = 120.5f
            };

            _repository.SalvarImovel(imovel);

            var result = _repository.BuscarPorIdImovel(imovel.Id);
            Assert.NotNull(result); 
            Assert.Equal("123456", result.InscricaoIPTU);

            File.Delete("temp_imoveis.json");
        }
    }
}