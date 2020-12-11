using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTree;

public class Scientist : MonoBehaviour
{
    BehaviorTree behavior;

    // Start is called before the first frame update
    void Start()
    {
        Node root = null;

        this.behavior = new BehaviorTree(root);
    }

    // Update is called once per frame
    void Update()
    {
        behavior.run();
    }
}
