using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public static SpawnZone Instance;

    private BoxCollider spawnArea;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        spawnArea = GetComponent<BoxCollider>();
    }

    public Vector3 GetRandomPosition()
    {
        float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        float z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);
        return new Vector3(x, spawnArea.transform.position.y, z);
    }
}
