using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BTree
{
    public class Node
    {
        public List<Node> children;

        public Node() { children = new List<Node>(); }

        public void addChild(Node node)
        {
            this.children.Add(node);
        }

        public virtual bool run() { return false; }
    }

    class SelectorNode : Node
    {
        public override bool run()
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
        public override bool run()
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