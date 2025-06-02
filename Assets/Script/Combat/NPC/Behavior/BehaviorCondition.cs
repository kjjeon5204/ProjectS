using UnityEngine;


namespace ProjectS.Combat.NPC.Behavior {
    public enum BehaviorConditionType {
        TargetPosition
    }

    [System.Serializable]
    public class BehaviorCondition {
        [SerializeField] private BehaviorConditionType _conditionType;


        public bool MeetsCondition(NPCCharacter npcCharacter) {
            return true;
        }
    }
}