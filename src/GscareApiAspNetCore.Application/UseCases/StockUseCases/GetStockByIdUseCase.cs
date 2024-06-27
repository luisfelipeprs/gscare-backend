using AutoMapper;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Domain.Repositories.StockRepositories;
using GscareApiAspNetCore.Communication.Responses.StockResponses;

namespace GscareApiAspNetCore.Application.UseCases.StockUseCases;
public class GetStockByIdUseCase : IGetStockByIdUseCase
{
    private readonly IStockReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetStockByIdUseCase(IStockReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseStockJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException("STOCK_NOT_FOUND");
        }

        return _mapper.Map<ResponseStockJson>(result);
    }
}
