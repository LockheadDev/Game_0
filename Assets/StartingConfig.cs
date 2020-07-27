using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingConfig : MonoBehaviour
{
    public OptionsMenu options;
    // Start is called before the first frame update
    void Start()
    {
        options.Refresh();
    }

}
