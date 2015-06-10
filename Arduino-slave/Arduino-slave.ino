#include <SPI.h>
#include "mcp_can.h"
#include <SoftwareSerial.h>
#include <Bounce2.h>

// Set CS pin for CAN bus
// Default D10
const int SPI_CS_PIN = 10;
MCP_CAN CAN(SPI_CS_PIN);

// Set button pin
const int button = 18;
Bounce debouncer = Bounce();

// Set serial LCD
SoftwareSerial sLCD =  SoftwareSerial(3, 6);

// Define LCD commands
#define COMMAND 0xFE
#define CLEAR   0x01
#define LINE0   0x80
#define LINE1   0xC0
#define LINE2   0x94
#define LINE3   0xD4

void setup()
{
  // Setup Serial
  Serial.begin(9600);

  // Setting up the button, setup the Bounce instance :
  pinMode(button, INPUT);
  digitalWrite(button, HIGH);
  debouncer.attach(button);
  debouncer.interval(5); // interval in ms

  // Setup serial LCD and clear the screen
  sLCD.begin(9600);
  clear_lcd();
  sLCD.print("uCook!");
  delay(1000);
  clear_lcd();

START_INIT:

  // Init CAN bus with baudrate 500k
  if (CAN_OK == CAN.begin(CAN_500KBPS))
  {
    // CAN Bus init is ok
    Serial.println("CAN Shield init ok!");
    sLCD.print("CAN Shield init ok!");
    // Wait one sec
    delay(1000);
  }
  else
  {
    // CAN bus init failed
    Serial.println("CAN Shield init fail");
    Serial.println("Trying again");
    sLCD.print("CAN Shield init fail");
    sLCD.write(COMMAND);
    sLCD.write(LINE1);
    sLCD.print("Trying again");
    // Wait one sec
    delay(1000);
    // Try again
    goto START_INIT;
  }
}


void loop()
{
  // Check if button is pressed
  checkButton();

  // Create variables for CAN Receive
  unsigned char len = 0;
  unsigned char buf[8];

  // CAN Commands
  unsigned char cmdBier[8] = {98, 105, 101, 114, 32, 32, 32, 32};     //bier
  unsigned char cmdGetID[8] = {103, 101, 116, 105, 100, 32, 32, 32};  //getid
  unsigned char cmdDev00[8] = {100, 101, 118, 48, 58, 48, 32, 32};    //dev00
  unsigned char cmdDev01[8] = {100, 101, 118, 48, 58, 49, 32, 32};    //dev01
  unsigned char cmdDev10[8] = {100, 101, 118, 49, 58, 48, 32, 32};    //dev01
  unsigned char cmdDev11[8] = {100, 101, 118, 49, 58, 49, 32, 32};    //dev11
  unsigned char cmdDev20[8] = {100, 101, 118, 50, 58, 48, 32, 32};    //dev01
  unsigned char cmdDev21[8] = {100, 101, 118, 50, 58, 49, 32, 32};    //dev11

  // Check if data coming
  if (CAN_MSGAVAIL == CAN.checkReceive())
  {
    // Read data,  len: data length, buf: data buf
    CAN.readMsgBuf(&len, buf);
    Serial.print("buf contains:\t");

    // Print the data
    for (int i = 0; i < len; i++)
    {
      if (buf[i] == 0) buf[i] = 32;
      Serial.write(buf[i]);
      sLCD.write(COMMAND);
      sLCD.write(LINE2 + i);
      sLCD.write(buf[i]);
    }


    // compare string commands
    if (strncmp((char*)buf, (char*)cmdGetID, 8) == 0)
    {
      sLCD.write(COMMAND);
      sLCD.write(CLEAR);
      sLCD.write(COMMAND);
      sLCD.write(LINE0);
      sLCD.print("ID SHIZZLE");
    }
    else if (strncmp((char*)buf, (char*)cmdDev00, 8) == 0)
    {
      sLCD.write(COMMAND);
      sLCD.write(CLEAR);
      sLCD.write(COMMAND);
      sLCD.write(LINE0);
      sLCD.print("cmdDev00");
    }
    else if (strncmp((char*)buf, (char*)cmdDev01, 8) == 0)
    {
      sLCD.write(COMMAND);
      sLCD.write(CLEAR);
      sLCD.write(COMMAND);
      sLCD.write(LINE0);
      sLCD.print("cmdDev01");
    }
    else if (strncmp((char*)buf, (char*)cmdDev10, 8) == 0)
    {
      sLCD.write(COMMAND);
      sLCD.write(CLEAR);
      sLCD.write(COMMAND);
      sLCD.write(LINE0);
      sLCD.print("cmdDev10");
    }
    else if (strncmp((char*)buf, (char*)cmdDev11, 8) == 0)
    {
      sLCD.write(COMMAND);
      sLCD.write(CLEAR);
      sLCD.write(COMMAND);
      sLCD.write(LINE0);
      sLCD.print("cmdDev11");
    }
    else if (strncmp((char*)buf, (char*)cmdDev20, 8) == 0)
    {
      sLCD.write(COMMAND);
      sLCD.write(CLEAR);
      sLCD.write(COMMAND);
      sLCD.write(LINE0);
      sLCD.print("cmdDev20");
    }
    else if (strncmp((char*)buf, (char*)cmdDev21, 8) == 0)
    {
      sLCD.write(COMMAND);
      sLCD.write(CLEAR);
      sLCD.write(COMMAND);
      sLCD.write(LINE0);
      sLCD.print("cmdDev21");
    }


    Serial.println();

    memset(buf, 0, sizeof(buf));
  }
}

// Clear LCD function
void clear_lcd(void)
{
  sLCD.write(COMMAND);
  sLCD.write(CLEAR);
}

// Check button press - with debounce
void checkButton()
{
  debouncer.update();
  if ( debouncer.rose() ) {
    sLCD.write(COMMAND);
    sLCD.write(LINE3);
    sLCD.print("Button");
  }

}

/*********************************************************************************************************
  END FILE
*********************************************************************************************************/
