using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;
    void Start()
    {
        // 2
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

  
    void OnCollisionEnter(Collision collision)
    {
        // 2
        if (collision.gameObject.name == "Player")
        {
            // 3
            Destroy(this.transform.parent.gameObject);
            // 4
            Debug.Log("Item collected!");
            gameManager.Items += 1;
            gameManager.PrintLootReport();
        }
    }
}
