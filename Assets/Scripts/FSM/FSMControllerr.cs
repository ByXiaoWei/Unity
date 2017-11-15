using UnityEngine;
using System.Collections;
using UnityFramework;
public class FSMControllerr : MonoBehaviour {

    public void Init() {
        FSM.FSMState idleState = new FSM.FSMState("idle");
        FSM.FSMState runState = new FSM.FSMState("run");
        FSM.FSMState jumpState = new FSM.FSMState("jump");
        FSM.FSMState doubleJumpState = new FSM.FSMState("doubleJump");
        //FSM.FSMState dieState = new FSM.FSMState("die");
        FSM.FSMTranslation run = new FSM.FSMTranslation(idleState, "Run", runState, Run);
        FSM.FSMTranslation jump = new FSM.FSMTranslation(runState, "Jump", jumpState, Jump);
        FSM.FSMTranslation doubleJump = new FSM.FSMTranslation(jumpState, "DoubleJump", doubleJumpState, DoubleJump);

        FSM.GetInstance().AddState(idleState);
        FSM.GetInstance().AddState(runState);
        FSM.GetInstance().AddState(jumpState);
        FSM.GetInstance().AddState(doubleJumpState);

        FSM.GetInstance().AddTranslation(run);

        FSM.GetInstance().AddTranslation(jump);
        FSM.GetInstance().AddTranslation(doubleJump);

        FSM.GetInstance().Start(runState);
    }
    void Update()
    {
        Run();
    }
    void Run()
    {
        Debug.Log("Run");
        
        this.transform.Translate(transform.forward * Time.deltaTime) ;
    }
    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up*100);
    }
    void DoubleJump() {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
    }
}
