using System.Collections.Generic;
using UnityEngine;


namespace ProjectS.Combat.NPC.Behavior {
    public abstract class NPCBehavior : ScriptableObject {

        public string BehaviorID;
        [SerializeField] private List<BehaviorCondition> _conditions;

        public virtual bool MeetsBehaviorConditions(NPCCharacter npcCharacter) {
            //Check if all entries in _condition's MeetCondition method returns true.
            return _conditions.TrueForAll(x => x.MeetsCondition(npcCharacter));
        }

        public abstract NPCRuntimeBehavior GenerateRuntimeBehavior(NPCCharacter npcCharacter);


    }
}