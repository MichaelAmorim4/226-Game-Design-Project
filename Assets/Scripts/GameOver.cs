using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : Interactable
{

    // When the player interacts with the item
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    // Pick up the item
    void PickUp()
    {
        SceneManager.LoadScene("Game Over");
    }

}