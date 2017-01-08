﻿// Author : Maxime JUMELLE
// Project : More Post-Processing Effects Package
// If you have any suggestion or comment, you can write me at webmaster[at]hardgames3d.com

Shader "MorePPEffects/Dreamy" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "" {}
	}

	CGINCLUDE
	
	#include "UnityCG.cginc"
	
	struct v2f {
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
	};
	
	sampler2D _MainTex;
	float strength;
	
	v2f vert( appdata_img v ) 
	{
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv = v.texcoord.xy;
		return o;
	} 
	
	float4 frag(v2f i) : SV_Target 
	{
		float4 result = tex2D(_MainTex, i.uv);
		  
		result += tex2D(_MainTex, i.uv + 0.001f * strength);
		result += tex2D(_MainTex, i.uv + 0.001f * strength);
		result += tex2D(_MainTex, i.uv + 0.002f * strength);
		result += tex2D(_MainTex, i.uv + 0.003f * strength);
		result += tex2D(_MainTex, i.uv + 0.004f * strength);
		result += tex2D(_MainTex, i.uv + 0.005f * strength);
		 
		result += tex2D(_MainTex, i.uv - 0.001f * strength);
		result += tex2D(_MainTex, i.uv - 0.001f * strength);
		result += tex2D(_MainTex, i.uv - 0.002f * strength);
		result += tex2D(_MainTex, i.uv - 0.003f * strength);
		result += tex2D(_MainTex, i.uv - 0.004f * strength);
		result += tex2D(_MainTex, i.uv - 0.005f * strength);
		 
		result.rgb = (float3)((result.r + result.g + result.b) / 2.0f);
		result = result / 8.5f;
		return result;
	}

	ENDCG 
	
Subshader {
 Pass {
	  ZTest Always Cull Off ZWrite Off

      CGPROGRAM
      #pragma vertex vert
      #pragma fragment frag
      ENDCG
  }
  
}

Fallback off
	
}

