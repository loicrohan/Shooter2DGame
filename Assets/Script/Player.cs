using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    //player
    [SerializeField]
    float _playerSpeed;
    //laser shooting
    [SerializeField]
    bool laserTrigger;
    public GameObject _laserPrefab;
    public GameObject _tripleShootPrefab;
    private float _fireRate=0.2f;
    private float _canFire=0.0f;
    //Active shield
    public bool _shieldTrigger=false;
    //public float _shieldSpeed;
    [SerializeField]
    GameObject _shielPrefab;
    //Active Speed
    [SerializeField]
    private float _speedBoost = 12f;
    private float _speedBoostDuration = 8;
    [SerializeField]
    private float _NormalSpeed = 6;
    //Spawning Script
    private Spawning _spawnManager;
    //uimanger script
    private UIManager _uiManager;
    //Add score
    public int _score;
    //Player Lives
    public int _lives;
    //result Display
    [SerializeField]
    private Text _displayResult;
    [SerializeField]
    GameObject _scoreDisplayUi;
    public bool _gameOverTrigger=false;
    //To add audio source
    [SerializeField]
    private AudioClip _laserClip;
    private AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _scoreDisplayUi.SetActive(false);
        _shielPrefab.SetActive(false);
        transform.position = new Vector2(0, 0);

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<Spawning>();
        _audioSource = GetComponent<AudioSource>();
        if(_audioSource==null)
        {
            Debug.Log("AudioSource in the player NULL!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            //Debug.Log("laser fired");
            _canFire = Time.time + _fireRate;
            InstantiatingLaser();
            _audioSource.Play();
            Debug.Log("Audio played");
        }
    }

    public void playerMovement()
    {
        float Xinput = Input.GetAxis("Horizontal");
        float Yinput = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(Xinput, Yinput);
        transform.Translate(direction*_playerSpeed*Time.deltaTime);

        //transform.Translate(Vector2.right * Xinput * _playerSpeed * Time.deltaTime);
        //transform.Translate(Vector2.down * Yinput * _playerSpeed * Time.deltaTime);

        if(transform.position.y > 2.0f)
        {
            transform.position = new Vector2(transform.position.x, 2.0f);
            
        }
        else if(transform.position.y<-3.5f)
        {
            transform.position = new Vector2(transform.position.x, -3.5f);
        }
        else if(transform.position.x>7.5f)
        {
            transform.position = new Vector2(7.5f, transform.position.y);
        }
        else if(transform.position.x<-7.5f)
        {
            transform.position = new Vector2(-7.5f, transform.position.y);
        }
    }

    public void DamagePlayer()
    {
        if(_shieldTrigger==true)
        {
            _shieldTrigger = false;
            _shielPrefab.SetActive(false);

            return;
        }

        _lives--;
        _uiManager.UpdateLives(_lives);
        Debug.Log(_lives);

        if(_lives<1)
        {
            _displayResult.text = "LOSER";
            Destroy(this.gameObject);
            _spawnManager.onPlayerDeath();
            Debug.Log("spawning stoped");
            _gameOverTrigger = true;
            GameOver();
            Debug.Log("player lose");
        }

    }


    public void InstantiatingLaser()
    {
        if(laserTrigger==true)
         {
            //Debug.Log("laser tripleshoot");
            Instantiate(_tripleShootPrefab, new Vector2(transform.position.x+-0.2f,transform.position.y+0.89f), Quaternion.identity);
         }
         else
         {
            //Debug.Log("laser shoot");
            Instantiate(_laserPrefab,new Vector2(transform.position.x,transform.position.y+1.53f), Quaternion.identity);
        }
    }



    public void ActiveShield()
    {
        Debug.Log("shield is activated");
        _shieldTrigger = true;
        _shielPrefab.SetActive(true);
        //Instantiate(_shielPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        StartCoroutine(sheildPowerActive());
    }

    IEnumerator sheildPowerActive()
    {       
        yield return new WaitForSeconds(8.0f);
        Debug.Log("shield deactivated");
        _shieldTrigger = false;
        _shielPrefab.SetActive(false);
    }

    public void ActiveSpeed()
    {
        StartCoroutine(SpeedBoost());
    }

    IEnumerator SpeedBoost()
    {
        _playerSpeed = _speedBoost;
        yield return new WaitForSeconds(_speedBoostDuration);
        _playerSpeed = _NormalSpeed;
    }

    public void ActiveTripleShoot()
    {
        StartCoroutine(TripleShoot());
    }

    IEnumerator TripleShoot()
    {
        laserTrigger = true;
        //Debug.Log("laser trigger is on");
        yield return new WaitForSeconds(7);
        laserTrigger = false;
        //Debug.Log("laser trigger is off");
    }

    public void AddScore()
    {
        _score += 10;
        _uiManager.UpdateScore(_score);
        Debug.Log("score added");
        Debug.Log(_score);

        if(_score>=1000)
        {
            _displayResult.text = "WINNER";
            _spawnManager.onPlayerDeath();
            //SceneManager.LoadScene("Winner");
            Time.timeScale = 0;
            _gameOverTrigger = true;
            GameOver();
        }

    }

    public void GameOver()
    {
        if (_gameOverTrigger == true)
        {
            _scoreDisplayUi.SetActive(true);
            Debug.Log(_gameOverTrigger);
        }
        else
        {
            _scoreDisplayUi.SetActive(false);
            Debug.Log(_gameOverTrigger);

        }
    }
}