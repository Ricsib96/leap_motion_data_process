using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Test : MonoBehaviour {

    List<List<ReadFile.Point>> hands;
    ReadFile a;
    public GameObject sphere,sphere2;
    
    Vector3 pos;
    Vector3 pos2;

    // Use this for initialization
    void Start () {
        a = new ReadFile();      
        //a.readFile();
        //  hands = a.getHands();
        //   LittleFinger lf = gameObject.GetComponentInChildren<LittleFinger>();
        GameObject lf = GameObject.Find("TestLines");
        LittleFinger lfScript = lf.GetComponent<LittleFinger>();
        lfScript.Set(a.getPoints("mp_lf"), a.getPoints("mn_lf"), a.getPoints("ppn_lf"), a.getPoints("ipn_lf"), a.getPoints("dpn_lf"));
        

      //  Debug.Log(hands.ElementAt(0).ElementAt(0));
       
        //Debug.Log(first.transform.position);
      //  pos = first.transform.position;
       // pos2 = second.transform.position;
       
       
    }
	
	// Update is called once per frame
	void Update () {

        /*pos.x += 0.001f;
        sphere.transform.position += pos;
        pos2.x += 0.001f;
        sphere2.transform.position -= pos;
        */

    }
}
