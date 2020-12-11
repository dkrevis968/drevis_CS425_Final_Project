using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BTree
{
    public class Node
    {
        public List<Node> children;

        public void addChild(Node node)
        {
            children.Add(node);
        }

        public bool run() { return false; }
    }

    class SelectorNode : Node
    {
        new bool run()
        {
            foreach (Node child in children)
            {
                if (child.run())
                {
                    return true;
                }
            }

            return false;
        }
    };

    class SequenceNode : Node
    {
        new bool run()
        {
            foreach (Node child in children)
            {
                if (!child.run())
                {
                    return false;
                }
            }

            return true;
        }
    };

    public class BehaviorTree
    {
        Node root;

        public BehaviorTree(Node node) { root = node; }

        public bool run()
        {
            if (this.root == null)
                return false;

            return root.run();
        }
    }
}