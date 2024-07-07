using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        // Consider hashing the password before sending it to the server
        form.AddField("password", passwordField.text);

        UnityWebRequest www = UnityWebRequest.Post("http://sqlconnect/register.php", form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            if (www.downloadHandler.text == "0")
            {
                Debug.Log("User created successfully");
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("User creation failed. Error #" + www.downloadHandler.text);
            }
        }
        else
        {
            Debug.Log("Error During Registration: " + www.error);
        }
    }

    public void VerifyInputs()
    {
        // Add additional validation if necessary
        submitButton.interactable = (nameField.text.Length >= 2 && passwordField.text.Length >= 4);
    }
}