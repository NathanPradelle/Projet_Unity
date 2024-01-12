using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image  spriteRenderer;
    public grappin Grappin;
    public dash Dash;
    public Image  spriteRenderer2;// Référence vers le composant SpriteRenderer
    // Start is called before the first frame update
    void Start()
    {

        // Chargez une image depuis le dossier "Resources"
        Sprite loadedSprite = Resources.Load<Sprite>("dash");
        Sprite loadedSprite2 = Resources.Load<Sprite>("dash_croix");
        if (loadedSprite != null || loadedSprite2 != null)
        {
            if (Dash.counter > 0)
            {
                spriteRenderer.sprite = loadedSprite;
            }
            else {
                spriteRenderer2.sprite = loadedSprite2;
            }
        }
        else
        {
            Debug.LogError("Erreur de chargement de l'image.");
        }
    }
}
