using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private AudioClip npcVoice;
    [SerializeField] private AudioClip playerVoice;
    [SerializeField] private float typingTime;
    [SerializeField] private int charsToPlaySound;
    private bool isPlayerTalking;

    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;//The panel that contains the dialogue text
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string[] dialogueLines;//The lines of dialogue that will be displayed

    private bool isPlayerInRange;
    private AudioSource audioSource;
    private bool didDialogueStart;
    private int lineIndex;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = npcVoice;
    }
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Space)){
            if(!didDialogueStart){
                 StartDialogue();
            }
           else if(dialogueText.text == dialogueLines[lineIndex]){
                NextDialogueLine();
            }
            else{
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }
    public void StartDialogue(){
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex=0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine(){
        lineIndex++;
        if(lineIndex < dialogueLines.Length){
            StartCoroutine(ShowLine());
        }
        else{
            didDialogueStart=false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private void SelectAudioClip(){
        //The string start with an especific text to determine the audio clip to play
        audioSource.clip = dialogueLines[lineIndex].StartsWith("Tú: ") ? playerVoice : npcVoice;
    }

    private IEnumerator ShowLine(){
        SelectAudioClip();
        dialogueText.text = string.Empty;
        int charIndex = 0;
        foreach(char letter in dialogueLines[lineIndex]){
            dialogueText.text += letter;

            if(charIndex % charsToPlaySound == 0){//Play the sound every x characters
                audioSource.Play();
            }
            
            charIndex++;
            yield return new WaitForSecondsRealtime(typingTime);
        }

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
