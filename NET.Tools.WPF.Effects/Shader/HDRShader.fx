sampler2D implicitInput : register(s0);
float highValue : register(c0);
float lowValue : register(c1);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    float4 hdr;
    
    float3 high = color.rgb * highValue + float3(1,1,1) * (1-highValue);
    float3 low = color.rgb * lowValue + float3(0,0,0) * (1-lowValue);
    
    float value = (color.r + color.g + color.b) / 3;
    
    hdr.rgb = high.rgb * (1-value) + low.rgb * value;
    hdr.a = color.a;
    
    return hdr;
}