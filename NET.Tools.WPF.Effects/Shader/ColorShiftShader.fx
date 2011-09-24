sampler2D implicitInput : register(s0);
float value : register(c0);
float channelR : register(c1);
float channelG : register(c2);
float channelB : register(c3);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    
    color.r += tex2D( implicitInput , uv + value).r * channelR; 
	color.g += tex2D( implicitInput , uv + value).g * channelG; 
	color.b += tex2D( implicitInput , uv + value).b * channelB;
	
	return color;
}