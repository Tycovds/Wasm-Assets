using UnityEngine;
using UnityEngine.UI;

public class init_blocks : MonoBehaviour
{
    //Get cube prefab
    public GameObject cube;
    public Slider size_slider;
    public Slider column_slider;
    public Slider row_slider;
    public Button reset;
    int size = 2;
    int columns = 3;
    int rows = 3;
  
    void Start()
    {

        init_cubes();
        
        //listen for reset button
        reset.onClick.AddListener(resetScene);
    }
    //reset scene with new slider values
    void resetScene()
    {
        //get current cubes in scene
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("cube");
        //get every cube in list and destroy it
        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
        }
        //get slider values
        size = (int)size_slider.value;
        columns = (int)column_slider.value;
        rows = (int)row_slider.value;
        //make new cubes
        init_cubes();
    }

    //make cubes based on size, columns and rows
    void init_cubes()
    {
        for (int i = 0; i < columns; ++i)
        {
            for (int j = 0; j < rows; ++j)
            {
                //Change the cube prefab scale with the size we want
                cube.transform.localScale = new Vector3(size, size, size);

                //Instantiate a new cube in the middle of the camera with the right column (x) and row (y) coördinates
                Instantiate(cube, new Vector3(i * size - Mathf.Ceil(columns * size / 2), j * size + Mathf.Ceil(rows * size / 2), 2), Quaternion.identity);
            }
        }
    }
   
}
