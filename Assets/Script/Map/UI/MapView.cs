using ProjectS.PlayerData;
using UnityEngine;


namespace ProjectS.Map.UI
{
    public class MapView : MonoBehaviour
    {
        public NodeObject nodeViewPrefab;
        public Transform nodeHolder;
        public Transform edgesHolder;

        public void DisplayMap()
        {
            //Get current map information from user information
            PlayerMapData mapData = UserInfoManager.Instance.GetSubData<PlayerMapData>();
            MapData currentMap = mapData.currentMap;

            //Loop through each of the nodes and instantiate with the nodeViewPrefab
            for (int i = 0; i < currentMap.nodes.Count; i++)
            {
                NodeObject nodeObject = Instantiate(nodeViewPrefab, nodeHolder);
                nodeObject.InitializeNode(currentMap.nodes[i]);
            }


            //Loop through edges and display edges.

        }
    }
}