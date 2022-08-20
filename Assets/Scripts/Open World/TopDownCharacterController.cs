using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed=4.0f;

        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 3);
                
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            if (Input.GetKey(KeyCode.G))
            {
                SaveManager.SavePlayer(this);
                Debug.Log("Saved");
            }
            if (Input.GetKey(KeyCode.C))
            {
                PlayerData playerData = SaveManager.LoadPlayer();
                transform.position = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);
                Debug.Log("Loaded");
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);
            bool fliped = dir.x < 0;
            this.transform.rotation = Quaternion.Euler(0, fliped ? 0 : 180, 0);
            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
