using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public Light dirLight;
    private ParticleSystem _ps;
    private bool _isRaingo = false;

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        StartCoroutine(Weather());
    }

    private void Update()
    {
        if (_isRaingo && dirLight.intensity > 0.25f)
            LightIntensity(-1);
        else if (!_isRaingo && dirLight.intensity < 0.5f)
            LightIntensity(1);

    }

    private void LightIntensity(int v)
    {
        dirLight.intensity += 0.1f * Time.deltaTime * v;
    }

    IEnumerator Weather()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(10f, 15f));

            if (_isRaingo)
                _ps.Stop();
            else
                _ps.Play();

            _isRaingo = !_isRaingo;
        }
    }
}
