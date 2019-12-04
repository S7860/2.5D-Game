using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  GameObject playerObj;
  Vector3 cameraOffSet;

  void Start()
  {
    playerObj = GameObject.Find("Player");
    cameraOffSet = new Vector3(10,10,-3);
  }

  void Update()
  {
      transform.position = playerObj.transform.position + cameraOffSet;
  }


}
