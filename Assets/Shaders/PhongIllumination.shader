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
		_Ambient("AmbientPower", Range(0,1)) = 0.8
		_RimColor("Rim Color", Color) = (1,1,1,1)
		_RimAmount("Rim Amount", Range(0, 1)) = 1
		_MainTex("Texture",2D) = "white" {}
		//_BumpMap ("Bumpmap", 2D) = "bump" {}
		
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

			// expands to several variants to handle different fog types (off/linear/exp/exp2).
			#pragma multi_compile_fog

			//to ensure the shader compiles properly for the needed passes.
			// fwdbase would becomes fwdadd for any additional lights in their own pass.
			#pragma multi_compile_fwdbase
			#include "Lighting.cginc"

			#include "AutoLight.cginc"

			float4 _RimColor;
			float _RimAmount;
			float _Gloss;
			float _Diffuse;
			float4 _Color;
			float _Specular;

			uniform sampler2D _MainTex;

			float4 _MainTex_ST;

			uniform sampler2D uv_BumpMap;
			float _Ambient;
 
			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD2;

			};
 
			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD2;
				float3 worldPos : TEXCOORD0;
				float3 worldNormal : TEXCOORD1;

				//store fog data 
				UNITY_FOG_COORDS(3)


				//store shadow data
				SHADOW_COORDS(4)


			};

		
			v2f vert(a2v v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
			
				//activate tile  and offset parameter for texture
				o.uv = TRANSFORM_TEX (v.uv, _MainTex);

				//calculate shadow data
				TRANSFER_SHADOW(o)

				//calculate fog data
				UNITY_TRANSFER_FOG(o,o.pos);
				return o;
			}


			//phong lighting implementation
			float4 frag(v2f i) : SV_Target
			{
				
			

				//normals in world space
				float3 worldNormal = normalize(i.worldNormal);

				//light vector in  world space
				float3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));

				//view vector in world space
				float3 worldViewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));


				float lon = (dot(worldNormal, worldLightDir) > 0?1:0);

				
	
				// Sample the texture for the "unlit" colour for this pixel
				float4 unlitColor = tex2D(_MainTex, i.uv);

				//ambient component
				float3 ambient = unlitColor * _Color.rgb * UNITY_LIGHTMODEL_AMBIENT.rgb * _Ambient;

				//Attenuation factor for directional light
				float fAtt = 1.0;

				
				
				//cartoonlization； more info seeing  https://roystan.net/articles/toon-shader.html
				//diffus component with  toon-like implementing
				float3 diffuse = unlitColor * fAtt * _Color.rgb * _LightColor0.rgb * _Diffuse * (dot(worldNormal, worldLightDir) > 0?1:0);

				//specular component using  blinn-Phong approsimation:
				//specular constant is contained in _specular.rgb
				float3 halfDir = normalize(worldLightDir + worldViewDir);
				float3 specular =  smoothstep(0.005, 0.01, _LightColor0.rgb  * pow(dot(worldNormal, halfDir), _Gloss)) * _Specular;


				//the  back part of an object
				float4 rimDot = 1 - dot(worldViewDir, worldNormal);

				//cartoonlizing
				float rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimDot);

				//final color for rim
				float4 rim = rimIntensity * _RimColor;

				//built-in macro; calculating attenuation for diffrent type of lights
				float4 returnColor;
				returnColor.rgb = ambient +  (diffuse + specular) * SHADOW_ATTENUATION(i)+ rim;


				//render fog
				UNITY_APPLY_FOG(i.fogCoord, returnColor);
	
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
			// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members lightCoord)
			//#pragma exclude_renderers d3d11
		
			#pragma vertex vert
			#pragma fragment frag

			// same as multi_compile_fwdadd, but also includes ability for the lights to have real-time shadows.
			#pragma multi_compile_fwdadd_fullshadows
			#include "Lighting.cginc"

			//inlcude definition of USING_DIRECTION_LIGHT,POINT and SPOT 
			#include "AutoLight.cginc"



				float4 _RimColor;
			float _RimAmount;
 
			float _Gloss;
			float _Diffuse;
	
			float4 _Color;
			float _Specular;


			uniform sampler2D _MainTex;

			float4 _MainTex_ST;

			float _Ambient;

			float _Reflection;
 
			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD2;
			};
 
			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD2;
				float3 worldPos : TEXCOORD0;
				float3 worldNormal : TEXCOORD1;

				UNITY_FOG_COORDS(3)
				//store shadow data
				SHADOW_COORDS(4)

			};
 
			v2f vert(a2v v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.uv = v.uv;

							
				o.uv = TRANSFORM_TEX (v.uv, _MainTex);

				TRANSFER_SHADOW(o)
				UNITY_TRANSFER_FOG(o,o.pos);
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

				//directional light vector in world space
				#ifdef USING_DIRECTIONAL_LIGHT  
					float3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);
				#else
					//vectors of other light sources in world space
					float3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz - i.worldPos.xyz);
				#endif


				//diffuse component with toon-like implementation
				float3 diffuse = unlitColor.rgb * _Color.rgb * _LightColor0.rgb * _Diffuse * (dot(worldNormal, worldLightDir) > 0?1:0);
 
				//specular component with toon-like implementation
				float3 halfDir = normalize(worldLightDir + worldViewDir);
				float3 specular =   smoothstep(0.005, 0.01, _LightColor0.rgb  * pow((dot(worldNormal, halfDir)) , _Gloss)) * _Specular;

				//Rim lighting is the addition of illumination to the edges of an object to simulate reflected light or backlighting.

				//the  back part of an object
				float4 rimDot = 1 - dot(worldViewDir, worldNormal);

				//cartoonlizing
				float rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimDot);

				//final color for rim
				float4 rim = rimIntensity * _RimColor;
				
				//built-in macro; calculating attenuation for diffrent type of lights
				 UNITY_LIGHT_ATTENUATION(fAtt, i, i.worldPos);




				//built-in macro; calculating attenuation for diffrent type of lights
				float4 returnColor;
	
				//render fog
				UNITY_APPLY_FOG(i.fogCoord, returnColor);

				//ambient lighting has been calculated in the last pass
				//take shadow attenuation into account,  for more info seeing https://docs.unity3d.com/Manual/SL-VertexFragmentShaderExamples.html
				returnColor.rgb = ((diffuse + specular) *SHADOW_ATTENUATION(i) + rim) * fAtt;
				returnColor.a = _Color.a;
				return returnColor;
			}
				ENDCG
        }
	}

//call shadow casting pass

FallBack  "Diffuse"
}