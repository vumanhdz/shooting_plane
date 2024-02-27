using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotter : MonoBehaviour
{
    public GameObject PlayerBullet;
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public float bulletSpawnTime = 1f;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Fire()
    {
        Instantiate(PlayerBullet, SpawnPoint1.position, Quaternion.identity);
        Instantiate(PlayerBullet, SpawnPoint2.position, Quaternion.identity);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            audioSource.Play();
        }
    }
}
