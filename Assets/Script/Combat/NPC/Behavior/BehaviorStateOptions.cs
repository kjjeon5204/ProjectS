using ProjectS.Combat.Player;
using UnityEngine;


namespace ProjectS.Combat.NPC.Behavior
{
    /// <summary>
    /// This class defines various addtional actions that can be performed by the NPC during its behavior state.
    /// This includes things like rotating the model, moving, or activating certain effects, etc.
    /// </summary>
    [System.Serializable]
    public class BehaviorStateOptions
    {
        public float MoveSpeed = 0.0f; // Default movement speed
        public float RotationSpeed = 0.0f; // Default rotation speed in degrees per second
        public bool SetToTargetPosition = false; // If true, the NPC directly teleport to the target's xz position
        public bool SetToForceLookTarget = false; // If true, the NPC will look at the target without moving


        public void OnEnter(NPCCharacter npcCharacter)
        {

            if (SetToTargetPosition)
            {
                PlayerCharacter target = npcCharacter.GetTarget();
                Vector3 position = target.transform.position;
                position.y = npcCharacter.transform.position.y; // Keep the NPC's y position unchanged

                Debug.Log("Set position to target: " + position);   
                // Teleport the NPC to the target's xz position
                npcCharacter.transform.SetPositionAndRotation(position, npcCharacter.transform.rotation);
                //npcCharacter.transform.position = position;
            }

            if (SetToForceLookTarget)
            {
                PlayerCharacter target = npcCharacter.GetTarget();
                

                if (target != null && (target.transform.position - npcCharacter.transform.position).magnitude > 0.1f)
                {
                    Vector3 direction = target.transform.position - npcCharacter.transform.position;
                    direction.y = 0; // Keep the NPC's y rotation unchanged
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    npcCharacter.transform.rotation = targetRotation;
                }
            }
        }

        public void OnUpdate(NPCCharacter npcCharacter)
        {
            npcCharacter.transform.position += npcCharacter.transform.forward * MoveSpeed * Time.deltaTime;

            // Rotate the NPC character at the target using rotation speed
            if (npcCharacter.GetTarget() != null)
            {
                Vector3 direction = npcCharacter.GetTarget().transform.position - npcCharacter.transform.position;
                if (direction.sqrMagnitude > 0.01f) // Check if the target is not too close
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    npcCharacter.transform.rotation = Quaternion.RotateTowards(npcCharacter.transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
                }
            }
        }

        public void OnExit(NPCCharacter npcCharacter)
        {

        }
    }
}
