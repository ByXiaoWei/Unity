using UnityEngine;
using System.Collections;
using UnityFramework;
public class APP : SingleTonMono<APP>{
    public APPMode mode = APPMode.Developing;
    private APP() { }
    void Awake() {
        //Application.tra
    }
}
public enum APPMode {
    Developing,
    QA,
    Release
}
