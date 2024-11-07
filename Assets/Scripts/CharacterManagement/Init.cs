using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Init : MonoBehaviour
{
    public static Character player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject selectedCharacter = CharacterSelect.selectedCharacter;
        GameObject playerObject = Instantiate(selectedCharacter, transform.position, quaternion.identity);
        playerObject.name = "Player";

        switch(selectedCharacter.name)
        {
            case "Bui_Binh":
                player = new Bui_Binh(playerObject);
                break;
            case "An_Dan":
                player = new An_Dan(playerObject);
                break;
            case "Tai_Beo":
                player = new Tai_Beo(playerObject);
                break;
            case "Minh_Duc":
                player = new Minh_Duc(playerObject);
                break;
        }
        
    }
}
