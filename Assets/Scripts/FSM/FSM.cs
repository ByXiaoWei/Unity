using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace UnityFramework
{
    public class FSM : SingleTonMono<FSM>
    {
        public delegate void FSMCallBack();
        public class FSMState {
            public string _name;
            public FSMState(string name)
            {
                _name = name;
            }
            public Dictionary<string, FSMTranslation> translantionDic = new Dictionary<string, FSMTranslation>();
        }
        public class FSMTranslation {
            public FSMState fromState;
            public string name;
            public FSMState toState;
            public FSMCallBack callBack;
            public FSMTranslation(FSMState fromState,string name,FSMState toState,FSMCallBack callBack)
            {
                this.fromState = fromState;
                this.toState = toState;
                this.name = name;
                this.callBack = callBack;
               
            }
        }
        private FSMState currentState;
        Dictionary<string, FSMState> stateDic = new Dictionary<string, FSMState>();
       
        public void AddState(FSMState state) {
            if (stateDic.ContainsKey(state._name)) {
                return;
            }
            stateDic.Add(state._name, state);
        }
        public void AddTranslation(FSMTranslation translation) {
           
            stateDic[translation.fromState._name].translantionDic[translation.name] = translation;
        }
        public void Start(FSMState state) {
            currentState = state;
        }
        public void HandleEvent(string name) {
            if (currentState != null && currentState.translantionDic.ContainsKey(name)) {
                Debug.Log("FromState:" + currentState._name);
                currentState.translantionDic[name].callBack();
                currentState = currentState.translantionDic[name].toState;
                Debug.Log("toState:" + currentState._name);
            }
        }
        void Update()
        {
            //Debug.Log(currentState._name);
        }
    }
}