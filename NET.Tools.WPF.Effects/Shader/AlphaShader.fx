sampler2D implicitInput : register(s0);
float value : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    
    color.a = value;
    
    return color;
}