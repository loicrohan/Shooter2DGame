using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLaser : MonoBehaviour
{
    [SerializeField]
    private float _EnemyLaserSpeed;
    [SerializeField]
    private AudioClip _clip;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LaserMovement();
    }

    public void LaserMovement()
    {
        transform.Translate(Vector3.down * _EnemyLaserSpeed * Time.deltaTime);

        if (transform.position.y < -7.5f)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.DamagePlayer();
            }
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
    }


}
