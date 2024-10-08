﻿using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases
{
    public class GetDocumentUseCase : IGetDocumentUseCase
    {
        private readonly IDocumentRepository _documentRepository;

        public GetDocumentUseCase(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<Document?> Execute(string documentName)
        {
            return await _documentRepository.GetDocumentByNameAsync(documentName);
        }

        public async Task<IEnumerable<Document>> GetDocumentsByUserIdAsync(long userId)
        {
            return await _documentRepository.GetDocumentsByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _documentRepository.GetAllDocumentsAsync();
        }
    }
}
