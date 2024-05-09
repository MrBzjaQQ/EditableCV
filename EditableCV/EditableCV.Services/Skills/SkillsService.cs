using AutoMapper;
using EditableCV.Dal.SkillsData;
using EditableCV.Domain.Models;
using EditableCV.Resources;
using EditableCV.Services.Shared;
using EditableCV.Services.SkillDto;

namespace EditableCV.Services.Skills;
internal sealed class SkillsService(ISkillsRepository repository, IMapper mapper) : ISkillsService
{
    private readonly ISkillsRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<SkillReadDto>> GetSkillsAsync(CancellationToken cancellationToken)
    {
        var skills = await _repository.GetAllSkillsAsync(cancellationToken);
        return _mapper.Map<IList<SkillReadDto>>(skills);
    }

    public async Task<Response<SkillReadDto>> GetSkillByIdAsync(int id, CancellationToken cancellationToken)
    {
        var skill = await _repository.GetSkillByIdAsync(id, cancellationToken);
        if (skill == null)
        {
            return Response<SkillReadDto>.CreateFailed(System.Net.HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, id));
        }

        return Response<SkillReadDto>.CreateSuccess(_mapper.Map<SkillReadDto>(skill));
    }

    public async Task<Response<SkillReadDto>> AddSkillAsync(SkillCreateDto createSkill, CancellationToken cancellationToken)
    {
        var skill = _mapper.Map<Skill>(createSkill);
        await _repository.CreateSkillAsync(skill, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return Response<SkillReadDto>.CreateSuccess(_mapper.Map<SkillReadDto>(skill));
    }

    public async Task<Response> EditSkillAsync(int id, SkillUpdateDto updateSkill, CancellationToken cancellationToken)
    {
        var skill = await _repository.GetSkillByIdAsync(id, cancellationToken);
        if (skill is null)
        {
            return Response.CreateFailed(System.Net.HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, id));
        }

        _mapper.Map(updateSkill, skill);
        await _repository.SaveChangesAsync(cancellationToken);
        return Response.CreateSuccess(System.Net.HttpStatusCode.NoContent);
    }

    public async Task DeleteSkillAsync(int id, CancellationToken cancellationToken)
    {
        await _repository.DeleteSkillAsync(id, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}
