
using Unity.Mathematics;
using UnityEngine;

public class BasketStorage : MonoBehaviour
{
    public GameObject storedEgg;
    public Transform eggHolder;

    private int eggCount =1;

   public float x,z;
    public float layerHeight=0.05f;
    public void AddEgg()
    {

        int eggperRow=3;
         
        int row= eggCount/eggperRow;
        int column= eggCount% eggperRow;
        int layer= row/eggperRow;
    Vector3 offset= new Vector3((column-1)* x, layer *layerHeight,((row % eggperRow)-1) * z );
    GameObject egg =Instantiate(storedEgg, eggHolder);
    egg.transform.localPosition= offset;
    egg.transform.localRotation= Quaternion.identity;
    
    eggCount++;
    }
}
