using ProjectS.Combat.NPC.Behavior;
using ProjectS.Combat.Player;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace ProjectS.Combat.NPC {
    public class BossMonster : NPCCharacter {
        [SerializeField] private List<NPCBehavior> _behaviors;
        [SerializeField] private float behaviorPollCooldown = 1.0f;
        [SerializeField] private float defaultMoveSpeed = 5.0f;
        [SerializeField] private float defaultRotationSpeed = 45.0f; // Degrees per second
        [SerializeField] private List<NPCModelReference> modelReferences;

        private NPCRuntimeBehavior _currentBehavior;

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
                else {
                    //If a behavior is found, activate the behavior.
                    _currentBehavior.ActivateBehavior();
                    Debug.Log(string.Format("Activating behavior: {0}", _currentBehavior.GetType().Name));
                }
            }
            //If a behavior already exists, don't play behavior.
        }

        private NPCRuntimeBehavior PollBehavior() {
            //Get all behavior that meets the current condition
            List<NPCRuntimeBehavior> validBehaviors = _runtimeBehaviors.FindAll(x => x.MeetsBehaviorConditions(this));

            if (validBehaviors.Count == 0) {
                return null;
            }

            int selection = Random.Range(0, validBehaviors.Count);

            return validBehaviors[selection];
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            //Find and target the player character in scene.
            _playerCharacter = FindAnyObjectByType(typeof(PlayerCharacter)) as PlayerCharacter;
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
            HandleDefaultMovement();
            UpdateBehaviors();

            if (_currentBehavior != null) {
                _currentBehavior.UpdateBehavior();
            }
        }

        protected void UpdateBehaviors()
        {
            //Run through all behaviors and call default update method
            foreach (var behavior in _runtimeBehaviors)
            {
                if (behavior != null)
                {
                    behavior.DefaultUpdate();
                }
            }
        }

        public void HandleDefaultMovement()
        {
            Animator characterAnimator = GetComponent<Animator>();
            if (_currentBehavior == null && defaultMoveSpeed > 0.0f)
            {
                //If target player exists, move towards the player character if the player character is more than 4 units aways
                if (_playerCharacter != null && Vector3.Distance(transform.position, _playerCharacter.transform.position) > 4.0f)
                {
                    //Move towards the player character
                    Vector3 direction = (_playerCharacter.transform.position - transform.position).normalized;
                    transform.position += direction * defaultMoveSpeed * Time.deltaTime;
                    //Rotate towards the player character
                    if ((_playerCharacter.transform.position - transform.position).magnitude > 0.1f)
                    {
                        Quaternion targetRotation = Quaternion.LookRotation(direction);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, defaultRotationSpeed * Time.deltaTime);

                    }

                    if (characterAnimator != null)
                    {
                        //Set the animator speed to move
                        characterAnimator.SetFloat("MoveSpeed", defaultMoveSpeed);
                    }
                    return;
                }
            }

            //If the player character is too close or no player character exists, stop moving
            if (characterAnimator != null)
            {
                //Set the animator speed to move
                characterAnimator.SetFloat("MoveSpeed", 0.0f);
            }
        }

        public override PlayerCharacter GetTarget() {
            return _playerCharacter;
        }

        public override void EndCurrentBehavior()
        {
            if (_currentBehavior != null)
            {
                //End the current behavior
                _currentBehavior.EndBehavior();
                _currentBehavior = null;
            }
        }

        public override void TriggerAttack(NPCAttackData attackData)
        {
            Debug.Log(string.Format("Triggering attack: {0} on target: {1}", _currentBehavior.GetBehavior().name, _playerCharacter.name));
        }

        public override NPCRuntimeBehavior GetCurrentRuntimeBehavior()
        {
            return _currentBehavior;
        }

        public void HandleAnimationEvent()
        {
            if (_currentBehavior != null)
            {
                //Call the animator event on the current behavior
                _currentBehavior.TriggerAnimatorEvent("AnimationEvent");
            }
            else
            {
                Debug.LogWarning("No current behavior to handle animation event.");
            }
        }
    }
}
