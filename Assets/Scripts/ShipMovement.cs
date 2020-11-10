using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{
    public static ShipMovement Instance { get; private set; }
    private Rigidbody2D rb2d;
    [SerializeField]
    private GameObject shipShoot;
    public Button btnUp, btnDown;
    private bool canShoot = true;
    private float shipSpeed = 10;
    private float shootDelay = 0.3f;
    public bool movUp = false , movDown = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        btnUp.onClick.AddListener(MoveUp);
        btnDown.onClick.AddListener(MoveDown);
            
    }
    private void Update()
    {
       
        if (movUp)
        {
            MoveUp();
        }
        else if (movDown)
        {
            MoveDown();
        }
        else
        {
            Stop();
        }

        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            Shoot();
        }

        movUp = false;
        movDown = false;

    }

    private IEnumerator CO_Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    public void MoveUp()
    {
        movUp = true;
        Move(shipSpeed);
    }

    public void MoveDown()
    {
        movDown = true;
        Move(-shipSpeed);
    }

    public void Stop()
    {
        Move(0f);
    }

    private void Move(float speed)
    {
        rb2d.velocity = new Vector2(0, speed);
    }

    public void Shoot()
    {
        StartCoroutine(CO_Shoot());
        var laserPoint = GameObject.Find("shipShoot").transform;
        Instantiate(shipShoot, new Vector3(laserPoint.position.x, laserPoint.position.y, 0f), Quaternion.identity);
    }
}
