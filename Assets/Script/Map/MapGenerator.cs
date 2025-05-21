using System.Collections.Generic;
using UnityEngine;


namespace ProjectS.Map
{
    public class MapGenerator
    {
        public static MapData GenerateMap(MapConfig mapConfig)
        {
            MapData mapData = new MapData();

            mapData.nodes = new List<Node>();
            mapData.edges = new List<Edge>();

            int numberOfNodes = mapConfig.numberOfNodes;
            

            //Create nodes
            for (int i = 0; i < numberOfNodes; i++)
            {
                Node nodeData = new Node();

                //Generate random position for the node
                float width = mapConfig.mapSize.x;
                float height = mapConfig.mapSize.y;
                float x = Random.Range(-width / 2, width / 2);
                float y = Random.Range(-height / 2, height / 2);

                nodeData.nodeId = i;
                nodeData.nodePosition = new Vector2(x, y);


                mapData.nodes.Add(nodeData);

                //Randommly create an edge to one of the existing nodes
                if (i > 0)
                {
                    Edge edge = new Edge();
                    int index = Random.Range(0, i);
                    edge.node1ID = i; //New node
                    edge.node2ID = index; //One of existing nodes
                    mapData.edges.Add(edge);
                }
            }


            return mapData;
        }
    }
}