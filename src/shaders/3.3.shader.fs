#version 330 core
out vec4 FragColor;

in vec3 FragPos;
in vec3 Normal;
in vec3 Color;

uniform float u_time;
uniform vec3 lightPos;
uniform vec3 viewPos;

void main()
{
    // Ambient
    float ambientStrength = 0.2*u_time;
    vec3 ambient = ambientStrength * Color;
  
    // Diffuse
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diff * Color;

    vec3 result = (ambient + diffuse);
    FragColor = vec4(abs(sin(result.x*u_time)), abs(cos(result.y*u_time+0.4)), abs(cos(result.z*u_time+0.7)), 1.0);
}
