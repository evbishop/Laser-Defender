using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;

public class ERC1155BalanceOfExample : MonoBehaviour
{
    [SerializeField] SpriteRenderer player;

    async void Start()
    {
        string chain = "ethereum";
        string network = "rinkeby";
        string contract = "0x88b48f654c30e99bc2e4a1559b4dcf1ad93fa656";
        string account = PlayerPrefs.GetString("Account");
        string tokenId = "41462924012407924625429813191293949761107184749737816237578625369961326968833";

        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        print(balanceOf);

        if (balanceOf > 0)
        {
            player.color = Color.red;
        }
    }
}
