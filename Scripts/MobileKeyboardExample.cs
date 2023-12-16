using UnityEngine;

public class MobileKeyboardExample : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;

    private void Start()
    {
        // Show the keyboard when the player taps on the text input field
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
    }

    private void Update()
    {
        // Check if the player has finished typing
        if (keyboard.done)
        {
            // Do something with the typed text
            Debug.Log("Player typed: " + keyboard.text);
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Do something based on the touch phase
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Code to handle touch began
                    break;
                case TouchPhase.Moved:
                    // Code to handle touch move
                    break;
                case TouchPhase.Ended:
                    // Code to handle touch end
                    break;
            }
        }
    }
}
