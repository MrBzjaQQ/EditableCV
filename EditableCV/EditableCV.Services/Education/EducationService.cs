using AutoMapper;
using EditableCV.Dal.EducationInstitutionData;
using EditableCV.Domain.Models;
using EditableCV.Resources;
using EditableCV.Services.EducationalInstitutionDto;
using EditableCV.Services.Shared;

namespace EditableCV.Services.Education;
internal sealed class EducationService(IEducationRepository repository, IMapper mapper) : IEducationService
{
    private readonly IEducationRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<InstitutionReadDto>> GetAllInstitutionsAsync(CancellationToken cancellationToken)
    {
        var institutions = await _repository.GetAllInstitutionsAsync(cancellationToken);
        return _mapper.Map<IList<InstitutionReadDto>>(institutions);
    }

    public async Task<Response<InstitutionReadDto>> GetInstitutionByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result =  await _repository.GetInstitutionByIdAsync(id, cancellationToken);
        if (result == null)
        {
            return Response<InstitutionReadDto>.CreateFailed(System.Net.HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, id));
        }

        return Response<InstitutionReadDto>.CreateSuccess(_mapper.Map<InstitutionReadDto>(result));
    }

    public async Task<Response<InstitutionReadDto>> AddInstitutionAsync(InstitutionCreateDto createInstitution, CancellationToken cancellationToken)
    {
        var institution = _mapper.Map<EducationalInstitution>(createInstitution);
        if (!institution.IsValid)
        {
            Response<InstitutionReadDto>.CreateFailed(System.Net.HttpStatusCode.BadRequest, ErrorStrings.ProvidedDataIsInvalid);
        }

        await _repository.CreateInstitutionAsync(institution, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return Response<InstitutionReadDto>.CreateSuccess(_mapper.Map<InstitutionReadDto>(institution));
    }

    public async Task<Response> EditInstitutionAsync(int id, InstitutionUpdateDto updateInstitution, CancellationToken cancellationToken)
    {
        var institution = await _repository.GetInstitutionByIdAsync(id, cancellationToken);
        if (institution is null)
        {
            return Response.CreateFailed(System.Net.HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, id));
        }

        var resultInstitution = _mapper.Map(updateInstitution, institution);
        if (!resultInstitution.IsValid)
        {
            return Response.CreateFailed(System.Net.HttpStatusCode.BadRequest, ErrorStrings.ProvidedDataIsInvalid);
        }

        await _repository.SaveChangesAsync(cancellationToken);
        return Response.CreateSuccess(System.Net.HttpStatusCode.NoContent);
    }

    public async Task DeleteInstitutionAsync(int id, CancellationToken cancellationToken)
    {
        await _repository.DeleteInstitutionAsync(id, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}
