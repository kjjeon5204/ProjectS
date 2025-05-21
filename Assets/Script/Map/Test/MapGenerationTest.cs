using ProjectS.Map.UI;
using UnityEngine;



namespace ProjectS.Map.Tests
{
    public class MapGenerationTest : MonoBehaviour
    {
        public GameObject nodePrefab;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

            // Create a MapConfig object with the desired number of nodes
            MapConfig mapConfig = ScriptableObject.CreateInstance<MapConfig>();
            mapConfig.numberOfNodes = 10; // Set the number of nodes for the test
            // Generate the map using the MapGenerator
            MapData mapData = MapGenerator.GenerateMap(mapConfig);

            //Display map
            //Loop through each of the nodes and instantiate with the nodeViewPrefab
            for (int i = 0; i < mapData.nodes.Count; i++)
            {
                NodeObject nodeObject = Instantiate(nodePrefab).GetComponent<NodeObject>();
                nodeObject.InitializeNode(mapData.nodes[i]);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
