using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    [SerializeField]
    float _laserSpeed;
    //Enemy Explosion
    public bool _explosionTrigger=false;
    /*[SerializeField]
    private GameObject _explosionPrefab;*/

    // Start is called before the first frame update
    void Start()
    {
        //_explosionPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        LaserMovement();
    }

    public void LaserMovement()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);

        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="enemy")
        {
            ActiveExplosion();
            Debug.Log("enemy destroyed");
            //Instantiate(_explosionPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
 

        }
    }

    //_________________ACTIVE EXPLOSION_________________
    public void ActiveExplosion()
    {
        _explosionTrigger = true;
        //_explosionPrefab.SetActive(true);
        Debug.Log("explosion activated");
        //Instantiate(_explosionPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        StartCoroutine(ExplosionDeactive());
    }
    IEnumerator ExplosionDeactive()
    {
        yield return new WaitForSeconds(5.0f);
        Debug.Log("explosion deactivated");
        Debug.Log(gameObject);
        _explosionTrigger = false;
        //_explosionPrefab.SetActive(false);
    }
}