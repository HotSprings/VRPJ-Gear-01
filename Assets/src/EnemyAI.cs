using UnityEngine;
using UnityEngine.VR;
using VRStandardAssets.Utils;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI {

    private bool init = false;
    private float count = 0;
    private float countMax = 0;
    private Vector3 startPos = new Vector3(0, 0, 0);
    private Vector3 nextMovePos = new Vector3(0, 0, 0);
    public Transform targetTransform = null;

    public enum AIType {
        RANDOM_MOVE = 0
    }
    private AIType m_AI = AIType.RANDOM_MOVE;

    public EnemyAI() {

    }

    public void update() {
        if(m_AI == AIType.RANDOM_MOVE) {
            if (init) {
                init = false;
                count = 0;
                countMax = Random.Range(2.0f, 10.0f);
                
                float x = Random.Range(-6.0f, 6.0f);
                float y = Random.Range(0f, 6.0f);
                float z = Random.Range(-6.0f, 6.0f);
                nextMovePos = new Vector3(x, y, z);
                startPos = targetTransform.localPosition;

            }
            if (count >= countMax) {
                reset();
            }
            else {
                targetTransform.LookAt(new Vector3(0, 2, 0));

                Vector3 vpos = nextMovePos - startPos;
                Vector3 velocity = (vpos/countMax) * count;

                targetTransform.localPosition = startPos + velocity;
            }
        }
        count += Time.deltaTime;
    }

    public void changeAIType(AIType type) {
        if(m_AI != type) {
            m_AI = type;
            reset();
        }
    }

    public void reset() {
        init = true;
    }

}
