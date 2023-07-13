using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawningYOffset = 3f;
    [SerializeField] Enemy alpha, beta, meteor;
    [SerializeField] float diffUpgradeTime = 8f;
    [SerializeField] float interval = 4f;
    List<Enemy> activeEnemyTypes = new List<Enemy>();
    bool isGameRunning = true;
    float topLeftX;
    Camera cam;
    
    public UnityEvent<Enemy> OnEnemySpawned;

    private void Awake()
    {
        cam = Camera.main;
        FixWorldPosition();
    }

    private void Start()
    {
        StartCoroutine(DifficultyPumper());
        StartCoroutine(Spawning());
    }
    // Fix the position of the Spawner based on screen size width and height
    public void FixWorldPosition()
    {
        Vector2 fixedPoint = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.safeArea.yMax));
        transform.position = fixedPoint + Vector2.up * spawningYOffset;
        topLeftX = cam.ScreenToWorldPoint(new Vector3(Screen.safeArea.x, 0)).x;
        topLeftX += 0.5f;
    }

    // Spawn enemies in timed intervals
    IEnumerator Spawning()
    {
        yield return new WaitForSeconds(1f);
        while (isGameRunning)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(interval+Random.Range(-0.2f * interval, +0.2f * interval));
        }

    }

    // Create a single instance of Enemy
    public void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, activeEnemyTypes.Count);
        Enemy enemy = Instantiate(activeEnemyTypes[randomEnemy]);
        float randomXPosition = Random.Range(topLeftX, topLeftX * -1);
        enemy.transform.position = new Vector2(randomXPosition,transform.position.y);
        OnEnemySpawned.Invoke(enemy);
    }

    // Increase the game difficulty as time passes
    IEnumerator DifficultyPumper()
    {
        activeEnemyTypes.Add(alpha);
        yield return new WaitForSeconds(diffUpgradeTime);
        activeEnemyTypes.Add(alpha);
        activeEnemyTypes.Add(meteor);
        yield return new WaitForSeconds(diffUpgradeTime);
        activeEnemyTypes.Add(alpha);
        activeEnemyTypes.Add(beta);
        while (isGameRunning)
        {
            yield return new WaitForSeconds(diffUpgradeTime);
            interval *= 0.9f;   
        }

    }
}
