using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Ballon : MonoBehaviour
{
    [SerializeField]
    private BalloonType balloonType;
    private Rigidbody2D rb2d;
    [SerializeField]
    private List<Sprite> ballons;
    [SerializeField]
    public GameManager Instance;

  

    void Start()
    {
        Instance = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        rb2d = GetComponent<Rigidbody2D>();
        
        int randomType = Random.Range(0, 4);

        balloonType = (BalloonType)randomType;

        GetComponent<SpriteRenderer>().sprite = ballons[randomType];

        float moveSpeed = Random.Range(0,4);

        if (balloonType == BalloonType.Blue)
        {
            moveSpeed = 10;
        }

        rb2d.velocity = new Vector2(0.0f, moveSpeed);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ShipShoot>() != null && GetComponent<SpriteRenderer>().sprite == ballons[0])
        {
            Instance.updateScore(50);
            print("Azul");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.GetComponent<ShipShoot>() != null)
        {
            Instance.updateScore(10);
            print("X");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
public enum BalloonType
{
    Blue = 0, Green = 1, Orange = 2, Red = 3
}
