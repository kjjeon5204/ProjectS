using UnityEngine;


namespace ProjectS.Combat.NPC.Behavior {
    public class TurnToFaceTargetRuntimeBehavior : NPCRuntimeBehavior {
        private TurnToFaceTarget _behavior => (TurnToFaceTarget)_baseBehavior;

        private Vector3 targetPlayerCoordinate;
        private float rotationSpeed;

        public TurnToFaceTargetRuntimeBehavior(NPCBehavior npcBehavior, NPCCharacter npcCharacter) : base(npcBehavior, npcCharacter) {
        }

        public override void ActivateBehavior() {

            targetPlayerCoordinate = _npcCharacter.GetTarget().transform.position;
            Vector3 localCoord = _npcCharacter.transform.InverseTransformPoint(targetPlayerCoordinate);


            HandleAnimatorTrigger(localCoord); //Set animation trigger.


            float degreeOffset = Vector3.Angle(Vector3.forward, localCoord);

            //Calculate the rotation so that the npc is correctly facing the target.
            rotationSpeed = degreeOffset / _behavior.TimeToRotate;


        }

        private void HandleAnimatorTrigger(Vector3 localTargetCoord) {
            Animator characterAnimator = _npcCharacter.GetComponent<Animator>();

            //Convert the target's coordinate to the local space of the npc.

            //Set animator trigger depending on which side of the npc the target is.
            if (localCoord.x < 0) { //Target is left of the npc os set trigger left.
                characterAnimator.SetTrigger(_behavior.TurnLeftTrigger);
            }
            else {
                characterAnimator.SetTrigger(_behavior.TurnRightTrigger);
            }

        }

        public override void EndBehavior() {

        }

        public override void InterruptBehavior() {

        }

        public override void UpdateBehavior() {

        }
    }
}