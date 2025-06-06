using UnityEngine;
using System.Collections.Generic;


namespace ProjectS.Combat.NPC.Behavior
{
    public enum PartType
    {
        AttackCollider,
    }

    /// <summary>
    /// The following class contains references to attack that can be used by the NPCAttackData to control different 
    /// components of the npc game object.
    /// </summary>
    [System.Serializable]
    public class NPCModelReference
    {
        public string PartReferenceID;
        public PartType PartType;
        public GameObject ModelPart;
    }
}