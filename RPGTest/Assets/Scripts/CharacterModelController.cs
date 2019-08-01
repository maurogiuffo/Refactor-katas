using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModelController : MonoBehaviour
{
    [SerializeField]
    GameObject _aliveModel;

    [SerializeField]
    GameObject _deadModel;

    RPGCharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = this.GetComponent<RPGCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float scale = 1 + ((_characterController.Level-1) * 0.5f);
        this.transform.localScale = Vector3.one * scale;
        _aliveModel.SetActive(_characterController.State == Constants.CharacterStates.alive);
        _deadModel.SetActive(_characterController.State == Constants.CharacterStates.dead);
    }
}
