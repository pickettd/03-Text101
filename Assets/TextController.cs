﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

    public Text text;
    public GameObject prisonImage;
	private float shade;
	private Color whiteColor;
	private Color blackColor;
    
	private enum States {
		cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, stairs_0, stairs_1,
		stairs_2, courtyard, floor, corridor_1, corridor_2, corridor_3,closet_door, in_closet
		};
	private States myState;
    
    // Use this for initialization
	void Start () {
	    myState = States.cell;
	    whiteColor = new Color32(255,255,255,255);
	    blackColor = new Color32(0,0,0,255);
	    shade = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if 		(myState == States.cell) 		{cell();}
		else if (myState == States.sheets_0) 	{sheets_0();}
		else if (myState == States.sheets_1) 	{sheets_1();}
		else if (myState == States.lock_0) 		{lock_0();}
		else if (myState == States.lock_1) 		{lock_1();}
		else if (myState == States.mirror) 		{mirror();}
		else if (myState == States.cell_mirror) {cell_mirror();}
		else if (myState == States.corridor_0) 	{corridor_0();}
		else if (myState == States.stairs_0) 	{stairs_0();}
		else if (myState == States.stairs_1) 	{stairs_1();}
		else if (myState == States.stairs_2) 	{stairs_2();}
		else if (myState == States.courtyard) 	{courtyard();}
		else if (myState == States.floor) 		{floor();}
		else if (myState == States.corridor_1) 	{corridor_1();}
		else if (myState == States.corridor_2) 	{corridor_2();}
		else if (myState == States.corridor_3) 	{corridor_3();}
		else if (myState == States.closet_door) {closet_door();}
		else if (myState == States.in_closet) 	{in_closet();}
	}
	
	void in_closet() {
		text.text = "Inside the closet you see a cle(╯°□°）╯︵ ┻━┻)aner's uniform that looks about your size! " +
					"Seems like your day is looking-up.\n\n" +
					"Press D to Dress up, R to Return to the corridor, or X to yell as loud as you can";
		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.corridor_2;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
		else if (Input.GetKeyDown(KeyCode.D)) 	{myState = States.corridor_3;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
	}
	
	void closet_door() {
		text.text = "You are looking at a closet door, unfortunately it's locked. " +
					"Maybe you could find something around to help enourage it open?\n\n" +
					"Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
	}
	
	void corridor_3() {
		text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
					"You strongly consider the run for freedom.\n\n" +
					"Press S to take the Stairs, or U to Undress";
		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.courtyard;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
		else if (Input.GetKeyDown(KeyCode.U))	{myState = States.in_closet;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
	}
	
	void corridor_2() {
		text.text = "Back in the c\norridor, h\naving declined to dr\ness-up as a cleaner.\n\n" +
					"Press C to revi\nsit the Cl\noset, and S to climb the stairs";
		if 		(Input.GetKeyDown(KeyCode.C)) 	{myState = States.in_closet;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
		else if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairs_2;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
	}
	
	void corridor_1() {
		text.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
					"Now what? You wonder if that lock on the closet would succumb to " +
					"to some lock-picking?\n\n" +
					"P to Pick the lock, and S to climb the stairs";
		if (Input.GetKeyDown(KeyCode.P)) 		{myState = States.in_closet;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
		else if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairs_1;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
	}
	
	void floor () {
		text.text = "Rummagaing around on the dirty floor, you find a hairclip.\n\n" +
					"Press R to Return to the standing, or H to take the Hairclip." ;
		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.corridor_0;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
		else if (Input.GetKeyDown(KeyCode.H)) 	{myState = States.corridor_1;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
	}	
	
	void courtyard () {
		text.text = "You walk through the courtyard dressed as a cleaner. " +
					"The guard tips his hat at you as you waltz past, claiming " +
					"your freedom. You heart races as you walk into the sunset.\n\n" +
					"Press P or O to Play again." ;
		//if (Input.GetKeyDown(KeyCode.P)) 		{myState = States.cell;}
		if (Input.GetKeyDown(KeyCode.O)) 		{myState = States.cell;}
	}	
	
	void stairs_0 () {
		text.text = "You start walking up the stairs towards the outside light. " +
					"You realise it's not break time, and you'll be caught immediately. " +
					"You slither back down the stairs and reconsider.\n\n" +
					"Press R to Return to the corridor. Press 🙂 to smile" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.corridor_0;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
	}
	
	void stairs_1 () {
		text.text = "Unfortunately weilding a puny hairclip hasn't given you the " +
					"confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
					"Press R to Retreat down the stairs" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.corridor_1;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
	}
	
	void stairs_2() {
		text.text = "You feel smug for picking the closet door open, and are still armed with " +
					"a hairclip (now badly bent). Even these achievements together don't give " +
					"you the courage to climb up the staris to your death!\n\n" +
					"Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.corridor_2;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
	}
	
	void cell () {
		prisonImage.SetActive(false);
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror and L to view Lock" ;
		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_0;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
		else if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.mirror;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_0;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
    }
    
	void mirror() {
		prisonImage.SetActive(true);
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
					"Press T to Take the mirror, or R to Return to cell" ;
		if 		(Input.GetKeyDown(KeyCode.T)) 	{myState = States.cell_mirror;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
		else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
    }
    
	void cell_mirror() {
		prisonImage.SetActive(true);
		text.text = "You are still in your cell, and you STILL want to escape! There are " +
					"some dirty sheets on the bed, a mark where the mirror was, " +
					"and that pesky door is still there, and firmly locked!\n\n" +
					"Press S to view Sheets, or L to view Lock" ;
		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_0;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_1;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
    }
   
    void sheets_0 () {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life. " +
					"As you look at the sheets you realize that they are actually " +
					"designer brand, and very high thread count. How strange. " +
					"Are they a donation to the prison? Is it supposed to make it better? " +
					"The warden must have a good discount for high quality linens " +
					"I guess!\n\n" +
					"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
    }
    
	void sheets_1() {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
					"any better.\n\n" +
					"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell_mirror;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
    }
    
    void lock_0() {
		text.text = "This is one of those button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
    }
    
	void lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it round " +
					"so you can see the lock. You can just make out fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press O to Open, or R to Return to your cell" ;
		if 		(Input.GetKeyDown(KeyCode.O)) 	{myState = States.corridor_0;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
		else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_mirror;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
    }
    
	void corridor_0() {
		text.text = "You're out of your cell, but not out of trouble." +
					"You are in the corridor, there's a closet and some stairs leading to " +
					"the courtyard. There's also various detritus on the floor.\n\n" +
					"C to view the Closet, F to inspect the Floor, and S to climb the stairs";
		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairs_0;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
		else if (Input.GetKeyDown(KeyCode.F)) 	{myState = States.floor;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
		else if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.closet_door;if (shade > 0) {shade -= 0.1f;}text.color = Color.Lerp(blackColor,whiteColor,shade);}
	}
}
