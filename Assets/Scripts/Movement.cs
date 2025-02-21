using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _vitessePromenade;
    private Rigidbody _rb;
    private Vector3 directionInput;

    // variables de contr�le d'animation
    [SerializeField] private float _modifierAnimTranslation;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    void OnForwardBackward(InputValue directionBase)
    {
        Vector2 directionAvecVitesse = directionBase.Get<Vector2>() * _vitessePromenade;
        directionInput = new Vector3(directionAvecVitesse.x, 0f, directionAvecVitesse.y);
    }
    void OnUpDown(InputValue directionBase)
    {
        Vector2 directionAvecVitesse = directionBase.Get<Vector2>() * _vitessePromenade;
        directionInput = new Vector3(0f, directionAvecVitesse.y, 0f);
    }
    // Update is called once per frame
  void FixedUpdate()
    {
        // calculer et appliquer la translation
        Vector3 mouvement = directionInput;
        // appliquer la vitesse de translation
        _rb.AddForce(mouvement, ForceMode.VelocityChange);

        // calculer un modifiant pour la vitesse d'animation
        Vector3 vitesseSurPlane = new Vector3(_rb.velocity.x, _rb.velocity.y, 0f);
        _animator.SetFloat("Vitesse", vitesseSurPlane.magnitude * _modifierAnimTranslation);
        //_animator.SetFloat("Deplacement", vitesseSurPlane.magnitude);
    }
}
