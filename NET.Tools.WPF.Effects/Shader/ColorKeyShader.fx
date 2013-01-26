//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- ColorKeyAlphaEffect
//
//--------------------------------------------------------------------------------------

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D  implicitInputSampler : register(s0);
float channelR : register(c0);
float channelG : register(c1);
float channelB : register(c2);
float tolerance : register(c3);

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
   float4 color = tex2D( implicitInputSampler, uv );
   
   if( (color.r >= channelR - tolerance && color.r <= channelR + tolerance) && 
       (color.g >= channelG - tolerance && color.g <= channelG + tolerance) &&
	   (color.b >= channelB - tolerance && color.b <= channelB + tolerance) ) {
      color.rgba = 0;
   }
   
   return color;
}
