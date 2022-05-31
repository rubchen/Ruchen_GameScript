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
        //�v���C���[�̈ʒu�擾
        playerPos = player.transform.position;
        rotateCamera();
    }
    private void LateUpdate()
    {
        //�v���C���[��ǔ�
        mainCamera.transform.position += player.transform.position - lastTargetPosition;
        lastTargetPosition = player.transform.position;
    }

    //�J��������]������
    private void rotateCamera()
    {
        
        //X,Y�����̉�]�̓x�������`
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, 0, 0);

        //���C���J��������]������
        mainCamera.transform.RotateAround(playerPos, Vector3.up, angle.x);
        mainCamera.transform.RotateAround(playerPos, transform.right, angle.y);
    }
}