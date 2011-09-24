sampler2D implicitInput : register(s0);
sampler2D tex1 : register(s1); 
float changed : register(c0);
float value : register(c1);

float4 main(float2 uv : TEXCOORD) : COLOR
{
	if (!changed)
	{
		float4 color1 = tex2D(implicitInput, uv);
		float4 color2 = tex2D(tex1, uv);
    
		color1.r += tex2D( implicitInput , uv + value).r * color2.r; 
		color1.g += tex2D( implicitInput , uv + value).g * color2.g; 
		color1.b += tex2D( implicitInput , uv + value).b * color2.b;
		
		return color1;
	}
	else
	{
		float4 color1 = tex2D(tex1, uv);
		float4 color2 = tex2D(implicitInput, uv);
    
		color1.r += tex2D( tex1 , uv + value).r * color2.r; 
		color1.g += tex2D( tex1 , uv + value).g * color2.g; 
		color1.b += tex2D( tex1 , uv + value).b * color2.b;
		
		return color1;
	}
}