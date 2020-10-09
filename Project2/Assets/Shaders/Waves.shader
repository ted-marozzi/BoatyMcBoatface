// Author: Mehmet Koseoglu
// StudentID: 925573
// Class: COMP30019, 2020 Semester 2
// Description: A shader that uses displacement of vertices with Gerstner Waves
//              to create a realistic looking water. (Phong Illumination added
//              by team member Zhirui Xin)

Shader "Custom/Waves 1.3"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _WaveA("WaveA (dirX, dirY, steepness, length)", Vector) = (-1,-1,0.1,10)
        _WaveB("WaveB", Vector) = (0,-1,0.2,15)
        _WaveC("WaveC", Vector) = (-1,-1.3,0.2,15)
        _Diffuse("DiffuseConstant", Range(0,1)) = 1
		_Gloss("GlossConstant", Range(1,256)) = 20
		_Specular("SpecularPower", Range(0,1)) = 1
        _Transparency ("Transparency",Range(0,1)) = 0.9



    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
    
        LOD 200
        
        CGPROGRAM

        // Physically based Standard lighting model, and enable shadows on all light types 
        #pragma surface surf Phong alpha vertex:vert addshadow

        // Use shader model 3.0 target, to get nicer looking lighting   
        #pragma target 3.0

        sampler2D _MainTex;

        //screePos is to sample the depth texture of terrain under water 
        struct Input
        {
            float2 uv_MainTex;
   
        };

  
        static const float gravity = 9.8;

        fixed4 _Color;
        float4 _WaveA;
        float4 _WaveB;
        float4 _WaveC;
        float _Gloss;
		float _Diffuse;
		float _Specular;
        float _Transparency;

        //Custom lighting model, used phong lighting model 
        half4 LightingPhong (SurfaceOutput s, half3 worldLightDir, half3 worldViewDir, half fAtt) {
      
			//normals in world space 
			float3 worldNormal = s.Normal;

			//ambient component
			float3 ambient = s.Albedo  * UNITY_LIGHTMODEL_AMBIENT.xyz;

			//LdotN
			float LdotN = dot(worldLightDir,worldNormal);

			//diffus component 
			float3 diffuse =  _Diffuse  * _LightColor0.rgb * s.Albedo * saturate(LdotN);

			//specular component using  blinn-Phong approsimation: 
			float3 halfDir = normalize(worldLightDir + worldViewDir);
			float3 specular =  _LightColor0.rgb * pow(saturate(dot(worldNormal, halfDir)),  _Gloss) * _Specular;
 
            //Phong lighting
			return float4 (ambient + (diffuse + specular) * fAtt, _Transparency);
        }

        // found on htps://catlikecoding.com/unity/tutorials/flow/waves/
        float3 GerstnerWave (
			float4 wave, float3 p, inout float3 tangent, inout float3 binormal
		) {
		    float steepness = wave.z;
		    float wavelength = wave.w;
		    float num_waves = 2 * UNITY_PI / wavelength;
            // c is the speed of the wave, its related to wave number & gravity for realistic look
			float c = sqrt(gravity / num_waves);
			float2 direction = normalize(wave.xy);
			float f = num_waves * (dot(direction, p.xz) - c * _Time.y);
			
            // a is the relatino between wave length & height, used to prevent overlap of waves
            float a = steepness / num_waves;

			tangent += float3(
				-direction.x * direction.x * (steepness * sin(f)),
				direction.x * (steepness * cos(f)),
				-direction.x * direction.y * (steepness * sin(f))
			);
			binormal += float3(
				-direction.x * direction.y * (steepness * sin(f)),
				direction.y * (steepness * cos(f)),
				-direction.y * direction.y * (steepness * sin(f))
			);
			return float3(
				direction.x * (a * cos(f)),
				a * sin(f),
				direction.y * (a * cos(f))
			);
		}


        void vert(inout appdata_full vertexData) {
			float3 gridPoint = vertexData.vertex.xyz;
			float3 tangent = float3(1, 0, 0);
			float3 binormal = float3(0, 0, 1);
			float3 p = gridPoint;
            // we can keep adding waves and they are all relative
            // to a flat surface so they add up realistically

			p += GerstnerWave(_WaveA, gridPoint, tangent, binormal);
            p += GerstnerWave(_WaveB, gridPoint, tangent, binormal);
            p += GerstnerWave(_WaveC, gridPoint, tangent, binormal);

			float3 normal = normalize(cross(binormal, tangent));
			vertexData.vertex.xyz = p;
			vertexData.normal = normal;
		}

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
     		
        }
        ENDCG
    }
 
    
}