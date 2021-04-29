using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipplePostProccessor : MonoBehaviour
{
    public Material RippleMaterial;
    public float MaxAmount = 50f;
 
    [Range(0,1)]
    public float Friction = .9f;
 
    private float Amount = 0f;
 
    void Update()
    {
       
 
        this.RippleMaterial.SetFloat("_Amount", this.Amount);
        this.Amount *= this.Friction;
    }
    public void RippleEffect()
    {
        this.Amount = this.MaxAmount;
        Vector3 pos = Input.mousePosition;
        this.RippleMaterial.SetFloat("_CenterX", pos.x);
        this.RippleMaterial.SetFloat("_CenterY", pos.y);
    }
 
    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, this.RippleMaterial);
    }
    public void friction()
    {

        Friction = 0.92f;
    }
    public void frictionA()
    {

        Friction = 0.93f;
    }
}
