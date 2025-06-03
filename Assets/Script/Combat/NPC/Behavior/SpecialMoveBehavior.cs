using UnityEngine;

namespace ProjectS.Combat.NPC.Behavior
{
    [CreateAssetMenu(fileName = "NPCBehavior_SpecialMoveBehavior", menuName = "ProjectS/Combat/NPC/Behavior/SpecialMoveBehavior")]
    public class SpecialMoveBehavior : NPCBehavior
    {
        public string SpecialMoveTrigger;
        public float MoveSpeed;
        public float RotationSpeed;

        public override NPCRuntimeBehavior GenerateRuntimeBehavior(NPCCharacter npcCharacter)
        {
            return new SpecialMoveRuntimeBehavior(this, npcCharacter);  
        }
    }
}