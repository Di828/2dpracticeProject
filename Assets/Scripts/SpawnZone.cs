using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject gameController;    
    private Vector2 spawnPosition;
    private List<GameObject> spawnedPlatforms = new List<GameObject>();
    private float speed;
    private float previousSpeed;
    private void Start()
    {
        spawnPosition = new Vector2(11, 2);                
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isSpeedChanged())
            ChangeSpeedOfSpawnedPlatforms();
        float randomLength = Random.Range(3f, 10f);        
        Vector2 randomScale = new Vector2(randomLength, 1);        
        GameObject spawnedPlatforn = Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
        spawnedPlatforn.transform.localScale = randomScale;
        spawnedPlatforn.transform.position = new Vector2 (spawnPosition.x - randomLength/2 - 0.5f,spawnPosition.y);
        spawnPosition.y *= -1;
        spawnedPlatforn.GetComponent<MovingLeft>().SetSpeed(speed);
        spawnedPlatforms.Add(spawnedPlatforn);
    }    
    private bool isSpeedChanged()
    {
        speed = gameController.GetComponent<GameController>().GameSpeed;
        if (speed - previousSpeed > 0.1)
        {
            previousSpeed = speed;
            return true;
        }
        return false;
    }
    private void ChangeSpeedOfSpawnedPlatforms()
    {
        foreach (var platform in spawnedPlatforms)
        {
            if (platform != null)
                platform.GetComponent<MovingLeft>().SetSpeed(speed);
        }
    }
    public void RemoveComponent(GameObject objectToRemove)
    {
        spawnedPlatforms.Remove(objectToRemove);
    }
}
