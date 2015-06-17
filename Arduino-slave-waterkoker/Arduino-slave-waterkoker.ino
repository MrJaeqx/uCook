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

  // Check if message is available
  if (CAN_MSGAVAIL == CAN.checkReceive())
  {
    // Read data from CAN bus
    CAN.readMsgBuf(&len, buf);    // read data,  len: data length, buf: data buf

    // Convert unsinged char to char
    for (int i = 0; i < len; i++)
    {
      msg[i] = buf[i];
    }

    // Put char buffer in string
    String message(msg);

    // Send I'm alive
    if (message == "UPDATE")
    {
      char stmp[8] = {0};
      waterkokerSlaveStartup.toCharArray(stmp, 8);
      CAN.sendMsgBuf(0x02, 0, 8, (unsigned char *) stmp);
    }
    // Check for commands from CAN
    else if (message.length() > 0)
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
        }
      }
    }
  }
}

// Check if button is pressed
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

// Check delays with millis()
void checkTime() {
  if (millis() - time > 10000 && !msgSent) {
    // Cooking done
    char stmpC[8] = {0};
    waterCooks.toCharArray(stmpC, 8);
    Serial.print("Can return val: ");
    Serial.println(CAN.sendMsgBuf(0x02, 0, 8, (unsigned char *) stmpC), DEC);

    digitalWrite(doneCookingPin, HIGH);
    msgSent = true;
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
