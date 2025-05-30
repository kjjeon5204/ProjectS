using ProjectS.Combat.Player;
using UnityEngine;


namespace ProjectS.Skill
{
    public class DodgeRuntimeSkillData : AbstractRuntimeSkillData
    {
        public DodgeRuntimeSkillData(PlayerCharacter character, AbstractSkillData skillData) : base(character, skillData)
        {
        }

        public override void ActivateSkill(Vector3 coord)
        {
            throw new System.NotImplementedException();
        }

        public override void EndSkill()
        {
            throw new System.NotImplementedException();
        }

        public override void InterruptSkill()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsPressable()
        {
            throw new System.NotImplementedException();
        }

        public override void TriggerSkillEffect()
        {
            throw new System.NotImplementedException();
        }

        public override bool UpdateSkill()
        {
            throw new System.NotImplementedException();
        }
    }
}

