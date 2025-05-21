using NUnit.Framework;
using UnityEngine;


namespace ProjectS.Map
{
    [CreateAssetMenu(fileName = "MapConfig", menuName = "Map/MapConfig")]
    public class MapConfig : ScriptableObject
    {
        public int numberOfNodes; // Number of nodes in the map

        public Vector2 mapSize; // Size of the map in Unity units
    }
}