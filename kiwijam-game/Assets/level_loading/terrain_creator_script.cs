using Unity.VisualScripting;
using UnityEngine;

public class cell_loader : MonoBehaviour
{
    public GameObject cell;
    public GameObject player;

    private Vector2 old_cell = new Vector2(100, 100);

    private bool[,] loaded_cells = new bool[5, 5];




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 current_cell = new Vector2(
            Mathf.Floor(player.transform.position.x / 20),
            Mathf.Floor(player.transform.position.y / 20)
            );
        current_cell.x = (int)Mathf.Clamp(current_cell.x, 0, 5);
        current_cell.y = (int)Mathf.Clamp(current_cell.y, 0, 5);


        if (
            current_cell != old_cell &&
            loaded_cells[(int)current_cell.x, (int)current_cell.y] == false
            )
        {
            loaded_cells[(int)current_cell.x, (int)current_cell.y] = true;

            Debug.Log("try to load" + current_cell);
            GameObject cell_scene = Instantiate(cell);
            cell_scene.GetComponent<SCR_PerlinNoiseMap>().cell_position = current_cell;
        }





        old_cell = current_cell;
    }





}

