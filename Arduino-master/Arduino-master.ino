#include <mcp_can.h>
#include <SPI.h>

const int SPI_CS_PIN = 10;
MCP_CAN CAN(SPI_CS_PIN);                                    // Set CS pin

String command = "";
String ini = "INI";
String ack = "AC+";

void setup()
{
  Serial.begin(9600);

START_INIT:

  if (CAN_OK == CAN.begin(CAN_500KBPS))                  // init can bus : baudrate = 500k
  {
    Serial.println("Master CAN uCook!");
  }
  else
  {
    Serial.println("CAN BUS Shield init fail");
    Serial.println("Init CAN BUS Shield again");
    delay(100);
    goto START_INIT;
  }
}



void loop()
{
  CAN_Receive();
  
  SerialRead(&command);
  
  
  if(command.length() > 0 && command.length() <= 8)
  {
    CAN_Send(0x00, command);
  }
  else if(command.length() > 8)
  {
    Serial.print("Command is too long (>8):\t\t");
    Serial.println(command);
  }

  command = "";
  delay(100);                       // send data per 100ms
}
