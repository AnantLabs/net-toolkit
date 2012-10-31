sampler2D input : register(s0);
sampler2D tex1 : register(s1); 
float changed : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR 
{ 
	float4 clr1; 
	if (!changed)
		clr1= tex2D(tex1, uv.xy); 
	else
		clr1= tex2D(input, uv.xy); 

	float4 Color; 
	if (!changed)
		Color= tex2D( input , uv.xy); 
	else
		Color= tex2D( tex1 , uv.xy); 

	if (Color.r<clr1.r) Color.r=clr1.r; 
	if (Color.g<clr1.g) Color.g=clr1.g; 
	if (Color.b<clr1.b) Color.b=clr1.b; 

	return Color; 
}