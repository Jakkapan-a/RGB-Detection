#include <PINOUT.h>
#include <BUTTON.h>

PINOUT Alarm(11);  // NG sound alarm
PINOUT AC(10);     // On relay contact AC voltage
BUTTON BTmode_01(15);
BUTTON BTmode_02(16);
BUTTON BTmode_03(17);
BUTTON BTmode_04(18);
BUTTON BTcal(19);
/*
Color code
  1. Green
  2. Red
  3. Blue
  4. Black
  5. White
  6. Yellow
  7. Pink
*/

unsigned long period = 1000;
int period_overspend = -1000;
unsigned long last_time_cs = 0;

// Variables count down
const int setCount = 6;  // Set count down time 10 seconds
int countDown = 0;           // Count down time

bool stringComplete = false;  // whether the string is complete
String inputString = "";

void serialEvent() {
  while (Serial.available()) {
    // get the new byte:

    char inChar = (char)Serial.read();
    if (inChar == '#') {
      stringComplete = true;  // Set state complete to true
      inputString.trim();     // Remove space
      break;
    }
    if (inChar == '>' || inChar == '<' || inChar == '\n' || inChar == '\r' || inChar == '\t' || inChar == ' ' || inChar == '?') {
      continue;
    }
    inputString += inChar;
  }
}
void Working() {
  if (millis() - last_time_cs > period) {
    if (countDown > 0) {
      countDown--;
      Serial.println(countDown);
    } else {
      // Serial.println("Count down time is over");
      Alarm.off();
      AC.off();
    }

    last_time_cs = millis();

  } else if (millis() < 1000) {
    last_time_cs = millis();
  }

}

void serialCommand(String command) {
  Serial.println(">" + command + "<");
}
void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
        AC.off();
      Alarm.off();
}

void loop() {
  // put your main code here, to run repeatedly:
if (stringComplete) {  // If state complete is true
    if(inputString == "1") {
      AC.on();
      Alarm.off();
      countDown = setCount;
    }else
    if(inputString == "2") {
      AC.off();
      Alarm.on();
    }else
    if(inputString == "3") {
      // AC.off();
      Alarm.off();
    }else
    if(inputString == "4") {
      // AC.off();

      Alarm.off();
    }    
    delay(40);
    serialCommand(inputString);
    inputString = "";
    stringComplete = false;
  }
  Working();

    count =0;
  }
