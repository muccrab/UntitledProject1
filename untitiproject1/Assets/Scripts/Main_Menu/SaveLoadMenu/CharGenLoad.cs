using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharGenLoad
{
    
    public static void SaveCharacters(){
        Character ch1 = GameObject.Find("Char1").GetComponent<Character>();
        Character ch2 = GameObject.Find("Char2").GetComponent<Character>();
        LoadController.resetCharacters();
        LoadController.addCharacter(new SaveChatacterObj(ch1));
        LoadController.addCharacter(new SaveChatacterObj(ch2));
    }

    
    public static Character loadCharacter(Character character, int charID){
        Character tempchar = LoadController.getCharacter(charID);
        if (tempchar is not null) 
        {
            Debug.Log(character.name);
            return tempchar;
        }
        return character;   
    }

    
}
