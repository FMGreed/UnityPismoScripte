using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AugmentedR_GP_SCript : MonoBehaviour
{
    float startLatitude;
    float startLongitude;

    float currentLatitude;
    float currentLongitude;

    bool setStartValues = true;

    float distance;

    Text distanceText;

    IEnumerator GetLocation()
    {
        while(true)
        {
            //Provjeravamo ima li korisnik uključenu lokaciju
            if(!Input.location.isEnabledByUser)
            {
                yield break;
            }

            //Dodjeljujemo početak lokacije
            Input.location.Start(1f, 1f);

            //Čekanje za lokaciju
            int maxWait = 20;

            while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            //Ako se nije našla lokacija unutar 20 sekundi
            if(maxWait < 1)
            {
                Debug.Log("Isteklo vrijeme!");
                yield break;
            }

            //Ako je konekcija neuspiješna
            if(Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Nije bilo moguće odrediti lokaciju");
                yield break;
            }

            //Ako smo pronašli lokaciju i primili vrijednost kordinata
            else
            {
                Debug.Log("Location: " + Input.location.lastData.latitude + ", " + Input.location.lastData.longitude + ", " + Input.location.lastData.altitude + ", " + Input.location.lastData.horizontalAccuracy + ", " + Input.location.lastData.timestamp);

                //Učitati vrijednost kordinata korisniku
                if(setStartValues)
                {
                    startLatitude = Input.location.lastData.latitude;
                    startLongitude = Input.location.lastData.longitude;
                    setStartValues = false;
                }

                //zapisivanje širina i dužina geografska svaki put
                currentLatitude = Input.location.lastData.latitude;
                currentLongitude = Input.location.lastData.longitude;

                //Izračunavanje udaljenosti između igrača i mjesta gdje se aplikacija pokrenula
            }
        }
    }

    //Računanje udaljenosti između kordinata uz pomoć planeta Zemlje, AKO SE NE SLAŽETE DA JE ZEMLJA OKRUGLA NAPIŠITE KOD SAMI
    public void Calc(float lat1, float lon1, float lat2, float lon2)
    {
        var R = 6371; //Radijus Zemlje u km
        var dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
        var dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
        float a = Mathf.Sin(dLat / 2) + Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) * Mathf.Sin(dLon / 2);
        var b = Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        distance = R * b;
        distance = distance * 1000; //Pretvaranje u metre
        distanceText.text = "Distance: " + distance;

    }
}
