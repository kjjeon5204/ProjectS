using ProjectS.Combat.NPC.Behavior.Conditions;
using UnityEngine;

namespace ProjectS.Combat.NPC.Behavior {

    /// <summary>
    /// Following data structure is used to serve as the base class for npc behaviors.
    /// </summary>
    public abstract class NPCRuntimeBehavior {
        protected NPCCharacter _npcCharacter;
        protected NPCBehavior _baseBehavior;

        public float CooldownTimer { get; private set; } = 0.0f;


        public NPCRuntimeBehavior(NPCBehavior npcBehavior, NPCCharacter npcCharacter) {
            _baseBehavior = npcBehavior;
            _npcCharacter = npcCharacter;
        }

        public virtual void ActivateBehavior()
        {
            SetCooldown();
        }

        /// <summary>
        /// This update method is only called when the behavior is active.
        /// </summary>
        public abstract void UpdateBehavior();

        public abstract void EndBehavior();

        public abstract void InterruptBehavior();

        public NPCBehavior GetBehavior() {
            return _baseBehavior;
        }


        /// <summary>
        /// Following is used to increment the behavior sequence with 
        /// states containing multiple sequences. Sequence starts at 0
        /// when the ActivateBehavior is called and increments by one.
        /// This method is called by the animator at the end of 
        /// each state sequence.
        /// </summary>
        public abstract void IncrementBehaviorSequence();

        /// <summary>
        /// Called by the animator to trigger an event in the animator.
        /// </summary>
        public abstract void TriggerAnimatorEvent(string eventName);

        public virtual void OnBehaviorStateEnter()
        {

        }


        public virtual void OnBehaviorStateExit()
        {
        }


        public virtual bool MeetsBehaviorConditions(NPCCharacter npcCharacter)
        {
            //Check if all entries in _condition's MeetCondition method returns true.
            return _baseBehavior.MeetsBehaviorConditions(npcCharacter, this);
        }

        /// <summary>
        /// This is called by the NPCCharacter's Update method every frame regardless of the behavior state.
        /// </summary>
        public virtual void DefaultUpdate()
        {
            UpdateCooldownTimer(Time.deltaTime);
        }

        protected void UpdateCooldownTimer(float deltaTime)
        {
            if (CooldownTimer > 0.0f)
            {
                CooldownTimer -= deltaTime;
                if (CooldownTimer < 0.0f)
                {
                    CooldownTimer = 0.0f;
                }
            }
        }


        public void SetCooldown()
        {
            //Get cooldown condition
            BehaviorCondition cooldownCondition = _baseBehavior.GetCondition(BehaviorConditionType.CooldownCondition);
            if (cooldownCondition != null)
            {
                CooldownTimer = cooldownCondition.CooldownCondition.CooldownTime;
            }
        }
    }
}