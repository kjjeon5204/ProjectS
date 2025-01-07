using System.Collections;
using UnityEngine;


namespace ProjectS.SinglePlayer {
    public enum GameState {
        GameLoading,
        CharacterSelection,
        GamePlay,
    }


    public class SPGameController : MonoBehaviour
    {
        public GameState gameState = GameState.GameLoading;


        public void StartGameLoading() {
            gameState = GameState.GameLoading;
            Debug.Log("Game Loading");

            // Load any assets and components needed for the game play.
            StartCoroutine(loading_sequence());
        }

        private IEnumerator loading_sequence() {
            bool isGameLoading = check_game_loading_state();

            while (isGameLoading) {
                // Load the game assets and components.
                yield return null;
                isGameLoading = check_game_loading_state();
            }


            LoadingComplete(); // Call the loading complete method.
        }

        private bool check_game_loading_state() {
            return true;
        }

        /// <summary>
        /// Called when the game loading is complete.
        /// </summary>
        public void LoadingComplete() {

        }


        public void ShowCharacterSelection() {
            gameState = GameState.CharacterSelection;
            Debug.Log("Character Selection");

            // Show character selection screen.

        }


        public void StartGamePlay() {
            gameState = GameState.GamePlay;
            Debug.Log("Game Play");

            // Start the game play.

        }



        // Start is called once before the first execution of Update after the MonoBehaviour is created
        // Entry point for th game.
        void Start()
        {
            StartGameLoading();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}