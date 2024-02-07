using System.Net.Mime;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    #region skill gameobjects

    [SerializeField] private UnityEngine.UI.Image freezeSkill;
    [SerializeField] private UnityEngine.UI.Image powerUpSkill;
    
    #endregion
    
    #region skill bools

    public bool isFreezeSkillUnlocked;
    public bool isPowerUpSkillUnlocked;

    #endregion

    private void Update()
    {
        if (isFreezeSkillUnlocked)
        {
            freezeSkill.color = Color.white;
        }

        if (isPowerUpSkillUnlocked)
        {
            powerUpSkill.color =Color.white;
        }
    }
}
