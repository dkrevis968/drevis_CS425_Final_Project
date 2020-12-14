using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BTree;


public class Task1 : Node
{
    UnityEngine.AI.NavMeshAgent sc;
    UnityEngine.AI.NavMeshAgent pl;

    public Task1(UnityEngine.AI.NavMeshAgent scientist, UnityEngine.AI.NavMeshAgent player)
    {
        sc = scientist;
        pl = player;
    }

    public override bool run()
    {
        float distance = Vector3.Distance(sc.transform.position, pl.transform.position);

        if (distance < 20)
            return true;
        return false;
    }
}

public class Task2 : Node
{
    UnityEngine.AI.NavMeshAgent sc;
    UnityEngine.AI.NavMeshAgent pl;

    public Task2(UnityEngine.AI.NavMeshAgent scientist, UnityEngine.AI.NavMeshAgent player)
    {
        sc = scientist;
        pl = player;
    }

    public override bool run()
    {
        sc.SetDestination(pl.transform.position);
        return true;
    }
}

public class Task3 : Node
{
    UnityEngine.AI.NavMeshAgent sc;
    UnityEngine.AI.NavMeshAgent osc;

    public Task3(UnityEngine.AI.NavMeshAgent scientist, UnityEngine.AI.NavMeshAgent otherScientist)
    {
        sc = scientist;
        osc = otherScientist;
    }

    public override bool run()
    {
        float distance = Vector3.Distance(sc.transform.position, osc.transform.position);

        if (distance < 10)
            return true;
        return false;
    }
}

public class Task4 : Node
{
    UnityEngine.AI.NavMeshAgent sc;
    UnityEngine.AI.NavMeshAgent osc;

    public Task4(UnityEngine.AI.NavMeshAgent scientist, UnityEngine.AI.NavMeshAgent otherScientist)
    {
        sc = scientist;
        osc = otherScientist;
    }

    public override bool run()
    {
        sc.SetDestination(sc.transform.position - osc.transform.position);
        return true;
    }
}

public class Task5 : Node
{
    UnityEngine.AI.NavMeshAgent sc;

    public Task5(UnityEngine.AI.NavMeshAgent scientist)
    {
        sc = scientist;
    }

    public override bool run()
    {
        if (!sc.CalculatePath(sc.destination, new UnityEngine.AI.NavMeshPath()))
            return true;

        if (Vector3.Distance(sc.transform.position, sc.destination) < 4)
            return true;

        return false;
    }
}

public class Task6 : Node
{
    UnityEngine.AI.NavMeshAgent sc;

    public Task6(UnityEngine.AI.NavMeshAgent scientist)
    {
        sc = scientist;
    }

    public override bool run()
    {
        sc.SetDestination(new Vector3(Random.Range(-21.0f, 21.0f), 0f, Random.Range(-21.0f, 21.0f)));
        return false;
    }
}

public class Task7 : Node
{
    UnityEngine.AI.NavMeshAgent sc;

    public Task7(UnityEngine.AI.NavMeshAgent scientist)
    {
        sc = scientist;
    }

    public override bool run()
    {
        //Allow scientist to wander/search

        return true;
    }
}

public class Scientist : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent pl;
    public UnityEngine.AI.NavMeshAgent sc;
    public UnityEngine.AI.NavMeshAgent osc;
    BehaviorTree behavior;
    public Text loseText;

    // Start is called before the first frame update
    void Awake()
    {
        SelectorNode root = new SelectorNode();

        SequenceNode seq1 = new SequenceNode();
        Task1 task1 = new Task1(sc, pl);
        Task2 task2 = new Task2(sc, pl);
        seq1.addChild(task1);
        seq1.addChild(task2);

        SequenceNode seq2 = new SequenceNode();
        Task3 task3 = new Task3(sc, osc);
        Task4 task4 = new Task4(sc, osc);
        seq2.addChild(task3);
        seq2.addChild(task4);

        SelectorNode sel2 = new SelectorNode();
        SequenceNode seq3 = new SequenceNode();
        Task5 task5 = new Task5(sc);
        Task6 task6 = new Task6(sc);
        seq3.addChild(task5);
        seq3.addChild(task6);
        Task7 task7 = new Task7(sc);
        sel2.addChild(seq3);
        sel2.addChild(task7);

        root.addChild(seq1);
        root.addChild(seq2);
        root.addChild(sel2);

        behavior = new BehaviorTree(root);

        sc.SetDestination(sc.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        behavior.run();

        if (Vector3.Distance(sc.transform.position, pl.transform.position) < 4)
        {
            pl.gameObject.SetActive(false);
            pl.transform.position = new Vector3(100f, 100f, 100f);
            loseText.gameObject.SetActive(true);
        }
    }
}
