using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetObjectInactive(Collision2D collision)
    {
        collision.gameObject.SetActive(false);
    }   
}
