using ProjectS.Combat.Player;
using UnityEngine;


namespace ProjectS.Skill
{
    public abstract class AbstractSkillData : ScriptableObject
    {
        public string SkillID;


        public abstract AbstractRuntimeSkillData GenerateRuntimeSkillData(PlayerCharacter character);
    }

}
