using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.81f;
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitmarkerPrefab;
    [SerializeField]
    private AudioSource _weaponAudio;
    [SerializeField]
    private int currentAmmo;
    private int maxAmmo = 60;
    private bool _isReloading = false;
    private UIManager _uiManager;
    [SerializeField]
    public bool hasCoin = false;

	// Use this for initialization
	void Start () {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        currentAmmo = maxAmmo;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _uiManager.UpdateAmmo(currentAmmo);
	}
	
	// Update is called once per frame
	void Update () {
        CalculateMovement();

        if (Input.GetMouseButton(0) && currentAmmo > 0 && !_isReloading) {
            Shoot();
        } else {
            _muzzleFlash.SetActive(false);
            _weaponAudio.Stop();
        }

        if ((Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && !_isReloading) || currentAmmo == 0) {
            _isReloading = true;
            StartCoroutine(Reload());
        }
            

        if (Input.GetKey(KeyCode.Escape)) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
            
	}

    void Shoot() {
        _muzzleFlash.SetActive(true);
        currentAmmo--;
        _uiManager.UpdateAmmo(currentAmmo);
        if (!_weaponAudio.isPlaying)
            _weaponAudio.Play();

        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, out hitInfo)) {
            Debug.Log("Hit: " + hitInfo.transform.name);
            GameObject hitmarker = Instantiate(_hitmarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitmarker, 1f);
        }
    }

    void CalculateMovement() {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator Reload() {
        yield return new WaitForSeconds(1.5f);
        currentAmmo = maxAmmo;
        _uiManager.UpdateAmmo(currentAmmo);
        _isReloading = false;
    }
}
