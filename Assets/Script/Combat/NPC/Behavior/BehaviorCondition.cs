using ProjectS.Combat.NPC.Behavior.Conditions;
using UnityEngine;


namespace ProjectS.Combat.NPC.Behavior {
    public enum BehaviorConditionType {
        TargetPositionCondition,
        CooldownCondition,
    }

    [System.Serializable]
    public class BehaviorCondition {
        [SerializeField] private BehaviorConditionType _conditionType;

        //Condition Options. When condition option is added be sure to add to the property drawer as well.
        public TargetPositionCondition TargetPositionCondition;
        public CooldownCondition CooldownCondition;

        public bool MeetsCondition(NPCCharacter npcCharacter, NPCRuntimeBehavior behavior) {
            switch (_conditionType) {
                case BehaviorConditionType.TargetPositionCondition:
                    return TargetPositionCondition.DoesMatchCondition(npcCharacter, behavior);
                case BehaviorConditionType.CooldownCondition:
                    return CooldownCondition.DoesMatchCondition(npcCharacter, behavior);
                default:
                    Debug.LogError($"Unknown behavior condition type: {_conditionType}");
                    return false;
            }
        }

        public BehaviorConditionType GetConditionType() {
            return _conditionType;
        }
    }
}