using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Core;

public class CharacterModelController : MonoBehaviour
{
    [SerializeField]
    GameObject _aliveModel;

    [SerializeField]
    GameObject _deadModel;

    Character _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = this.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        float scale = 1 + ((_characterController.Level-1) * 0.5f);
        this.transform.localScale = Vector3.one * scale;
        _aliveModel.SetActive(!_characterController.isDead());
        _deadModel.SetActive(_characterController.isDead());
    }
}
