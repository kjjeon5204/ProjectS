using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;


namespace ProjectS.Combat.Player
{
    /// <summary>
    /// The following class connects input to the character controller and is responsible for
    /// passing in input events to the player model.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter playerCharacter;

        [SerializeField] private Camera gameCam;

        [Header("Input Action Asset")]
        [SerializeField] private InputActionAsset inputActionAsset;


        [Header("Action Map Name References")]
        [SerializeField] private string playerActionMapName = "Player";

        [Header("Action Name References")]
        [SerializeField] private string moveClickActionName = "MoveClick";
        [SerializeField] private string skill1ActionName = "Skill1";
        [SerializeField] private string skill2ActionName = "Skill2";
        [SerializeField] private string skill3ActionName = "Skill3";
        [SerializeField] private string skill4ActionName = "Skill4";

        private InputAction moveClickAction;
        private InputAction skill1Action;
        private InputAction skill2Action;
        private InputAction skill3Action;
        private InputAction skill4Action;


        private bool initialized = false;

        private void Start()
        {

            // Get the action map from the input action asset
            InputActionMap playerActionMap = inputActionAsset.FindActionMap(playerActionMapName);
            
            // Get the action from the action map
            moveClickAction = playerActionMap.FindAction(moveClickActionName);
            skill1Action = playerActionMap.FindAction(skill1ActionName);
            skill2Action = playerActionMap.FindAction(skill2ActionName);
            skill3Action = playerActionMap.FindAction(skill3ActionName);
            skill4Action = playerActionMap.FindAction(skill4ActionName);


            // Enable the action map
            playerActionMap.Enable();

            RegisterInputAction();

            initialized = true;
        }

        private void RegisterInputAction()
        {
            // Register the callback for the click action
            moveClickAction.performed += HandleClickAction;
            skill1Action.performed += HandleSkill1Action;
            skill2Action.performed += HandleSkill2Action;
            skill3Action.performed += HandleSkill3Action;
            skill4Action.performed += HandleSkill4Action;
        }

        private void HandleClickAction(InputAction.CallbackContext context)
        {
            PassMovement();
        }

        public void PassMovement()
        {
            Mouse mouse = Mouse.current;

            //Get mouse position
            Vector2 mousePosition = mouse.position.ReadValue();
            //Convert to world position
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

            //Raycast to ground and get the hit point
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f, LayerMask.GetMask("Ground")))
            {
                //Get the hit point
                Vector3 hitPoint = hit.point;

                //Pass the hit point to the player character
                playerCharacter.ReceiveInputCoord(hitPoint);
            }
        }

        public Vector3 GetCurrentMouseToGameCoord()
        {

            Mouse mouse = Mouse.current;

            //Get mouse position
            Vector2 mousePosition = mouse.position.ReadValue();
            //Convert to world position
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

            //Raycast to ground and get the hit point
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f, LayerMask.GetMask("Ground")))
            {
                //Get the hit point
                Vector3 hitPoint = hit.point;

                //Pass the hit point to the player character
                return hitPoint;
            }
            return Vector3.zero;
        }

        public Vector2 GetMousePosition()
        {
            Mouse mouse = Mouse.current;
            Vector2 mousePosition = mouse.position.ReadValue();
            return mousePosition;
        }

        private void HandleSkill1Action(InputAction.CallbackContext context)
        {
            // Handle skill 1 action
            Debug.Log("Skill 1 Pressed");
            playerCharacter.ActivateSkill1(GetCurrentMouseToGameCoord());
        }

        private void HandleSkill2Action(InputAction.CallbackContext context)
        {
            // Handle skill 2 action
            Debug.Log("Skill 2 Pressed");
            playerCharacter.ActivateSkill2(GetMousePosition());
        }

        private void HandleSkill3Action(InputAction.CallbackContext context)
        {
            // Handle skill 3 action
            Debug.Log("Skill 3 Pressed");
            playerCharacter.ActivateSkill3(GetMousePosition());
        }

        private void HandleSkill4Action(InputAction.CallbackContext context)
        {
            // Handle skill 4 action
            Debug.Log("Skill 4 Pressed");
            playerCharacter.ActivateSkill4(GetMousePosition());
        }

        

        public void HandleInput()
        {
            
        }

        public void HandleKeyInput()
        {

        }

        private void OnEnable()
        {
            if (!initialized)
            {
                return;
            }
            moveClickAction.Enable();
        }

        private void OnDisable()
        {
            if (!initialized)
            {
                return;
            }
            moveClickAction.Disable();
        }

        private void Update()
        {
            if (initialized)
            {
                HandleLeftButtonHold();
            }
        }

        private void HandleLeftButtonHold()
        {
            if (moveClickAction.enabled)
            {
                if (moveClickAction.IsPressed()) {
                    PassMovement();
                }
            }
        }
    }
}

