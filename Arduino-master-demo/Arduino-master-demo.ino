// demo: CAN-BUS Shield, send data
#include <mcp_can.h>
#include <SPI.h>

// the cs pin of the version after v1.1 is default to D9
// v0.9b and v1.0 is default D10
const int SPI_CS_PIN = 10;

String reqDevs = "LIST ID";

MCP_CAN CAN(SPI_CS_PIN);                                    // Set CS pin

void setup()
{
  Serial.begin(9600);

START_INIT:

  if (CAN_OK == CAN.begin(CAN_500KBPS))                  // init can bus : baudrate = 500k
  {
    Serial.println("CAN BUS Shield init ok!");
  }
  else
  {
    Serial.println("CAN BUS Shield init fail");
    Serial.println("Init CAN BUS Shield again");
    delay(100);
    goto START_INIT;
  }
}

char stmp[8];

void loop()
{
  String command = "";
  if (Serial.available() > 0)
  {
    while (readNextCharacterFromSerial() != '#')
    {

    }
    while (command.indexOf('%') == -1)
    {
      command += readNextCharacterFromSerial();
    }
  }
  
  if(command.length() > 0)
  {
  int percentIndex = command.indexOf('%');
  Serial.println(command);
  command = command.substring(0, percentIndex);
  Serial.println(command);
  }
  
  if(command.startsWith("LIST"))
  {
    reqDevs.toCharArray(stmp, 9);
    CAN.sendMsgBuf(0x01, 0, 8, (unsigned char *) stmp);
  }
  else if(command.length() > 0 && command.length() <= 8)
  {
    command.toCharArray(stmp, 9);
    Serial.println(stmp);

    CAN.sendMsgBuf(0x00, 0, 8, (unsigned char *) stmp);
  }
  else if(command.length() > 8)
  {
    Serial.print("TE LANG:\t\t");
    Serial.println(command);
  }
  delay(100);                       // send data per 100ms
}

char readNextCharacterFromSerial()
{
  int value = -1;
  do
  {
    value = Serial.read();
  }
  while (value == -1);
  return (char) value;
}
