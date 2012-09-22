sampler2D implicitInput : register(s0);
float alpha : register(c0);
float details : register(c1);
float random : register(c2);

#define M_PI 3.14159265358979323846
#define fmodp(x,n) ((n)*frac((x)/(n)))

float rand(float ij)
{
  const float4 a=float4(M_PI * M_PI * M_PI * M_PI, exp(4.0),  1.0, 0.0);
  const float4 b=float4(pow(13.0, M_PI / 2.0), sqrt(1997.0),  0.0, 1.0);

  float2 xy0    = ij/M_PI;
  float2 xym    = fmodp(xy0.xy,257.0)+1.0;
  float2 xym2   = frac(xym*xym);
  float4 pxy    = float4(xym.yx * xym2 , frac(xy0));
  float2 xy1    = float2(dot(pxy,a) , dot(pxy,b));
  float2 result = frac(xy1);
  
  return (result*256.0);
}

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
	float ret = (rand(uv.x * uv.y * random) % 1.0f);

	if (ret <= details)
	{
		color.r = color.r * (1 - alpha) + (rand(uv.x * uv.y * random) % 1.0f) * alpha;
		color.g = color.g * (1 - alpha) + (rand(uv.x * uv.y * random) % 1.0f) * alpha;
		color.b = color.b * (1 - alpha) + (rand(uv.x * uv.y * random) % 1.0f) * alpha;
	}

    return color;
}