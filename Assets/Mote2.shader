// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32993,y:32552,varname:node_4013,prsc:2|diff-4739-OUT,normal-3514-RGB,emission-8663-RGB,alpha-9537-OUT,olwid-2753-OUT,olcol-4667-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32257,y:32557,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.7867647,c3:0.7867647,c4:1;n:type:ShaderForge.SFN_Fresnel,id:7524,x:32138,y:32863,varname:node_7524,prsc:2|EXP-7401-OUT;n:type:ShaderForge.SFN_Slider,id:7401,x:31740,y:32985,ptovrint:False,ptlb:Fresnel Color,ptin:_FresnelColor,varname:node_7401,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.995858,max:1;n:type:ShaderForge.SFN_OneMinus,id:3852,x:32364,y:32863,varname:node_3852,prsc:2|IN-7524-OUT;n:type:ShaderForge.SFN_Multiply,id:4739,x:32567,y:32599,varname:node_4739,prsc:2|A-1304-RGB,B-3852-OUT,C-8663-RGB;n:type:ShaderForge.SFN_Fresnel,id:7820,x:31970,y:33153,varname:node_7820,prsc:2|EXP-4864-OUT;n:type:ShaderForge.SFN_Slider,id:4864,x:31615,y:33242,ptovrint:False,ptlb:Fresnel Opacity,ptin:_FresnelOpacity,varname:node_4864,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_OneMinus,id:7244,x:32180,y:33153,varname:node_7244,prsc:2|IN-7820-OUT;n:type:ShaderForge.SFN_Tex2d,id:8663,x:32005,y:32704,ptovrint:False,ptlb:NoiseTex,ptin:_NoiseTex,varname:node_8663,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:18d26d8c726fa5b48a32eedb12296582,ntxv:0,isnm:False|UVIN-1501-UVOUT;n:type:ShaderForge.SFN_Time,id:738,x:30865,y:32751,varname:node_738,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:3377,x:31491,y:32590,varname:node_3377,prsc:2,uv:0;n:type:ShaderForge.SFN_Sin,id:7841,x:31279,y:32751,varname:node_7841,prsc:2|IN-5779-OUT;n:type:ShaderForge.SFN_RemapRange,id:3887,x:31468,y:32751,varname:node_3887,prsc:2,frmn:0,frmx:1,tomn:0,tomx:1|IN-7841-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4815,x:30840,y:32644,ptovrint:False,ptlb:Freq,ptin:_Freq,varname:node_4815,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:3423,x:30840,y:32556,ptovrint:False,ptlb:Phase,ptin:_Phase,varname:node_3423,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:5779,x:31085,y:32751,varname:node_5779,prsc:2|A-9142-OUT,B-738-T;n:type:ShaderForge.SFN_Add,id:9142,x:31012,y:32588,varname:node_9142,prsc:2|A-3423-OUT,B-4815-OUT;n:type:ShaderForge.SFN_OneMinus,id:263,x:32104,y:33014,varname:node_263,prsc:2|IN-8663-R;n:type:ShaderForge.SFN_Panner,id:1501,x:31706,y:32590,varname:node_1501,prsc:2,spu:0.05,spv:0.05|UVIN-3377-UVOUT,DIST-3887-OUT;n:type:ShaderForge.SFN_RemapRange,id:2753,x:32477,y:33021,varname:node_2753,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.09|IN-6425-OUT;n:type:ShaderForge.SFN_Slider,id:3832,x:32416,y:33398,ptovrint:False,ptlb:FadeOut,ptin:_FadeOut,varname:node_3832,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Clamp,id:9537,x:32635,y:33173,varname:node_9537,prsc:2|IN-690-OUT,MIN-690-OUT,MAX-3832-OUT;n:type:ShaderForge.SFN_Append,id:4667,x:32905,y:33137,varname:node_4667,prsc:2|A-9923-RGB,B-3832-OUT;n:type:ShaderForge.SFN_Color,id:9923,x:32572,y:32863,ptovrint:False,ptlb:node_9923,ptin:_node_9923,varname:node_9923,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:8678,x:31884,y:33364,varname:node_8678,prsc:2,v1:2;n:type:ShaderForge.SFN_Power,id:690,x:32218,y:33312,varname:node_690,prsc:2|VAL-7244-OUT,EXP-8678-OUT;n:type:ShaderForge.SFN_Power,id:6425,x:32304,y:33038,varname:node_6425,prsc:2|VAL-263-OUT,EXP-5710-OUT;n:type:ShaderForge.SFN_Vector1,id:5710,x:32257,y:33255,varname:node_5710,prsc:2,v1:15;n:type:ShaderForge.SFN_Tex2d,id:3514,x:32257,y:32762,ptovrint:False,ptlb:Normal Map,ptin:_NormalMap,varname:node_3514,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1d7326ab99dbcbe4a93f37e697abd79e,ntxv:3,isnm:True;proporder:1304-7401-4864-8663-4815-3423-3832-9923-3514;pass:END;sub:END;*/

