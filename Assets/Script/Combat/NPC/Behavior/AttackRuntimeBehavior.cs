using UnityEngine;

namespace ProjectS.Combat.NPC.Behavior
{
    public class AttackRuntimeBehavior : NPCRuntimeBehavior
    {
        private AttackBehavior _behavior => (AttackBehavior)_baseBehavior;

        public int CurrentBehaviorSequence { get; private set; } = 0;
        public int CurrentAttackIndex { get; private set; } = 0;    


        public AttackRuntimeBehavior(AttackBehavior npcBehavior, NPCCharacter npcCharacter) : base(npcBehavior, npcCharacter)
        {
        }
        public override void ActivateBehavior()
        {
            base.ActivateBehavior();

            Animator animator = _npcCharacter.GetComponent<Animator>();
            if (_behavior.DisableAnimatorRootMotion)
            {
                // Disable root motion if specified in the behavior
                if (animator != null)
                {
                    animator.applyRootMotion = false;
                }
                else
                {
                    Debug.LogError("Animator component not found on NPCCharacter. Cannot disable root motion.");
                }
            }

            CurrentBehaviorSequence = 0;
            CurrentAttackIndex = 0;

            //Start attack behavior by setting the animator trigger.
            if (animator != null)
            {
                animator.SetTrigger(_behavior.AnimatorTrigger);
            }
            else
            {
                Debug.LogError("Animator component not found on NPCCharacter. Cannot activate attack behavior.");
            }

        }

        private NPCAttackData GetCurrentAttackSequence()
        {
            if (_behavior.AttackDataList == null || _behavior.AttackDataList.Count == 0 || CurrentAttackIndex >= _behavior.AttackDataList.Count)
            {
                return null;
            }
            return _behavior.AttackDataList[CurrentAttackIndex];
        }

        private BehaviorStateOptions GetCurrentBehaviorStateOption()
        {
            if (_behavior.BehaviorStateOptions == null || _behavior.BehaviorStateOptions.Count == 0 || CurrentBehaviorSequence >= _behavior.BehaviorStateOptions.Count)
            {
                return null;
            }
            return _behavior.BehaviorStateOptions[CurrentBehaviorSequence];
        }




        public override void EndBehavior()
        {
            // Implement logic to end the attack behavior
            Animator animator = _npcCharacter.GetComponent<Animator>();
            if (_behavior.DisableAnimatorRootMotion)
            {
                // Disable root motion if specified in the behavior
                if (animator != null)
                {
                    animator.applyRootMotion = true;
                }
                else
                {
                    Debug.LogError("Animator component not found on NPCCharacter. Cannot disable root motion.");
                }
            }
        }
        public override void InterruptBehavior()
        {
            // Implement logic to interrupt the attack behavior
        }
        public override void UpdateBehavior()
        {
            // Implement logic to update the attack behavior each frame
            GetCurrentBehaviorStateOption()?.OnUpdate(_npcCharacter);
        }

        public override void OnBehaviorStateEnter()
        {
            base.OnBehaviorStateEnter();
            Debug.Log($"Entering behavior state: {CurrentBehaviorSequence} for attack behavior: {_baseBehavior.name}");
            GetCurrentBehaviorStateOption()?.OnEnter(_npcCharacter);
        }

        public override void OnBehaviorStateExit()
        {
            base.OnBehaviorStateExit();
            GetCurrentBehaviorStateOption()?.OnExit(_npcCharacter);

            CurrentBehaviorSequence++;
        }




        public override void IncrementBehaviorSequence()
        {
            CurrentBehaviorSequence++;
        }

        public override void TriggerAnimatorEvent(string eventName)
        {
            NPCAttackData attackData = GetCurrentAttackSequence();

            _npcCharacter.TriggerAttack(attackData);

            CurrentAttackIndex++; //Increment the attack index to the next attack in the sequence
        }
    }
}