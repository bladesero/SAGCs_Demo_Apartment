// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Lit Toon" {
	Properties {
		_Color ("Main Color", Color) = (.5,.5,.5,1)
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_Outline ("Outline width", Range (0, 0.03)) = .005
		_Factor("Factor", Range(0, 1)) = 0.5


		_Opacity ("Color over opacity", Range(0, 1)) = 1
		_MainTex ("Color up (RGBA)", 2D) = "white" { }
		_BumpMap ("Normalmap up", 2D) = "bump" { }
		_MainTex2 ("Color below (RGBA)", 2D) = "white" { }
		_BumpMap2 ("Normalmap below", 2D) = "bump" { }

//		_Metallic ("Metallic", Range(0,1)) = 0.0
		_DiffuseRamp ("Toon Ramp (RGB)", 2D) = "gray" {}
		_RimColor ("Rim Color", Color) = (1,1,1,1)
		_RimPower("Rim Power", Range(0, 10)) = 1
		_SpecularColor("Specular Color",Color)=(1,1,1,1)
		_SpecPower("Spec Power",Range(0.03125, 1)) = 0.0625
		_ToonEffect("Toon Effect",Range(0, 1)) = 0.5
	}

	SubShader {
		Pass{
		Tags{"LightMode"="Always"}
		Cull Front
		ZWrite On
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"
		float _Outline;
		float _Factor;
		float4 _OutlineColor;
		struct v2f {
		float4 pos:SV_POSITION;
		};

		v2f vert (appdata_full v) {
			v2f o;
			float3 dir=normalize(v.vertex.xyz);
			float3 dir2=normalize(v.normal);
			float D=dot(dir,dir2);
			dir=dir*sign(D);
			dir=dir*_Factor+dir2*(1-_Factor);
			v.vertex.xyz+=dir*_Outline;
			o.pos=UnityObjectToClipPos(v.vertex);
			return o;
		}
		float4 frag(v2f i):COLOR
		{
			float4 c = _OutlineColor;
			return c;
		}
		ENDCG
		}

		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf ToonRamp

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

//		sampler2D _MainTex;
		sampler2D _DiffuseRamp;
		half3 _RimColor;
		half _RimPower;
		half3 _SpecularColor;
		half _SpecPower;
		half _ToonEffect;

		#pragma lighting ToonRamp exclude_path:prepass
		inline half4 LightingToonRamp (SurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
		{
			#ifndef USING_DIRECTIONAL_LIGHT
			lightDir = normalize(lightDir);
			#endif

//			half3 normal=UnityObjectToWorldNormal(s.Normal);

			half NdotL = dot (s.Normal, lightDir)*0.5 + 0.5;
			half NdotV = saturate(dot(s.Normal,viewDir));
			half3 ramp = tex2D (_DiffuseRamp, float2(NdotL,NdotL)).rgb;
			half3 rim = _RimColor *pow(1-NdotV,_RimPower)*NdotL;

			half3 Diff = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
//			Diff = (Diff+1)/ 2;

			half3 HalfDir = normalize (lightDir+viewDir);
			half NH = max (0, dot(s.Normal, HalfDir));
			half spec = pow (NH, _SpecPower*32);
			half toonSpec = floor(spec*atten*2)/ 2;
			spec = lerp(spec,toonSpec,_ToonEffect);
			half3 Spec= _SpecularColor * _LightColor0.rgb * spec * (atten * 2);
//			half3 indirectDiff=unity_AmbientSky;

			half4 c;
			c.rgb = Diff+Spec;
			c.rgb +=rim;
			c.a = 0;
			return c;
		}

		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
        	float2 uv_MainTex2;
        	float2 uv_BumpMap2;
		};

//		half _Glossiness;
//		half _Metallic;
		sampler2D _MainTex;
		sampler2D _BumpMap;
		sampler2D _MainTex2;
		sampler2D _BumpMap2;

		fixed4 _Color;
		half _Opacity;

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 tex = tex2D (_MainTex, IN.uv_MainTex);
			fixed4 tex2 = tex2D (_MainTex2, IN.uv_MainTex2);
			fixed4 BlenTex;
			_Opacity*=tex.a;
			BlenTex.rgb = tex2.rgb<=0.5 ? 2*tex.rgb*tex2.rgb : 1-2*(1-tex.rgb)*(1-tex2.rgb);
			BlenTex.rgb = lerp(tex2.rgb, BlenTex.rgb, _Opacity);
			BlenTex.rgb *= _Color.rgb;
			o.Albedo = BlenTex.rgb;
			o.Alpha = tex2.a *_Color.a;

			fixed4 norm = tex2D(_BumpMap, IN.uv_BumpMap);
			fixed4 norm2 = tex2D(_BumpMap2, IN.uv_BumpMap2);
			BlenTex = norm2 <=0.5 ? 2*norm*norm2 : 1-2*(1-norm)*(1-norm2);
			BlenTex = lerp(norm2,BlenTex,_Opacity);
			o.Normal = UnpackNormal(BlenTex);

//			o.Albedo = tex.rgb;
			// Metallic and smoothness come from slider variables
//			o.Metallic = _Metallic;
//			o.Smoothness = _Glossiness;
//			o.Alpha = tex.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
