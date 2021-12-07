using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using TMPro;
public class DialogBox : MonoBehaviour {
    [SerializeField] Image talkBackground;
    [SerializeField] Image portrait;
    public Sprite portraitSprite { set { portrait.sprite = value; } }
    [SerializeField] TextMeshProUGUI textTMP;
    WaitForSeconds waitForSecond;
    float typingSpeed;

    DialogData dialogData;

    Coroutine dialogRoutine;
    public float TypingSpeed { get { return typingSpeed; } set { typingSpeed = value; waitForSecond = new WaitForSeconds(value); } }
    public bool isTyping = false;

    public event Action typingEnd = delegate { };

    public void StartDialog(DialogData dialogData, Sprite sprite) {
        this.dialogData = dialogData;
        portrait.sprite = sprite;
        gameObject.SetActive(true);
        dialogRoutine = StartCoroutine(C_TextUpdate(dialogData, 0.05f));
    }
    public void DialogCompletion() {
        StopCoroutine(dialogRoutine);
        textTMP.text = dialogData.dialog;
        isTyping = false;
        EventManager.Instance.TriggerEventMessage(dialogData.typingEndEvent);
        typingEnd();
    }
    IEnumerator C_TextUpdate(DialogData dialogData, float speed) {
        this.dialogData = dialogData;
        isTyping = true;

        TypingSpeed = speed;
        textTMP.text = "";
        int index = -1;
        int startIndex = 0;
        bool startCommand = false;
        StringBuilder bulider = new StringBuilder();
        StringBuilder commandBuilder = new StringBuilder();
        waitForSecond = new WaitForSeconds(speed);

        EventManager.Instance.TriggerEventMessage(dialogData.typingStartEvent);
        while (true) {
            index++;
            if (index >= dialogData.dialog.Length)
                break;

            if (dialogData.dialog[index] == '<') {
                startCommand = true;
                startIndex = index + 1;
                commandBuilder.Clear();
            }
            if (startCommand) {
                commandBuilder.Append(dialogData.dialog[index]);
                if (dialogData.dialog[index] == '>') {
                    string command = dialogData.dialog.Substring(startIndex, index - startIndex);
                    if (!TalkManager.Instance.Command(command)) {
                        bulider.Append(commandBuilder.ToString());
                    }
                    startCommand = false;
                }
                continue;
            }
            yield return waitForSecond;
            bulider.Append(dialogData.dialog[index]);
            textTMP.text = bulider.ToString();
        }
        DialogCompletion();
    }
}