using ProjectS.Map;
using ProjectS.Map.UI;
using ProjectS.PlayerData;
using UnityEngine;


namespace ProjectS.Menu.PrimaryGameMenu
{
    public class PrimaryGameMenuManager : AbstractPrimaryMenuScreen
    {
        public MapView mapView;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

            //Check if current user has a valid map and if it does not exist, generate through the MapDataManager
            PlayerMapData mapData = UserInfoManager.Instance.GetSubData<PlayerMapData>();
            if (mapData.currentMap == null)
            {
                MapDataManager.Instance.GenerateNewMapForUser();
            }


            //Once assignment is set, display map through MapView.DisplayMap()
            mapView.DisplayMap();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

