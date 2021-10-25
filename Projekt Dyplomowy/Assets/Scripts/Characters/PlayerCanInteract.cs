using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanInteract : MonoBehaviour
{
    // Start is called before the first frame update
    bool canClickObject = false;

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("I see you");
        canClickObject = true;
      //  player.collider.isTrigger = false;
     // GetComponent<Collider>().isTrigger = false;
    }

    private void OnTriggerExit2D(Collider2D other){
        Debug.Log("I cant see you");
        canClickObject = false;
    }

    void  Update(){
       if(canClickObject){
          // Debug.Log("You can click" + canClickObject);
           if(Input.GetMouseButtonDown(0)){
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction,Mathf.Infinity);
            if(hit.collider.name == "Player"){
                //
            }
            else if(hit){
                Debug.Log("You click -> " + hit.collider.name);
            }
            else{
                Debug.Log("No interaction");
            }
        }
       }
      

    }
   
}
