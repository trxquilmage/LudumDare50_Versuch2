using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public static class ExtensionMethods
{
    public static float Remap(this float value, float inputFrom, float inputTo, float outputFrom, float outputTo)
    {
        return (value - inputFrom) / (inputTo - inputFrom) * (outputTo - outputFrom) + outputFrom;
    }

    public static void CrossFadeAlphaFixed(GameObject uiObject, float alpha, float duration)
    {
        var img = uiObject.GetComponent<Image>();
        if (img == null)
        {
            var text = uiObject.GetComponent<Text>();
            //Make the alpha 1
            Color fixedColore = text.color;
            fixedColore.a = 1;
            text.color = fixedColore;

            //Set the 0 to zero then duration to 0
            text.CrossFadeAlpha(0f, 0f, true);

            //Finally perform CrossFadeAlpha
            text.CrossFadeAlpha(alpha, duration, false);
        }
        else
        {
            //Make the alpha 1
            Color fixedColor = img.color;
            fixedColor.a = 1;
            img.color = fixedColor;

            //Set the 0 to zero then duration to 0
            img.CrossFadeAlpha(0f, 0f, true);

            //Finally perform CrossFadeAlpha
            img.CrossFadeAlpha(alpha, duration, false);
        }
    }

    static Vector3[] directions = new Vector3[] { Vector3.left, Vector3.right, Vector3.forward, Vector3.back, Vector3.up, Vector3.down };

    public static Vector3 ClosestDirection(Vector3 directionToCheck)
    {
        var closestDotProduct = -1.0f;
        var closestDirection = Vector3.zero;

        foreach (Vector3 direction in directions)
        {
            var dot = Vector3.Dot(directionToCheck, direction);
            if (dot > closestDotProduct)
            {
                closestDirection = direction;
                closestDotProduct = dot;
            }
        }

        return closestDirection;
    }
}
