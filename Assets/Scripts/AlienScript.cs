using UnityEngine;

public class AlienScript : MonoBehaviour
{
    private bool playerCollided;
    public Animator Anim;
    
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnStartExploding()
    {

    }

    private void OnEndExploding()
    {
        DestroyAlien();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerCollided = collision.gameObject.CompareTag("Player");
        
        if (playerCollided)
        {
            CheckIfKillsOrDead(collision);
        }
    }

    #region Private Methods

    private void ActivateExplosionAnimation()
    {
        Anim.SetBool("PlayerCollided", playerCollided);
    }

    private void DisableCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void DestroyAlien()
    {
        Destroy(gameObject);
    }

    private void CheckIfKillsOrDead(Collision2D collision)
    {
        var direction = transform.position - collision.gameObject.transform.position;

        // It means that the collision happened on up or down.
        if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            // Up
            if(Mathf.Abs(direction.y) > 0)
            {
                DisableCollider();
                ActivateExplosionAnimation();
            }                            
        }
    }

    #endregion
}
