using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    [SerializeField] GameObject spawnZone;
    private void OnTriggerExit2D(Collider2D collision)
    {
        spawnZone.GetComponent<SpawnZone>().RemoveComponent(collision.transform.parent.gameObject);
        Destroy(collision.transform.parent.gameObject);
    }
}
