using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;
      RaycastHit hit;
   
  
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
        Cursor.visible = false; 
        
    }

    void OnGUI()
    {
        int size = 48;
        float posX = cam.pixelWidth/2 - size/4;
        float posY = cam.pixelHeight/2 - size/2;
       GUI.Label(new Rect(posX, posY+120, size, size), "" + hit.point);
        GUI.Label(new Rect(posX, posY, size, size), "*");
       // GUI.Label(new Rect(posX, posY, 5000, 5000), "Hello!");
        
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            
            Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);
            Ray ray = cam.ScreenPointToRay(point);
          
            if (Physics.Raycast(ray, out hit)){
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null){
                    target.ReactToHit();
                } else {
                    StartCoroutine(SphereIndicator(hit.point));
                }
                //Debug.Log("Hit " + hit.point);
                //StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }


    private IEnumerator SphereIndicator(Vector3 pos){
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
