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


        /// <summary>
        /// Following is used to increment the behavior sequence with 
        /// states containing multiple sequences. Sequence starts at 0
        /// when the ActivateBehavior is called and increments by one.
        /// This method is called by the animator at the end of 
        /// each state sequence.
        /// </summary>
        public abstract void IncrementBehaviorSequence();
    }
}