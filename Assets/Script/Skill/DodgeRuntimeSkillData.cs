using ProjectS.Combat.Player;
using UnityEngine;


namespace ProjectS.Skill
{
    public class DodgeRuntimeSkillData : AbstractRuntimeSkillData
    {
        private DodgeSkillData _skillData => (DodgeSkillData)SkillData;

        public DodgeRuntimeSkillData(PlayerCharacter character, AbstractSkillData skillData) : base(character, skillData)
        {
        }

        public override void ActivateSkill(Vector3 coord)
        {
            Character.PlayerAnimator.HandleSkillAnimationData(_skillData.AnimationData);
            coord.y = Character.transform.position.y;
            Character.transform.LookAt(coord); // Force look at the input coordinate.


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

