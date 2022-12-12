using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField]
    GameObject _enemyPrefab;
    public GameObject[] _powerUpsPrefab;
    private float _randpos;
    public bool _stopSpawning;

    // Start is called before the first frame update
    void Start()
    {
        _stopSpawning = false;
        StartCoroutine(SpawningEnemy());
        StartCoroutine(SpawningPowerUps());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawningEnemy()
    {
        while (_stopSpawning==false)
        {
            _randpos = Random.Range(7.5f, -7.5f);
            Instantiate(_enemyPrefab, new Vector2(_randpos, 6.5f), Quaternion.identity);
            yield return new WaitForSeconds(1f);

            if (transform.position.y < -7.5f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator SpawningPowerUps()
    {
        while (_stopSpawning==false)
        {
            _randpos = Random.Range(7.5f, -7.5f);
            Instantiate(_powerUpsPrefab[Random.Range(0, _powerUpsPrefab.Length)], new Vector2(_randpos, 6.5f), Quaternion.identity);
            yield return new WaitForSeconds(7.5f);

            if (transform.position.y < -7.5f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void onPlayerDeath()
    {
        _stopSpawning = true;
        Debug.Log("spawning stoped in spawnmanager script");
    }
}