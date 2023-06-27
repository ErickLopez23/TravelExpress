using Application.Attractions.DTOs;
using ErrorOr;
using MediatR;

namespace Application.Attractions.GetAll;

public record GetAllAttractionQuery : IRequest<ErrorOr<IReadOnlyList<AttractionResponse>>>;
