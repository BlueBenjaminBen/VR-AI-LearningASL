using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceAndDelete : MonoBehaviour
{
    [SerializeField]
    private Button SpaceBar;

    [SerializeField]
    private Button BackSpace;

    [SerializeField]
    private TMP_InputField inputField;

    private bool canPressSpace = true;
    private bool canPressDelete = true;
    
    void Start()
    {
        //Links buttons to their methods
        SpaceBar.onClick.AddListener(insertSpace);
        BackSpace.onClick.AddListener(deleteChar);
    }
    
    //Time between being able to press the space again to avoid accidental presses
    private IEnumerator SpaceCooldown()
    {
        if (canPressSpace)
        {
            insertSpace();
            canPressSpace = false;
            yield return new WaitForSeconds(0.5f);
            canPressSpace = true;
        } 
    }
    //Spacebar
    private void insertSpace()
    {
        inputField.text += " ";
        inputField.caretPosition = inputField.text.Length;
        
    }
    //Delete the last character
    private void deleteChar()
    {
        if (!string.IsNullOrEmpty(inputField.text)){
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
            inputField.caretPosition =inputField.text.Length; 
        }
    }
    //Time between being able to press the backspace again to avoid accidental presses
    private IEnumerator DeleteCooldown()
    {
        if (canPressDelete)
        {
            deleteChar();
            canPressDelete = false;
            yield return new WaitForSeconds(0.5f);
            canPressDelete = true;
        }
    }
}
