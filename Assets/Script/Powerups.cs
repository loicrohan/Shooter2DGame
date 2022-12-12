using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    [SerializeField]
    float _powerUpSpeed;
    public float _powerUpID;
    private Player _player;
    [SerializeField]
    private AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpMovement();
    }

    public void PowerUpMovement()
    {
        transform.Translate(Vector2.down * _powerUpSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="player")
        {
            Debug.Log(other);
            _player = other.gameObject.GetComponent<Player>();
            if (_player != null)
            {
                switch(_powerUpID)
                {
                    case 1:
                        Debug.Log("shield activated");
                        _player.ActiveShield();
                        break;

                    case 2:
                        Debug.Log("speed activated");
                        _player.ActiveSpeed();
                        break;

                    case 3:
                        Debug.Log("triple shoot activated");
                        _player.ActiveTripleShoot();
                        break;
                }
            }
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(gameObject);
        }
    }
}