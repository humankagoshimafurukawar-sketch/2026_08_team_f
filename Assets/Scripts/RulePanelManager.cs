using UnityEngine;

public class RulePanelManager : MonoBehaviour
{
    [SerializeField] GameObject ope_Panel;
    [SerializeField] GameObject obs_Panel;
    [SerializeField] GameObject disp_Panel;

    //======================================================================================================================
    public void SetActiveOpePanel()
    {
        ope_Panel.SetActive(true);
    }

    //----------------------------------------------------------------------------------------------------------------------
    public void SetInactiveOpePanel()
    {
        ope_Panel.SetActive(false);
    }

    //======================================================================================================================
    public void SetActiveObsPanel()
    {
        obs_Panel.SetActive(true);
    }

    //----------------------------------------------------------------------------------------------------------------------
    public void SetInactiveObsPanel()
    {
        obs_Panel.SetActive(false);
    }

    //======================================================================================================================
    public void SetActiveDisPanel()
    {
        disp_Panel.SetActive(true);
    }

    //----------------------------------------------------------------------------------------------------------------------
    public void SetInactiveDispPanel()
    {
        disp_Panel.SetActive(false);
    }
}
