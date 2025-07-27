using UnityEngine;

public class camera_script : MonoBehaviour
{
    public GameObject player;
    private Vector2 aim_pos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camera_aim = new Vector3(
            Mathf.Floor(player.transform.position.x / 20) * 20 + 10,
            Mathf.Floor(player.transform.position.y / 20) * 20 + 10,
            -10
            );

        transform.position = Vector3.Lerp(transform.position, camera_aim, (float)0.03);
    }
}