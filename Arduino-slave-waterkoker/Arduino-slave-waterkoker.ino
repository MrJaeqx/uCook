#include <SPI.h>
#include "mcp_can.h"
#include <Bounce2.h>

// Set CS pin for CAN bus
// Default D10
const int SPI_CS_PIN = 10;
MCP_CAN CAN(SPI_CS_PIN);

// Set button pin
#define button 18
Bounce debouncer = Bounce();

String buttonPressed = "2WK:AC+";
String waterCooks = "2WK:AC+";
String waterkokerSlaveStartup = "2WK:INI";

int isCookingPin = 7;
int doneCookingPin = 8;

unsigned long time;
bool timeUpdate = true;
bool msgSent = false;

void setup() {
  // Setup Serial
  Serial.begin(9600);

  // Setting up the button, setup the Bounce instance :
  pinMode(button, INPUT);

  pinMode(isCookingPin, OUTPUT);
  pinMode(doneCookingPin, OUTPUT);

  digitalWrite(isCookingPin, LOW);
  digitalWrite(doneCookingPin, LOW);

  digitalWrite(button, HIGH);
  debouncer.attach(button);
  debouncer.interval(5); // interval in ms

START_INIT:

  // Init CAN bus with baudrate 500k
  if (CAN_OK == CAN.begin(CAN_500KBPS))
  {
    Serial.println("CAN Shield init ok!");
    char iniBuffer[8] = {0};
    waterkokerSlaveStartup.toCharArray(iniBuffer, 8);
    CAN.sendMsgBuf(0x02, 0, 8, (unsigned char *) iniBuffer);
    delay(1000);
  }
  else
  {
    Serial.println("CAN Shield init fail");
    Serial.println("Trying again");
    delay(1000);
    goto START_INIT;
  }
}

void loop() {

  checkButton();
  checkTime();

  unsigned char len = 0;
  unsigned char buf[8];
  char msg[8];

  if (timeUpdate)
  {
    time = millis();
  }

  if (CAN_MSGAVAIL == CAN.checkReceive())           // check if data coming
  {
    CAN.readMsgBuf(&len, buf);    // read data,  len: data length, buf: data buf

    for (int i = 0; i < len; i++) // print the data
    {
      Serial.write(buf[i]);
      Serial.print(" ");

      msg[i] = buf[i];

    }
    Serial.println();

    String message(msg);

    if (message.length() > 0)
    {
      Serial.print("Message: \t");
      Serial.println(message);
      if (message.startsWith("2WK"))
      {
        if (message.substring(4, 7) == "ON+")
        {
          // start cooking
          digitalWrite(isCookingPin, HIGH);
          timeUpdate = false;
          Serial.println("ON BIATCH!");
        }
      }
    }
  }
}

void checkButton()
{
  debouncer.update();
  if ( debouncer.fell() ) {
    // Water filled
    char stmp[8] = {0};
    buttonPressed.toCharArray(stmp, 8);
    Serial.print("Can return val: ");
    Serial.println(CAN.sendMsgBuf(0x02, 0, 8, (unsigned char *) stmp), DEC);
  }

}

void checkTime() {
  if (millis() - time > 10000 && !msgSent) {
    // Cooking done
    char stmpC[8] = {0};
    waterCooks.toCharArray(stmpC, 8);
    Serial.print("Can return val: ");
    Serial.println(CAN.sendMsgBuf(0x02, 0, 8, (unsigned char *) stmpC), DEC);

    digitalWrite(doneCookingPin, HIGH);
    msgSent = true;
    /*
    int melody[] = { 262, 196, 196, 220, 196, 0, 247, 262 };
    int noteDurations[] = { 4, 8, 8, 4, 4, 4, 4, 4 };
    for (int thisNote = 0; thisNote < 8; thisNote++) {
      int noteDuration = 1000 / noteDurations[thisNote];
      tone(5, melody[thisNote], noteDuration);
      int pauseBetweenNotes = noteDuration * 1.30;
      delay(pauseBetweenNotes);
      noTone(5);
    }*/
  }
  else if (millis() - time > 20000)
  {
    // After 20sec LEDs uit
    digitalWrite(doneCookingPin, LOW);
    digitalWrite(isCookingPin, LOW);
    timeUpdate = true;
    msgSent = false;
  }
}
