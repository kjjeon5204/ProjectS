using ProjectS.Combat.Player;
using UnityEngine;


namespace ProjectS.Skill
{
    public abstract class AbstractRuntimeSkillData
    {
        public AbstractSkillData SkillData { get; private set; }

        public PlayerCharacter Character { get; private set; }

        public AbstractRuntimeSkillData(PlayerCharacter character, AbstractSkillData skillData)
        {
            SkillData = skillData;
            Character = character;
        }


        /// <summary>
        /// Function called when the skill button is pressed.
        /// For multi sequence skills, this can be pressed multiple times during single activation.
        /// </summary>
        public abstract void ActivateSkill(Vector3 coord);

        public abstract void TriggerSkillEffect();

        /// <summary>
        /// This method is called every frame to update the skill.
        /// Returns true if the skill is still active, false if the skill has ended.
        /// </summary>
        public abstract bool UpdateSkill();

        public abstract void InterruptSkill();

        public abstract void EndSkill();

        /// <summary>
        /// Determines whether or not the skill can be pressed.
        /// </summary>
        /// <returns></returns>
        public abstract bool IsPressable();

    }
}

