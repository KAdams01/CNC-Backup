# master branch

CNC Virtual Trainer – List of features

1.	Control Panel:<br/>
a)	Power on button – turning on the whole machine<br/>
b)	Power off button – turning off the whole machine<br/>
c)	Emergency stop button – stopping the machine immediately, making all the other buttons unusable until is pulled out again<br/>
d)	Power up button – checking if the start-up sequence was done correctly and moving both the workbench and the machine head to their zero position<br/>
e)	Axis buttons - choosing an axis (x / y / z)<br/>
f)	Speed buttons - choosing a speed (4 possibilities)<br/>
g)	Hand jog - moving the workbench and the machine head by rotating <br/>
h)	Handle jog button – changing the display from the start-up menu to the tool menu<br/>
i)	Arrows up / down / left / right – navigating through the tool and the work menus<br/>
j)	Part zero set button – setting the machine’s new zero point to the one the machine is currently at within the chosen axis<br/>
k)	Dial keypad (0-9) – writing a value to input to be set as the machine’s new zero point or to be added or subtracted<br/>
l)	F1 button – setting the value that is currently stored in the input field as the machine’s new zero point within the chosen axis<br/>
m)	Minus button – changing the value that is currently stored in the input field to be negative<br/>
n)	Point button – changing the value that is currently stored in the input field to be decimal<br/>
o)	Enter button – adding the value that is currently stored in the input field to the current machine’s new zero point within chosen axis (if the value is negative, then it is subtraction) and moving the coordinate to the right afterwards<br/>
p)	Reset button – resetting the machine’s current zero point within the chosen axis<br/>
q)	Cancel button – deleting currently stored value in the input field<br/>

2.	Screen display:<br/>
a)	Live updated coordinates – values under “Work G54” label in the bottom part of the screen displaying the machine current location within its own space (from 0 to 600 in all three axes)<br/>
b)	Movable field indicators (for rows in the tool menu, rows in the work menu, top menu and coordinates in the work menu) – available while in the tool and the work menus, used to indicate which field the user is currently at<br/>
c)	Input field – a field in the bottom left corner storing number entered by the user<br/>


3.	Other major interactables:<br/>
a)	Black button – used to insert the tool into the machine head’s clamp while being pressed<br/>
b)	Measuring tool (while inserted into the machine head’s clamp) – a tool used to measure the distance between its tip and the surface of the target inserted on the workbench in all three axes, with precision of .001 mm; if it touches the target and is being pushed further, it breaks<br/>
c)	Measuring tool’s dial – an arrow pointing at the numbers showing the distance between the measuring tool and the target<br/>
d)	Measuring tool (while outside of the machine) – a throwable object with two states: dirty and clean; can be inserted into the machine only if it’s clean<br/>
e)	Tool insertion highlighter – an outliner showing when and if the tool can be inserted (green if the tool is clean and red if dirty)<br/>
f)	Measurement highlighter – an outline of the measuring tool, appearing when the tool gets close enough to the target, changing its colour from green to red gradually<br/>
g)	Cloth – an object used to clean the tool; contains Unity’s cloth physics<br/>
h)	Magnifier – a magnifying glass used to help with reading small writings<br/>
i)	Sliding doors – doors of the machine, also one of the steps in the start-up sequence<br/>
j)	Control panel – can be rotated by grabbing its right edge<br/>
k)	Tool table – can be moved around by grabbing<br/>

4.	Other major features:<br/>
a)	Light on the control panel’s top right corner – used to indicate whether the machine is useable (green) or not (red) or is off (default grey)<br/>
b)	Respawn functionality – used to make sure the user cannot lose any of the throwable items, respawning them back in their original positions after a few seconds after touching the floor, the machine’s roof or the trash bin<br/>
c)	Set of working tools – a few tools located by default on the bottom shelf of the tool table; not used for any particular purpose in the trainer, being a part of it for a better immersion<br/>
d)	Hand pointers – two green “balls” located at the end of the pointing finger for both hands; used to indicate what the user is currently pointing at and therefore to make the navigation easier<br/>

5.	Quest log:<br/>
a)	Clipboard – a kinematic interactable object not affected by gravity that can be put wherever; used to display 2 past tasks, a current one and the two next<br/>
b)	Tips clipboard – located in right part of the clipboard; used to display additional information or tips to the current task<br/>
c)	Arrow button – used to enable and disable the tips clipboard <br/>
d)	English language button – choosing language of all the parts of the quest log to English<br/>
e)	Danish language button – choosing language of all the parts of the quest log to Danish<br/>
f)	Highlight button – turning on / off a highlighter on the button that needs to be pressed currently<br/>
g)	Reset button – resetting the quest log to the first task and turning off the machine (so that the start-up sequence needs to be done again)<br/>

