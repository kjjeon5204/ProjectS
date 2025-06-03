using UnityEngine;

namespace ProjectS.Combat.NPC.Behavior
{
    [System.Serializable]
    public class NPCAttackData
    {
        /// <summary>
        /// This is used to match to the ID of the <see cref="NPCAttackModelReference"/> on the npc model script.
        /// </summary>
        public string AttackReferenceID;
    }
}