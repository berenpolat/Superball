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
            freezeSkill.color = Color.blue;
        }

        if (isPowerUpSkillUnlocked)
        {
            powerUpSkill.color =Color.red;
        }
    }
}
