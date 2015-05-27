#include <SPI.h>
#include "mcp_can.h"
#include <SoftwareSerial.h>

// Set CS pin for CAN bus
// Default D10
const int SPI_CS_PIN = 10;
MCP_CAN CAN(SPI_CS_PIN);

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
  
  // Setup serial LCD and clear the screen
  sLCD.begin(9600);
  clear_lcd();
  sLCD.print("uCook Swagteam!");  
  delay(1000);
  clear_lcd();

START_INIT:

  // Init CAN bus with baudrate 500k
  if (CAN_OK == CAN.begin(CAN_500KBPS))
  {
    sLCD.print("CAN Shield init ok!");
    Serial.println("CAN Shield init ok!");
    delay(1000);
  }
  else
  {
    sLCD.print("CAN Shield init fail");
    Serial.println("CAN Shield init fail");
    sLCD.write(COMMAND);
    sLCD.write(LINE1);
    sLCD.print("Trying again");
    Serial.println("Trying again");
    delay(1000);
    goto START_INIT;
  }
}


void loop()
{
  unsigned char len = 0;
  unsigned char buf[8];

  if (CAN_MSGAVAIL == CAN.checkReceive())           // check if data coming
  {
    CAN.readMsgBuf(&len, buf);    // read data,  len: data length, buf: data buf

    for (int i = 0; i < len; i++) // print the data
    {
      Serial.write(buf[i]); Serial.print("\t");
      sLCD.write(COMMAND);
      sLCD.write(LINE2 + i);
      if(buf[i] == 0) buf[i] = 32;
      sLCD.write(buf[i]);
    }
    Serial.println();
  }
}

void clear_lcd(void)
{
  sLCD.write(COMMAND);
  sLCD.write(CLEAR);
}

/*********************************************************************************************************
  END FILE
*********************************************************************************************************/
