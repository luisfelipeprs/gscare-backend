using AutoMapper;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Domain.Repositories.StockRepositories;

namespace GscareApiAspNetCore.Application.UseCases.StockUseCases;
internal class UpdateStockUseCase : IUpdateStockUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStockUpdateOnlyRepository _repository;

    public UpdateStockUseCase(IMapper mapper, IUnitOfWork unitOfWork, IStockUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task Execute(long id, RequestStockJson request)
    {
        Validate(request);

        var stock = await _repository.GetById(id);

        if (stock is null)
        {
            throw new NotFoundException("STOCK_NOT_FOUND");
        }

        _mapper.Map(request, stock);

        _repository.Update(stock);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestStockJson request)
    {
        var validator = new StockValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
