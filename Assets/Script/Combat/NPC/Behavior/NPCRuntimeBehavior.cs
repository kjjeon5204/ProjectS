using UnityEngine;

namespace ProjectS.Combat.NPC.Behavior {

    /// <summary>
    /// Following data structure is used to serve as the base class for npc behaviors.
    /// </summary>
    public abstract class NPCRuntimeBehavior {
        protected NPCCharacter _npcCharacter;
        protected NPCBehavior _baseBehavior;


        public NPCRuntimeBehavior(NPCBehavior npcBehavior, NPCCharacter npcCharacter) {
            _baseBehavior = npcBehavior;
            _npcCharacter = npcCharacter;
        }

        public abstract void ActivateBehavior();

        public abstract void UpdateBehavior();

        public abstract void EndBehavior();

        public abstract void InterruptBehavior();
    }
}