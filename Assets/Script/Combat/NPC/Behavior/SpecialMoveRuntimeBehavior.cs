using UnityEngine;

namespace ProjectS.Combat.NPC.Behavior
{
    public class SpecialMoveRuntimeBehavior : NPCRuntimeBehavior
    {
        private SpecialMoveBehavior _behavior => (SpecialMoveBehavior)_baseBehavior;

        public SpecialMoveRuntimeBehavior(NPCBehavior npcBehavior, NPCCharacter npcCharacter) : base(npcBehavior, npcCharacter)
        {
        }
        public override void ActivateBehavior()
        {
            // Trigger the special move animation
            _npcCharacter.GetComponent<Animator>().SetTrigger(_behavior.SpecialMoveTrigger);
        }

        public override void EndBehavior()
        {
        }

        public override void InterruptBehavior()
        {
            EndBehavior();
        }



        public override void UpdateBehavior()
        {
            // Move the NPC character at the specified speed during the special move
            _npcCharacter.transform.position += _npcCharacter.transform.forward * _behavior.MoveSpeed * Time.deltaTime;

            // Optionally, you can add rotation logic if needed
            //Rotate the NPC character towards the target by ving at the specified rotation speed
            if (_npcCharacter.GetTarget() != null)
            {
                Vector3 direction = _npcCharacter.GetTarget().transform.position - _npcCharacter.transform.position;
                if (direction.sqrMagnitude > 0.01f) // Check if the target is not too close
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    _npcCharacter.transform.rotation = Quaternion.RotateTowards(_npcCharacter.transform.rotation, targetRotation, _behavior.RotationSpeed * Time.deltaTime);
                    _npcCharacter.transform.rotation = Quaternion.Euler(new Vector3(0, _npcCharacter.transform.rotation.eulerAngles.y, 0)); // Keep the y rotation only
                }
            }
        }

        public override void IncrementBehaviorSequence()
        {
            //This is single sequence behavior, so we do not need to increment the sequence.    
        }

        public override void TriggerAnimatorEvent(string eventName)
        {

        }
    }
}