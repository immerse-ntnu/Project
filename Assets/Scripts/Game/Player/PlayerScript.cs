using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;

    private float _horizontalforce = 3;
    private float _horizontalspeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody2D.AddForce(Vector2.up * _horizontalforce);
            _rigidbody2D.velocity = Vector2.up * _horizontalspeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody2D.AddForce(Vector2.down * _horizontalforce);
            _rigidbody2D.velocity = Vector2.down * _horizontalspeed;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody2D.AddForce(Vector2.left * _horizontalforce);
            _rigidbody2D.velocity = Vector2.left * _horizontalspeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody2D.AddForce(Vector2.right * _horizontalforce);
            _rigidbody2D.velocity = Vector2.right * _horizontalspeed;
        }
        
        
    }
}
