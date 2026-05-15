

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody body;
    public float moveSpeed=5;
    public float rotateSpeed=2;

     Vector3 movement;
  
    // Start is called before the first frame update
    void Start()
    { 
        body= GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.state != GameManager.GameState.Playing) return;
      float  horiz= Input.GetAxis("Horizontal");
     float   vertic= Input.GetAxis("Vertical");
     movement= new Vector3(horiz,0, vertic).normalized;
    }

   void  FixedUpdate()
    {
        Vector3 movePos= body.position + movement* moveSpeed* Time.fixedDeltaTime;

        body.MovePosition(movePos);
        if(movement != Vector3.zero)
        {
            Quaternion targetPos= Quaternion.LookRotation(movement);
            body.MoveRotation(Quaternion.Slerp(body.rotation, targetPos, rotateSpeed*Time.fixedDeltaTime));//Quaternion.Slerp(body.rotation, targetPos, rotateSpeed * Time.fixedDeltaTime));
        }

    }
}
