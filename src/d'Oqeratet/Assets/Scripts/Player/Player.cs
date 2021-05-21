using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct AssignmentList
{
    private List<AssignmentCard> assignments;//Private deck of assignments
    private int index;

    public AssignmentList(List<AssignmentCard> assignments) {
        this.assignments = assignments;
        this.index = -1;
    }

    public AssignmentCard NextAssignment() {
        if (assignments == null) {
            //Since this is run from after all the start-methods, GDM will have been initialised
            GameDataManager gdm = GameObject.Find("Game Manager").GetComponent<GameDataManager>();
            // Returns a shuffled deep copy of all assignments
            assignments = gdm.getAssignments();
            index = -1;
        }
        index += 1;
        if (index < assignments.Count) {
            return assignments[index];
        }
        //Requesting out of range
        return null;
    }

    public void InsertAssignment(AssignmentCard newCard) {
        assignments.Add(newCard);
    }
}

public class Player : MonoBehaviour
{
    // Script references
    public GameDataManager GDM;

    // Assignments
    AssignmentList assignments;
    AssignmentList failedAssignments;

    int successProbability;

    // Stats
    public int stamina;
    public int maxStamina;
    public int hp;
    public int money;

    private AssignmentCard lastAssignment = null;

    // Items

    //Friends

    void Start() {
        this.failedAssignments = new AssignmentList(new List<AssignmentCard>());

        // Stats
        this.stamina = 100;
        this.maxStamina = 100;
        this.hp = 0;
        this.money = 500;
    }

    // Used to add or remove stamina
    public void addStamina(int value) {
        if (stamina + value > maxStamina) {
            stamina = maxStamina;
        } else {
            stamina += value;
        }
    }

    // Used to add or remove money
    public void addMoney(int value) {
        money += value;
    }

    // Used to add or remove HP
    public void addHP(int value) {
        hp += value;
    }

    // Draw card from assignments
    public AssignmentCard drawCard() {
        //successProbability = 0;
        AssignmentCard assignment = assignments.NextAssignment();
        if (assignment == null) {
            //No more assignments left
            //Attempt to take one from failed assignment deck
            assignment = failedAssignments.NextAssignment();
        }

        this.lastAssignment = assignment;   

        return assignment;
    }

    public AssignmentCard getLastAssignment() {
        return this.lastAssignment;
    }

    public void failAssignment(AssignmentCard failedAssignment) 
    {
        this.failedAssignments.InsertAssignment(failedAssignment);
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
    }

    // Accept assignment
    /*void acceptAssignment(bool choice) {
        if (choice) {
            GDM.drawChapterCard();
            addStamina(-5);
            //FE.showActions();
        } else {
            //FE.showWorkOrRelax();
        }
    }*/

    // Study for assignment
    void study() {
        addStamina(-5);
        successProbability += 5;
    }

    // Attempt assignment
    /*void attemptAssignment() {
        addStamina(-15);
        addHP(5);

        // Roll for pass or fail
        if (successRate > Random.Range(0, 100)) {
            if (assignments.Contains(assignment)) {
                assignments.remove(assignment);
            } else {
                faliedAssignments.remove(assignment);
            }
        } else {
            if (assignments.contains(assignment)) {
                assignments.remove(assignment);
                faliedAssignments.add(assignment);
            }
        }

        //FE.endTurn();
    }*/

    void Update () {
        Transform card = transform.Find("Test Card Disp(Clone)");
        if (card != null)
        {
            if (this == GDM.getActivePlayer())
            {
                card.GetComponent<CardMovement>().desiredLocation = "face";
            }
            else
            {
                card.GetComponent<CardMovement>().desiredLocation = "draw_deck";
            }
        }
    }
}
