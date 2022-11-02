using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxActionManager : MonoBehaviour
{

    public static boxActionManager instance;
    public Stack<Action> actionsDone = new Stack<Action>();
    


    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (actionsDone.Count == 0)
            {
                return;
            }

            actionsDone.Pop().undoAction();
         
        }
    }

    public void addBoxToDestroy(GameObject g)
    {
        BoxAction a = new BoxAction(g);
            a.doAction();
        actionsDone.Push(a);

    }

    public void destroyBox(GameObject g)
    {
        Destroy(g);
    }

    public GameObject createBox(Vector3 loc)
    {
        GameObject g = Instantiate(Resources.Load<GameObject>("Box"));
        g.transform.position = loc;
       // Debug.Log(g.transform.position);
        return g;
    }
}

public abstract class Action{

    public abstract void doAction();

    public abstract void undoAction();
}

public class BoxAction : Action
{
    public GameObject box;
    public Vector3 location;

  public BoxAction(GameObject b)
    {
        box = b;
        location = b.transform.position;
    }

  
    public override void doAction()
    {
        boxActionManager.instance.destroyBox(box);
    }

    public override void undoAction()
    {
        box = boxActionManager.instance.createBox(location);
        location = box.transform.position;
    }
}
