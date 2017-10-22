// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32829,y:32728,varname:node_3138,prsc:2|emission-5137-OUT;n:type:ShaderForge.SFN_Tex2d,id:8253,x:31544,y:32920,ptovrint:False,ptlb:Main_Tex,ptin:_Main_Tex,varname:node_8253,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:64c00684f424b7f46b06a49dc4839744,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Blend,id:3202,x:32183,y:32749,varname:node_3202,prsc:2,blmd:5,clmp:True|SRC-2186-OUT,DST-3499-RGB;n:type:ShaderForge.SFN_ToggleProperty,id:8227,x:32171,y:32686,ptovrint:False,ptlb:Darken,ptin:_Darken,varname:node_8227,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Blend,id:3034,x:32171,y:33032,varname:node_3034,prsc:2,blmd:1,clmp:True|SRC-5977-OUT,DST-3499-RGB;n:type:ShaderForge.SFN_Multiply,id:114,x:32475,y:32983,varname:node_114,prsc:2|A-9516-OUT,B-3034-OUT;n:type:ShaderForge.SFN_Multiply,id:4863,x:32437,y:32767,varname:node_4863,prsc:2|A-8227-OUT,B-3202-OUT;n:type:ShaderForge.SFN_Add,id:5137,x:32630,y:32841,varname:node_5137,prsc:2|A-4863-OUT,B-114-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:9516,x:32171,y:32938,ptovrint:False,ptlb:Multiply,ptin:_Multiply,varname:node_9516,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_SceneColor,id:3499,x:31674,y:32772,varname:node_3499,prsc:2;n:type:ShaderForge.SFN_Slider,id:9326,x:31328,y:33195,ptovrint:False,ptlb:Opacity_Darken,ptin:_Opacity_Darken,varname:node_9326,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Subtract,id:2186,x:31859,y:32936,varname:node_2186,prsc:2|A-8253-RGB,B-9326-OUT;n:type:ShaderForge.SFN_Slider,id:2537,x:31369,y:33310,ptovrint:False,ptlb:Opacity_Multiply,ptin:_Opacity_Multiply,varname:node_2537,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.991453,max:1;n:type:ShaderForge.SFN_Multiply,id:5955,x:31776,y:33103,varname:node_5955,prsc:2|A-4357-OUT,B-2537-OUT;n:type:ShaderForge.SFN_OneMinus,id:5977,x:31959,y:33103,varname:node_5977,prsc:2|IN-5955-OUT;n:type:ShaderForge.SFN_OneMinus,id:4357,x:31685,y:32985,varname:node_4357,prsc:2|IN-8253-RGB;proporder:8227-9516-8253-9326-2537;pass:END;sub:END;*/

Shader "BlendMap/BlendMap01" {
    Properties {
        [MaterialToggle] _Darken ("Darken", Float ) = 0
        [MaterialToggle] _Multiply ("Multiply", Float ) = 1
        _Main_Tex ("Main_Tex", 2D) = "white" {}
        _Opacity_Darken ("Opacity_Darken", Range(0, 1)) = 0
        _Opacity_Multiply ("Opacity_Multiply", Range(0, 1)) = 0.991453
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers metal xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _Main_Tex; uniform float4 _Main_Tex_ST;
            uniform fixed _Darken;
            uniform fixed _Multiply;
            uniform float _Opacity_Darken;
            uniform float _Opacity_Multiply;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float4 _Main_Tex_var = tex2D(_Main_Tex,TRANSFORM_TEX(i.uv0, _Main_Tex));
                float4 node_3499 = sceneColor;
                float3 emissive = ((_Darken*saturate(max((_Main_Tex_var.rgb-_Opacity_Darken),node_3499.rgb)))+(_Multiply*saturate(((1.0 - ((1.0 - _Main_Tex_var.rgb)*_Opacity_Multiply))*node_3499.rgb))));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
