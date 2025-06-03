using System.Collections.Generic;
using UnityEngine;


namespace ProjectS.Combat.NPC.Behavior {
    public abstract class NPCBehavior : ScriptableObject {
        public string BehaviorID;
        [SerializeField] private List<BehaviorCondition> _conditions;
        public bool DisableAnimatorRootMotion = false; 

        public virtual bool MeetsBehaviorConditions(NPCCharacter npcCharacter, NPCRuntimeBehavior behavior) {
            //Check if all entries in _condition's MeetCondition method returns true.
            return _conditions.TrueForAll(x => x.MeetsCondition(npcCharacter, behavior));
        }

        public abstract NPCRuntimeBehavior GenerateRuntimeBehavior(NPCCharacter npcCharacter);


        public BehaviorCondition GetCondition(BehaviorConditionType conditionType) {
            return _conditions.Find(x => x.GetConditionType() == conditionType);
        }
    }
}