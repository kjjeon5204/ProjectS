using ProjectS.PlayerData;
using ProjectS.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace ProjectS.StartMenu
{
    /// <summary>
    /// Displays list of available save slots to select from.
    /// </summary>
    public class PlayerNameMenu : AbstractSubMenuScreen
    {
        public TMP_InputField playerNameInputField;
        public Button startButton;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            startButton.onClick.AddListener(StartNewGame);
        }

        /// <summary>
        /// Checks to verfy if the player name is valid.
        /// If it is, start the game. Otherwise, display an error message.
        /// </summary>
        public void StartNewGame()
        {
            //Get player name from the input field
            string playerName = playerNameInputField.text;

            if (IsPlayerNameValid(playerName))
            {
                UserDetailsData userDetail = UserInfoManager.Instance.GetSubData<UserDetailsData>();
                userDetail.SetUserName(playerName);

                //Start game
                Debug.Log("Starting new game with player name: " + playerName);
                MainController.StartGame();
            }
            else
            {
                //Display error message
                Debug.LogError("Invalid player name! Please enter a valid player name.");
            }
        }

        bool IsPlayerNameValid(string playerName)
        {
            return !string.IsNullOrEmpty(playerName);
        }
    }

}
