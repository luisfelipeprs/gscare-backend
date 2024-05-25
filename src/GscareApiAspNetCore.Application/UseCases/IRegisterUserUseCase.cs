﻿using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases;
public interface IRegisterUserUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestUserJson request);
}
