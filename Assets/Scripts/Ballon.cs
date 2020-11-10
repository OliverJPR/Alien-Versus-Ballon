using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{

    [SerializeField]
    private BalloonType balloonType;
    private Rigidbody2D rb2d;
    [SerializeField]
    private List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        int randomType = Random.Range(0, 4);

        balloonType = (BalloonType)randomType;

        GetComponent<SpriteRenderer>().sprite = sprites[randomType];

        float moveSpeed = Random.Range(0,4);

        if (balloonType == BalloonType.Blue)
        {
            moveSpeed *= 6;
        }

        rb2d.velocity = new Vector2(0.0f, moveSpeed);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Laser>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
public enum BalloonType
{
    Blue = 0, Green = 1, Orange = 2, Red = 3
}
