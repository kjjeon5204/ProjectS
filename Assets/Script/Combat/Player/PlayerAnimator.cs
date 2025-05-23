using ProjectS.Skill;
using UnityEngine;


namespace ProjectS.Combat.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        public PlayerCharacter PlayerCharacter;
        public SkillAnimationData CurrentAnimationData => _currentAnimationData;
        public SkillAnimationData QueuedAnimationData => _queuedAnimationData;

        private Animator _animator;

        private SkillAnimationData _currentAnimationData;
        private SkillAnimationData _queuedAnimationData;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            PlayerCharacter = GetComponentInParent<PlayerCharacter>();
            _animator = GetComponent<Animator>();
        }

        public void FlushAnimationData()
        {
            _currentAnimationData = null;
            _queuedAnimationData = null;
        }

        public void HandleSkillAnimationData(SkillAnimationData skillAnimationData)
        {
            //Triggers can generally be always set.
            _animator.SetTrigger(skillAnimationData.animationTrigger);

            if (_currentAnimationData == null)
            {
                SetCurrentAnimation(skillAnimationData);
            }
            else
            {
                _queuedAnimationData = skillAnimationData;
            }
        }

        /// <summary>
        /// Called by behaviour at the end.
        /// </summary>
        public void EndCurrentAnimationState()
        {
            _currentAnimationData = null;
        }

        public bool IsTriggerAlreadySet(SkillAnimationData skillAnimationData)
        {
            return _animator.GetBool(skillAnimationData.animationTrigger);
        }

        public void SetCurrentAnimation(SkillAnimationData dataToSet)
        {
            _currentAnimationData = dataToSet;

            PlayerCharacter.transform.Translate(_currentAnimationData.InstantMove, Space.Self);
        }

        public void UpdateSkillAnimationData()
        {
            if (_currentAnimationData != null)
            {
                //Check if the animation is done.
                PlayerCharacter.transform.Translate(_currentAnimationData.moveSpeed * Time.deltaTime, Space.Self);
            }
        }

        private void Update()
        {
            if (_currentAnimationData == null && _queuedAnimationData != null)
            {
                SetCurrentAnimation(_queuedAnimationData);
                _queuedAnimationData = null;
            }

            UpdateSkillAnimationData();
        }
    }
}