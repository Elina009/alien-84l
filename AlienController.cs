using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlienController : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController contr;
    Transform tr;
    float horizontalSpeed = 4.0f;
    float jumpHeight = 3f;
    bool isGrounded = false;
    public float score = 0;
    [SerializeField] TextMeshProUGUI scoretext;

    void Start()
    {
        contr = GetComponent<CharacterController>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Vertical");
        contr.Move(tr.forward * vertical * Time.deltaTime);
        tr.Rotate(0,h,0);
        if(Input.GetKeyDown("space") && isGrounded == true){
            contr.Move(tr.up * jumpHeight);
        }
    } 
    void OnControllerColliderHit(ControllerColliderHit col){
        if(col.gameObject.tag == "ground"){
            isGrounded = true;
        } 
        if(col.gameObject.tag == "points"){
            Destroy(col.gameObject);
            score = score + 1;
            scoretext.text = score;
        }
    }
}
