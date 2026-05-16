

using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody body;
    public float moveSpeed=5;
    public float rotateSpeed=2;

       #region Dash
     [Header("Dash Info")]
     public float dashSpeed=20;
     public float dashDura=0.2f;
     public float dashcoolDown=1.5f;

   
     bool isDash;
     bool canDash=true;
     Vector3 movement;

    TrailRenderer trail;

    public Slider dashCoolSlider;
     
    #endregion
    // Start is called before the first frame update
    void Start()
    { 
        body= GetComponent<Rigidbody>();
        trail= GetComponent<TrailRenderer>();

        trail.emitting= false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.state != GameManager.GameState.Playing) return;
      float  horiz= Input.GetAxis("Horizontal");
     float   vertic= Input.GetAxis("Vertical");
     movement= new Vector3(horiz,0, vertic).normalized;


    if(Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

     if(!canDash)
        {
            dashCoolSlider.value -= Time.deltaTime/dashcoolDown;
        }
    }


   System.Collections.IEnumerator Dash()
    {
        dashCoolSlider.value=0;
        canDash= false;
        isDash=true;

        trail.emitting= true;

        Vector3 dashDirection= movement;

        if(dashDirection == Vector3.zero)
        {
            dashDirection= transform.forward;
        }

        body.velocity= dashDirection* dashSpeed;
        yield return new WaitForSeconds(dashDura);

        isDash= false;
        body.velocity= Vector3.zero;

        trail.emitting=false;

        yield return new WaitForSeconds(dashcoolDown);

         canDash= true;

         dashCoolSlider.value=1;
    }
   void  FixedUpdate()
    {
        if(isDash)return;
        Vector3 movePos= body.position + movement* moveSpeed* Time.fixedDeltaTime;

        body.MovePosition(movePos);
        if(movement != Vector3.zero)
        {
            Quaternion targetPos= Quaternion.LookRotation(movement);
            body.MoveRotation(Quaternion.Slerp(body.rotation, targetPos, rotateSpeed*Time.fixedDeltaTime));//Quaternion.Slerp(body.rotation, targetPos, rotateSpeed * Time.fixedDeltaTime));
        }

    }
}
