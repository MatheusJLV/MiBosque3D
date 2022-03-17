using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 24)] private float TimeOfDay;
    public GameObject player;
    public int estacion;
    public float pendiente;
    public GameObject lucesAdicionales;


    private void Start()
    {
        estacion = 0;
        pendiente = 0.001f;
        TimeOfDay = 7f;
        if (RenderSettings.skybox.HasProperty("_Tint"))
            //Debug.Log(RenderSettings.skybox.color());
            RenderSettings.skybox.SetColor("_Tint", Color.white);
    }

    private void Update()
    {
        //Debug.Log(TimeOfDay);
        if (TimeOfDay > 5)
        {
            lucesAdicionales.SetActive(true);
        }

        if (estacion < player.GetComponent<Player>().playerData.maxStation)
        {
            estacion += 1;
            pendiente += 0.05f;

        }
        if (pendiente > 0)
        {
            progresar();
        }


    }
    private void progresar()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            TimeOfDay += Time.deltaTime / 4f;
            pendiente -= Time.deltaTime / (24f * 4f);
            TimeOfDay %= 24; //Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }



    }


    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}