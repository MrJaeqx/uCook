#include <Bounce2.h>

const int rLed = 2;
const int gLed = 3;
const int bLed = 4;
const int button = 5;

// Instantiate a Bounce object
Bounce debouncer = Bounce();
String command = "";

void setup()
{
  //Setup the LED
  pinMode(rLed, OUTPUT);
  pinMode(gLed, OUTPUT);
  pinMode(bLed, OUTPUT);
  pinMode(button, INPUT);
  digitalWrite(rLed, LOW);
  digitalWrite(gLed, LOW);
  digitalWrite(bLed, LOW);

  // After setting up the button, setup the Bounce instance :
  debouncer.attach(button);
  debouncer.interval(5); // interval in ms

  //initialize serial
  Serial.begin(9600);
}

void loop()
{
  // Update the Bounce instance
  debouncer.update();

  if ( debouncer.rose() ) {
    Serial.print("#buttonpressed%");
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

  if (command == "hello%")
  {
    Serial.print("#world%");
  }
  else if (command == "red%")
  {
    Serial.print("#okr%");
    digitalWrite(rLed, HIGH);
  }
  else if (command == "green%")
  {
    Serial.print("#okg%");
    digitalWrite(gLed, HIGH);
  }
  else if (command == "blue%")
  {
    Serial.print("#okb%");
    digitalWrite(bLed, HIGH);
  }
  else if (command == "off%")
  {
    Serial.print("#okoff%");
    digitalWrite(rLed, LOW);
    digitalWrite(gLed, LOW);
    digitalWrite(bLed, LOW);
  }
  else { // faulty input
  }

  command = "";
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

