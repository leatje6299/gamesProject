// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33067,y:32693,varname:node_3138,prsc:2|emission-6137-OUT;n:type:ShaderForge.SFN_Fresnel,id:1708,x:31928,y:32678,varname:node_1708,prsc:2|EXP-9095-OUT;n:type:ShaderForge.SFN_Slider,id:9095,x:31713,y:32865,ptovrint:False,ptlb:node_9095,ptin:_node_9095,varname:node_9095,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Add,id:8990,x:32116,y:32740,varname:node_8990,prsc:2|A-435-OUT,B-1708-OUT;n:type:ShaderForge.SFN_Slider,id:435,x:31822,y:32554,ptovrint:False,ptlb:node_435,ptin:_node_435,varname:node_435,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3478261,max:1;n:type:ShaderForge.SFN_Slider,id:4864,x:31877,y:33009,ptovrint:False,ptlb:node_4864,ptin:_node_4864,varname:node_4864,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.217391,max:5;n:type:ShaderForge.SFN_Step,id:2740,x:32286,y:32917,varname:node_2740,prsc:2|A-8990-OUT,B-4864-OUT;n:type:ShaderForge.SFN_OneMinus,id:3643,x:32312,y:33087,varname:node_3643,prsc:2|IN-2740-OUT;n:type:ShaderForge.SFN_Add,id:362,x:32302,y:32787,varname:node_362,prsc:2|A-8990-OUT,B-3643-OUT;n:type:ShaderForge.SFN_Multiply,id:6137,x:32786,y:32747,varname:node_6137,prsc:2|A-6405-RGB,B-362-OUT;n:type:ShaderForge.SFN_Color,id:6405,x:32445,y:32557,ptovrint:False,ptlb:node_6405,ptin:_node_6405,varname:node_6405,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5707547,c2:0.7342004,c3:1,c4:1;proporder:9095-435-4864-6405;pass:END;sub:END;*/

Shader "Shader Forge/ParticleEffect" {
    Properties {
        _node_9095 ("node_9095", Range(0, 1)) = 1
        _node_435 ("node_435", Range(0, 1)) = 0.3478261
        _node_4864 ("node_4864", Range(0, 5)) = 1.217391
        _node_6405 ("node_6405", Color) = (0.5707547,0.7342004,1,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _node_9095)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_435)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_4864)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_6405)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 _node_6405_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_6405 );
                float _node_435_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_435 );
                float _node_9095_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_9095 );
                float node_1708 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_node_9095_var);
                float node_8990 = (_node_435_var+node_1708);
                float _node_4864_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_4864 );
                float node_3643 = (1.0 - step(node_8990,_node_4864_var));
                float3 emissive = (_node_6405_var.rgb*(node_8990+node_3643));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
