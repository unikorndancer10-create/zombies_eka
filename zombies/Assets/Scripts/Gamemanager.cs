using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    public GameObject[] zombies;

    public GameObject selectedZombie;

    public Vector3 selectedSize;
    public Vector3 pushForce;

    public TMP_Text timerText;
    private float timer;

    private InputAction next, prev, jump;
    private int selectedIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        next = InputSystem.actions.FindAction("Next Zombie");
        prev = InputSystem.actions.FindAction("Prev Zombie");
        jump = InputSystem.actions.FindAction("Jump");



        SelectZomnie(selectedIndex);
    }

    void SelectZomnie(int index)
    {
        if (selectedZombie != null)
        {
            selectedZombie.transform.localScale = Vector3.one;
        }
        
        selectedZombie = zombies[index];
        selectedZombie.transform.localScale = selectedSize;
        Debug.Log("selected: " + selectedZombie);
    }
    // Update is called once per frame
    void Update()
    {
        if(next.WasPressedThisFrame())
        {
            Debug.Log("next");
            selectedIndex++;
            if (selectedIndex >= zombies.Length)
                selectedIndex = 0;
            SelectZomnie(selectedIndex);
        }
        if (prev.WasPressedThisFrame())
        {
            Debug.Log("prev");
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = zombies.Length -1;
            SelectZomnie(selectedIndex);
        }

        if(jump.WasPressedThisFrame())
        {
            Debug.Log("Jump");

            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            if(rb != null)
                rb.AddForce(pushForce);
        }

        timer += Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("F1") + "s";
    }
}
