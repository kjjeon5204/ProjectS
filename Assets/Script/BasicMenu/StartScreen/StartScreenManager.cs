using ProjectS;
using ProjectS.PlayerData;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectS.StartMenu
{
    /// <summary>
    /// Implements functionalities in the start screen.
    /// Display intro sequence and displays menu with with following menu options
    /// 1. Start New Game
    /// 2. Load Existing Game
    /// 3. Option
    /// 4. Quit
    /// </summary>
    public class StartScreenManager : AbstractPrimaryMenuScreen
    {
        public Button startNewGameButton;
        public Button loadExistingGameButton;
        public Button optionSelectedButton;
        public Button exitGameButton;

        public AbstractSubMenuScreen startNewGameScreen;



        public void StartNewGame()
        {
            //Display screen to select a save slot.
            Debug.Log("Display start new game screen");

            //Create new user session.
            UserInfoManager.Instance.CreateNewUserSession();
            MainController.Instance.DisplaySubMenu(startNewGameScreen);
        }

        public void LoadExistingGame()
        {

        }

        public void OptionSelected()
        {

        }

        public void ExitGameSelected()
        {
            Application.Quit();
        }

        /// <summary>
        /// Displays animation when the menu loads and followed by the 4 options fading in.
        /// </summary>
        /// <returns></returns>
        public IEnumerator ShowStartSequence()
        {
            yield return new WaitForSeconds(1f);
        }

        public IEnumerator StartSequence()
        {

            yield return StartCoroutine(ShowStartSequence());

            InitOptions();
        }

        protected bool HasExistingGame()
        {
            return false;
        }

        public void InitOptions()
        {
            startNewGameButton.onClick.AddListener(StartNewGame);
            loadExistingGameButton.onClick.AddListener(LoadExistingGame);
            optionSelectedButton.onClick.AddListener(OptionSelected);
            exitGameButton.onClick.AddListener(ExitGameSelected);

            loadExistingGameButton.interactable = HasExistingGame();
        }

        public void Start()
        {
            StartCoroutine(StartSequence());
        }
    }
}