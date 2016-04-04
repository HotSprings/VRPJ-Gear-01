using UnityEngine;
using UnityEngine.VR;
using VRStandardAssets.Utils;
using System.Collections;

public class MainController : MonoBehaviour {

    [SerializeField]
    private VRInput m_VRInput;
    [SerializeField]
    private GameLabel debugLabel;
    [SerializeField]
    private LightController m_lightController;
    [SerializeField]
    private Camera m_camera;

    void Start () {
        debugLabel = GameObject.Find("DebugLabel").GetComponent<GameLabel>();
        m_lightController = GameObject.Find("Spotlight").GetComponent<LightController>();
    }

    private void OnEnable() {
        m_VRInput.OnDown += downAction;
        m_VRInput.OnUp += upAction;
        m_VRInput.OnDoubleClick += doubleClickAction;
        m_VRInput.OnClick += clickAction;
        m_VRInput.OnCancel += cancelAction;
    }

    private void OnDisable() {
        m_VRInput.OnDown -= downAction;
        m_VRInput.OnUp -= upAction;
        m_VRInput.OnDoubleClick -= doubleClickAction;
        m_VRInput.OnClick -= clickAction;
        m_VRInput.OnCancel -= cancelAction;
    }

    void Update () {
        windowsDebug();
    }

    private void windowsDebug() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = m_camera.ScreenToWorldPoint(mousePos);
        m_camera.transform.LookAt(worldPos);
    }

    private void downAction() {
        debugLabel.addText(string.Format("{0:0000.000}:{1}",Time.time,"down"));
    }
    private void upAction() {
        debugLabel.addText(string.Format("{0:0000.000}:{1}", Time.time, "up"));
        m_lightController.changeLight();
    }
    private void doubleClickAction() {
        debugLabel.addText(string.Format("{0:0000.000}:{1}", Time.time, "double click"));
    }
    private void clickAction() {
        debugLabel.addText(string.Format("{0:0000.000}:{1}", Time.time, "click"));
    }
    private void cancelAction() {
        debugLabel.addText(string.Format("{0:0000.000}:{1}", Time.time, "cancel"));
    }


}
