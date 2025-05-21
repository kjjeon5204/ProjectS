
using ProjectS.Menu.PrimaryGameMenu;
using ProjectS.StartMenu;
using System.Collections.Generic;
using UnityEngine;



namespace ProjectS {
    /// <summary>
    /// Main controller is responsible for handling overall game logic and flow.
    /// </summary>
    public class MainController : MonoBehaviour
    {
        public static MainController Instance { get; private set; }

        public static void StartGame()
        {
            //Start the game
            //This is called to get into the game.
            ShowPrimaryGameMenu();
        }

        public static void ShowPrimaryGameMenu()
        {
            AbstractPrimaryMenuScreen primaryMenuPrefab = Instance.primaryScreenManagers.Find(x => x.GetType() == typeof(PrimaryGameMenuManager));
        
            //Instantiate the menu prefab
            AbstractPrimaryMenuScreen primaryMenu = Instantiate(primaryMenuPrefab, Instance.uiScreenHolder.transform);
        }


        public Camera uiCam;
        public Transform uiScreenHolder;

        public List<AbstractPrimaryMenuScreen> primaryScreenManagers;


        /// <summary>
        /// Instantiates and displays the initial screen.
        /// </summary>
        public void ShowStartScreen()
        {

        }

        /// <summary>
        /// Receives an instance of menu object prefab as type T
        /// The incoming prefab is instantiated as part of the screen and instantiated instance is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="menuObject"></param>
        /// <returns></returns>
        public T DisplaySubMenu<T>(T menuObject) where T : AbstractSubMenuScreen
        {
            return Instantiate(menuObject, uiScreenHolder);
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ShowStartScreen();

            Instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

}
