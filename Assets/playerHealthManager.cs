using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealthManager : MonoBehaviour
{

    public static playerHealthManager instnace = null;
    public GameObject player;
    int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        if(instnace == null)
        {
            instnace = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void subtractHealth(int amt)
    {
        health -= amt;
        Debug.Log(health);
        if(health <= 0)
        {
            Destroy(player.GetComponent<playerMovement>());
        }
    }
}
