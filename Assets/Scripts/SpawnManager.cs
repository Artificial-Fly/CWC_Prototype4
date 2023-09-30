using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float spawnRange = 8;
    int WaveNumber= 1;
    int enemyCount = 0;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(WaveNumber);
        Instantiate(powerupPrefab, PowerupPosGen(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount<1){
            SpawnEnemyWave(WaveNumber);
            Instantiate(powerupPrefab, PowerupPosGen(), powerupPrefab.transform.rotation);
        }
    }
    Vector3 PowerupPosGen(){
        float spawnPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange,spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX,0.15f,spawnPosZ);
        return randomPos;
    }
    Vector3 GenerateSpawnPosition(){
        float spawnPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange,spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX,8,spawnPosZ);
        return randomPos;
    }
    void SpawnEnemyWave(int waveNum){
        int enemyNum=waveNum/2+1;
        for(int i=0; i<enemyNum; i++){
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        WaveNumber++;
    }
}
