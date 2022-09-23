using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVote : MonoBehaviour
{
    Camera cam;

    bool canVote = false;

    public bool CanVote
    {
        get
        {
            return canVote;
        }
        set
        {
            canVote = value;
        }
    }

    public static PlayerVote instance;

    private void Awake()
    {
        instance = this;    

    }

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager_BH.instance.state == GameManager_BH.gameState.Vote)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                VoteFavorite();
            }
        }
        
    }

    void VoteFavorite()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        

        if(Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.GetComponent<Likes>())
            {
                hitInfo.collider.gameObject.GetComponent<Likes>().Like++;
                //canVote = false;
            }
        }
    }
}