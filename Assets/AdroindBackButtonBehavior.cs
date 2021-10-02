using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdroindBackButtonBehavior : MonoBehaviour
{
    public GameObject ob;
    public enum Function
    {
        closeWindows, quitAplication, none
    }
    public enum ObjectDestiny
    {
        destroy, close, none
    }

    public Function function;
    public ObjectDestiny objectDestiny;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(objectDestiny == ObjectDestiny.close){
                    ob.SetActive(false);
                }

                if(objectDestiny == ObjectDestiny.destroy){
                    Destroy(ob);
                }
                // Quit the application
                //Application.Quit();
            }
        }
    }
}
