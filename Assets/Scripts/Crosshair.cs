using UnityEngine;

public class Crosshair : MonoBehaviour {

    const float DEFAULT_SIZE = 5.0f;

    // crosshair's percentage compared to the screen width
    public float size = DEFAULT_SIZE;
    Rect crosshairSurface;
    Texture crosshairTexture;

	// Use this for initialization
	void Start () {
        crosshairTexture = Resources.Load("Textures/crosshair") as Texture;
        
        float crosshairLength = Screen.width * size / 100.0f;

        crosshairSurface = new Rect(
            Screen.width / 2.0f - crosshairLength / 2.0f,
            Screen.height/2.0f - crosshairLength /2.0f,
            crosshairLength,
            crosshairLength);

    }
	
	void OnGUI () {
        GUI.DrawTexture(crosshairSurface, crosshairTexture);
	}
}
