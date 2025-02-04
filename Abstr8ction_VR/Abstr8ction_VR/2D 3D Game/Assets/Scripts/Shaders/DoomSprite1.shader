﻿// Upgrade NOTE: commented out 'float4x4 _CameraToWorld', a built-in variable
// Upgrade NOTE: replaced '_CameraToWorld' with 'unity_CameraToWorld'
// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//https://github.com/unitycoder/DoomStyleBillboardTest

Shader "UnityCoder/DoomSprite1" {

Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
}

SubShader {

    Pass {
        //Tags {"Queue" = "Geometry" "RenderType" = "Transparent"}
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        //Cull off
       
        CGPROGRAM

	    #pragma vertex vert
	    #pragma fragment frag
		#pragma fragmentoption ARB_precision_hint_fastest
		#define PI 3.1415926535897932384626433832795
	    #include "UnityCG.cginc"

          uniform sampler2D _MainTex;
          uniform float4 _MainTex_ST;

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                half2 uv : TEXCOORD0;
                float3 normal : TEXCOORD1;
  //              float3 viewUp : TEXCOORD2;
                float3 viewRight : TEXCOORD3;
                float3 viewFront : TEXCOORD4;
            };
            
   

            // float4x4 _CameraToWorld;

            v2f vert (appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos (v.vertex);
                o.normal = float3(0,0,-1); //v.normal; // using fixed normal direction
                o.uv =  v.texcoord.xy;
               
                // Convert from camera to world space.
                float3 viewUpW = mul((float3x3)unity_CameraToWorld, float3(0,1,0));
                float3 viewRightW = mul((float3x3)unity_CameraToWorld, float3(1,0,0));
                float3 viewFrontW = mul((float3x3)unity_CameraToWorld, float3(0,0,-_ProjectionParams.x));
               
                // Convert from world to object space.
  //              o.viewUp = mul((float3x3)_Object2World, viewUpW);
                o.viewRight = mul((float3x3)unity_ObjectToWorld, viewRightW);
                o.viewFront = mul((float3x3)unity_ObjectToWorld, viewFrontW);
                          
               // billboard towards camera
  				float3 vpos=mul((float3x3)unity_ObjectToWorld, v.vertex.xyz);
 				float4 worldCoord=float4(unity_ObjectToWorld._m03,unity_ObjectToWorld._m13,unity_ObjectToWorld._m23,1);
				float4 viewPos=mul(UNITY_MATRIX_V,worldCoord)+float4(((float3x3)UNITY_MATRIX_V,vpos),0);
				
				float4 outPos=mul(UNITY_MATRIX_P,viewPos);
				o.pos = UnityPixelSnap (outPos);
               
                return o;
            }


            fixed4 frag(v2f i) : COLOR 
            {
                i.normal = normalize(i.normal);
//                i.viewUp = normalize(i.viewUp);
                i.viewRight = normalize(i.viewRight);
                i.viewFront = normalize(i.viewFront);
               
                fixed4 c = 0;
				float angle2 = (atan2(i.normal.y,i.viewFront.z))*(180/PI);
				
				float si = i.normal.x * i.viewRight.z - i.viewRight.x * i.normal.z;
				float co = i.normal.x * i.viewRight.x + i.normal.z * i.viewRight.z;
				angle2 = atan2(si, co)*(180/PI);
				
				if (angle2<0) angle2=360+angle2; // get angle value 0-360, instead of 0-180
				
				float frames = 8; // texture has 8 frames (side by side images)
				int index = angle2/45;
				float s = 1/frames;
				c = tex2D(_MainTex, float2(i.uv.x*s + s*(index)  ,i.uv.y));
                return c;
            }

        ENDCG
    }
}
}
