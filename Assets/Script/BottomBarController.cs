using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;

    private enum State
    {
        PLAYING, COMPLETED
    }

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
    }

    public void PlayNextSentence()
    {
        if (currentScene != null && sentenceIndex + 1 < currentScene.sentences.Count)
        {
            sentenceIndex++;
            StartCoroutine(TypeText(currentScene.sentences[sentenceIndex].text));
            personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        }
        else
        {
            Debug.LogWarning("No more sentences to play or currentScene is null");
        }
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}