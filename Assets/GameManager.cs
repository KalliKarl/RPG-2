using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxMessages = 25;

    public string username;

    public GameObject chatpanel, textObject;

    public Color playerMessage, info;

    public InputField Chatbox; 

    [SerializeField]
    List<Message> messageList = new List<Message>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Chatbox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(username + ": " + Chatbox.text, Message.MessageType.playerMessage);
                
                Chatbox.text = "";
            }
        }
        else
        {
            if (!Chatbox.isFocused && Input.GetKeyDown(KeyCode.Return))
                Chatbox.ActivateInputField();

        }
        if (!Chatbox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessageToChat("You Pressed space", Message.MessageType.info);
                Debug.Log("Space");
            }
        }
    }
    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMessage = new Message();
        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatpanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = Messagetypecolor(messageType);

        messageList.Add(newMessage);
    }

    Color Messagetypecolor(Message.MessageType messageType)
    {

        Color color = info ;

        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
        }
        color.a = 1;
        return color;
    }

    }

    [System.Serializable]
    public class Message {
        public string text;
        public Text textObject;
        public MessageType messageType;

        public enum MessageType{ playerMessage, info }

    }

