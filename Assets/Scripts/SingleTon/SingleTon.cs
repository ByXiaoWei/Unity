using UnityEngine;
using System.Collections;
namespace UnityFramework {
    public class SingleTon<T> where T : SingleTon<T>,new()
    {
        private static T _instance;
        protected SingleTon(){}
        public static T GetInstance(){
            if (_instance == null) {
                _instance = new T();
            }
            return _instance;
        }
    }
    public class SingleTonMono<T> : MonoBehaviour where T :MonoBehaviour {
        private static T _instance;
        protected SingleTonMono() { }
        public static T GetInstance() {
            if (_instance == null) {
                GameObject go = new GameObject("FSM");
                _instance = go.AddComponent<T>();
                go.name = _instance.name;
                GameObject.DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

}
