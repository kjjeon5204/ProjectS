using ProjectS.Skill;
using UnityEngine;


namespace ProjectS.Combat.NPC.Behavior {
    [CreateAssetMenu(fileName = "NPCBehavior_TurnToFaceTarget", menuName = "ProjectS/Combat/NPC/Behavior/TurnToFaceTarget", order = 1)]
    public class TurnToFaceTarget : NPCBehavior {
        public string TurnLeftTrigger;
        public string TurnRightTrigger;
        public float TimeToRotate;

        public override NPCRuntimeBehavior GenerateRuntimeBehavior(NPCCharacter npcCharacter) {
            return new TurnToFaceTargetRuntimeBehavior(this, npcCharacter);
        }
    }
}