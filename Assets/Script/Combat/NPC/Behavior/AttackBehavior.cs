using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

namespace ProjectS.Combat.NPC.Behavior
{
    [CreateAssetMenu(fileName = "NPCBehavior_AttackBehavior", menuName = "ProjectS/Combat/NPC/Behavior/AttackBehavior", order = 1)]
    public class AttackBehavior : NPCBehavior
    {
        public string AnimatorTrigger;

        /// <summary>
        /// Following contains list of attack effects that triggers when the attack behavior is activated.
        /// Every time an event is triggered by the animator, it activates the current attack effect in the list then increments the sequence.
        /// This allows for multiple attack effects to be triggered in a single attack behavior.
        /// </summary>
        public List<NPCAttackData> AttackDataList;

        /// <summary>
        /// Following contains list of additional actions that can be performed by the NPC during its behavior state.
        /// Each option corresponds to a specific state in the sequence of states defined in the animator.
        /// </summary>
        public List<BehaviorStateOptions> BehaviorStateOptions;

        public override NPCRuntimeBehavior GenerateRuntimeBehavior(NPCCharacter npcCharacter)
        {
            return new AttackRuntimeBehavior(this, npcCharacter);
        }
    }
}