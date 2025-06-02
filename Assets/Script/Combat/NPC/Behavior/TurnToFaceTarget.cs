using ProjectS.Skill;
using UnityEngine;


namespace ProjectS.Combat.NPC.Behavior {
    public class TurnToFaceTarget : NPCBehavior {
        public string TurnLeftTrigger;
        public string TurnRightTrigger;
        public float TimeToRotate;

        public override NPCRuntimeBehavior GenerateRuntimeBehavior(NPCCharacter npcCharacter) {
            return new TurnToFaceTargetRuntimeBehavior(this, npcCharacter);
        }
    }
}