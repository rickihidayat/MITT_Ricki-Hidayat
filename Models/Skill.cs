using System.Collections.Generic;

#nullable disable

namespace MITT_Ricki_Hidayat.Models
{
    public partial class Skill
    {
        public Skill()
        {
            UserSkills = new HashSet<UserSkill>();
        }

        public int SkillId { get; set; }
        public string SkillName { get; set; }

        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
