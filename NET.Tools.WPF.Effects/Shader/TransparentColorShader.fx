sampler2D implicitInput : register(s0);
float4 inColor : register(c0);
float value : register(c1);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    
    color.r = color.r * (1-value) + inColor.r * value;
    color.g = color.g * (1-value) + inColor.g * value;
    color.b = color.b * (1-value) + inColor.b * value;
    color.a = color.a * (1-value) + inColor.a * value;
    
    return color;
}