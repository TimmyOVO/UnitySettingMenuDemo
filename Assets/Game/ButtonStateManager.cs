using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStateManager : MonoBehaviour
{
    private Dictionary<string, bool> buttonStateMap;

    public Button airplaneMode;
    public Button cellularMode;
    public Button wifi;
    public Button bluetooth;


    public Sprite wifiOn;
    public Sprite wifiOff;

    public Sprite cellularOn;
    public Sprite cellularOff;

    public Sprite airplaneOn;
    public Sprite airplaneOff;

    public Sprite bluetoothOn;
    public Sprite bluetoothOff;

    // Start is called before the first frame update
    void Start()
    {
        buttonStateMap = new Dictionary<string, bool>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool GetButtonState(Button button)
    {
        bool result = false;
        if(!this.buttonStateMap.TryGetValue(button.name,out result))
        {
            this.buttonStateMap[button.name] = false;
        }
        return result;
    }

    public void PreesButton(Button button, Sprite on, Sprite off)
    {
        bool b = this.GetButtonState(button);
        button.image.sprite = this.GetNextSprite(button,on,off);
        this.buttonStateMap[button.name] = !b;

    }

    public Sprite GetNextSprite(Button button,Sprite on,Sprite off)
    {
        if (this.GetButtonState(button))
        {
            return on;
        }
        else
        {
            return off;
        }
    }

    public void OnAirplaneModeClick()
    {
        this.PreesButton(airplaneMode, airplaneOn, airplaneOff);
    }
    public void OnCellularModeClick()
    {
        this.PreesButton(cellularMode, cellularOn, cellularOff);
    }

    public void OnWifiClick()
    {
        this.PreesButton(wifi, wifiOn, wifiOff);
    }
    public void OnBluetoothClick()
    {
        this.PreesButton(bluetooth, bluetoothOn, bluetoothOff);
    }
}
