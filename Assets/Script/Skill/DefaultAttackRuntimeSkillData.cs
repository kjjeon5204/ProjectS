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
        /// <summary>
        /// Animation sequence refers to the animation input.
        /// Animation Sequence is controlled by input.
        /// </summary>
        private int _currentAnimationIndex = 0;
        /// <summary>
        /// Trigger index refers to the actual skill effect happening. There can be multiple triggers in a single animation sequence.
        /// </summary>
        private int _currentEffectIndex = 0;

        public DefaultAttackRuntimeSkillData(PlayerCharacter character, AbstractSkillData skillData) : base(character, skillData)
        {
        }


        public override void ActivateSkill(Vector3 coord)
        {
            //Check animation sequence is valid
            if (_currentAnimationIndex < _skillData.AnimationSequence.Count && !Character.PlayerAnimator.IsTriggerAlreadySet(_skillData.AnimationSequence[_currentAnimationIndex]))
            {
                Character.PlayerAnimator.HandleSkillAnimationData(_skillData.AnimationSequence[_currentAnimationIndex]);

                coord.y = Character.transform.position.y; //Set the y coordinate to the player character's y coordinate. This is to prevent 
                Character.transform.LookAt(coord); //For now, force look directly at the input coord.

                //Check if the trigger is set.
                _currentAnimationIndex++;
                Debug.Log("Current attack index: " + _currentAnimationIndex);
            }
        }

        public override void TriggerSkillEffect()
        {
            _currentEffectIndex++;
            Debug.Log("Current skill trigger index: " + _currentEffectIndex);  
        }

        public override void EndSkill()
        {
            Debug.Log(SkillData.SkillID + " ended. Reset");
            _currentAnimationIndex = 0;
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
            return false;
        }

    }
}

