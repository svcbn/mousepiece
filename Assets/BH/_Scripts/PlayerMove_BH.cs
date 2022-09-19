using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PhotonView))]
public class PlayerMove_BH : MonoBehaviour
{
    public float speed = 5;

    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        GameManager_BH.instance.playerPV.Add(GetComponent<PhotonView>());
        GameManager_BH.instance.playerList.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //anim.SetFloat("Speed", v);
        //anim.SetFloat("Direction", h);

        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        cc.Move(dir * speed * Time.deltaTime);
    }
}
