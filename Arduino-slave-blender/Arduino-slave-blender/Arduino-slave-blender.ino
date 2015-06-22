#include <SPI.h>
#include "mcp_can.h"
#include <Bounce2.h>
#include <Servo.h>

// Create servo and servo position
Servo servo;
int pos = 0;
bool up = true;

// Set CS pin for CAN bus
// Default D10
const int SPI_CS_PIN = 10;
MCP_CAN CAN(SPI_CS_PIN);

// Set button pin
#define button 18
Bounce debouncer = Bounce();

String buttonPressed = "3BL:AC+";
String doneBlending = "3BL:AC+";
String blenderSlaveStartup = "3BL:INI";

unsigned long time;
bool timeUpdate = true;
unsigned long time1;
bool timeUpdate1 = true;
bool msgSent = false;

void setup() {
  // Setup Serial
  Serial.begin(9600);

  // Setting up the button, setup the Bounce instance :
  pinMode(button, INPUT);

  digitalWrite(button, HIGH);
  debouncer.attach(button);
  debouncer.interval(5); // interval in ms

  // Servo on pin 6
  servo.attach(6);

START_INIT:

  // Init CAN bus with baudrate 500k
  if (CAN_OK == CAN.begin(CAN_500KBPS))
  {
    Serial.println("CAN Shield init ok!");
    char iniBuffer[8] = {0};
    blenderSlaveStartup.toCharArray(iniBuffer, 8);
    CAN.sendMsgBuf(0x03, 0, 8, (unsigned char *) iniBuffer);
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
      blenderSlaveStartup.toCharArray(stmp, 8);
      CAN.sendMsgBuf(0x03, 0, 8, (unsigned char *) stmp);
    }
    // Check for commands from CAN
    else if (message.length() > 0)
    {
      Serial.print("Message: \t");
      Serial.println(message);
      if (message.startsWith("3BL"))
      {
        if (message.substring(4, 7) == "ON+")
        {
          // start blending
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
    // Blender filled
    char stmp[8] = {0};
    buttonPressed.toCharArray(stmp, 8);
    Serial.print("Can return val: ");
    Serial.println(CAN.sendMsgBuf(0x03, 0, 8, (unsigned char *) stmp), DEC);
  }

}

// Check delays with millis()
void checkTime() {
  if (millis() - time > 1000) {
    if (timeUpdate1)
    {
      time1 = millis();
    }
    timeUpdate1 = false;

    // Blending
    servo.write(pos);

    if (millis() - time1 > 1) {
      if (up) pos++; else pos--;
      if (pos == 180) up = false;
      if (pos == 0) up = true;
      timeUpdate1 = true;
    }

    // Blending done
    if (millis() - time > 20000)
    {
      char stmpC[8] = {0};
      doneBlending.toCharArray(stmpC, 8);
      Serial.print("Can return val: ");
      Serial.println(CAN.sendMsgBuf(0x03, 0, 8, (unsigned char *) stmpC), DEC);
      timeUpdate = true;
      pos = 0;
      up = true;
    }

  }
}
