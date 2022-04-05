using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WebGLSendTransactionExample : MonoBehaviour
{
    [SerializeField] string hash;

    async public void OnSendTransaction()
    {
        // account to send to
        string to = "0x04F267C1001fa7552a24aCc7BC71145E4AfD01a7";
        // amount in wei to send
        string value = "50000000000000000";
        // gas limit OPTIONAL
        string gasLimit = "";
        // gas price OPTIONAL
        string gasPrice = "";
        // connects to user's browser wallet (metamask) to send a transaction
        try {
            string response = await Web3GL.SendTransaction(to, value, gasLimit, gasPrice);
            Debug.Log(response);
            hash = response;
        } catch (Exception e) {
            Debug.LogException(e, this);
        }
    }

    void Update()
    {
        if (hash.Contains("0"))
            SceneManager.LoadScene("Game");
    }
}