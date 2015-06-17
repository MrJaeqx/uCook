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

String buttonPressed = "1GP:BTN";

int pit1Pins[3] = {4, 5, 6};
int pit2Pins[3] = {7, 8, 9};
//int pit3Pins[3] = {7, 8, 9};
//int pit4Pins[3] = {11, 12, 13};

int pit1Power = 0;
int pit2Power = 0;
//int pit3Power = 0;
//int pit4Power = 0;

void setup() {
   // Setup Serial
  Serial.begin(9600);
  
  // Setting up the button, setup the Bounce instance :
  pinMode(button, INPUT);
  for(int i = 0; i < 3; i++)
  {
    pinMode(pit1Pins[i], OUTPUT);
    pinMode(pit2Pins[i], OUTPUT);
    
    digitalWrite(pit1Pins[i], LOW);
    digitalWrite(pit2Pins[i], LOW);
  }
  
  digitalWrite(button, HIGH);
  debouncer.attach(button);
  debouncer.interval(5); // interval in ms

START_INIT:

  // Init CAN bus with baudrate 500k
  if (CAN_OK == CAN.begin(CAN_500KBPS))
  {
    Serial.println("CAN Shield init ok!");
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
  
  unsigned char len = 0;
  unsigned char buf[8];
  char msg[8];

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
    
    if(message.length() > 0)
    {
      Serial.print("Message: \t");
      Serial.println(message);
      if(message.startsWith("1GP"))
      {
        if(message.substring(4, 6) == "P1")
        {
          if(message.charAt(6) == '+')
          {
            pit1Power = HIGH;
          }
          else if(message.charAt(6) == '-')
          {
            pit1Power = LOW;
          }
          
          for(int i = 0; i < 3; i++)
          {
            digitalWrite(pit1Pins[i], pit1Power);
          }
        }
        
        else if(message.substring(4,6) == "P2")
        {
          if(message.charAt(6) == '+')
          {
            pit2Power = HIGH;
          }
          else if(message.charAt(6) == '-')
          {
            pit2Power = LOW;
          }
          
          for(int i = 0; i < 3; i++)
          {
            digitalWrite(pit2Pins[i], pit2Power);
          }
        }
      } 
    }
  }
}

void checkButton()
{
  debouncer.update();
  if ( debouncer.fell() ) {
    char stmp[8] = {0};
    buttonPressed.toCharArray(stmp, 8);
    Serial.print("Can return val: ");
    Serial.println(CAN.sendMsgBuf(0x01, 0, 8, (unsigned char *) stmp), DEC);
  }

}
