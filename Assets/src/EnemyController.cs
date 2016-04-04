using UnityEngine;
using UnityEngine.VR;
using VRStandardAssets.Utils;
using System.Collections;

public class EnemyController : MonoBehaviour {
    [SerializeField]
    private Camera m_camera;
    [SerializeField]
    private AudioClip m_DamegeClip;
    [SerializeField]
    private VRInteractiveItem m_InteractiveItem;

    private AudioSource m_Audio;                                    // Used to play the various audio clips.
    private Renderer m_Renderer;                                    // Used to make the target disappear before it is removed.
    private Collider m_Collider;                                    // Used to make sure the target doesn't interupt other shots happening.
    private bool m_IsEnding;                                        // Whether the target is currently being removed by another source.

    private EnemyAI AI = null;

    public EnemyController() {

    }

    void Start() {
        m_Audio = GetComponent<AudioSource>();
        m_InteractiveItem = GetComponent<VRInteractiveItem>();
        Debug.Log(m_InteractiveItem);
        m_Renderer = GetComponent<Renderer>();
        m_Collider = GetComponent<Collider>();

        AI = new EnemyAI();
        AI.targetTransform = this.transform;
        AI.reset();
    }

    void Update() {
        AI.update();
    }

    private void OnEnable() {
        Debug.Log("OnEnable" + m_InteractiveItem);
        m_InteractiveItem.OnDown += HandleDown;
    }


    private void OnDisable() {
        m_InteractiveItem.OnDown -= HandleDown;
    }


    private void OnDestroy() {
        // Ensure the event is completely unsubscribed when the target is destroyed.
    }

    private void HandleDown() {
        // If it's already ending, do nothing else.
        if (m_IsEnding)
            return;

        // Otherwise this is ending the target's lifetime.
        //m_IsEnding = true;

        // Turn off the visual and physical aspects.
        //m_Renderer.enabled = false;
        //m_Collider.enabled = false;

        // Play the clip of the target being hit.
        m_Audio.clip = m_DamegeClip;
        m_Audio.Play();

        // Instantiate the shattered target prefab in place of this target.
        //GameObject destroyedTarget = Instantiate(m_DestroyPrefab, transform.position, transform.rotation) as GameObject;

        // Destroy the shattered target after it's time out duration.
        //Destroy(destroyedTarget, 60);

    }
}
