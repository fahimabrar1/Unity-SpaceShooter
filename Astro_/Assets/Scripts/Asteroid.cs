using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Camera camera;
    public Slider slider;

    private void Start()
    {
        camera = FindObjectOfType<Camera>();

        slider.transform.LookAt(camera.transform,camera.transform.position);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("bolt"))
        {
            AstroParticles.Astro(gameObject.transform);
            GameHazard.reEnque(gameObject);
            PlayerController.reEnque(other.gameObject);
            SoundManager.PlaySound("Explosion");
            ScoreSystem.UpdateScore();
            Points.getPoints();
        }else if (other.gameObject.tag.Equals("ship"))
        {
            MenuManager.DeadMenu();
            AstroParticles.Astro(gameObject.transform);
            PlaneParticles.Particles();
            GameHazard.reEnque(gameObject);
            SoundManager.PlaySound("Explosion");
            Debug.Log(other.gameObject.tag);
            other.gameObject.SetActive(false);
            SoundManager.PlaySound("Explosion");

            GameHazard.playeralive = false;
        }
    }
}
