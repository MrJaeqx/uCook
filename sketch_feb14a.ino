#include <Bounce2.h>

const int btnPin = 2;
const int btnPin2 = 3;
const int ledPin = 4;

// Instantiate a Bounce object
Bounce debouncer = Bounce(); 
Bounce debouncer2 = Bounce();
String command = "";

void setup()
{
  // Setup the button
  pinMode(btnPin,INPUT);
  pinMode(btnPin2,INPUT);

  // After setting up the button, setup Bounce object
  debouncer.attach(btnPin);
  debouncer2.attach(btnPin2);
  debouncer.interval(5);
  debouncer2.interval(5);

  //Setup the LED
  pinMode(ledPin,OUTPUT);
  digitalWrite(ledPin,HIGH);

  //initialize serial
  Serial.begin(9600);
}

void loop()
{
  //1.Led gaat aan als knop1 en knop2 (beide ingedrukt) bediend worden (and). 
  //2.Led gaat aan als knop1 of knop2 of beide knoppen bediend word(t)en (or). 
  //3.Led gaat aan als knop1 of knop2 bediend wordt (xor). 

  // Update the debouncer
  debouncer.update();
  debouncer2.update();

  // Get the update value
  int btn1 = debouncer.read();
  int btn2 = debouncer2.read();

  // If incoming command == xor, or, and
  // then use the right method
  if (Serial.available() >0)
  {
    while(readNextCharacterFromSerial() != '#')
    {

    }
    while(command.indexOf('%') == -1)
    {
      command += readNextCharacterFromSerial();
    }

  }

  if (command == "or")
  {
    Or(btn1, btn2); 
  }
  else if (command == "xor")
  {
    Xor(btn1, btn2);
  }
  else if (command == "and")
  {
    And(btn1, btn2);
  }
  else { // faulty input 
  }

  command = "";
}

void Or(int button1, int button2)
{
  if ((button1 == HIGH) && (button2 == HIGH))
  {
    // led gaat aan
    digitalWrite(ledPin, HIGH );
  }
  else {
    digitalWrite(ledPin, LOW );
  }
}

void And(int button1, int button2)
{
  if ((button1 == HIGH) || (button2 == HIGH))
  {
    // led gaat aan
    digitalWrite(ledPin, HIGH );
  }
  else {
    digitalWrite(ledPin, LOW );
  }
}

void Xor(int button1, int button2)
{
  if (((button1 != HIGH) && (button2 == HIGH)) || ((button1 == HIGH) && (button2 != HIGH))) 
  {
    // led gaat aan
    digitalWrite(ledPin, HIGH );
  }
  else {
    digitalWrite(ledPin, LOW );
  }
}

char readNextCharacterFromSerial()
{ 
  int value = -1;
  do
  {
    value = Serial.read();
  } 
  while(value == -1);
  return (char) value;
}

