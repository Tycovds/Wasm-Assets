using UnityEngine;

public class mouse_down : MonoBehaviour
{
    public GameObject cube;
    public Rigidbody body;

    //When the mouse hovers over the cubes, it turns to this color
    Color mouseover_color = new Color32(255, 68, 68, 255);

    //This stores the cubes original color
    Color original_color;

    //Get the cubes mesh renderer to access the color
    MeshRenderer mesh_renderer;

    public int torque = 20;

    void Start()
    {
        //Get the mesh renderer component from the cube
        mesh_renderer = GetComponent<MeshRenderer>();

        //Fetch the original color of the GameObject
        original_color = mesh_renderer.material.color;
    }

    void OnMouseOver()
    {
        // Change the color of the GameObject to red when the mouse is over GameObject
        mesh_renderer.material.color = mouseover_color;

        //Rotate the cube with w a s d and jump space
        if (Input.GetKey("w"))
        {
            body.AddTorque(torque, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            body.AddTorque(-torque, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            body.AddTorque(0, 0, torque);
        }
        if (Input.GetKey("d"))
        {
            body.AddTorque(0, 0, -torque);
        }
        if (Input.GetKey("space"))
        {
            body.AddForce(0, 10, 0);
        }
    }

    void OnMouseExit()
    {
        // Reset the color of the cube back to normal
        mesh_renderer.material.color = original_color;
    }

}
