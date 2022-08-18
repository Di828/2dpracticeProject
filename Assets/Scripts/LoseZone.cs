using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseZone : MonoBehaviour
{
    [SerializeField] GameObject gameController;
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.GetComponent<Player>() != null)
            Destroy(collision.gameObject);
        gameController.GetComponent<GameController>().GameOver();
    }
}
