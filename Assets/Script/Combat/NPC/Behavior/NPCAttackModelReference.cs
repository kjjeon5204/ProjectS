using UnityEngine;
using System.Collections.Generic;


namespace ProjectS.Combat.NPC.Behavior
{
    /// <summary>
    /// The following class contains references to attack that can be used by the NPCAttackData to control different 
    /// components of the npc game object.
    /// </summary>
    [System.Serializable]
    public class NPCAttackModelReference
    {
        public string AttackReferenceID;

        public List<Collider> AttackColliders;
    }
}