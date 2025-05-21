
using ProjectS.PlayerData;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectS.Map
{
    public class MapDataManager : MonoBehaviour
    {
        public static MapDataManager Instance { get; private set; }


        public List<MapConfig> configsList = new List<MapConfig>();

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Instance = this;
        }

        /// <summary>
        /// Generates and assigns new map information to the user currently loaded.
        /// </summary>
        public void GenerateNewMapForUser()
        {
            PlayerMapData playerMapData = UserInfoManager.Instance.GetSubData<PlayerMapData>();

            MapData mapData = MapGenerator.GenerateMap(configsList[0]);

            playerMapData.SetMapData(mapData);
        }
    }
}

