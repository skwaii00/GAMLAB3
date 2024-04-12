using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject trangPhuc; // Menu cần tắt
    void Start()
    {
        
        UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        HideMenu();
        
    }
    public void HideMenu()
    {
        trangPhuc.SetActive(false); // Hiển thị Menu
    }
}
