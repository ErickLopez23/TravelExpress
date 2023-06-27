using Application.Attractions.DTOs;
using ErrorOr;
using MediatR;

namespace Application.Attractions.GetById;

public record GetAttractionByIdQuery(Guid Id) : IRequest<ErrorOr<AttractionResponse>>;
