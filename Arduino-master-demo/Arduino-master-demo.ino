#include <mcp_can.h>
#include <SPI.h>

const int SPI_CS_PIN = 10;
MCP_CAN CAN(SPI_CS_PIN);                                    // Set CS pin

String command = "";

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

char stmp[8] = {0};

void loop()
{
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
    if(message == "1GP:BTN")
    {
      Serial.println("#Gaspit pressed%");
    }
  }
  
  
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
  
  if(command.length() > 0 && command.length() <= 8)
  {
    command.toCharArray(stmp, 8);

    CAN.sendMsgBuf(0x00, 0, 8, (unsigned char *) stmp);
  }
  else if(command.length() > 8)
  {
    Serial.print("Longer than 8 still need to configure this:\t\t");    // TODO
    Serial.println(command);
  }

  command = "";
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
