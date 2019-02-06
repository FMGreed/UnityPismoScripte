using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AugmentedScript : MonoBehaviour
{
    float orgLatitude;
    float orgLongitude;
    float currentLatitude;
    float currentLongitude;

    Vector3 targetPosision;
    Vector3 currentPosition;

    bool SetOriginalValues = true;

    public Text distanceText;

    IEnumerator GetLocation()
    {
        while(true)
        {
            //Provjera dali korisnik ima uključenu lokaciju
            if(Input.location.isEnabledByUser)
            {
                yield break;
            }

            //Postizanje lokacije
            Input.location.Start(1f, 1f);

            //Čekanje učitavanja lokacije
            int maxWait = 20;
            while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            //Service status se nije učitao
            if(maxWait < 1)
            {
                Debug.Log("Isteklo vreme, probaj ponovo!");
            }

            //Ako connection faila (if connection failed)
            if(Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Nije moguće odrediti lokaciju, probaj opet ili uključ internet, il kup dobar mobtel jbt");
                yield break;
            }

            //kada je oboje prošlo uredu, odnoso učitali smo lokaciju i vrijednosti
            else
            {
                Debug.Log("Location: " + Input.location.lastData.latitude + ", " + Input.location.lastData.longitude + ", " + Input.location.lastData.altitude + ", " + Input.location.lastData.horizontalAccuracy + ", " + Input.location.lastData.timestamp);
            }

            //Dodjeljivanje lokacije
            if(SetOriginalValues)
            {
                orgLatitude = Input.location.lastData.latitude;
                orgLongitude = Input.location.lastData.longitude;
                SetOriginalValues = false;
            }

            //prepiši lokaciju nanovo
            currentLatitude = Input.location.lastData.latitude;
            currentLongitude = Input.location.lastData.longitude;

            //Računanje udaljenosti između igrača i mjesta gdje se aplikacija pokrenula
            //DZ UČITATI CALC
        }
    }
    public void Calc(float lat1, float lon1, float lat2, float lon2)
    {
        var R = 6371; //Radijus Zemlje u km
        var dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
        var dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLon / 2) + Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180);
        var b = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        float distance = R * b;
        distance = distance * 1000f; //Pretvaramo vrijednost iz kilometre u metre
        distanceText.text = "Distance: " + distance;
    }
}
