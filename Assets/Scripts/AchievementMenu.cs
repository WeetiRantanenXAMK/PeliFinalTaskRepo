using UnityEngine;

public class AchievementMenu : MonoBehaviour
{
    [Header("Locked Blocks")]
    [SerializeField] GameObject Locked1;
    [SerializeField] GameObject Locked2;
    [SerializeField] GameObject Locked3;
    [SerializeField] GameObject Locked4;
    [SerializeField] GameObject Locked5;
    [SerializeField] GameObject Locked6;

    [Header("Unlocked Blocks")]
    [SerializeField] GameObject Unlocked1;
    [SerializeField] GameObject Unlocked2;
    [SerializeField] GameObject Unlocked3;
    [SerializeField] GameObject Unlocked4;
    [SerializeField] GameObject Unlocked5;
    [SerializeField] GameObject Unlocked6;

    [Header("DEBUG CONDITIONS")]
    [SerializeField] bool Gotten1;
    [SerializeField] bool Gotten2;
    [SerializeField] bool Gotten3;
    [SerializeField] bool Gotten4;
    [SerializeField] bool Gotten5;
    [SerializeField] bool Gotten6;

    private void OnEnable()
    {
        // K‰yd‰‰n saavutusten tilanteet l‰pi

        if (Gotten1)
        {
            Locked1.SetActive(false);
            Unlocked1.SetActive(true);
        }
        if (Gotten2)
        {
            Locked2.SetActive(false);
            Unlocked2.SetActive(true);
        }
        if (Gotten3)
        {
            Locked3.SetActive(false);
            Unlocked3.SetActive(true);
        }
        if (Gotten4)
        {
            Locked4.SetActive(false);
            Unlocked4.SetActive(true);
        }
        if (Gotten5)
        {
            Locked5.SetActive(false);
            Unlocked5.SetActive(true);
        }
        if (Gotten6)
        {
            Locked6.SetActive(false);
            Unlocked6.SetActive(true);
        }
    }


    public void CloseAchiMenu()
    {
        this.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        Unlocked1.SetActive(false);
        Unlocked2.SetActive(false);
        Unlocked3.SetActive(false);
        Unlocked4.SetActive(false);
        Unlocked5.SetActive(false);
        Unlocked6.SetActive(false);

        Locked1.SetActive(true);
        Locked2.SetActive(true);
        Locked3.SetActive(true);
        Locked4.SetActive(true);
        Locked5.SetActive(true);
        Locked6.SetActive(true);
    }
}
