// demo: CAN-BUS Shield, send data
#include <mcp_can.h>
#include <SPI.h>
#include <Bounce2.h>

// the cs pin of the version after v1.1 is default to D9
// v0.9b and v1.0 is default D10
const int SPI_CS_PIN = 10;
const int button = 18;

MCP_CAN CAN(SPI_CS_PIN);                                    // Set CS pin

// Instantiate a Bounce object
Bounce debouncer = Bounce();
String command = "";

void setup()
{
  Serial.begin(9600);
  pinMode(button, INPUT);
  digitalWrite(button, HIGH);

  // After setting up the button, setup the Bounce instance :
  debouncer.attach(button);
  debouncer.interval(5); // interval in ms

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

unsigned char stmp[8] = {0, 1, 2, 3, 4, 5, 6, 7};
void loop()
{

  debouncer.update();

  if ( debouncer.rose() ) {
    // send data:  id = 0x00, standrad flame, data len = 8, stmp: data buf
    CAN.sendMsgBuf(0x00, 0, 8, stmp);
    delay(100);                       // send data per 100ms
  }

}

/*********************************************************************************************************
  END FILE
*********************************************************************************************************/
