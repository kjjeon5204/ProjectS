using ProjectS.Combat.NPC.Behavior;
using UnityEngine;
using System.Collections.Generic;
using ProjectS.Combat.Player;

namespace ProjectS.Combat.NPC {
    public class BossMonster : NPCCharacter {
        [SerializeField] private List<NPCBehavior> _behaviors;
        [SerializeField] private float behaviorPollCooldown = 1.0f;


        private NPCBehavior _currentBehavior;

        private float behaviorPollTracker = 0.0f;
        private PlayerCharacter _playerCharacter;
        private List<NPCRuntimeBehavior> _runtimeBehaviors;


        private void UpdateBehaviorPoll() {
            if (_currentBehavior == null) {
                behaviorPollTracker -= Time.deltaTime;
            }

            if (_currentBehavior == null && behaviorPollTracker < 0.0f ) {
                //Poll next behavior
                _currentBehavior = PollBehavior();
                behaviorPollTracker = behaviorPollCooldown;

                if (_currentBehavior == null ) {
                    Debug.Log(string.Format("No behavior found! Repolling in {0} seconds.", behaviorPollCooldown));
                }
            }
            //If a behavior already exists, don't play behavior.
        }

        private NPCBehavior PollBehavior() {
            //Get all behavior that meets the current condition
            List<NPCBehavior> behaviors = _behaviors.FindAll(x => x.MeetsBehaviorConditions(this));

            if (_behaviors.Count == 0) {
                return null;
            }

            int selection = Random.Range(0, behaviors.Count);

            return behaviors[selection];
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            //Find and target the player character in scene.
            Object playerObject = FindAnyObjectByType(typeof(PlayerCharacter));
            InitializeBehaviors();
        }

        private void InitializeBehaviors() {
            _runtimeBehaviors = new List<NPCRuntimeBehavior>();

            foreach (var entry in _behaviors) {
                _runtimeBehaviors.Add(entry.GenerateRuntimeBehavior(this));
            }
        }

        // Update is called once per frame
        void Update() {
            UpdateBehaviorPoll();
        }

        public override PlayerCharacter GetTarget() {
            return _playerCharacter;
        }
    }
}
