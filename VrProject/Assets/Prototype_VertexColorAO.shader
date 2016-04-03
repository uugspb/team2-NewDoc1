// Shader created with Shader Forge v1.25 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.25;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:839,x:32719,y:32712,varname:node_839,prsc:2|emission-6430-OUT;n:type:ShaderForge.SFN_VertexColor,id:6719,x:31890,y:32702,varname:node_6719,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6967,x:32383,y:32706,varname:node_6967,prsc:2|A-3185-RGB,B-6719-RGB,C-3899-OUT;n:type:ShaderForge.SFN_Slider,id:3339,x:31890,y:33074,ptovrint:False,ptlb:VertexAOvsTextureAO,ptin:_VertexAOvsTextureAO,varname:node_3339,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:277,x:31890,y:32870,ptovrint:False,ptlb:AO,ptin:_AO,varname:node_277,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:3899,x:32143,y:32850,varname:node_3899,prsc:2|A-6719-A,B-277-RGB,T-3339-OUT;n:type:ShaderForge.SFN_Color,id:3185,x:31890,y:32527,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3185,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Cubemap,id:3986,x:31890,y:33190,ptovrint:False,ptlb:Cubemap,ptin:_Cubemap,varname:node_3986,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,pvfc:0|MIP-9464-OUT;n:type:ShaderForge.SFN_Lerp,id:8671,x:32292,y:33192,varname:node_8671,prsc:2|A-2367-OUT,B-8734-OUT,T-8592-OUT;n:type:ShaderForge.SFN_Multiply,id:8734,x:32098,y:33254,varname:node_8734,prsc:2|A-3986-RGB,B-6774-OUT,C-6584-OUT;n:type:ShaderForge.SFN_Fresnel,id:6774,x:31890,y:33377,varname:node_6774,prsc:2|EXP-7-OUT;n:type:ShaderForge.SFN_Slider,id:7,x:31890,y:33543,ptovrint:False,ptlb:Reflection_Fresnel,ptin:_Reflection_Fresnel,varname:node_7,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.180326,max:7;n:type:ShaderForge.SFN_ValueProperty,id:9464,x:31718,y:33190,ptovrint:False,ptlb:cubemap_MIP,ptin:_cubemap_MIP,varname:node_9464,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:6584,x:32098,y:33411,ptovrint:False,ptlb:Reflection_Power,ptin:_Reflection_Power,varname:node_6584,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Vector1,id:2367,x:32098,y:33192,varname:node_2367,prsc:2,v1:0;n:type:ShaderForge.SFN_Slider,id:8592,x:32188,y:33118,ptovrint:False,ptlb:Reflection_Visibility,ptin:_Reflection_Visibility,varname:node_8592,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Add,id:6430,x:32542,y:32812,varname:node_6430,prsc:2|A-6967-OUT,B-8671-OUT;proporder:3339-277-3185-3986-9464-8592-7-6584;pass:END;sub:END;*/

Shader "Unlit/Prototype/Prototype_VertexColorAO" {
    Properties {
        _VertexAOvsTextureAO ("VertexAOvsTextureAO", Range(0, 1)) = 0
        _AO ("AO", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _Cubemap ("Cubemap", Cube) = "_Skybox" {}
        _cubemap_MIP ("cubemap_MIP", Float ) = 0
        _Reflection_Visibility ("Reflection_Visibility", Range(0, 1)) = 1
        _Reflection_Fresnel ("Reflection_Fresnel", Range(0, 7)) = 1.180326
        _Reflection_Power ("Reflection_Power", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 100
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float _VertexAOvsTextureAO;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            uniform float4 _Color;
            uniform samplerCUBE _Cubemap;
            uniform float _Reflection_Fresnel;
            uniform float _cubemap_MIP;
            uniform float _Reflection_Power;
            uniform float _Reflection_Visibility;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv0, _AO));
                float node_2367 = 0.0;
                float4 _Cubemap_var = texCUBElod(_Cubemap,float4(viewReflectDirection,_cubemap_MIP));
                float3 emissive = ((_Color.rgb*i.vertexColor.rgb*lerp(float3(i.vertexColor.a,i.vertexColor.a,i.vertexColor.a),_AO_var.rgb,_VertexAOvsTextureAO))+lerp(float3(node_2367,node_2367,node_2367),(_Cubemap_var.rgb*pow(1.0-max(0,dot(normalDirection, viewDirection)),_Reflection_Fresnel)*_Reflection_Power),_Reflection_Visibility));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
