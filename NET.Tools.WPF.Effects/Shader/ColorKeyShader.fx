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

   float difR = abs(channelR - color.r);
   float toleranceR = abs(difR - 1) * tolerance;

   float difG = abs(channelG - color.g);
   float toleranceG = abs(difG - 1) * tolerance;

   float difB = abs(channelB - color.b);
   float toleranceB = abs(difB - 1) * tolerance;
   
   if( (color.r >= channelR - toleranceR && color.r <= channelR + toleranceR) && 
       (color.g >= channelG - toleranceG && color.g <= channelG + toleranceG) &&
	   (color.b >= channelB - toleranceB && color.b <= channelB + toleranceB) ) {
      color.rgba = 0;
   }
   
   return color;
}
