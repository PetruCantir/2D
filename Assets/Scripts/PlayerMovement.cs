using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool onGround;
    private float checkRadius = 0.5f;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private Rigidbody2D _rbPlayer;
    [SerializeField] private Transform _checkGround;
    [SerializeField] private Animator _anim;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private SpriteRenderer _sp;
    

    private void Start()
    {
        _rbPlayer.GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sp = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        Move();
        Jumping();
        CheckingGround();
    }

    private void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;
        _anim.SetFloat("Walk", Mathf.Abs(movement));
        _sp.flipX = movement > 0;
    }

    private void Jumping()
    {
       if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            _rbPlayer.AddForce(Vector2.up * jumpForce);
        } 
    }

    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(_checkGround.position, checkRadius, _ground);
        _anim.SetBool("onGround", onGround);
    }
}
