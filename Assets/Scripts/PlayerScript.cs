using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    bool AlreadyInSoil = false;
    bool IsWalking = false;
    bool IsExploding = false;

    private float JumpSpeed = 7f;
    private float Speed = 2f;
    private float Direction = 0f;
    private Rigidbody2D Rb2D;

    private Animator Anim;

    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!IsExploding)
        {
            Walk();
            Jump();
            UpdateTransitions();
            ScoreManager.Instance.DisplayScore();            
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (AlreadyInSoil is true)
            {
                Rb2D.velocity = new Vector2(Rb2D.velocity.x, JumpSpeed);
                AlreadyInSoil = false;
            }
        }
    }

    private void Walk()
    {
        Direction = Input.GetAxis("Horizontal");

        if (Direction > 0f)
        {
            Rb2D.velocity = new Vector2(Direction * Speed, Rb2D.velocity.y);
            transform.localScale = new Vector2(0.32341144f, .32341144f);
            IsWalking = true;
        }
        else if (Direction < 0f)
        {
            Rb2D.velocity = new Vector2(Direction * Speed, Rb2D.velocity.y);
            transform.localScale = new Vector2(-0.32341144f, 0.32341144f);
            IsWalking = true;
        }
        else
        {
            Rb2D.velocity = new Vector2(0, Rb2D.velocity.y);
            IsWalking = false;
        }
    }

    private void UpdateTransitions()
    {
        Anim.SetFloat("Speed", Mathf.Abs(Rb2D.velocity.x));
        Anim.SetBool("OnGround", AlreadyInSoil);
        Anim.SetBool("OnWalk", IsWalking);
    }

    private void PlayerCollideWithABlock(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            if (AlreadyInSoil is false)
                AlreadyInSoil = true;
        }
    }

    private void PlayerCollideWithASpike(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Block_With_Spike"))
        {
            PlayerDie();
        }
    }

    private void PlayerCollideWithACrystal(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Crystal"))
        {
            ScoreManager.Instance.AddScore(5);
        }
    }

    private void PlayerCollideWithAnEnemy(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            CheckIfKillsOrDead(collision);
        }
    }

    private void PlayerCollideWithTheGround(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundKiller"))
        {            
            PlayerDie();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerCollideWithABlock(collision);
        PlayerCollideWithASpike(collision);
        PlayerCollideWithACrystal(collision);
        PlayerCollideWithAnEnemy(collision);
        PlayerCollideWithTheGround(collision);
    }

    private void PlayerDie()
    {
        Anim.Play("Explosion");
        Rb2D.velocity = new Vector2(0, 0);
        Rb2D.gravityScale = 0.0f;
        ScoreManager.Instance.ZeroScore();
    }

    private void RestartScenario()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void StartExplosion()
    {
        IsExploding = true;
    }

    private void EndExplosion()
    {
        IsExploding = false;
        RestartScenario();
    }

    private void CheckIfKillsOrDead(Collision2D collision)
    {
        var direction = transform.position - collision.gameObject.transform.position;

        // It means that the collision happened on the sides.
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            ScoreManager.Instance.ZeroScore();
            PlayerDie();
        }
    }
}