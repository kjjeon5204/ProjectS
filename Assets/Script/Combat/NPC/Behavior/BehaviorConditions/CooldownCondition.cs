using Unity.VisualScripting;
using UnityEngine;

namespace ProjectS.Combat.NPC.Behavior.Conditions
{
    [System.Serializable]
    public class CooldownCondition
    {
        public float CooldownTime = 0f;

        public bool DoesMatchCondition(NPCCharacter npcCharacter, NPCRuntimeBehavior behavior)
        {
            return behavior.CooldownTimer == 0.0f;
        }
    }
}
