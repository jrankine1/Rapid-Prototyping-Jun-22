using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum MoveDirection { up, down, left, right}

public class Playtesting : GameBehaviour
{
    Renderer rend;
    public float moveDistance = 2f;
    public float moveSpeed = 1f;
    public Ease moveEase;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangePlayerColour();

        if (Input.GetKeyDown(KeyCode.UpArrow))
            MovePlayer(MoveDirection.up);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            MovePlayer(MoveDirection.down);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MovePlayer(MoveDirection.left);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            MovePlayer(MoveDirection.right);
    }

    void MovePlayer( MoveDirection _direction)
    {
        switch(_direction)
        {
            case MoveDirection.up:
                transform.DOMoveZ(transform.position.z + moveDistance, moveSpeed).SetEase(moveEase).OnComplete(()=> CameraShake());
                break;
            case MoveDirection.down:
                transform.DOMoveZ(transform.position.z - moveDistance, moveSpeed).SetEase(moveEase).OnComplete(() => CameraShake());
                break;
            case MoveDirection.left:
                transform.DOMoveX(transform.position.x - moveDistance, moveSpeed).SetEase(moveEase).OnComplete(() => CameraShake());
                break;
            case MoveDirection.right:
                transform.DOMoveX(transform.position.x + moveDistance, moveSpeed).SetEase(moveEase).OnComplete(() => CameraShake());
                break;
        }
        //ChangePlayerScale();
        ChangePlayerColour();
        
    }

    void ChangePlayerScale()
    {
        transform.DOScale(Vector3.one * 2, moveSpeed / 2).OnComplete(()=> transform.DOScale(Vector3.one, moveSpeed / 2));
    }

    void ChangePlayerColour()
    {
        //rend.material.color = GetRandomColor();
        rend.material.DOColor(GetRandomColor(), 1f);
    }

    void CameraShake()
    {
        Camera.main.DOShakePosition(moveSpeed, 0.4f);
    }
}
