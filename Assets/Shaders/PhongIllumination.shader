// Author: Zhirui Xin
// StudentID: 980700
// Class: COMP30019, 2020 Semester 2
// Description: A custom shader that is applied to every material utilising
// 		the powerful phong lighting model.
Shader "Custom/Phong"
{
	Properties
	{

		_Diffuse("DiffuseConstant", Range(0,1)) = 1
		_Color("SurfaceColor",Color)  = (0,0,0,1)
		_Gloss("GlossConstant", Range(1,256)) = 20
		_Specular("SpecularPower", Range(0,1)) = 1
		_MainTex("Texture",2D) = "white" {}
		
	}
	SubShader
	{
		
		Tags { "RenderType" = "Opaque" }
 
		//Base Pass 
		Pass
		{
			// For forward rendering, the Pass will calculate the ambient light, 
            // the most important parallel light, per-vertex/SH light source and LightMaps 
			Tags{"LightMode" = "ForwardBase"}
 
			CGPROGRAM
 
			#pragma vertex vert
			#pragma fragment frag

			//to ensure the shader compiles properly for the needed passes.
			// fwdbase would becomes fwdadd for any additional lights in their own pass.
			#pragma multi_compile_fwdbase
			#include "Lighting.cginc"
 
			float _Gloss;
			float _Diffuse;
			float4 _Color;
			float _Specular;
			uniform sampler2D _MainTex;
 
			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 uv : TEXCOORD2;
			};
 
			struct v2f {
				float4 vertex : SV_POSITION;
				float4 uv : TEXCOORD2;
				float3 worldPos : TEXCOORD0;
				float3 worldNormal : TEXCOORD1;
			};

		
			v2f vert(a2v v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.uv = v.uv;
				return o;
			}


			//phong lighting implementation
			float4 frag(v2f i) : SV_Target
			{

				// Sample the texture for the "unlit" colour for this pixel
				float4 unlitColor = tex2D(_MainTex, i.uv);

				//normals in world space
				float3 worldNormal = normalize(i.worldNormal);

				//light vector in  world space
				float3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));

				//view vector in world space
				float3 worldViewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));

				//ambient component
				float3 ambient = unlitColor * _Color.rgb * UNITY_LIGHTMODEL_AMBIENT.xyz;

				//Attenuation factor for directional light
				float fAtt = 1.0;

				//LdotN 
				float LdotN = dot(worldLightDir,worldNormal);

				//diffus component
				float3 diffuse = unlitColor * fAtt * _Color.rgb * _LightColor0.rgb * _Diffuse * saturate(LdotN);

				//specular component using  blinn-Phong approsimation:
				//specular constant is contained in _specular.rgb
				float3 halfDir = normalize(worldLightDir + worldViewDir);
				float3 specular =  fAtt * _LightColor0.rgb  * pow(saturate(dot(worldNormal, halfDir)), _Gloss) * _Specular;
 
				
				float4 returnColor;
				returnColor.rgb = ambient.rgb + diffuse.rgb + specular.rgb;
				returnColor.a = _Color.a;
				return returnColor;
			}
			ENDCG
		}
 
		//Addtional Pass 
		Pass
		{
			//this is used to process other un-important lights, each lights will call this pass once

			Tags{"LightMode" = "ForwardAdd"}
 
			//addtive mode, see https://docs.unity3d.com/Manual/SL-Blend.html
			Blend OneMinusDstColor One
 
			CGPROGRAM
 
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdadd
			#include "Lighting.cginc"

			//inlcude definition of USING_DIRECTION_LIGHT,POINT and SPOT 
			#include "AutoLight.cginc"

 
			float _Gloss;
			float _Diffuse;

			float4 _Color;
			float _Specular;
			uniform sampler2D  _MainTex;
 
			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 uv : TEXCOORD2;
			
			};
 
			struct v2f {
				float4 vertex : SV_POSITION;
				float4 uv : TEXCOORD2;
				float3 worldPos : TEXCOORD0;
				float3 worldNormal : TEXCOORD1;
			};
 
			v2f vert(a2v v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.uv = v.uv;
				return o;
			}
 
			float4 frag(v2f i) : SV_Target
			{

				// Sample the texture for the "unlit" colour for this pixel
				float4 unlitColor = tex2D(_MainTex, i.uv);

				//normals in world space
				float3 worldNormal = normalize(i.worldNormal);

				//View vector in world space  
				float3 worldViewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));

				//light vector in world space
				float3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);
				
				//diffuse component
				float3 diffuse = unlitColor.rgb * _Color.rgb * _LightColor0.rgb * _Diffuse * saturate(dot(worldNormal, worldLightDir));
 
				//specular component 
				float3 halfDir = normalize(worldLightDir + worldViewDir);
				float3 specular = _LightColor0.rgb  * pow(saturate(dot(worldNormal, halfDir)), _Gloss) * _Specular;

				//Attenuation factor for directional light
				float fAtt = 1.0;
 
				//ambient lighting has been calculated in the last pass 
				return float4 ((diffuse + specular) * fAtt, _Color.a);
			}
				ENDCG
		}
	}
}