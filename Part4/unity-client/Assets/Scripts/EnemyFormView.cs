using UnityEngine;
using UnityEngine.UI;

public class EnemyFormView : MonoBehaviour 
{
    public InputField nameField;
    public InputField healthField;
    public InputField attackField;
    public Button createButton;

    public void InitFormView(System.Action<EnemyRequestData> callback)
    {
        createButton.onClick.AddListener(()=>{
                OnCreateClicked(callback);
            }
        );
    }

    public void OnCreateClicked(System.Action<EnemyRequestData> callback)
    {
        if (InputsAreValid())
        {
            var enemy = new EnemyRequestData(
            
                nameField.text,
                int.Parse(healthField.text),
                int.Parse(attackField.text)
            );
            
            callback(enemy);
        }
        else
        {
            Debug.LogWarning("Invalid Input");
        }
    }

    private bool InputsAreValid()
    {
        return !(string.IsNullOrEmpty(nameField.text) || 
            string.IsNullOrEmpty(healthField.text) || 
            string.IsNullOrEmpty(healthField.text) );
    }
}