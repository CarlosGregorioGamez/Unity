using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timeBetweenWaves = 5f;
    public int enemiesPerWave = 5;
    public float spawnRadius = 10f;

    private float countdown = 2f;
    private int waveNumber = 1;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("No se encontró al jugador con la etiqueta 'Player'");
        }
    }

    void Update()
    {
        if (player == null) return;

        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }
    }

    void SpawnWave()
    {
        Debug.Log($"Spawning wave {waveNumber}");

        for (int i = 0; i < enemiesPerWave; i++)
        {
            Vector2 spawnPos = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }

        waveNumber++;
        enemiesPerWave += 2; // opcional: aumenta enemigos por oleada
    }
}
