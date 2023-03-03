using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1Statue : MonoBehaviour
{
    public GameObject followGO;
    private GameObject interactButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (interactButton != null)
        {
            return;
        }
        //judge if is player enter
        if(other.gameObject.name != "PF Player")
        {
            return;
        }

        interactButton = UIFactory.GenerateInteractButton(followGO, 300,250,"You: ...a statue?",()=> {
            GameObject.Destroy(interactButton);
            interactButton = null;
            Debug.Log("InteractButton Clicked!");
        });
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //judge if is player enter
        if (other.gameObject.name != "PF Player")
        {
            return;
        }

        if (interactButton != null)
        {
            Destroy(interactButton);
            interactButton = null;
        }
    }
}
