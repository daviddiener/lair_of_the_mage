using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollider : MonoBehaviour
{
      private void OnTriggerEnter2D(Collider2D collider)
    {
        transform.parent.gameObject.GetComponent<Soldier_ai>().OnCollisionEnter2DChild(collider);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        transform.parent.gameObject.GetComponent<Soldier_ai>().OnCollisionExit2DChild(collider);
    }
}
