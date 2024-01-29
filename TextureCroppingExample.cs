using UnityEngine;

public class TextureCroppingExample : MonoBehaviour
{
    // Reference to the original texture
    public Texture2D originalTexture;
    public Texture2D croppedTexture;
    public SpriteRenderer spriteRenderer;

    // Specify the center position and size of the crop
    public int centerX;
    public int centerY;
    public int cropWidth;
    public int cropHeight;

    void Start()
    {
        // Call the CropTexture function with the specified coordinates and size
        croppedTexture = CropTexture(originalTexture, centerX, centerY, cropWidth, cropHeight);

        // Just an example
        spriteRenderer.material.mainTexture = croppedTexture;
    }


    Texture2D CropTexture(Texture2D sourceTexture, int centerX, int centerY, int width, int height)
    {
        int x = centerX - width / 2;
        int y = centerY - height / 2;

        // Ensure the crop region stays within the bounds of the original texture
        x = Mathf.Clamp(x, 0, sourceTexture.width - width);
        y = Mathf.Clamp(y, 0, sourceTexture.height - height);

        // Create a new texture with the specified size
        Texture2D croppedTexture = new Texture2D(width, height);

        // Get the pixels from the original texture within the specified region
        Color[] pixels = sourceTexture.GetPixels(x, y, width, height);

        // Set the pixels on the new texture
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();

        return croppedTexture;
    }
}
