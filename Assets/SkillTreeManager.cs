using System.Net.Mime;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    #region skill gameobjects

    [SerializeField] private Image freezeSkill;
    [SerializeField] private Image powerUpSkill;
    
    #endregion
    
    #region skill bools

    public bool isFreezeSkillUnlocked;
    public bool isPowerUpSkillUnlocked;

    #endregion

    private void Update()
    {
        if (isFreezeSkillUnlocked)
        {
       
        }

        if (isPowerUpSkillUnlocked)
        {
            
        }
    }
}
