using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
{
    private GameController gameController;
    
    public GameObject enemy;
    public Vector3 spawnValues;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int count;
    
    private IEnumerator coroutine;

    void Awake()
    {
        gameController = GameController.GetInstance().GetComponent<GameController>();
    }
    
    void Start ()
    {
        coroutine = SpawnWaves();
        StartCoroutine(coroutine);
    }
    
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.Euler(0, 180, 0);
                Instantiate (enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            count--;
            if (count == 0)
            {
                StopSpawnWaves();
            }
            yield return new WaitForSeconds (waveWait);
        }
    }
    
    /*
     * Остановить волны, отправить GameController что волны закончились
     */
    void StopSpawnWaves()
    {
        StopCoroutine(coroutine);

        //Сообщить GameController что волны закончились
        gameController.FinishSpawnWaves();
    }

}