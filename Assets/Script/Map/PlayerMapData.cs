using ProjectS.PlayerData;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectS.Map
{
    public class PlayerMapData : BasePlayerData
    {
        public static PlayerMapData CreateNew()
        {
            return new PlayerMapData(false);
        }


        public MapData currentMap;

        public List<int> occupiedNodes;

        public PlayerMapData(bool isInitialized) : base(isInitialized)
        {
        }

        /// <summary>
        /// When setting new map, the occupied nodes list should be reset.
        /// </summary>
        /// <param name="mapToSet"></param>
        public void SetMapData(MapData mapToSet)
        {
            occupiedNodes = new List<int>();
            currentMap = mapToSet;
        }

        public void SetStartingNode(int startingNodeIndex)
        {
            if (occupiedNodes == null) occupiedNodes = new List<int>();
            
            occupiedNodes.Add(startingNodeIndex);
        }
    }
}
