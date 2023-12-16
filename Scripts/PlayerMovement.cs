using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using ExitGames.Client.Photon;
public class PlayerMovement : MonoBehaviourPunCallbacks
{

    public GameObject leftLeg;
    public GameObject rightLeg;
    Rigidbody2D leftLegRB;
    Rigidbody2D rightLegRB;
    int jumps = 1;
    public PhotonView view;
    bool isJumping = false;
    public GameObject camHolder;
    public Animator anim;
    public Text nameText;
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float legWait = .5f;
    public Transform torso;
    public GameObject body;
    private bool moveLeft;
    private bool moveRight;
    private bool jump;
    bool isPaused = false;
    public bool dead = false;
    public static Dictionary<int, PlayerMovement> playerList = new Dictionary<int, PlayerMovement>();
    public int ID;
    public GameObject buttonHolder;
    // Start is called before the first frame update

   
    void Start()
    {
        playerList.Add(ID, this);
        leftLegRB = leftLeg.GetComponent<Rigidbody2D>();
        rightLegRB = rightLeg.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
        moveLeft = false; moveRight = false;
         
        view = GetComponent<PhotonView>();
      


    }
    public void PointerDownLeft()
    {
        if (view.IsMine)
        {
            moveLeft = true;
        }
    }
    public void PointerUpLeft()
    {
        if (view.IsMine)
        {
            moveLeft = false;
        }
    }
    public void PointerDownJump()
    {
        if (view.IsMine)
        {
            jump = true;
        }
    }
    public void PointerUpJump()
    {
        if (view.IsMine)
        {
            jump = false;
        }
    }

    public void PointerDownRight()
    {
        if (view.IsMine)
        {
            moveRight = true;
        }
    }
    public void PointerUpRight()
    {
        if (view.IsMine)
        {
            moveRight = false;
        }
    }



    public void Death()
    {
        if (view.IsMine)
        {
            dead = true;
            //body.SetActive(false);
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("Menu");
         
            
            //body.SetActive(true);
        }
    }
 
    public void LeaveRoom()
    {
     

        
    }

 

    // Update is called once per frame
    void Update()
    {

        if (view.IsMine)
        {
            nameText.text = PhotonNetwork.NickName;
            nameText.GetComponent<Text>().color = Color.yellow;
        }
        else
        {
            nameText.text = view.Owner.NickName;
            nameText.GetComponent<Text>().color = Color.blue;
        }
        if (view.IsMine)
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                string playerNickname = player.NickName;
                Text nameText = FindNicknameText(player.ActorNumber);
                if (nameText != null)
                {
                    nameText.text = playerNickname;
                }
            }
            Text FindNicknameText(int playerActorNumber)
            {
                // Find the UI text component for the player with the specified actor number
                Text nameText = GameObject.Find("NameText").GetComponent<Text>();
                return nameText;
            }




            nameText.text = PhotonNetwork.NickName;
            if (moveRight)
            {

                anim.Play("WalkLeft");
                StartCoroutine(MoveRight(legWait));

            }
            else if (moveLeft)
            {
                anim.Play("WalkLeft");
                StartCoroutine(MoveLeft(legWait));
            }
            else if (jump)
            {

                Jump();
            }

            else
            {
                
                anim.Play("idle");
            }
                
            
            
            
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    horizontal = touch.deltaPosition.x;
                    vertical = touch.deltaPosition.y;
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene("Menu");
               
            }


            

           

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    anim.Play("WalkLeft");
                    StartCoroutine(MoveRight(legWait));
                }
                else
                {
                    anim.Play("WalkRight");
                    StartCoroutine(MoveLeft(legWait));

                }

            }
            else
            {
                anim.Play("idle");
            }
            if (Input.GetKeyDown(KeyCode.Space) && jumps == 1)
            {
                isJumping = true;
                leftLegRB.AddForce(Vector2.up * (jumpHeight * 1000));
                rightLegRB.AddForce(Vector2.up * (jumpHeight * 1000));
                jumps = 0;
                StartCoroutine(wait());

            }
        }
        else if (!view.IsMine && camHolder.transform.GetChild(0).GetComponent<Camera>().enabled)
        {
            // Destroy(camHolder);
            camHolder.transform.GetChild(0).GetComponent<Camera>().enabled = false;
        }
        else if (!view.IsMine)
        {
            buttonHolder.SetActive(false);
            for (int i = 0; i < buttonHolder.transform.childCount; i++)
            {
                buttonHolder.transform.GetChild(i).gameObject.SetActive(false);
            }
        }



    }
    public void Jump()
    {
        if (jumps ==1)
        {
            isJumping = true;
            leftLegRB.AddForce(Vector2.up * (jumpHeight * 1000));
            rightLegRB.AddForce(Vector2.up * (jumpHeight * 1000));
            jumps = 0;
            StartCoroutine(wait());
        }
      
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.8f);
        jumps = 1;
    }

    IEnumerator MoveRight(float seconds)
    {
        leftLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        rightLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
    }

    IEnumerator MoveLeft(float seconds)
    {
        rightLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        leftLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
    }
 
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(PhotonNetwork.NickName);
        }
        else
        {
            // Network player, receive data
            this.nameText.text = (string)stream.ReceiveNext();
        }
    }

    
}