sampler2D implicitInput : register(s0);
float scaleX : register(c0);
float scaleY : register(c1);
float movingX : register(c2);
float movingY : register(c3);

float4 main(float2 uv : TEXCOORD) : COLOR
{
	uv.y += (sin(uv.y*scaleX+movingX)*scaleY+movingY);
    float4 color = tex2D(implicitInput, uv);  
    
    return color;
}