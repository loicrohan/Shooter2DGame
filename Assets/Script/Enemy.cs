using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _enemySpeed;
    //ENEMY SHOOTING LEVEL_2
    public GameObject _EnemyLaserPrefab;
    private float _fireRate = 0.5f;
    private float _canFire = 0.0f;
    [SerializeField]
    private GameObject enemyExplosionPrefab;
    [SerializeField]
    private AudioClip _clip;



    // Start is called before the first frame update
    void Start()
    {
        //Player _player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            Debug.Log("enemy laser fired");
            _canFire = Time.time + _fireRate;
            EnemyShoots();
        }
        EnemyMovement();

    }

    public void EnemyMovement()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        if(transform.position.y < -7.5f)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            if(player!=null)
            {
                player.DamagePlayer();
            }
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }

        if(other.gameObject.tag=="laser")
        {
            Debug.Log("laser hitted enemy");
            Destroy(other.gameObject);
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Player _player = GameObject.Find("Player").GetComponent<Player>();
            if (_player!=null)
            {
                _player.AddScore();
                Debug.Log("player score added");
            }
            
        }
    }

    //_________________SHOOTING AT ENEMY_________________

    public void EnemyShoots()
    {
        Instantiate(_EnemyLaserPrefab, new Vector3(transform.position.x, transform.position.y + -1.53f, 0), Quaternion.identity);
    }
}
