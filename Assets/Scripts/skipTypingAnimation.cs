using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skipTypingAnimation : MonoBehaviour
{
    public typewriterUI typewriter;

    public void OnClick()
    {
        Debug.Log("Button clicked"); // Debug statement
        typewriter.skipTypingAnimation = true;
    }
}

