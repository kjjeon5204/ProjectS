using UnityEngine;


namespace ProjectS.Map.UI
{
    public class NodeObject : MonoBehaviour
    {
        Node nodeData;

        public void InitializeNode(Node node)
        {
            nodeData = node;

            //Handle positioning based on node.
            transform.position = node.nodePosition;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

