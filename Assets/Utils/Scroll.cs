using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private static int ScrollWidth => 30;
    private static float ScrollSpeed => 25;

    private void MoveCamera()
    {
        var xpos = Input.mousePosition.x;
        var ypos = Input.mousePosition.y;
        var movement = new Vector3(0, 0, 0);
        
        //Debug.Log(xpos);
        //Debug.Log(ypos);
        
        
        if (xpos >= 0 && xpos < ScrollWidth)
        {
            movement.x -= ScrollSpeed;
        } else if (xpos <= Screen.width && xpos > Screen.width - ScrollWidth)
        {
            movement.x += ScrollSpeed;
        }
        
        //vertical camera movement
        if(ypos >= 0 && ypos < ScrollWidth) {
            movement.z -= ScrollSpeed;
        } else if(ypos <= Screen.height && ypos > Screen.height - ScrollWidth) {
            movement.z += ScrollSpeed;
        }
        
        //calculate desired camera position based on received input
        Vector3 origin = transform.position;
        Vector3 destination = origin;
        destination.x += movement.x;
        //destination.y += origin.y;
        destination.z += movement.z;

        transform.position = Vector3.MoveTowards(origin, destination, Time.deltaTime * ScrollSpeed);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }
}
