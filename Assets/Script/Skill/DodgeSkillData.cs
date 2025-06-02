using ProjectS.Combat.Player;
using UnityEngine;


namespace ProjectS.Skill
{
    [CreateAssetMenu(fileName = "DodgeSkillData", menuName = "Scriptable Objects/DodgeSkillData")]
    public class DodgeSkillData : AbstractSkillData
    {
        public SkillAnimationData AnimationData;

        public override AbstractRuntimeSkillData GenerateRuntimeSkillData(PlayerCharacter character)
        {
            return new DodgeRuntimeSkillData(character, this);
        }
    }
}

