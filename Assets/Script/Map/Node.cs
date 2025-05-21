using UnityEngine;


namespace ProjectS.Map
{
    public class Node
    {
        /// <summary>
        /// Node IDs are indexed 0 to numberOfNodes - 1. 
        /// ID can be used to access the list as index.
        /// </summary>
        public int nodeId;
        public NodeType nodeType;

        public Vector2 nodePosition;

    }
}