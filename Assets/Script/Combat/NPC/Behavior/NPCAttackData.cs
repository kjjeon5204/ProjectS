using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;   

namespace ProjectS.Combat.NPC.Behavior
{
    public enum NPCAttackType
    {
        Melee,
        Ranged
    }

    [System.Serializable]
    public class NPCAttackData
    {
        /// <summary>
        /// This is used to match to the ID of the <see cref="NPCAttackModelReference"/> on the npc model script.
        /// </summary>
        public string AttackReferenceID;
        public NPCAttackType AttackType;

        public MeleeAttackOption MeleeAttackOption;
    }
}