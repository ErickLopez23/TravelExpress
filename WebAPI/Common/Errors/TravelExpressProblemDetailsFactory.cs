﻿using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using WebAPI.Common.Http;

namespace WebAPI.Common.Errors;

public class TravelExpressProblemDetailsFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;

    public TravelExpressProblemDetailsFactory(ApiBehaviorOptions options)
    {
        _options = options;
    }

    public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
    {
        statusCode ??= 500;

        var problemDetails = new ProblemDetails()
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance
        };

        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
    {
        if (modelStateDictionary is null)
            throw new ArgumentException(nameof(modelStateDictionary));

        statusCode ??= 400;

        var validationProblemDetails = new ValidationProblemDetails(modelStateDictionary)
        {
            Status = statusCode,
            Type = type,
            Detail = detail,
            Instance = instance
        };

        if (title is not null)
            validationProblemDetails.Title = title;

        ApplyProblemDetailsDefaults(httpContext, validationProblemDetails, statusCode.Value);

        return validationProblemDetails;
    }

    private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
    {
        problemDetails.Status ??= statusCode;

        if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
        {
            problemDetails.Title = clientErrorData.Title;
            problemDetails.Type = clientErrorData.Link;
        }

        var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

        if (traceId is not null)
        {
            problemDetails.Extensions["traceId"] = traceId;
        }

        var errors = httpContext.Items[HttpContextItemKeys.Errors] as List<Error>;

        if (errors is not null)
        {
            problemDetails.Extensions.Add("errorCodes", errors.Select(e => e.Code));
        }
    }
}
