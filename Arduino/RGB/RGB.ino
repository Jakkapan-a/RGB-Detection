#include <TcPINOUT.h>
#include <TcBUTTON.h>

#define LED_RED_PIN 9 // LED RED
TcPINOUT LedRED(LED_RED_PIN);  // NG sound LedRED
#define LED_GREEN_PIN 8 // LED GREEN
void Green(bool);
TcPINOUT ledGREEN(LED_GREEN_PIN,Green);     // On relay contact AC voltage

#define relaySTATUS 2 // Button
TcPINOUT relayStatus(relaySTATUS,NULL,true);  // Button


#define RELAY_1_PIN 4 // Relay 1
TcPINOUT relay1(RELAY_1_PIN);  // Relay 1

#define RELAY_2_PIN 5 // Relay 2
TcPINOUT relay2(RELAY_2_PIN);  // Relay 2

#define RELAY_3_PIN 6 // Relay 3
TcPINOUT relay3(RELAY_3_PIN);  // Relay 3

#define RELAY_4_PIN 7 // Relay 4
TcPINOUT relay4(RELAY_4_PIN);  // Relay 4

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

int period_overspend = -1000;
unsigned long last_time_cs = 0;

// Variables count down
const int setCount = 15;  // Set count down time 15 seconds
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
  if (millis() - last_time_cs > 1000) {
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
    if(inputString == "1" || inputString == "ok" || inputString == "OK" ) {
      ledGREEN.on();
      LedRED.off();
      countDown = setCount;
    }else
    if(inputString == "2"  || inputString == "ng" || inputString == "NG" ) {
      ledGREEN.off();
      countDownRed = setCountRed;
      LedRED.on();
    }else
    if(inputString == "3" || inputString == "4" || inputString == "null") {
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
    relay1.on();
    relay2.on();
    relay3.on();
    relay4.on();
  } else {
    relayStatus.off();
    relay1.off();
    relay2.off();
    relay3.off();
    relay4.off();
  }
}