using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases;
public interface IDeleteDocumentUseCase
{
    Task Execute(long documentId);
}