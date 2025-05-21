using ProjectS.Combat.Player;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


namespace ProjectS.Skill
{
    /// <summary>
    /// This class is used to store the runtime data of the default attack skill
    /// and keep any trackers that are necessary.
    /// </summary>
    public class DefaultAttackRuntimeSkillData : AbstractRuntimeSkillData
    {
        private DefaultAttackSkillData _skillData => (DefaultAttackSkillData)SkillData;

        //Tracker variables
        private int _currentAttackIndex = 0;

        public DefaultAttackRuntimeSkillData(PlayerCharacter character, AbstractSkillData skillData) : base(skillData)
        {
        }

        public override void ActivateSkill()
        {
            _currentAttackIndex++;
            Debug.Log("Current attack index: " + _currentAttackIndex);
        }

        public override void EndSkill()
        {
            Debug.Log(SkillData.SkillID + " ended.");
            _currentAttackIndex = 0;
        }

        public override void InterruptSkill()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsPressable()
        {
            return true;
        }

        public override bool UpdateSkill()
        {
            if (_currentAttackIndex >= _skillData.SequenceCount)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}

