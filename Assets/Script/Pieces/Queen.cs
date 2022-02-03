using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (this.transform.parent.GetComponent<TileClick>().enabled == true)
        {
            this.transform.parent.GetComponent<TileClick>().OnMouseDown();
        }
        print(this.name);
    }
}
