using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ScriptableObject
{
    /*
    // Script references
    GameDataManager GDM;
    //FrontEnd FE;

    // Assignements
    List<Card> assignments;
    List<Card> failedAssignments;
    Card assignment;
    int successRate;

    // Stats
    private int stamina;
    static int maxStamina;
    private float hp;
    private int money;

    // Items

    // Start is called before the first frame update
    public Player()
    {   
        // Returns a deep copy of all assignments
        assignments = GDM.getAssignments();
        failedAssignments = new List<Card>();

        // Stats
        int stamina = 100;
        int maxStamina = 100;
        float hp = 0f;
        int money = 500;
    }

    // Used to add or remove stamina
    void addStamina(int value) {
        if (stamina + value > maxStamina) {
            stamina = maxStamina;
        } else {
            stamina += value;
        }
    }

    // Used to add or remove money
    void addMoney(int value) {
        money += value;
    }

    // Used to add or remove HP
    void addHP(int value) {
        hp += value;
    }

    // Used to add or remove stamina
    int getStamina() {
        return stamina;
    }

    // Used to add or remove money
    int getMoney() {
        return money;
    }

    // Used to add or remove HP
    float getHP() {
        return hp;
    }

    // Draw card from assignments
    void drawCard() {
        successRate = 0;
        if (assignments.size != 0) {
            assignment = assignments.next();
        } else if (failedAssignments.Size != 0) {
            assignment = failedAssignments.next();
        }
        
        //FE.showAssignmentOptions();
    }

    // Work or relax
    void goToWork(bool choice) {
        
        // True for work
        if (choice) {
            addStamina(-5);
            addMoney(20);

        // False for relax
        } else {
            addStamina(10);
        }

        //FE.endTurn();
    }

    // Accept assignment
    void acceptAssignment(bool choice) {
        if (choice) {
            GDM.drawChapterCard();
            addStamina(-5);
            //FE.showActions();
        } else {
            //FE.showWorkOrRelax();
        }
    }

    // Study for assignment
    void study() {
        addStamina(-5);
        successRate += 5;
    }

    // Attempt assignment
    void attemptAssignment() {
        addStamina(-15);
        addHP(5);

        // Roll for pass or fail
        if (successRate > Random.Range(0, 100)) {
            if (assignements.contains(assignment)) {
                assignements.remove(assignment);
            } else {
                faliedAssignements.remove(assignment);
            }
        } else {
            if (assignements.contains(assignment)) {
                assignements.remove(assignment);
                faliedAssignements.add(assignment);
            }
        }

        //FE.endTurn();
    }
    */
}
