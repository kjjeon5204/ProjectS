using ProjectS.Combat.NPC.Behavior;
using ProjectS.Combat.Player;
using UnityEngine;

namespace ProjectS.Combat.NPC {
    public abstract class NPCCharacter : MonoBehaviour {

        public abstract PlayerCharacter GetTarget();

        public abstract void EndCurrentBehavior();

        public abstract void TriggerAttack(NPCAttackData attackData);

        public abstract NPCRuntimeBehavior GetCurrentRuntimeBehavior();
    }
}

