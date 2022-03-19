using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    private Animator Anim;
    private bool playerCollided = false;

    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnStartExploding()
    {
        
    }

    private void OnEndExploding()
    {
        DestroyCrystal();
        DecreaseCrystalValueAfterExplosion();
        CheckIfNeedsCreateMoreCrystals();        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerCollided = collision.gameObject.CompareTag("Player");

        if (playerCollided)
        {
            DisableCollider();
            playerCollided = true;
            ActivateExplosionAnimation();
        }
    }

    #region Private Methods

    private int GetCrystalNumber()
    {
        return CrystalGenerator.Instance.GetCrystalNumber();
    }

    private void DisableCollider()
    {
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
    }

    private void ActivateExplosionAnimation()
    {
        Anim.SetBool("PlayerCollided", playerCollided);
    }

    private void DecreaseCrystalValueAfterExplosion()
    {
        CrystalGenerator.Instance.SetCrystalNumber(GetCrystalNumber() - 1);
    }

    private void DestroyCrystal()
    {
        Destroy(gameObject);
    }

    private void CheckIfNeedsCreateMoreCrystals()
    {
        if (GetCrystalNumber() < 1)
            CrystalGenerator.Instance.Generate3NewCrystals();
    }

    #endregion
}
