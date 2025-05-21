using ProjectS.Combat.Player;
using UnityEngine;



namespace ProjectS.Skill
{
    [CreateAssetMenu(fileName = "DefaultAttackSkillData", menuName = "Scriptable Objects/DefaultAttackSkillData")]
    public class DefaultAttackSkillData : AbstractSkillData
    {
        public int SequenceCount = 1;   

        public override AbstractRuntimeSkillData GenerateRuntimeSkillData(PlayerCharacter character)
        {
            return new DefaultAttackRuntimeSkillData(character, this);
        }
    }
}
