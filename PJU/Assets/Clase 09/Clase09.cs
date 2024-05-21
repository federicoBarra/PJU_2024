using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase09 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    //Time.unscaledDeltaTime;
	    //Time.timeScale = 0;
        //Time.fixedDeltaTime
        //Time.fixedUnscaledDeltaTime
	}

    IEnumerator Coru()
    {
	    yield return new WaitForSecondsRealtime(5);

		yield return null;
    }
}
