using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image spriteRenderer;
    public Image spriteRenderer2;
    public grappin Grappin;
    public dash Dash;
    private Sprite loadedSprite;
    private Sprite loadedSprite2;
    private Sprite loadedSprite3;
    private Sprite loadedSprite4;// Référence vers le composant SpriteRenderer
    // Start is called before the first frame update
    void Start()
    {

        // Chargez une image depuis le dossier "Resources"
        loadedSprite = Resources.Load<Sprite>("dash_pouvoir"); 
        loadedSprite2 = Resources.Load<Sprite>("dash_croix");
        loadedSprite3 = Resources.Load<Sprite>("grappin_pouvoir"); 
        loadedSprite4 = Resources.Load<Sprite>("grappin_croix");
        if (loadedSprite != null || loadedSprite2 != null){}
        else
        {
            Debug.LogError("Erreur de chargement de l'image.");
        }
    }

    void Update()
    {
        if (Dash.counter > 0 && Grappin.counter > 0)
        {
            spriteRenderer.sprite = loadedSprite;
            spriteRenderer2.sprite = loadedSprite3;
        }
        else if (Grappin.counter > 0)
        {
            spriteRenderer2.sprite = loadedSprite3;
            spriteRenderer.sprite = loadedSprite2;
        }
        else if (Dash.counter > 0)
        {
            spriteRenderer.sprite = loadedSprite;
            spriteRenderer2.sprite = loadedSprite4;
        }
        else {
            spriteRenderer.sprite = loadedSprite2;
            spriteRenderer2.sprite = loadedSprite4;
        }
    }
}