using EditableCV_backend.Models;
using System.Collections.Generic;

namespace EditableCV_backend.Data.Skills
{
    public interface ISkillsRepository : IRepository
  {
    IEnumerable<Skill> GetAllSkills();
    Skill GetSkillById(int id);
    void CreateSkill(Skill skill);
    void UpdateSkill(Skill skill);
    void DeleteSkill(Skill skill);
  }
}
