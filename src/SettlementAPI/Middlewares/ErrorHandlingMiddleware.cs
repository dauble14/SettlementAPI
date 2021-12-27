﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SettlementAPI.Exceptions;
using SettlementAPI.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SettlementAPI.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<ErrorHandlingMiddleware> logger)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = new ApiErrorResponse();

            switch (exception)
            {
                //TODO: all exceptions caused by the user
                case NotSupportedException _:
                case AlreadyExistsException _:
                case ValidationException _:
                case NotFoundException _:
                    code = HttpStatusCode.BadRequest;
                    result = new ApiErrorResponse(exception.Message);
                    break;
                case Exception e:
                    logger.LogError(exception, "SERVER ERROR");
                    code = HttpStatusCode.InternalServerError;
                    result = string.IsNullOrWhiteSpace(e.Message) ? new ApiErrorResponse("Error") : new ApiErrorResponse(e.Message);
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            string jsonResponse = JsonSerializer.Serialize(result);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
