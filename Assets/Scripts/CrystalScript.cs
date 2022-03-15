using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    private Animator Anim;
    private bool playerCollided = false;    

    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnStartExploding()
    {

    }

    private void OnEndExploding()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCollided = true;
            Anim.SetBool("PlayerCollided", playerCollided);
            CrystalSpawn.Generate3NewCrystals();
        }
    }
}
