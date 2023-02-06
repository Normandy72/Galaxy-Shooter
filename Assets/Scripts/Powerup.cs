using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    // ID for powerups
    // 0 = triple shot
    // 1 = speed
    // 2 = shields
    [SerializeField] private int _powerupID;

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                if(_powerupID == 0)
                {
                    player.TripleShotActive();
                }
                else if(_powerupID == 1)
                {
                    Debug.Log("Collected speed boost");
                }
                else if(_powerupID == 2)
                {
                    Debug.Log("Shields collected");
                }
            }
            
            Destroy(this.gameObject);
        }
    }
}