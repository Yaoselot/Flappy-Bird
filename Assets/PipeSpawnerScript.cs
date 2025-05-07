// valor de x para desaparecer los pipes -28

using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject Pipe;

    public float spawnRate = 3f;
    private float timer = 0f;
    public float heightOffset = 8f;
    public float deathZone = -28f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            timer = 0f;
            SpawnPipe();
            Debug.Log("Creando una tubería");
        }   
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
