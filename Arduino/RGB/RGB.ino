#include <TcPINOUT.h>
#include <TcBUTTON.h>

#define ledRedPIN 3 // LED RED
TcPINOUT LedRED(ledRedPIN);  // NG sound LedRED
#define ledGreenPIN 4 // LED GREEN
void Green(bool);
TcPINOUT ledGREEN(ledGreenPIN,Green);     // On relay contact AC voltage

#define relaySTATUS 2 // Button
TcPINOUT relayStatus(relaySTATUS,NULL,true);  // Button
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
const int setCount = 10;  // Set count down time 10 seconds
int countDown = 0;           // Count down time
int countDownRed = 0;
const int setCountRed = 1; 
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
    } else {
      if(countDownRed>0){
        countDownRed--;
      }else{
         LedRED.off();
      }
      ledGREEN.off();
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
        ledGREEN.off();
      LedRED.off();
}

void loop() {
  // put your main code here, to run repeatedly:
if (stringComplete) {  // If state complete is true
    if(inputString == "1") {
      ledGREEN.on();
      LedRED.off();
      countDown = setCount;
    }else
    if(inputString == "2") {
      ledGREEN.off();
      countDownRed = setCountRed;
      LedRED.on();
    }else
    if(inputString == "3") {
      // ledGREEN.off();
      LedRED.off();
    }else
    if(inputString == "4") {
      // ledGREEN.off();
      LedRED.off();
    }    
    delay(10);
    serialCommand(inputString);
    inputString = "";
    stringComplete = false;
  }
  Working();
  }

void Green(bool state) {
  if (state) {
    relayStatus.on();
  } else {
    relayStatus.off();
  }
}