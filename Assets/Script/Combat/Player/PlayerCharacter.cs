using ProjectS.Skill;
using System.Collections;
using UnityEngine;


namespace ProjectS.Combat.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        [SerializeField] private AbstractSkillData skill1Data;
        [SerializeField] private AbstractSkillData skill2Data;

        [SerializeField] private AbstractSkillData skill3Data;

        [SerializeField] private AbstractSkillData skill4Data;

        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float rotationSpeed = 720f;

        
        public AbstractRuntimeSkillData Skill1RuntimeData { get; private set; } 
        public AbstractRuntimeSkillData Skill2RuntimeData { get; private set; }
        public AbstractRuntimeSkillData Skill3RuntimeData { get; private set; }
        public AbstractRuntimeSkillData Skill4RuntimeData { get; private set; }

        /// <summary>
        /// Following variable checks to see if the player can receive the movement input or not.
        /// </summary>
        private bool canReceiveMoveInput = true;

        private Animator _playerAnimator;
        

        private AbstractRuntimeSkillData _currentlyActiveSkill;


        private Vector3 targetPosition;
        private Quaternion targetLookRotation;


        //Input value is vector3 in world cooredinate space.
        public void ReceiveInputCoord(Vector3 inputPos)
        {
            if (!canReceiveMoveInput) //If movement input is not allowed ignore input command.
            {
                return;
            }

            //Set the target position to the input position.
            targetPosition = inputPos;

            //Set the target look rotation to the input position.
            targetLookRotation = Quaternion.LookRotation(inputPos - transform.position);
        }

        public void ActivateSkill1(Vector3 inputCoord)
        {
            Debug.Log("Activating Skill 1.");
            if (_currentlyActiveSkill != Skill1RuntimeData)
            {
                _currentlyActiveSkill = Skill1RuntimeData;
            }
            _currentlyActiveSkill.ActivateSkill();
        }

        public void ActivateSkill2(Vector2 mousePos)
        {
            Debug.Log("Skill 2 activated");
        }

        public void ActivateSkill3(Vector2 mousePos)
        {
            Debug.Log("Skill 3 activated");
        }

        public void ActivateSkill4(Vector2 mousePos)
        {
            Debug.Log("Skill 4 activated");
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //Initialize the skill runtime data
            Skill1RuntimeData = skill1Data.GenerateRuntimeSkillData(this);
            Skill2RuntimeData = skill2Data.GenerateRuntimeSkillData(this);
            Skill3RuntimeData = skill3Data.GenerateRuntimeSkillData(this);
            Skill4RuntimeData = skill4Data.GenerateRuntimeSkillData(this);

            _playerAnimator = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateMovementState();
            HandleSkillState();
        }



        public void UpdateMovementState()
        {
            //Rotate the player towards the target look rotation
            if (targetLookRotation != Quaternion.identity)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetLookRotation, rotationSpeed * Time.deltaTime);
            }

            //Check if the player is moving
            if (targetPosition != transform.position)
            {
                //Move the player to the target position
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
                _playerAnimator.SetFloat("MoveSpeed", moveSpeed);
            }
            else
            {
                //If the player is not moving, set the move speed to 0
                _playerAnimator.SetFloat("MoveSpeed", 0);
            }
        }

        public void HandleSkillState()
        {
            if (_currentlyActiveSkill != null)
            {
                bool isFinished = !_currentlyActiveSkill.UpdateSkill();

                if (isFinished)
                {
                    _currentlyActiveSkill.EndSkill();
                    _currentlyActiveSkill = null; //Set the currently active skill to null
                }
            }
        }
    }
}

