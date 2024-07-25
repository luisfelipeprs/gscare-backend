using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases;
public interface IUpdateDocumentUseCase
{
    Task<Document?> Execute(long documentId, DocumentUpdateDto documentDto);
}