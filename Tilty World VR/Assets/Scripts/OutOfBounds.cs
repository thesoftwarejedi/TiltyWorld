using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour {
    void OnTriggerExit(Collider other)
    {
        //reload the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
