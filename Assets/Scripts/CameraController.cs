using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public float Offset;
    public float OffsetSmoothing;
    private Vector3 PlayerPosition;

    void Update()
    {
        // Match x,y,z position of the player
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);

        if(Player.transform.localScale.x > 0f)
        {
            PlayerPosition = new Vector3(PlayerPosition.x + Offset, PlayerPosition.y, PlayerPosition.z);
        }
        else
        {
            PlayerPosition = new Vector3(PlayerPosition.x - Offset, PlayerPosition.y, PlayerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, PlayerPosition, OffsetSmoothing * Time.deltaTime);
    }
}
