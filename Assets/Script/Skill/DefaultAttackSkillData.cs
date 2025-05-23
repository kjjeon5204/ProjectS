using ProjectS.Combat.Player;
using UnityEngine;
using System.Collections.Generic;



namespace ProjectS.Skill
{
    [CreateAssetMenu(fileName = "DefaultAttackSkillData", menuName = "Scriptable Objects/DefaultAttackSkillData")]
    public class DefaultAttackSkillData : AbstractSkillData
    {
        public int SequenceCount = 1;

        public List<SkillAnimationData> AnimationSequence;

        public List<SkillEffectData> SkillEffectSequence;

        public override AbstractRuntimeSkillData GenerateRuntimeSkillData(PlayerCharacter character)
        {
            return new DefaultAttackRuntimeSkillData(character, this);
        }
    }
}