Shader "Shader Forge/Mote2" {
    Properties {
        _Color ("Color", Color) = (1,0.7867647,0.7867647,1)
        _FresnelColor ("Fresnel Color", Range(0, 1)) = 0.995858
        _FresnelOpacity ("Fresnel Opacity", Range(0, 1)) = 1
        _NoiseTex ("NoiseTex", 2D) = "white" {}
        _Freq ("Freq", Float ) = 1
        _Phase ("Phase", Float ) = 0.1
        _FadeOut ("FadeOut", Range(0, 1)) = 1
        _node_9923 ("node_9923", Color) = (1,1,1,1)
        _NormalMap ("Normal Map", 2D) = "bump" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform sampler2D _NoiseTex; uniform float4 _NoiseTex_ST;
            uniform float _Freq;
            uniform float _Phase;
            uniform float _FadeOut;
            uniform float4 _node_9923;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 node_738 = _Time + _TimeEditor;
                float2 node_1501 = (o.uv0+(sin(((_Phase+_Freq)*node_738.g))*1.0+0.0)*float2(0.05,0.05));
                float4 _NoiseTex_var = tex2Dlod(_NoiseTex,float4(TRANSFORM_TEX(node_1501, _NoiseTex),0.0,0));
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*(pow((1.0 - _NoiseTex_var.r),15.0)*0.09+0.0),1) );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                return fixed4(float4(_node_9923.rgb,_FadeOut).rgb,0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _FresnelColor;
            uniform float _FresnelOpacity;
            uniform sampler2D _NoiseTex; uniform float4 _NoiseTex_ST;
            uniform float _Freq;
            uniform float _Phase;
            uniform float _FadeOut;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 node_738 = _Time + _TimeEditor;
                float2 node_1501 = (i.uv0+(sin(((_Phase+_Freq)*node_738.g))*1.0+0.0)*float2(0.05,0.05));
                float4 _NoiseTex_var = tex2D(_NoiseTex,TRANSFORM_TEX(node_1501, _NoiseTex));
                float3 diffuseColor = (_Color.rgb*(1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelColor))*_NoiseTex_var.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = _NoiseTex_var.rgb;
/// Final Color:
                float3 finalColor = diffuse + emissive;
                float node_690 = pow((1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelOpacity)),2.0);
                return fixed4(finalColor,clamp(node_690,node_690,_FadeOut));
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _FresnelColor;
            uniform float _FresnelOpacity;
            uniform sampler2D _NoiseTex; uniform float4 _NoiseTex_ST;
            uniform float _Freq;
            uniform float _Phase;
            uniform float _FadeOut;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 node_738 = _Time + _TimeEditor;
                float2 node_1501 = (i.uv0+(sin(((_Phase+_Freq)*node_738.g))*1.0+0.0)*float2(0.05,0.05));
                float4 _NoiseTex_var = tex2D(_NoiseTex,TRANSFORM_TEX(node_1501, _NoiseTex));
                float3 diffuseColor = (_Color.rgb*(1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelColor))*_NoiseTex_var.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float node_690 = pow((1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelOpacity)),2.0);
                return fixed4(finalColor * clamp(node_690,node_690,_FadeOut),0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
