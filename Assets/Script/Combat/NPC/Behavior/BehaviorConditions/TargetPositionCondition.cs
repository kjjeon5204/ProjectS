using UnityEngine;
using System.Collections.Generic;


namespace ProjectS.Combat.NPC.Behavior.Conditions
{
    public enum AxisSelection
    {
        /// <summary>
        /// Check the distance in all three axes (X, Y, Z).
        /// </summary>
        XYZ = 0,
        /// <summary>
        /// Check the distance only in the X axis.
        /// </summary>
        X = 1,
        /// <summary>
        /// Check the distance only in the Y axis.
        /// </summary>
        Y = 2,
        /// <summary>
        /// Check the distance only in the Z axis.
        /// </summary>
        Z = 3
    }

    public enum ComparisonType
    {
        LessThan,
        LessThanOrEqualTo,
        EqualTo,
        GreaterThanOrEqualTo,
        GreaterThan
    }

    [System.Serializable]
    public class DistanceCondition
    {
        public AxisSelection Axis;
        public ComparisonType Comparison;
        public float Value;
    }

    [System.Serializable]
    public class AngleCondition
    {
        public ComparisonType Comparison;
        public float Value;
    }

    /// <summary>
    /// Condition to check if the target position is valid for the NPC.
    /// </summary>
    [System.Serializable]
    public class TargetPositionCondition
    {
        public bool DistanceCheck = false;
        public List<DistanceCondition> DistanceConditions;


        public bool AngleCheck = false;
        [Header("Angles are in degrees")]
        public List<AngleCondition> AngleConditions;


        public bool DoesMatchCondition(NPCCharacter npcCharacter, NPCRuntimeBehavior behavior)
        {
            //First check if the target is valid.
            if (npcCharacter.GetTarget() == null)
            {
                Debug.LogWarning("TargetPositionCondition: NPC has no target to check against.");
                return false;
            }

            Vector3 targetPosition = npcCharacter.GetTarget().transform.position;
            Vector3 npcPosition = npcCharacter.transform.position;
            Vector3 targetLocalPosition = npcCharacter.transform.InverseTransformPoint(targetPosition);
            bool returnValue = true;
            //Run distance checks if enabled.
            if (DistanceCheck)
            {
                foreach (var condition in DistanceConditions)
                {
                    float distance = 0f;
                    switch (condition.Axis)
                    {
                        case AxisSelection.X:
                            distance = Mathf.Abs(targetLocalPosition.x);
                            break;
                        case AxisSelection.Y:
                            distance = Mathf.Abs(targetLocalPosition.y);
                            break;
                        case AxisSelection.Z:
                            distance = Mathf.Abs(targetLocalPosition.z);
                            break;
                        case AxisSelection.XYZ:
                            distance = Vector3.Distance(targetPosition, npcPosition);
                            break;
                    }
                    switch (condition.Comparison)
                    {
                        case ComparisonType.LessThan:
                            if (distance >= condition.Value) returnValue &= distance < condition.Value;
                            break;
                        case ComparisonType.LessThanOrEqualTo:
                            if (distance > condition.Value) returnValue &= distance <= condition.Value;
                            break;
                        case ComparisonType.EqualTo:
                            if (Mathf.Abs(distance - condition.Value) > 0.01f) returnValue &= Mathf.Abs(distance - condition.Value) < 0.01f; // Allow a small margin of error
                            break;
                        case ComparisonType.GreaterThanOrEqualTo:
                            if (distance < condition.Value) returnValue &= distance >= condition.Value;
                            break;
                        case ComparisonType.GreaterThan:
                            if (distance <= condition.Value) returnValue &= distance > condition.Value;
                            break;
                    }
                }
            }

            //Run angle checks if enabled.
            if (AngleCheck)
            {
                Vector3 npcForward = npcCharacter.transform.forward;
                Vector3 targetDirection = (targetPosition - npcPosition).normalized;
                float angle = Vector3.Angle(npcForward, targetDirection);
                foreach (var condition in AngleConditions)
                {
                    switch (condition.Comparison)
                    {
                        case ComparisonType.LessThan:
                            if (angle >= condition.Value) returnValue &= angle < condition.Value;
                            break;
                        case ComparisonType.LessThanOrEqualTo:
                            if (angle > condition.Value) returnValue &= angle <= condition.Value;
                            break;
                        case ComparisonType.EqualTo:
                            if (Mathf.Abs(angle - condition.Value) > 0.01f) returnValue &= Mathf.Abs(angle - condition.Value) < 0.01f; // Allow a small margin of error
                            break;
                        case ComparisonType.GreaterThanOrEqualTo:
                            if (angle < condition.Value) returnValue &= angle >= condition.Value;
                            break;
                        case ComparisonType.GreaterThan:
                            if (angle <= condition.Value) returnValue &= angle > condition.Value;
                            break;
                    }
                }
            }
            Debug.Log($"TargetPositionCondition: Condition met: {returnValue} for NPC: {npcCharacter.name} with target: {npcCharacter.GetTarget().name}");

            return returnValue;
        }
    }
}
