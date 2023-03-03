using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    public GameObject buttonModel;
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI speakerTitleText;
    public TextMeshProUGUI speakerContentText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(string speakerName,string speakerTitle,string speakContent,List<ConversationOption> options)
    {
        speakerNameText.text = speakerName;
        speakerTitleText.text = speakerTitle;
        speakerContentText.text = speakContent;
    }
}
