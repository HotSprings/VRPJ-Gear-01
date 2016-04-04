using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

    [SerializeField]
    private Light m_light;

    void Awake() {
        
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeLight() {
        if(!m_light.enabled) {
            m_light.enabled = true;
            //m_light.color = new Color(m_light.color.r, m_light.color.g, m_light.color.b, 1.0f);
        }
        else {
            m_light.enabled = false;
            //m_light.color = new Color(m_light.color.r, m_light.color.g, m_light.color.b, 0f);
        }
    }
}
