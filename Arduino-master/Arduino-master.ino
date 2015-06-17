#include <mcp_can.h>
#include <SPI.h>

const int SPI_CS_PIN = 10;
MCP_CAN CAN(SPI_CS_PIN);                                    // Set CS pin

String command = "";
String ini = "INI";
String ack = "AC+";

String appliances[10];

unsigned long lastIniTime = 0;
boolean sendList = false;

void setup()
{
  Serial.begin(9600);
  Setup_Appliances(appliances);

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
  
  if(command == "RESET%")
  {
    Setup_Appliances(appliances);
  }
  
  if(command == "UPDATE%")
  {
    CAN_Send(0x00, "UPDATE");
    sendList = true;
    lastIniTime = millis();
  }
  
  if(sendList == true && (millis() - lastIniTime > 1000))
  {
    Send_ApplianceList(appliances);
    sendList = false;
    Setup_Appliances(appliances);
  }
  
  else if(command.length() > 0 && command.length() <= 8)
  {
    CAN_Send(0x00, command);
  }
  else if(command.length() > 8)
  {
    Serial.print("Command is too long (>8):\t\t");
    Serial.println(command);
  }

  command = "";
  millis();
  delay(10);  // send data per 10ms
}
