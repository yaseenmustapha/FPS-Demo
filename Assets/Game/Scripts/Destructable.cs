using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {
    [SerializeField]
    private GameObject _destroyed;

    public void DestroyObject() {
        Instantiate(_destroyed, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
