using GscareApiAspNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases;
public interface IGetDocumentUseCase
{
    Task<Document?> Execute(string documentName);
}