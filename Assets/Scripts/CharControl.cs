using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharControl : MonoBehaviour
{
    private NavMeshAgent mMeshAgent;
    private int blood = 5;
    private Brick mPreviousBrick;
    private Brick mCurrentBrick;

    void Start()
    {
        mMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Debug.Log("Le diste click secundario a un ladrillo");
                GameObject hitObject = hit.transform.gameObject;
                Brick brick = hitObject.GetComponent<Brick>();
                if (brick != null) {
                    brick.Blocked();
                }
            }
        }
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                Brick brick = hitObject.GetComponent<Brick>();
                if (brick != null) {
                    mMeshAgent.SetDestination(hit.transform.position);
                }
            }
        }
        DetectMine();
    }

    private void DetectMine()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.2f, out hit)) {
            GameObject hitObject = hit.transform.gameObject;
            Brick brick = hitObject.GetComponent<Brick>();
            if (brick != null) {
                brick.ShowSecret();

                if (brick.mine && mPreviousBrick != null) {
                    mMeshAgent.SetDestination(mPreviousBrick.transform.position);
                    blood -= 1;
                }

                if (brick != mCurrentBrick) {
                    mPreviousBrick = mCurrentBrick;
                    mCurrentBrick = brick;
                }
            }
        }
    }
}