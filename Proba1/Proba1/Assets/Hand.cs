using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    List<List<ReadFile.Point>> hands;
    ReadFile a;
    public float nextFrame;
   // LineRenderer line;

    // Use this for initialization
    void Start () {

        PipeClient client = new PipeClient();
        client.StartClient();

        a = new ReadFile();
        a.readFile(client.File_name);

        LittleFinger lfScript = this.GetComponentInChildren<LittleFinger>();
        lfScript.Set(a.getPoints("mp_lf"), a.getPoints("mn_lf"), a.getPoints("ppn_lf"), a.getPoints("ipn_lf"), a.getPoints("dpn_lf"));

        MiddleFinger mfScript = this.GetComponentInChildren<MiddleFinger>();
        mfScript.Set(a.getPoints("mp_mf"), a.getPoints("mn_mf"), a.getPoints("ppn_mf"), a.getPoints("ipn_mf"), a.getPoints("dpn_mf"));

        RingFinger rfScript = this.GetComponentInChildren<RingFinger>();
        rfScript.Set(a.getPoints("mp_rf"), a.getPoints("mn_rf"), a.getPoints("ppn_rf"), a.getPoints("ipn_rf"), a.getPoints("dpn_rf"));

        IndexFinger ifScript = this.GetComponentInChildren<IndexFinger>();
        ifScript.Set(a.getPoints("mp_if"), a.getPoints("mn_if"), a.getPoints("ppn_if"), a.getPoints("ipn_if"), a.getPoints("dpn_if"));

        Thumb tScript = this.GetComponentInChildren<Thumb>();
        tScript.Set(a.getPoints("mn_t"), a.getPoints("ppn_t"), a.getPoints("ipn_t"), a.getPoints("dpn_t"));

        Palm pScript = this.GetComponentInChildren<Palm>();
        pScript.Set(a.getPoints("mp_rf"), a.getPoints("mn_rf"), a.getPoints("mp_mf"), a.getPoints("mn_mf"));

        tScript.setNextFrame(nextFrame);
        lfScript.setNextFrame(nextFrame);
        mfScript.setNextFrame(nextFrame);
        rfScript.setNextFrame(nextFrame);
        ifScript.setNextFrame(nextFrame);
        pScript.setNextFrame(nextFrame);


    }

    // Update is called once per frame
    void Update () {
		
	}

    public float getCounter()
    {
        return nextFrame;
    }

}
