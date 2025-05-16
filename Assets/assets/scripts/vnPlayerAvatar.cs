
using UnityEngine;
using UnityEngine.UI;

public class vnPlayerAvatar : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] panels;
    public static vnPlayerAvatar instance;
    private SpriteRenderer vaAvatar;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        vaAvatar = GetComponent<SpriteRenderer>();
    }

    

    // Update is called once per frame


    public static void ExpresionVaAvatarChanger(CharacterEmotion emotion)
    {
        if (instance != null && instance.panels != null && (int)emotion < instance.panels.Length)
        {

            instance.vaAvatar.sprite = instance.panels[(int)emotion];

        }

    }
    
}


public enum CharacterEmotion
{
    happy,
    sad,
    idea,
    neutro,
    talk,
    talk2

}
