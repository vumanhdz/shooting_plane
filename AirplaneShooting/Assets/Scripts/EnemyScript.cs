using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform gunpoint;
    public GameObject enemyBullet;
    public GameObject enemyExpolsion;
    public HealthBar healthbar;
    public float enemyBulletSpawnTime = 0.5f;
    public float speed = 1f;
    public float health = 10f;
    public GameObject Coin;
/*    public AudioClip explosionSound;
*//*    public AudioSource audioSource;
*/


    float barSize = 1f;
    float damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyShooting());
        damage = barSize / health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            DamageHealthbar();
            Destroy(collision.gameObject);
            if (health<=0 )
            {
/*                audioSource.PlayOneShot(explosionSound, 0.5f);
*/                Instantiate(Coin, transform.position, Quaternion.identity);
                Destroy(gameObject);
                GameObject EnemyExpolsiony = Instantiate(enemyExpolsion, transform.position, Quaternion.identity);
                Destroy(EnemyExpolsiony, 0.4f);
            }
            
        }
    }

    void DamageHealthbar()
    {
        if (health > 0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthbar.SetSize(barSize);
        }
    }
    void EnemyFire()
    {
        Instantiate(enemyBullet, gunpoint.position, Quaternion.identity);
    }
    IEnumerator EnemyShooting()
    {
        while (true) 
        {
            yield return new WaitForSeconds(enemyBulletSpawnTime);
            EnemyFire();
        }
    }
}
