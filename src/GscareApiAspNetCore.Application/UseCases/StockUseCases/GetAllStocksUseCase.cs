using AutoMapper;
using GscareApiAspNetCore.Communication.Responses.StockResponses;
using GscareApiAspNetCore.Domain.Repositories.StockRepositories;

namespace GscareApiAspNetCore.Application.UseCases.StockUseCases;
public class GetAllStocksUseCase : IGetAllStocksUseCase
{
    private readonly IStockReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllStocksUseCase(IStockReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseStocksJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseStocksJson
        {
            Stocks = _mapper.Map<List<ResponseShortStockJson>>(result)
        };
    }
}
