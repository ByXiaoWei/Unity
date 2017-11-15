using UnityEngine;
using System.Collections;
using UnityFramework;
public class FSMTest : MonoBehaviour {

    // Use this for initialization
    void Start() {
        GameObject.Find("Cube").GetComponent<FSMControllerr>().Init();
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.J)) {
            FSM.GetInstance().HandleEvent("Jump");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            FSM.GetInstance().HandleEvent("DoubleJump");
        }
    } 
}
