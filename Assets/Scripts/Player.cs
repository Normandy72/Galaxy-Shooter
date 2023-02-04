using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 0.5f;
    private float _canFire = -1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position  = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }
    }

    void CalculateMovement()
    {
        // --- user input ---
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        // Vector3.right == new Vector3(1, 0, 0);
        // Vector3.up == new Vector3(0, 1, 0);
        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        transform.Translate(direction * _speed * Time.deltaTime);


        // --- bounds ---
        // if(transform.position.y >= 0)
        // {
        //     transform.position = new Vector3(transform.position.x, 0, 0);
        // }
        // else if(transform.position.y <= -3.8f)
        // {
        //     transform.position = new Vector3(transform.position.x, -3.8f, 0);
        // }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if(transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if(transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }
}
