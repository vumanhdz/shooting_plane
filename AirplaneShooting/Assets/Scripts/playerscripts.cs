using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscripts : MonoBehaviour
{
    public GameObject explosion;
    public HealthPlayer healthPlayer;
    public CoinCountScrips coinCountScrips;
    public GameController gameController;
    public float speed = 10f;
    public float padding = 0.8f;
    public float minX;
    public float maxX;
    public float maxY;
    public float minY;

    public AudioSource audioSource;
    public AudioClip damageSound;
    public AudioClip explosionSound;

    public float health = 20f;
    float barFillAmount = 1f;
    float damage = 0;
    // Start is called before the first frame update
    void Start()
    {
        Findboundaries();
        damage = barFillAmount / health;
    }
    void Findboundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;

    }

    // Update is called once per frame Vertical
    void Update()
    {
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime*speed;
        
        float newXpos = Mathf.Clamp(transform.position.x + deltaX,minX,maxX);
        float newYpos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newXpos, newYpos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            audioSource.PlayOneShot(damageSound, 0.5f);
            DamageHealthbar();
            Destroy(collision.gameObject);
            if (health <= 0)
            {
/*                audioSource.PlayOneShot(explosionSound, 0.5f);
*/                gameController.GameOver();
                Destroy(gameObject);
                GameObject blast = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(blast, 2f);
            }
        }
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coinCountScrips.Addcount();
        }
    }
    void DamageHealthbar()
    {
        if (health > 0)
        {
            health -= 1;
            barFillAmount = barFillAmount - damage;
            healthPlayer.SetAmount(barFillAmount);
        }
    }
}
