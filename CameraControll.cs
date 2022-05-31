using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    public float rotateSpeed = 2.0f;
    private GameObject mainCamera;
    public GameObject player;
    private Vector3 playerPos;
    private Vector3 lastTargetPosition;

    void Start()
    {
        mainCamera = Camera.main.gameObject;
    }


    void Update()
    {
        //プレイヤーの位置取得
        playerPos = player.transform.position;
        rotateCamera();
    }
    private void LateUpdate()
    {
        //プレイヤーを追尾
        mainCamera.transform.position += player.transform.position - lastTargetPosition;
        lastTargetPosition = player.transform.position;
    }

    //カメラを回転させる
    private void rotateCamera()
    {
        
        //X,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, 0, 0);

        //メインカメラを回転させる
        mainCamera.transform.RotateAround(playerPos, Vector3.up, angle.x);
        mainCamera.transform.RotateAround(playerPos, transform.right, angle.y);
    }
}