using ProjectS.Combat.Player;
using UnityEngine;

namespace ProjectS.Combat.NPC {
    public abstract class NPCCharacter : MonoBehaviour {

        public abstract PlayerCharacter GetTarget();
    }
}

